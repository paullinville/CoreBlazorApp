using System;

namespace SecurityModel.Common.Interfaces;

public interface IRoleRoleHolder
{
	int ChildRoleRef { get; set; }
	int ParentRoleRef { get; set; }
	DateTime CreateDate { get; set; }
	int RoleRoleHolderRef { get; set; }

	public static void Map(IRoleRoleHolder fromData, IRoleRoleHolder toData)
	{
		if (fromData == null || toData == null) return;
		toData.ChildRoleRef = fromData.ChildRoleRef;
		toData.ParentRoleRef = fromData.ParentRoleRef;
		toData.CreateDate = fromData.CreateDate;
		toData.RoleRoleHolderRef = fromData.RoleRoleHolderRef;
	}

	public void MapTo(IRoleRoleHolder toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IRoleRoleHolder fromData)
	{
		Map(fromData, this);
	}
}