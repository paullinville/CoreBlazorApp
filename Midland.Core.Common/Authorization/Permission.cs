using Midland.Core.ApplicationSecurity;

namespace Midland.Core.Authorization;

public class Permission
{
    public Permission()
    { }

    public Permission(IMidlandApplication app)
    {
        applicationName = app.Name;
        applicationGuid = app.Guid;
        applicationSlug = app.Slug;
        actions = new List<string>();
    }

    public Permission(IMidlandApplication app, IEnumerable<string> allowedActions)
    {
        applicationName = app.Name;
        applicationGuid = app.Guid;
        applicationSlug = app.Slug;
        actions = new List<string>(allowedActions);
    }

#pragma warning disable IDE1006 // 3/4/2024 Latest version of Microsoft.IdentityModel.Tokens does not recoginze either Newtonsoft or System.Text.Json property naming attributes.
    public string applicationName { get; set; }
    public string applicationSlug { get; set; }
    public Guid applicationGuid { get; set; }
    public List<string> actions { get; set; }
#pragma warning restore IDE1006 // Naming Styles
}