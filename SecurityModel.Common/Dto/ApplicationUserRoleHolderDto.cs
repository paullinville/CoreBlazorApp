using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class ApplicationUserRoleHolderDto : IApplicationUserRoleHolder
{
	public ApplicationUserRoleHolderDto(IApplicationUserRoleHolder values)
	{
		values?.MapTo(this);
	}

	public ApplicationUserRoleHolderDto()
	{ }

	public int? ApplicationRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime CreateDate { get; set; }

	public int ApplicationUserRoleHolderRef { get; set; }

	public int? RoleRef { get; set; }

	public int? UserRef { get; set; }
}