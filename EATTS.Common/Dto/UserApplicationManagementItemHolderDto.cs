using System;

namespace EATTS.Common.Dto;

public class UserApplicationManagementItemHolderDto : IUserApplicationManagementItemHolder
{
	public UserApplicationManagementItemHolderDto(IUserApplicationManagementItemHolder values)
	{
		values?.MapTo(this);
	}

	public UserApplicationManagementItemHolderDto()
	{ }

	public int? ApplicationManagementItemRef { get; set; }

	public int ColumnNumber { get; set; }

	public DateTime CreateDate { get; set; }

	public string ImageType { get; set; }

	public int UserApplicationManagementItemHolderRef { get; set; }

	public int TablePosition { get; set; }

	public int? UserRef { get; set; }
}