using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ApplicationReportBase : IApplicationReportBase
{
	[Range(1, int.MaxValue)]
	public int ApplicationRef { get; set; }
}