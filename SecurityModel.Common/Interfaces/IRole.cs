using System;

namespace SecurityModel.Common.Interfaces;

public interface IRole
{
	int ApplicationRef { get; set; }
	int? ContextTypeRef { get; set; }
	DateTime CreateDate { get; set; }
	int? CreateUserRef { get; set; }
	string Description { get; set; }
	byte IsActionGroupFlag { get; set; }
	bool IsActiveFlag { get; set; }
	string Name { get; set; }
	int RoleRef { get; set; }
	DateTime? UpdateDate { get; set; }
	int? UpdateUserRef { get; set; }

	public static void Map(IRole fromData, IRole toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.ContextTypeRef = fromData.ContextTypeRef;
		toData.CreateDate = fromData.CreateDate;
		toData.CreateUserRef = fromData.CreateUserRef;
		toData.Description = fromData.Description + "";
		toData.IsActionGroupFlag = fromData.IsActionGroupFlag;
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.Name = fromData.Name + "";
		toData.RoleRef = fromData.RoleRef;
		toData.UpdateDate = fromData.UpdateDate;
		toData.UpdateUserRef = fromData.UpdateUserRef;
	}

	public void MapFrom(IRole fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IRole toData)
	{
		Map(this, toData);
	}
}