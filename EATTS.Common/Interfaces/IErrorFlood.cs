using System;

namespace EATTS.Common.Interfaces;

public interface IErrorFlood
{
	int ErrorFloodRef { get; set; }
	int ErrorRef { get; set; }
	DateTime FloodEnd { get; set; }
	DateTime FloodStart { get; set; }

	public static void Map(IErrorFlood fromData, IErrorFlood toData)
	{
		if (fromData == null || toData == null) return;
		toData.ErrorFloodRef = fromData.ErrorFloodRef;
		toData.ErrorRef = fromData.ErrorRef;
		toData.FloodEnd = fromData.FloodEnd;
		toData.FloodStart = fromData.FloodStart;
	}

	public void MapTo(IErrorFlood toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorFlood fromData)
	{
		Map(fromData, this);
	}
}