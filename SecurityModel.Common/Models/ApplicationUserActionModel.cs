using System.ComponentModel.DataAnnotations;
using System;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Models;

public class ApplicationUserActionModel : IApplicationUserAction
{
    public ApplicationUserActionModel()
    { }

    public ApplicationUserActionModel(IApplicationUserAction values)
    {
        values?.MapTo(this);
    }

    [Required]
    [StringLength(150)]
    public string ActionName { get; set; }

    public int ActionRef { get; set; }

    [StringLength(150)]
    public string ApplicationApiName { get; set; }

    public Guid ApplicationGuid { get; set; }

    public bool ApplicationIsActiveFlag { get; set; }

    [Required]
    [StringLength(150)]
    public string ApplicationName { get; set; }

    public int ApplicationRef { get; set; }

    [StringLength(90)]
    public string ApplicationSlug { get; set; }

    [StringLength(250)]
    public string ApplicationVirtualDirectory { get; set; }

    [StringLength(100)]
    public string UserFullName { get; set; }

    public int UserRef { get; set; }

    public SecurityModel.Common.Dto.ApplicationUserActionDto CreateDto()
    {
        var createdItem = new SecurityModel.Common.Dto.ApplicationUserActionDto();
        createdItem.ActionName = ActionName;
        createdItem.ActionRef = ActionRef;
        createdItem.ApplicationApiName = ApplicationApiName;
        createdItem.ApplicationGuid = ApplicationGuid;
        createdItem.ApplicationIsActiveFlag = ApplicationIsActiveFlag;
        createdItem.ApplicationName = ApplicationName;
        createdItem.ApplicationRef = ApplicationRef;
        createdItem.ApplicationSlug = ApplicationSlug;
        createdItem.ApplicationVirtualDirectory = ApplicationVirtualDirectory;
        createdItem.UserFullName = UserFullName;
        createdItem.UserRef = UserRef;
        return createdItem;
    }
}