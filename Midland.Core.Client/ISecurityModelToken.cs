using Midland.Core.Common;
using System.IdentityModel.Tokens.Jwt;

namespace Midland.Core.Client;

public interface ISecurityModelToken
{
    IUserTokenRequestModel ApiListRequest { get; set; }

    Task<JwtSecurityToken> GetSecurityToken();

    Task<string> GetToken();

    Task SetAuthorization(HttpClient httpClient);
}