using System;

namespace EATTS.Common.Interfaces;

public interface IApplication
{
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	short IsActiveFlag { get; set; }
	int ApplicationRef { get; set; }
	string VirtualDirectory { get; set; }

	public static void Map(IApplication fromData, IApplication toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.VirtualDirectory = fromData.VirtualDirectory + "";
	}

	public void MapTo(IApplication toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IApplication fromData)
	{
		Map(fromData, this);
	}
}