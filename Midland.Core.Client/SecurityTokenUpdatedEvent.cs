using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using System.IdentityModel.Tokens.Jwt;

namespace Midland.Core.Client;

public class SecurityTokenUpdatedEvent : ChannelEvent<TokenChangeData>
{
    public SecurityTokenUpdatedEvent()
    {
        this.Name = "Security Token Update";
    }

    public SecurityTokenUpdatedEvent(JwtSecurityToken oldToken, JwtSecurityToken newToken) : this()
    {
        Value = new TokenChangeData
        {
            OldToken = oldToken,
            NewToken = newToken
        };
    }
}

public class TokenChangeData
{
    public JwtSecurityToken OldToken { get; set; }
    public JwtSecurityToken NewToken { get; set; }
}