using Midland.Core.Client;
using Midland.Core.Common;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace BlazorApp.Data;

public class MockSecurityModelToken : ISecurityModelToken
{
    private readonly string _mockToken;
    private readonly JwtSecurityToken _token;

    public MockSecurityModelToken(IConfiguration configuration)
    {
        _mockToken = configuration["MockToken"] ?? throw new InvalidOperationException("MockToken key is missing from appsettings.Local.json.");
        _token = new JwtSecurityTokenHandler().ReadJwtToken(_mockToken);
    }

    public IUserTokenRequestModel ApiListRequest { get; set; } = new UserTokenRequestModel();

    public Task<JwtSecurityToken> GetSecurityToken()
    {
        return Task.FromResult(_token);
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
