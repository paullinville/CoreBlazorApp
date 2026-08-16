//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class ErrorStatusDto : IErrorStatus
{
	public ErrorStatusDto(IErrorStatus values)
	{
		values?.MapTo(this);
	}

	public ErrorStatusDto()
	{ }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2000)]
	public string AdditionalDescription { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string Description { get; set; }

	public int ErrorStatusRef { get; set; }

	public short IsActiveFlag { get; set; }
}