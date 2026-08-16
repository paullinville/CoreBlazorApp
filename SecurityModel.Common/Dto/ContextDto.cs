using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class ContextDto : IContext
{
	public ContextDto(IContext values)
	{
		values?.MapTo(this);
	}

	public ContextDto()
	{ }

	public int ApplicationContextRef { get; set; }

	public int ApplicationRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime CreateDate { get; set; }

	public int ContextRef { get; set; }

	public int TypeRef { get; set; }
}