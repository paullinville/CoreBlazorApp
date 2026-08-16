using System;

namespace EATTS.Common.Interfaces;

public interface IVisit
{
	int? UserRef { get; set; }
	string LastPage { get; set; }
	int VisitRef { get; set; }
	DateTime Timestamp { get; set; }

	public static void Map(IVisit fromData, IVisit toData)
	{
		if (fromData == null || toData == null) return;
		toData.UserRef = fromData.UserRef;
		toData.LastPage = fromData.LastPage + "";
		toData.VisitRef = fromData.VisitRef;
		toData.Timestamp = fromData.Timestamp;
	}

	public void MapTo(IVisit toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IVisit fromData)
	{
		Map(fromData, this);
	}
}