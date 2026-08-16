using System;

namespace SecurityModel.Common.Models;

public class AuditReport
{
	public string ResponsibleUser { get; set; }
	public string ActionDescription { get; set; }
	public DateTime Date { get; set; }
}