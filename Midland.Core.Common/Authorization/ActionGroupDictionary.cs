using Midland.Core.Common;
using System.Security.Claims;

namespace Midland.Core.Authorization;

public class ActionGroupDictionary : Dictionary<string, HashSet<string>>
{
    public ActionGroupDictionary()
    { }

    public ActionGroupDictionary(IEnumerable<AuthorizeBearerAttribute> all)
    {
        if (all.IsNotEmpty())
        {
            if (all.SelectMany(a => a.Actions).All(r => r == AuthConstants.Authenticated))
            {
                Add(AuthConstants.AuthorizeBearerAttributeStandardGroup, new HashSet<string> { AuthConstants.Authenticated });
            }
            else
            {
                foreach (var action in all)
                {
                    if (!ContainsKey(action.Group.Trim().ToLower()))
                    {
                        Add(action.Group.Trim().ToLower(), new HashSet<string>());
                    }

                    action.Actions.ForEach(r => this[action.Group.Trim().ToLower()].Add(r));
                }
            }
        }
    }

    public bool AllowAllAuthenticated()
    {
        return this.SelectMany(r => r.Value).All(r => r == AuthConstants.Authenticated);
    }

    public List<string> MissingClaims(List<string> userActionClaims)
    {
        if (this.IsEmpty())
        {
            return null;
        }
        var allMissing = new List<string>();
        foreach (var group in this.Keys)
        {
            var groupMissingActions = new List<string>();
            foreach (var action in this[group])
            {
                if (!userActionClaims.Values().Contains(action))
                {
                    groupMissingActions.Add($"{group}:{action}");
                }
            }
            if (groupMissingActions.IsEmpty())
            {
                return new List<string>();
            }
            else
            {
                allMissing.AddRange(groupMissingActions);
            }
        }
        return allMissing;
    }
}