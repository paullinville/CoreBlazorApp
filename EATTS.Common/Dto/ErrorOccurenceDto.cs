using System;

namespace EATTS.Common.Dto;

public class ErrorOccurenceDto : IErrorOccurence
{
	public ErrorOccurenceDto(IErrorOccurence values)
	{
		values?.MapTo(this);
	}

	public ErrorOccurenceDto()
	{ }

	public DateTime CreateDate { get; set; }

	public int ErrorOccurenceRef { get; set; }

	public int? ErrorRef { get; set; }

	public int? UserRef { get; set; }
}