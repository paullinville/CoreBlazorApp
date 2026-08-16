using System;

namespace EATTS.Common.Dto;

public class ErrorCategoryDto : IErrorCategory
{
	public ErrorCategoryDto(IErrorCategory values)
	{
		values?.MapTo(this);
	}

	public ErrorCategoryDto()
	{ }

	public DateTime CreateDate { get; set; }

	public string Description { get; set; }

	public short IsActiveFlag { get; set; }

	public int ErrorCategoryRef { get; set; }
}