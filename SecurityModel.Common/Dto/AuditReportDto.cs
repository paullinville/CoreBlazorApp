using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class AuditReportDto : IAuditReport
{
	public AuditReportDto(IAuditReport values)
	{
		values?.MapTo(this);
	}

	public AuditReportDto()
	{ }

	public int ApplicationRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime AuditCreateDate { get; set; }

	[StringLength(2147483647)]
	public string AuditDescription { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string AuditDetail { get; set; }

	public int AuditRef { get; set; }

	public int UserRef { get; set; }
}