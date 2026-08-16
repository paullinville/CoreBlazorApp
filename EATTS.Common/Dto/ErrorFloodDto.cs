using System;

namespace EATTS.Common.Dto;

public class ErrorFloodDto : IErrorFlood
{
	public ErrorFloodDto(IErrorFlood values)
	{
		values?.MapTo(this);
	}

	public ErrorFloodDto()
	{ }

	public int ErrorFloodRef { get; set; }

	public int ErrorRef { get; set; }

	public DateTime FloodEnd { get; set; }

	public DateTime FloodStart { get; set; }
}