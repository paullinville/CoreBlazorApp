using System.ComponentModel.DataAnnotations;
using System;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Models;

public class ApplicationRoleActionModel : IApplicationRoleAction
{
    public ApplicationRoleActionModel()
    { }

    public ApplicationRoleActionModel(IApplicationRoleAction values)
    {
        values?.MapTo(this);
    }

    [Required]
    [StringLength(400)]
    public string ActionDescription { get; set; }

    [Required]
    [StringLength(150)]
    public string ActionName { get; set; }

    public int ActionRef { get; set; }

    [StringLength(150)]
    public string ApplicationApiName { get; set; }

    [Required]
    [StringLength(400)]
    public string ApplicationDescription { get; set; }

    public Guid ApplicationGuid { get; set; }

    [Required]
    [StringLength(150)]
    public string ApplicationName { get; set; }

    public int ApplicationRef { get; set; }

    [StringLength(90)]
    public string ApplicationSlug { get; set; }

    [StringLength(250)]
    public string ApplicationVirtualDirectory { get; set; }

    [Required]
    [StringLength(400)]
    public string RoleDescription { get; set; }

    public bool RoleIsActiveFlag { get; set; }

    [Required]
    [StringLength(150)]
    public string RoleName { get; set; }

    public int RoleRef { get; set; }

    public SecurityModel.Common.Dto.ApplicationRoleActionDto CreateDto()
    {
        var createdItem = new SecurityModel.Common.Dto.ApplicationRoleActionDto();
        createdItem.ActionDescription = ActionDescription;
        createdItem.ActionName = ActionName;
        createdItem.ActionRef = ActionRef;
        createdItem.ApplicationApiName = ApplicationApiName;
        createdItem.ApplicationDescription = ApplicationDescription;
        createdItem.ApplicationGuid = ApplicationGuid;
        createdItem.ApplicationName = ApplicationName;
        createdItem.ApplicationRef = ApplicationRef;
        createdItem.ApplicationSlug = ApplicationSlug;
        createdItem.ApplicationVirtualDirectory = ApplicationVirtualDirectory;
        createdItem.RoleDescription = RoleDescription;
        createdItem.RoleIsActiveFlag = RoleIsActiveFlag;
        createdItem.RoleName = RoleName;
        createdItem.RoleRef = RoleRef;
        return createdItem;
    }
}