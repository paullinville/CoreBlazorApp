using System;

namespace EATTS.Common.Dto;

public class VisitDto : IVisit
{
	public VisitDto(IVisit values)
	{
		values?.MapTo(this);
	}

	public VisitDto()
	{ }

	public int? UserRef { get; set; }

	public string LastPage { get; set; }

	public int VisitRef { get; set; }

	public DateTime Timestamp { get; set; }
}