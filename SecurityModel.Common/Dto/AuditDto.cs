using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class AuditDto : IAudit
{
	public AuditDto(IAudit values)
	{
		values?.MapTo(this);
	}

	public AuditDto()
	{ }

	public int ApplicationRef { get; set; }

	public int AuditRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime CreateDate { get; set; }

	[StringLength(2147483647)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string Detail { get; set; }

	public int UserRef { get; set; }
}