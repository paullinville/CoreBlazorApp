using System;

namespace SecurityModel.Common.Models;

public class AuditReportCriteria : ApplicationReportBase
{
	public DateTime? EndDate { get; set; }
	public string Keyword { get; set; }
	public DateTime? StartDate { get; set; }
	public int? UserRef { get; set; }
}