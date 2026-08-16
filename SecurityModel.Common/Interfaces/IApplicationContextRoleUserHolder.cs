using System;

namespace SecurityModel.Common.Interfaces;

public interface IApplicationContextRoleUserHolder
{
	DateTime CreateDate { get; set; }
	bool IsActiveFlag { get; set; }
	int ApplicationContextRoleUserHolderRef { get; set; }
	int ApplicationRef { get; set; }
	int ContextRef { get; set; }
	int RoleRef { get; set; }
	int UserRef { get; set; }

	public static void Map(IApplicationContextRoleUserHolder fromData, IApplicationContextRoleUserHolder toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.ApplicationContextRoleUserHolderRef = fromData.ApplicationContextRoleUserHolderRef;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.ContextRef = fromData.ContextRef;
		toData.RoleRef = fromData.RoleRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IApplicationContextRoleUserHolder toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IApplicationContextRoleUserHolder fromData)
	{
		Map(fromData, this);
	}
}