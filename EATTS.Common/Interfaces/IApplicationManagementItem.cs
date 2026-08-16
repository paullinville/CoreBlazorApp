using System;

namespace EATTS.Common.Interfaces;

public interface IApplicationManagementItem
{
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	string ID { get; set; }
	short IsActiveFlag { get; set; }
	int ApplicationManagementItemRef { get; set; }

	public static void Map(IApplicationManagementItem fromData, IApplicationManagementItem toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.ID = fromData.ID + "";
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.ApplicationManagementItemRef = fromData.ApplicationManagementItemRef;
	}

	public void MapTo(IApplicationManagementItem toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IApplicationManagementItem fromData)
	{
		Map(fromData, this);
	}
}