//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Dto;

public class ApplicationUserRoleActionDto : IApplicationUserRoleAction 
{
    public ApplicationUserRoleActionDto(IApplicationUserRoleAction values)
    {
        values?.MapTo(this);
    }

    public ApplicationUserRoleActionDto()
    { }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime ActionCreateDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string ActionDescription { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string ActionName { get; set; }

    public int ActionRef { get; set; }

    [StringLength(150)]
    public string ApplicationApiName { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime? ApplicationCreateDate { get; set; }

    public int? ApplicationCreateUserRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string ApplicationDescription { get; set; }

    public Guid ApplicationGuid { get; set; }

    public bool ApplicationIsActiveFlag { get; set; }

    public int ApplicationIsLoadedFlag { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string ApplicationName { get; set; }

    public int ApplicationRef { get; set; }

    [StringLength(90)]
    public string ApplicationSlug { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime ApplicationUserRoleHolderCreateDate { get; set; }

    [StringLength(250)]
    public string ApplicationVirtualDirectory { get; set; }

    public int? ContextTypeRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime RoleCreateDate { get; set; }

    public int? RoleCreateUserRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string RoleDescription { get; set; }

    public bool RoleIsActiveFlag { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string RoleName { get; set; }

    public int RoleRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime? RoleUpdateDate { get; set; }

    public int? RoleUpdateUserRef { get; set; }

    [StringLength(100)]
    public string UserFullName { get; set; }

    public int UserRef { get; set; }

    [StringLength(1)]
    public char? UserStatus { get; set; }

}