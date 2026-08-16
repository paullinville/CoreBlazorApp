using System;

namespace EATTS.Common.Dto;

public class ManagementItemDto : IManagementItem
{
	public ManagementItemDto(IManagementItem values)
	{
		values?.MapTo(this);
	}

	public ManagementItemDto()
	{ }

	public DateTime CreateDate { get; set; }

	public string Description { get; set; }

	public string ID { get; set; }

	public short IsActiveFlag { get; set; }

	public int ManagementItemRef { get; set; }
}