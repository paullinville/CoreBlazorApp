using System;

namespace EATTS.Common.Interfaces;

public interface IErrorCategory
{
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	short IsActiveFlag { get; set; }
	int ErrorCategoryRef { get; set; }

	public static void Map(IErrorCategory fromData, IErrorCategory toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.ErrorCategoryRef = fromData.ErrorCategoryRef;
	}

	public void MapTo(IErrorCategory toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorCategory fromData)
	{
		Map(fromData, this);
	}
}