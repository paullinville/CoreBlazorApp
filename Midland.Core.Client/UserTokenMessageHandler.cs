namespace Midland.Core.Client;

public class UserTokenMessageHandler : DelegatingHandler
{
    private readonly ISecurityModelToken _securityToken;

    public UserTokenMessageHandler(ISecurityModelToken securityToken)
    {
        _securityToken = securityToken;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var userToken = await _securityToken.GetToken();
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userToken);

        return await base.SendAsync(request, cancellationToken);
    }
}