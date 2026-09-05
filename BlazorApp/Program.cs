using BlazorApp;
using BlazorApp.Common;
using BlazorApp.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

var configLoader = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

// 1. Load required environment.json from wwwroot
var environmentBytes = await configLoader.GetByteArrayAsync("environment.json");
using var environmentStream = new MemoryStream(environmentBytes);
builder.Configuration.AddJsonStream(environmentStream);

// 2. Read required environment value
var env = builder.Configuration["Environment"] ?? throw new InvalidOperationException("Environment key is missing from environment.json.");

// 3. Load required appsettings.{env}.json from wwwroot
var envSettingsBytes = await configLoader.GetByteArrayAsync($"appsettings.{env}.json");
using var envSettingsStream = new MemoryStream(envSettingsBytes);
builder.Configuration.AddJsonStream(envSettingsStream);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 4. Bind settings normally
var settings = new ClientSettings
{
    ApplicationName = string.Empty,
    ApiHost = string.Empty
};
builder.Configuration.Bind(settings);
settings.Environment = env;
builder.Services.AddSingleton(settings);

if (settings.UseMocks)
{
#if DEBUG
    builder.Services.AddSingleton<IUserTokenRequestModel, UserTokenRequestModel>();
    builder.Services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
    builder.Services.AddScoped<IEattsApiRepository, MockEattsRepository>();
    builder.Services.AddScoped<ISecurityModelApiRepository, MockSecurityModelRepository>();
    builder.Services.AddSingleton<ISecurityModelToken, MockSecurityModelToken>();
#else
    // Release build — mocks removed
    Console.WriteLine("WARNING: UseMocks=true in Release, but mock repositories are not included.");
    throw new InvalidOperationException("UseMocks=true in Release, but mock repositories are not included.");
#endif
}
else
{
    //todo the next line is required I believe due to the SecurityModelToken. ClientSettings has this as a property, but it is not registered as a service. Research.
    builder.Services.AddSingleton<IUserTokenRequestModel>(sp => sp.GetRequiredService<ClientSettings>().UserTokenRequestModel);
    builder.Services.AddTransient<CredentialsMessageHandler, CredentialsMessageHandler>();
    builder.Services.AddTransient<UserTokenMessageHandler, UserTokenMessageHandler>();
    builder.Services.AddHttpClient<ISecurityModelToken, SecurityModelToken>(client => client.BaseAddress = new Uri($"{settings.SecurityModelHost}SecurityModel/"))
                    .AddHttpMessageHandler<CredentialsMessageHandler>();

    builder.Services.AddHttpClient<IEmployeeRepository, EmployeeRepository>(client => client.BaseAddress = new Uri($"{settings.ApiHost}EmployeeData/")).AddHttpMessageHandler<UserTokenMessageHandler>();
    builder.Services.AddHttpClient<IEattsApiRepository, EattsRepository>(client => client.BaseAddress = new Uri($"{settings.ApiHost}EATTS/")).AddHttpMessageHandler<UserTokenMessageHandler>();
    builder.Services.AddHttpClient<ISecurityModelApiRepository, SecurityModelApiRepository>(client => client.BaseAddress = new Uri($"{settings.ApiHost}SecurityModel/")).AddHttpMessageHandler<UserTokenMessageHandler>();
}

builder.Services.AddSingleton<IEventChannelBus, EventChannelBus>();
builder.Services.AddSingleton<ApplicationErrorHandler>();
builder.Services.AddScoped<ErrorReportState>();
builder.Services.AddTelerikBlazor();
builder.Services.AddScoped<ThemeService>();

var host = builder.Build();
_ = host.Services.GetRequiredService<ApplicationErrorHandler>();
await host.RunAsync();
