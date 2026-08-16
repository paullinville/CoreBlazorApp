using System;

namespace SecurityModel.Common.Interfaces;

public interface IApplicationUserRoleHolder
{
	int? ApplicationRef { get; set; }
	DateTime CreateDate { get; set; }
	int ApplicationUserRoleHolderRef { get; set; }
	int? RoleRef { get; set; }
	int? UserRef { get; set; }

	public static void Map(IApplicationUserRoleHolder fromData, IApplicationUserRoleHolder toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.CreateDate = fromData.CreateDate;
		toData.ApplicationUserRoleHolderRef = fromData.ApplicationUserRoleHolderRef;
		toData.RoleRef = fromData.RoleRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IApplicationUserRoleHolder toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IApplicationUserRoleHolder fromData)
	{
		Map(fromData, this);
	}
}