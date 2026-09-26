using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace Midland.Core.Client;

public class SecurityModelToken : ISecurityModelToken
{
    private const string V2Route = "v2/Token/User";
    private readonly HttpClient _httpClient;
    private readonly IEventChannelBus _eventChannelBus;

    public SecurityModelToken(HttpClient httpClient, IUserTokenRequestModel requestModel, IEventChannelBus eventChannelBus)
    {
        _httpClient = httpClient;
        ApiListRequest = requestModel ?? new Midland.Core.Common.UserTokenRequestModel();
        this._eventChannelBus = eventChannelBus;
    }

    public SecurityModelToken()
    {
    }

    public IUserTokenRequestModel ApiListRequest { get; set; }
    private static JwtSecurityToken? SecurityToken { get; set; }
    private static string? Token { get; set; }

    public async Task<JwtSecurityToken> GetSecurityToken()
    {
        await CheckToken();
        return SecurityToken;
    }

    public async Task<string> GetToken()
    {
        await CheckToken();
        return Token;
    }

    public string GetUrl()
    {
        var url = V2Route;
        string add = "?";
        foreach (var primary in ApiListRequest.PrimaryApplications.Values())
        {
            url += $"{add}{nameof(IUserTokenRequestModel.PrimaryApplications)}={primary.ToString()}";
            add = "&";
        }

        foreach (var other in ApiListRequest.OtherApplications.Values())
        {
            url += $"{add}{nameof(IUserTokenRequestModel.OtherApplications)}={other.ToString()}";
            add = "&";
        }

        return url;
    }

    public async Task SetAuthorization(HttpClient httpClient)
    {
        var token = await GetToken();
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }

    public void SetToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var oldToken = SecurityToken;
        if (tokenHandler.CanReadToken(Token))
        {
            try
            {
                SecurityToken = tokenHandler.ReadJwtToken(Token);
            }
            catch
            {
                SecurityToken = null;
            }
            _eventChannelBus.PublishAsync(new SecurityTokenUpdatedEvent(oldToken, SecurityToken));
        }
    }

    private async Task CheckToken()
    {
        try
        {
            if (SecurityToken == null || SecurityToken.ValidTo < DateTime.UtcNow.AddSeconds(-10))
            {
                Token = await _httpClient.GetStringAsync(GetUrl());
                SetToken();
            }
        }
        catch (Exception ex)
        {
            ex.Data.Add("CheckToken", "Error In CheckToken");
            throw;
        }
    }
}