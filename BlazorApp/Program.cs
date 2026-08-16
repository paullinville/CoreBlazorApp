using BlazorApp;
using BlazorApp.Classes;
using BlazorApp.Data;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Configuration.AddJsonFile($"appsettings.{builder.HostEnvironment.Environment}.json", true, true);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new ClientSettings();
builder.Configuration.Bind(settings);
builder.Services.AddSingleton(settings);

//todo the next line is required I believe due to the SecurityModelToken but not sure. Research.
builder.Services.AddSingleton<IUserTokenRequestModel, UserTokenRequestModel>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(settings.ApiHost) });

builder.Services.AddScoped<CredentialsMessageHandler, CredentialsMessageHandler>();
builder.Services.AddHttpClient<ISecurityModelToken, SecurityModelToken>(client => client.BaseAddress = new Uri($"{settings.ApiHost}SecurityModel/"))
				.AddHttpMessageHandler<CredentialsMessageHandler>();

builder.Services.AddHttpClient<IEattsApiRepository, EattsRepository>(client => client.BaseAddress = new Uri($"{settings.ApiHost}EATTS/"));
builder.Services.AddHttpClient<IEmployeeRepository, EmployeeRepository>(client => client.BaseAddress = new Uri($"{settings.ApiHost}EmployeeData/"));
builder.Services.AddHttpClient<ISecurityModelApiRepository, SecurityModelApiRepository>(client => client.BaseAddress = new Uri($"{settings.ApiHost}SecurityModel/"));

builder.Services.AddSingleton<IEventChannelBus, EventChannelBus>();
builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();