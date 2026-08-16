using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ApplicationUserRoleModel : IApplicationUserRole
{
	public ApplicationUserRoleModel()
	{ }

	public ApplicationUserRoleModel(IApplicationUserRole values)
	{
		values?.MapTo(this);
	}

	[StringLength(150)]
	public string ApplicationApiName { get; set; }

	public DateTime? ApplicationCreateDate { get; set; }

	public int? ApplicationCreateUserRef { get; set; }

	[Required]
	[StringLength(400)]
	public string ApplicationDescription { get; set; }

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

	public int? ContextTypeRef { get; set; }

	public DateTime HolderCreateDate { get; set; }

	public DateTime RoleCreateDate { get; set; }

	public int? RoleCreateUserRef { get; set; }

	[Required]
	[StringLength(400)]
	public string RoleDescription { get; set; }

	public byte RoleIsActionGroupFlag { get; set; }

	public bool RoleIsActiveFlag { get; set; }

	[Required]
	[StringLength(150)]
	public string RoleName { get; set; }

	public int RoleRef { get; set; }

	public DateTime? RoleUpdateDate { get; set; }

	public int? RoleUpdateUserRef { get; set; }

	[StringLength(100)]
	public string UserFullName { get; set; }

	public string UserLastNameFirst { get; set; }
	public int? UserRef { get; set; }
}