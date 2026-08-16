using System;

namespace EATTS.Common.Interfaces;

public interface IErrorHistory
{
	string Comment { get; set; }
	DateTime CreateDate { get; set; }
	int ErrorHistoryRef { get; set; }
	int? ErrorRef { get; set; }
	int? UserRef { get; set; }

	public static void Map(IErrorHistory fromData, IErrorHistory toData)
	{
		if (fromData == null || toData == null) return;
		toData.Comment = fromData.Comment + "";
		toData.CreateDate = fromData.CreateDate;
		toData.ErrorHistoryRef = fromData.ErrorHistoryRef;
		toData.ErrorRef = fromData.ErrorRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IErrorHistory toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorHistory fromData)
	{
		Map(fromData, this);
	}
}