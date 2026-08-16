namespace Midland.Core.Authorization;

public class TokenData
{
    public string Subject { get; set; }
    public Guid JwtIdentifier { get; set; }
    public List<Permission> Permissions { get; set; }
    public long LifetimeSeconds { get; set; }
    public IDictionary<string, object> AdditionalClaims { get; set; } = new Dictionary<string, object>();
    public List<Guid> OtherApplications { get; set; }
    public int NotBeforeDelay { get; set; } = 15;

    //3/4/2024
    //Latest version of Microsoft.IdentityModel.Tokens does not recognize either NewtonSoft or System.Text.Json property naming attributes.
#pragma warning disable IDE1006 // Naming Styles
    public string userId { get; set; }
    public int? version { get; set; }
    public TokenSubjectType? subjectType { get; set; }
#pragma warning restore IDE1006 // Naming Styles
}