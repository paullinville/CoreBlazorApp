using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class UserActionView : ActionEditDetailModel
{
    public UserActionView()
    {
    }

    public UserActionView(IApplicationUserRoleAction action, IEnumerable<string> roles)
    {
        ActionRef = action.ActionRef;
        Description = action.ActionDescription;
        Name = action.ActionName;
        ApplicationRef = action.ApplicationRef;
        CreateDate = action.ActionCreateDate;

        Roles = roles.Values().ToList();
    }

    public List<string> Roles { get; set; }
}