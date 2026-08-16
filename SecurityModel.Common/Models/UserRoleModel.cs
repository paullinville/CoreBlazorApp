using System;

namespace SecurityModel.Common.Models;

public class UserRoleModel : EmployeeSimple
{
	public UserRoleModel()
	{ }

	public UserRoleModel(IMidlandUser midlandUser, IApplicationUserRole role) : base(midlandUser)
	{
		CreateDate = role.HolderCreateDate;
		RoleRef = role.RoleRef;
		ApplicationRef = role.ApplicationRef;
		Name = role.RoleName;
		Description = role.RoleDescription;
	}

	public string Name { get; set; }
	public string Description { get; set; }
	public DateTime CreateDate { get; set; }
	public int RoleRef { get; set; }
	public int ApplicationRef { get; set; }
}