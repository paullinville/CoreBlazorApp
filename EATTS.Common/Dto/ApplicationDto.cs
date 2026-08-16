using System;

namespace EATTS.Common.Dto;

public class ApplicationDto : IApplication
{
	public ApplicationDto(IApplication values)
	{
		values?.MapTo(this);
	}

	public ApplicationDto()
	{ }

	public DateTime CreateDate { get; set; }

	public string Description { get; set; }

	public short IsActiveFlag { get; set; }

	public int ApplicationRef { get; set; }

	public string VirtualDirectory { get; set; }
}