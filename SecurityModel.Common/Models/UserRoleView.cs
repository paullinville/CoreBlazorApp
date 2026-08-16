using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class UserRoleView
{
	public UserRoleView()
	{ }

	public UserRoleView(IApplicationUserRole aur)
	{
		Name = aur.RoleName;
		Description = aur.RoleDescription;
		RoleRef = aur.RoleRef;
		ApplicationRef = aur.ApplicationRef;
		CreateDate = aur.HolderCreateDate;
	}

	public UserRoleView(IApplicationUserRoleAction userRoleAction)
	{
		Name = userRoleAction.RoleName;
		Description = userRoleAction.RoleDescription;
		RoleRef = userRoleAction.RoleRef;
		ApplicationRef = userRoleAction.ApplicationRef;
		CreateDate = userRoleAction.ApplicationUserRoleHolderCreateDate;
	}

	public List<ActionViewModel> Actions { get; set; }
	public int ApplicationRef { get; set; }
	public DateTime CreateDate { get; set; }
	public string Description { get; set; }
	public string Name { get; set; }
	public int RoleRef { get; set; }
}