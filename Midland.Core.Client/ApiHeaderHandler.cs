using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Midland.Core.Api;
using Midland.Core.Authorization;

namespace Midland.Core.Client;

public class ApiHeaderHandler<TApi>(IRestApiHelper apiHelper) : DelegatingHandler
    where TApi : class, IApiClient
{
    public TApi Api { get; set; }
    public IRestApiHelper ApiHelper { get; set; } = apiHelper;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Any(h => h.Key == AuthConstants.AuthorizationHeader))
        {
            request.Headers.Remove(AuthConstants.AuthorizationHeader);
        }

        foreach (var header in ApiHelper.DefaultHeaders())
        {
            request.Headers.Add(header.Name, header.Value);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}