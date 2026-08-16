using System;

namespace EATTS.Common.Dto;

public class ApplicationManagementItemDto : IApplicationManagementItem
{
	public ApplicationManagementItemDto(IApplicationManagementItem values)
	{
		values?.MapTo(this);
	}

	public ApplicationManagementItemDto()
	{ }

	public DateTime CreateDate { get; set; }

	public string Description { get; set; }

	public string ID { get; set; }

	public short IsActiveFlag { get; set; }

	public int ApplicationManagementItemRef { get; set; }
}