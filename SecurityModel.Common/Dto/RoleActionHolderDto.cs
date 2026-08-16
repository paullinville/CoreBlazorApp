using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class RoleActionHolderDto : IRoleActionHolder
{
	public RoleActionHolderDto(IRoleActionHolder values)
	{
		values?.MapTo(this);
	}

	public RoleActionHolderDto()
	{ }

	public int ActionRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime RoleActionGroupHolderCreateDate { get; set; }

	public int RoleRef { get; set; }
}