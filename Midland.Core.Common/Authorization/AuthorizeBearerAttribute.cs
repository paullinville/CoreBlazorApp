namespace Midland.Core.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorizeBearerAttribute : Attribute
{
    public AuthorizeBearerAttribute(params string[] actions)
    {
        if (actions.IsEmpty())
        {
            Actions = new string[0];
        }
        else
        {
            Actions = actions.Where(a => a.IsNotNullOrBlank()).Values().ToArray();
        }
    }

    private AuthorizeBearerAttribute()
    {
        Actions = ["*"];
    }

    /// <summary>
    /// New array of Actions that must be in the claims
    /// </summary>
    public string[] Actions { get; set; }

    public string Group { get; set; } = "Standard";
}