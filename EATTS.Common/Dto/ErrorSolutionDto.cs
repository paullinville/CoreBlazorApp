using System;

namespace EATTS.Common.Dto;

public class ErrorSolutionDto : IErrorSolution
{
	public ErrorSolutionDto(IErrorSolution values)
	{
		values?.MapTo(this);
	}

	public ErrorSolutionDto()
	{ }

	public int? ErrorRef { get; set; }

	public DateTime CreateDate { get; set; }

	public string Description { get; set; }

	public int ErrorSolutionRef { get; set; }

	public int? UserRef { get; set; }
}