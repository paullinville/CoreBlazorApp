using System;

namespace SecurityModel.Common.Interfaces;

public interface IApplicationUserRoleHolderHistory
{
	int? ApplicationRef { get; set; }
	DateTime ApplicationUserRoleHolderCreateDate { get; set; }
	int ApplicationUserRoleHolderRef { get; set; }
	int? RoleRef { get; set; }
	int? UserRef { get; set; }

	public static void Map(IApplicationUserRoleHolderHistory fromData, IApplicationUserRoleHolderHistory toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.ApplicationUserRoleHolderCreateDate = fromData.ApplicationUserRoleHolderCreateDate;
		toData.ApplicationUserRoleHolderRef = fromData.ApplicationUserRoleHolderRef;
		toData.RoleRef = fromData.RoleRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IApplicationUserRoleHolderHistory toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IApplicationUserRoleHolderHistory fromData)
	{
		Map(fromData, this);
	}
}