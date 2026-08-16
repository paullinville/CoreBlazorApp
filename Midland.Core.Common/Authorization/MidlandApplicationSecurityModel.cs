using System.Collections.ObjectModel;

namespace Midland.Core.ApplicationSecurity;

public class MidlandApplicationSecurityModel
{
    public List<string> Actions { get; set; }
    public MidlandApplication MidlandApplication { get; set; }
    public ReadOnlyDictionary<Guid, MidlandServiceToken> ServiceTokens { get; set; }
    public string Token { get; set; }
}