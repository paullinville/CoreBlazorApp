using Midland.Core.Client;
using Midland.Core.Common;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using Midland.Core.SimpleMessageBus;

namespace BlazorApp.Data;

public class MockSecurityModelToken : ISecurityModelToken
{
    private readonly string _mockToken;
    private readonly JwtSecurityToken _token;
    private readonly IEventChannelBus _eventBus;

    private static int _tokenChangeCount = 0;

    public MockSecurityModelToken(IConfiguration configuration, IEventChannelBus eventBus)
    {
        _mockToken = configuration["MockToken"] ?? throw new InvalidOperationException("MockToken key is missing from appsettings.Local.json.");
        _token = new JwtSecurityTokenHandler().ReadJwtToken(_mockToken);
        this._eventBus = eventBus;
    }

    public IUserTokenRequestModel ApiListRequest { get; set; } = new UserTokenRequestModel();

    public async Task<JwtSecurityToken> GetSecurityToken()
    {
        if ((_tokenChangeCount > 4))
        {
            await _eventBus.PublishAsync(new SecurityTokenUpdatedEvent(_token, _token));
            _tokenChangeCount = 0;
        }
        return _token;
    }

    public Task<string> GetToken()
    {
        return Task.FromResult(_mockToken);
    }

    public Task SetAuthorization(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _mockToken);
        return Task.CompletedTask;
    }
}