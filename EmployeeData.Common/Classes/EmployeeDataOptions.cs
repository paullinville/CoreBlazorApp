using EmployeeData.Common.Models;
using System.Collections.Generic;

namespace EmployeeData.Common;

public class EmployeeDataOptions
{
	public List<Setting> OtherSettings { get; set; }
	public UKGConfiguration UKGConfiguration { get; set; }
	public int NonSystemCostCenter { get; set; }
	public string SpecialTypeCode { get; set; }
}

public class UKGConfiguration
{
	public List<ReportModel> Reports { get; set; }
}