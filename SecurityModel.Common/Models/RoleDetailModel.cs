using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class RoleDetailModel : RoleViewModel
{
	public RoleDetailModel()
	{ }

	public RoleDetailModel(IRole values) : base(values)
	{
		ApplicationRef = values.ApplicationRef;
		IsActive = values.IsActiveFlag;
		CreateUserRef = values.CreateUserRef;
		CreateDate = values.CreateDate;
	}

	public RoleDetailModel(IApplicationUserRole values)
	{
		ApplicationRef = values.ApplicationRef;
		IsActive = values.RoleIsActiveFlag;
		Description = values.RoleDescription + "";
		Name = values.RoleName + "";
		RoleRef = values.RoleRef;
		CreateDate = values.RoleCreateDate;
		CreateUserRef = values.RoleCreateUserRef;
	}

	public List<int> ActionGroupRefs { get; set; }
	public List<int> ActionRefs { get; set; }
	public DateTime? CreateDate { get; set; }

	public int? CreateUserRef { get; set; }
}