namespace Midland.Core.Authorization;

public class ActionGroup
{
    public ActionGroup()
    { }

    public List<string> ActionClaims { get; set; }
    public string Description { get; set; }

    public string Name { get; set; }
}