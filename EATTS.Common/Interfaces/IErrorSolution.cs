using System;

namespace EATTS.Common.Interfaces;

public interface IErrorSolution
{
	int? ErrorRef { get; set; }
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	int ErrorSolutionRef { get; set; }
	int? UserRef { get; set; }

	public static void Map(IErrorSolution fromData, IErrorSolution toData)
	{
		if (fromData == null || toData == null) return;
		toData.ErrorRef = fromData.ErrorRef;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.ErrorSolutionRef = fromData.ErrorSolutionRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IErrorSolution toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorSolution fromData)
	{
		Map(fromData, this);
	}
}