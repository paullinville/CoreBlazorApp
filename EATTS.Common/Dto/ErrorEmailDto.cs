using System;

namespace EATTS.Common.Dto;

public class ErrorEmailDto : IErrorEmail
{
	public ErrorEmailDto(IErrorEmail values)
	{
		values?.MapTo(this);
	}

	public ErrorEmailDto()
	{ }

	public DateTime CreateDate { get; set; }

	public int ErrorEmailRef { get; set; }

	public string Snapshot { get; set; }
}