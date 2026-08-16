using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class RoleDto : IRole
{
	public RoleDto(IRole values)
	{
		values?.MapTo(this);
	}

	public RoleDto()
	{ }

	public int ApplicationRef { get; set; }

	public int? ContextTypeRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/999 11:59AM")]
	public DateTime CreateDate { get; set; }

	public int? CreateUserRef { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(400)]
	public string Description { get; set; }

	public byte IsActionGroupFlag { get; set; }

	public bool IsActiveFlag { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(150)]
	public string Name { get; set; }

	public int RoleRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/999 11:59AM")]
	public DateTime? UpdateDate { get; set; }

	public int? UpdateUserRef { get; set; }
}