using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class ContextTypeDto : IContextType
{
	public ContextTypeDto(IContextType values)
	{
		values?.MapTo(this);
	}

	public ContextTypeDto()
	{ }

	public int ApplicationRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime CreateDate { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(500)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(150)]
	public string Name { get; set; }

	public int ContextTypeRef { get; set; }
}