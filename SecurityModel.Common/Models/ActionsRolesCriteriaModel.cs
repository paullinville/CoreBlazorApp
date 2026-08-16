using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class ActionsRolesCriteriaModel : FilterCriteriaBase
{
    [FilterProperty(nameof(IApplicationRoleAction.ActionName))]
    public List<string> Actions { get; set; }

    public virtual int ApplicationRef { get; set; }

    /// <summary>
    /// Defaults to true.
    /// </summary>
    [FilterProperty(nameof(IApplicationRoleAction.RoleIsActiveFlag))]
    public bool? IsActive { get; set; } = true;
}