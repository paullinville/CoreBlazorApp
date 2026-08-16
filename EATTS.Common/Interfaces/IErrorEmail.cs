using System;

namespace EATTS.Common.Interfaces;

public interface IErrorEmail
{
	DateTime CreateDate { get; set; }
	int ErrorEmailRef { get; set; }
	string Snapshot { get; set; }

	public static void Map(IErrorEmail fromData, IErrorEmail toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.ErrorEmailRef = fromData.ErrorEmailRef;
		toData.Snapshot = fromData.Snapshot + "";
	}

	public void MapTo(IErrorEmail toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorEmail fromData)
	{
		Map(fromData, this);
	}
}