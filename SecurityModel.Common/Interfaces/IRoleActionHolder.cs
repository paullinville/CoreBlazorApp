using System;

namespace SecurityModel.Common.Interfaces;

public interface IRoleActionHolder
{
	int ActionRef { get; set; }
	DateTime RoleActionGroupHolderCreateDate { get; set; }
	int RoleRef { get; set; }

	public static void Map(IRoleActionHolder fromData, IRoleActionHolder toData)
	{
		if (fromData == null || toData == null) return;
		toData.ActionRef = fromData.ActionRef;
		toData.RoleActionGroupHolderCreateDate = fromData.RoleActionGroupHolderCreateDate;
		toData.RoleRef = fromData.RoleRef;
	}

	public void MapTo(IRoleActionHolder toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IRoleActionHolder fromData)
	{
		Map(fromData, this);
	}
}