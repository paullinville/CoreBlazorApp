using System;

namespace EATTS.Common.Interfaces;

public interface IErrorAdditionalInfo
{
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	int ErrorAdditionalInfoRef { get; set; }
	int? ErrorRef { get; set; }
	int? UserRef { get; set; }

	public static void Map(IErrorAdditionalInfo fromData, IErrorAdditionalInfo toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.ErrorAdditionalInfoRef = fromData.ErrorAdditionalInfoRef;
		toData.ErrorRef = fromData.ErrorRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IErrorAdditionalInfo toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorAdditionalInfo fromData)
	{
		Map(fromData, this);
	}
}