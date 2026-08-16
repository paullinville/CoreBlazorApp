using System.ComponentModel.DataAnnotations;
using System;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Models;

public class ApplicationUserRoleActionModel : IApplicationUserRoleAction
{
    public ApplicationUserRoleActionModel()
    { }

    public ApplicationUserRoleActionModel(IApplicationUserRoleAction values)
    {
        values?.MapTo(this);
    }

    public DateTime ActionCreateDate { get; set; }

    [Required]
    [StringLength(400)]
    public string ActionDescription { get; set; }

    [Required]
    [StringLength(150)]
    public string ActionName { get; set; }

    public int ActionRef { get; set; }

    [StringLength(150)]
    public string ApplicationApiName { get; set; }

    public DateTime? ApplicationCreateDate { get; set; }

    public int? ApplicationCreateUserRef { get; set; }

    [Required]
    [StringLength(400)]
    public string ApplicationDescription { get; set; }

    public Guid ApplicationGuid { get; set; }

    public bool ApplicationIsActiveFlag { get; set; }

    public int ApplicationIsLoadedFlag { get; set; }

    [Required]
    [StringLength(150)]
    public string ApplicationName { get; set; }

    public int ApplicationRef { get; set; }

    [StringLength(90)]
    public string ApplicationSlug { get; set; }

    public DateTime ApplicationUserRoleHolderCreateDate { get; set; }

    [StringLength(250)]
    public string ApplicationVirtualDirectory { get; set; }

    public int? ContextTypeRef { get; set; }

    public DateTime RoleCreateDate { get; set; }

    public int? RoleCreateUserRef { get; set; }

    [Required]
    [StringLength(400)]
    public string RoleDescription { get; set; }

    public bool RoleIsActiveFlag { get; set; }

    [Required]
    [StringLength(150)]
    public string RoleName { get; set; }

    public int RoleRef { get; set; }

    public DateTime? RoleUpdateDate { get; set; }

    public int? RoleUpdateUserRef { get; set; }

    [StringLength(100)]
    public string UserFullName { get; set; }

    public int UserRef { get; set; }

    [StringLength(1)]
    public char? UserStatus { get; set; }

    public SecurityModel.Common.Dto.ApplicationUserRoleActionDto CreateDto()
    {
        var createdItem = new SecurityModel.Common.Dto.ApplicationUserRoleActionDto();
        createdItem.ActionCreateDate = ActionCreateDate;
        createdItem.ActionDescription = ActionDescription;
        createdItem.ActionName = ActionName;
        createdItem.ActionRef = ActionRef;
        createdItem.ApplicationApiName = ApplicationApiName;
        createdItem.ApplicationCreateDate = ApplicationCreateDate;
        createdItem.ApplicationCreateUserRef = ApplicationCreateUserRef;
        createdItem.ApplicationDescription = ApplicationDescription;
        createdItem.ApplicationGuid = ApplicationGuid;
        createdItem.ApplicationIsActiveFlag = ApplicationIsActiveFlag;
        createdItem.ApplicationIsLoadedFlag = ApplicationIsLoadedFlag;
        createdItem.ApplicationName = ApplicationName;
        createdItem.ApplicationRef = ApplicationRef;
        createdItem.ApplicationSlug = ApplicationSlug;
        createdItem.ApplicationUserRoleHolderCreateDate = ApplicationUserRoleHolderCreateDate;
        createdItem.ApplicationVirtualDirectory = ApplicationVirtualDirectory;
        createdItem.ContextTypeRef = ContextTypeRef;
        createdItem.RoleCreateDate = RoleCreateDate;
        createdItem.RoleCreateUserRef = RoleCreateUserRef;
        createdItem.RoleDescription = RoleDescription;
        createdItem.RoleIsActiveFlag = RoleIsActiveFlag;
        createdItem.RoleName = RoleName;
        createdItem.RoleRef = RoleRef;
        createdItem.RoleUpdateDate = RoleUpdateDate;
        createdItem.RoleUpdateUserRef = RoleUpdateUserRef;
        createdItem.UserFullName = UserFullName;
        createdItem.UserRef = UserRef;
        createdItem.UserStatus = UserStatus;
        return createdItem;
    }
}