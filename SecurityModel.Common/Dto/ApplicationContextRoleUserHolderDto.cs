using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class ApplicationContextRoleUserHolderDto : IApplicationContextRoleUserHolder
{
	public ApplicationContextRoleUserHolderDto(IApplicationContextRoleUserHolder values)
	{
		values?.MapTo(this);
	}

	public ApplicationContextRoleUserHolderDto()
	{ }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime CreateDate { get; set; }

	public bool IsActiveFlag { get; set; }

	public int ApplicationContextRoleUserHolderRef { get; set; }

	public int ApplicationRef { get; set; }

	public int ContextRef { get; set; }

	public int RoleRef { get; set; }

	public int UserRef { get; set; }
}