using System;

namespace SecurityModel.Common.Dto;

public class RoleRoleHolderDto : IRoleRoleHolder
{
	public RoleRoleHolderDto(IRoleRoleHolder values)
	{
		values?.MapTo(this);
	}

	public RoleRoleHolderDto()
	{ }

	public int ChildRoleRef { get; set; }

	public int ParentRoleRef { get; set; }

	public DateTime CreateDate { get; set; }

	public int RoleRoleHolderRef { get; set; }
}