using Midland.Core.Authorization;
using System.Collections.ObjectModel;

namespace Midland.Core.ApplicationSecurity;

public class ApiSecurityInformation : MidlandApplication
{
    public ApiSecurityInformation()
    { }

    public ApiSecurityInformation(MidlandApplicationSecurityModel model)
    {
        Actions = model.Actions;
        ServiceTokens = model.ServiceTokens;
        Token = model.Token;
        ApplicationRef = model.MidlandApplication.ApplicationRef;
        Description = model.MidlandApplication.Description;
        Guid = model.MidlandApplication.Guid;
        IsLoaded = model.MidlandApplication.IsLoaded;
        Name = model.MidlandApplication.Name;
        Slug = model.MidlandApplication.Slug;
        VirtualDirectory = model.MidlandApplication.VirtualDirectory;
    }

    public List<ActionGroup> ActionGroups { get; set; }
    public List<string> Actions { get; set; }
    public ReadOnlyDictionary<Guid, MidlandServiceToken> ServiceTokens { get; set; }
    public string Token { get; set; }
}