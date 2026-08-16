using Midland.Core.Api;
using Midland.Core.Common;

namespace Midland.Core.Client;

public class ApiDiscoveryHandler<TApi>(IRestApiHelper apiHelper, ApiDefinition apiDefinition) : DelegatingHandler
	where TApi : class, IApiClient
{
	public IRestApiHelper ApiHelper { get; } = apiHelper;
	private ApiDefinition ApiDefinition { get; set; } = apiDefinition;
	private string BaseUrl { get; set; } = ApiConstants.DefaultBasePath;

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var addr = ApiHelper.GetDestination(ApiDefinition);
		BaseUrl = $"{ApiDefinition.Scheme.IsNullOrBlank(ApiConstants.DefaultScheme)}{addr}";

		var uri = new Uri(BaseUrl);
		var uriBuilder = new UriBuilder(request.RequestUri)
		{
			Host = uri.Host,
			Port = uri.Port
		};
		request.RequestUri = uriBuilder.Uri;

		using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
		{
			cts.CancelAfter(TimeSpan.FromSeconds(ApiDefinition?.RequestTimeout ?? ApiOptions.DefaultRequestTimeout));
			return await base.SendAsync(request, cancellationToken);
		}
	}
}