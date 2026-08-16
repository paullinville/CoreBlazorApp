using System;

namespace EATTS.Common.Interfaces;

public interface IManagementItem
{
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	string ID { get; set; }
	short IsActiveFlag { get; set; }
	int ManagementItemRef { get; set; }

	public static void Map(IManagementItem fromData, IManagementItem toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.ID = fromData.ID + "";
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.ManagementItemRef = fromData.ManagementItemRef;
	}

	public void MapTo(IManagementItem toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IManagementItem fromData)
	{
		Map(fromData, this);
	}
}