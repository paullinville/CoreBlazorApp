using Midland.Core.Api;
using Midland.Core.Common;
using System.Net;
using System.Text.Json;

namespace Midland.Core.Client;

public class ApiBlanketDiscoveryHandler<TApi>(IServiceApiHelper apiHelper, ApiDefinition apiDefinition) : DelegatingHandler
	where TApi : class, IApiClient
{
	public IServiceApiHelper ApiHelper { get; } = apiHelper;
	private ApiDefinition ApiDefinition { get; set; } = apiDefinition;

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var allAllocations = ApiHelper.GetConsulAddresses(ApiDefinition.Name);
		var Results = new List<ResponseContent>();
		int highestStatusCode = (int)HttpStatusCode.OK;
		foreach (var allocationAddress in allAllocations)
		{
			var uri = new Uri($"{ApiDefinition.Scheme.IsNullOrBlank(ApiConstants.DefaultScheme)}{allocationAddress}");
			var uriBuilder = new UriBuilder(request.RequestUri)
			{
				Host = uri.Host,
				Port = uri.Port
			};
			request.RequestUri = uriBuilder.Uri;

			using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
			{
				cts.CancelAfter(TimeSpan.FromSeconds(ApiDefinition?.RequestTimeout ?? ApiOptions.DefaultRequestTimeout));
				var response = await base.SendAsync(request, cancellationToken);
				highestStatusCode = int.Max((int)response.StatusCode, highestStatusCode);
				var content = new ResponseContent
				{
					StatusCode = response.StatusCode,
					Address = allocationAddress
				};

				string stringContent = await response.Content.ReadAsStringAsync();

				try
				{
					content.Content = JsonSerializer.Deserialize<object>(stringContent);
					content.IsJson = true;
				}
				catch
				{
					content.IsJson = false;
					content.Content = stringContent;
				}

				Results.Add(content);
			}
		}
		if (Results.Count > 0)
		{
			return new HttpResponseMessage((HttpStatusCode)highestStatusCode)
			{
				Content = new StringContent(JsonSerializer.Serialize(Results))
			};
		}
		else
		{
			return new HttpResponseMessage();
		}
	}
}