//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Dto;

public class ApplicationRoleActionDto : IApplicationRoleAction 
{
    public ApplicationRoleActionDto(IApplicationRoleAction values)
    {
        values?.MapTo(this);
    }

    public ApplicationRoleActionDto()
    { }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string ActionDescription { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string ActionName { get; set; }

    public int ActionRef { get; set; }

    [StringLength(150)]
    public string ApplicationApiName { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string ApplicationDescription { get; set; }

    public Guid ApplicationGuid { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string ApplicationName { get; set; }

    public int ApplicationRef { get; set; }

    [StringLength(90)]
    public string ApplicationSlug { get; set; }

    [StringLength(250)]
    public string ApplicationVirtualDirectory { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string RoleDescription { get; set; }

    public bool RoleIsActiveFlag { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string RoleName { get; set; }

    public int RoleRef { get; set; }

}