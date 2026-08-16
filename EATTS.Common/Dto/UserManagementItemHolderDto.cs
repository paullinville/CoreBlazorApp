using System;

namespace EATTS.Common.Dto;

public class UserManagementItemHolderDto : IUserManagementItemHolder
{
	public UserManagementItemHolderDto(IUserManagementItemHolder values)
	{
		values?.MapTo(this);
	}

	public UserManagementItemHolderDto()
	{ }

	public int? ManagementItemRef { get; set; }

	public int ColumnNumber { get; set; }

	public DateTime CreateDate { get; set; }

	public string ImageType { get; set; }

	public int UserManagementItemHolderRef { get; set; }

	public int TablePosition { get; set; }

	public int? UserRef { get; set; }
}