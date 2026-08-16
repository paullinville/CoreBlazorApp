using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Midland.Core.Api;
using Midland.Core.Common;
using Midland.Core.Logging;
using RestEase;
using Serilog;
using System.Text.Json;

namespace Midland.Core.Client;

public static class ApiClientServiceExtensions
{
	private static readonly JsonSerializerOptions DEFAULT_JSON_OPTIONS = new() { PropertyNameCaseInsensitive = true };

	/// <summary>
	/// API RestEase Client that will call all Nomad instances of the API.
	/// </summary>
	/// <typeparam name="TApiInterface">The RestEase interface</typeparam>
	/// <param name="services"></param>
	/// <param name="config"></param>
	/// <returns></returns>
	public static IHttpClientBuilder AddBlanketRestEaseApiClient<TApiInterface>(this IServiceCollection services,
																				IConfiguration config) where TApiInterface : class, IApiClient
	{
		var definition = services.GetApiDefinition(config, typeof(TApiInterface), null);

		services.AddScoped(provider => new ApiBlanketDiscoveryHandler<TApiInterface>(provider.GetRequiredService<IServiceApiHelper>(), definition));
		services.AddScoped(provider => new ApiHeaderHandler<TApiInterface>(provider.GetRequiredService<IRestApiHelper>()));

		return services.AddHttpClient(typeof(TApiInterface).Name,
							client =>
							{
								client.BaseAddress = ApiConstants.TempBaseAddress;
								client.Timeout = TimeSpan.FromSeconds(definition.RequestTimeout ?? ApiOptions.DefaultRequestTimeout);
							}
						)
						.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { UseDefaultCredentials = true })
						.AddHttpMessageHandler<ApiBlanketDiscoveryHandler<TApiInterface>>()
						.AddHttpMessageHandler<ApiHeaderHandler<TApiInterface>>()
						.AddTypedClient(RestClient.For<TApiInterface>);
	}

	public static IHttpClientBuilder AddRestEaseApiClient<TApiInterface>(
						this IServiceCollection services,
				IConfiguration config,
				string apiName = null)
				where TApiInterface : class, IApiClient
	{
		var definition = services.GetApiDefinition(config, typeof(TApiInterface), apiName);
		services.AddScoped(provider => new ApiDiscoveryHandler<TApiInterface>(provider.GetRequiredService<Midland.Core.Api.IRestApiHelper>(), definition));
		services.AddScoped(provider => new ApiHeaderHandler<TApiInterface>(provider.GetRequiredService<Midland.Core.Api.IRestApiHelper>()));

		return services.AddHttpClient(typeof(TApiInterface).Name,
				client =>
				{
					client.BaseAddress = ApiConstants.TempBaseAddress;
					client.Timeout = TimeSpan.FromSeconds(definition.RequestTimeout ?? ApiOptions.DefaultRequestTimeout);
				}
			)
			.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { UseDefaultCredentials = true })
			.AddHttpMessageHandler<ApiDiscoveryHandler<TApiInterface>>()
			.AddHttpMessageHandler<ApiHeaderHandler<TApiInterface>>()
			.AddTypedClient(RestClient.For<TApiInterface>);
	}

	public static string ApiNameFromClient(this Type apiType)
	{
		var attribute = (ApiNameAttribute)Attribute.GetCustomAttribute(apiType, typeof(ApiNameAttribute));

		return attribute?.Name;
	}

	public static TResponse Deserialize<TResponse>(this Response<TResponse> results)
			=> results.Deserialize(DEFAULT_JSON_OPTIONS);

	public static TResponse Deserialize<TResponse>(this Response<TResponse> results, JsonSerializerOptions options)
		=> JsonSerializer.Deserialize<TResponse>(results.StringContent, options);

	public static ApiDefinition GetApiDefinition(this IServiceCollection services, IConfiguration config, Type apiType, string apiName)
	{
		if (apiName.IsNullOrBlank())
		{
			apiName = ApiNameFromClient(apiType);
		}

		if (apiName.IsNullOrBlank())
		{
			var logData = new LogData
			{
				LogId = SequentialGuid.NewSql().ToString("D"),
				Message = $"Could not setup ApiClient. No apiName passed.",
				Action = nameof(ApiClientServiceExtensions.GetApiDefinition),
				Level = (int)LogLevel.Warning
			};

			Log.ForContext<LogData>().Warning("{@data}", logData);

			return new ApiDefinition();
		}

		var aeSection = config.GetSection(nameof(Application));
		if (aeSection == null) return new ApiDefinition(apiName);

		var appSection = aeSection.Get<Application>();
		if (appSection == null) return new ApiDefinition(apiName);

		if (appSection.ApiOptions == null) return new ApiDefinition(apiName);

		return appSection.ApiOptions.ApiList.Values().FirstOrDefault(a => a.Name == apiName) ?? new ApiDefinition(apiName, appSection);
	}
}