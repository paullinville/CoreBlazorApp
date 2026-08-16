using System;

namespace EATTS.Common.Dto;

public class ErrorHistoryDto : IErrorHistory
{
	public ErrorHistoryDto(IErrorHistory values)
	{
		values?.MapTo(this);
	}

	public ErrorHistoryDto()
	{ }

	public string Comment { get; set; }

	public DateTime CreateDate { get; set; }

	public int ErrorHistoryRef { get; set; }

	public int? ErrorRef { get; set; }

	public int? UserRef { get; set; }
}