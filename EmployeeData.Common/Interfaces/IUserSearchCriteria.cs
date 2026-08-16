using System.Collections.Generic;

namespace EmployeeData.Common.Interfaces;

public interface IUserSearchCriteria
{
	List<int> Companies { get; set; }
	List<int> CostCenters { get; set; }
	List<int> Departments { get; set; }
	List<int> Divisions { get; set; }
	List<int> EmployeeIds { get; set; }
	bool? IncludeNonHuman { get; set; }
	List<string> LocationCodes { get; set; }
	List<int> Managers { get; set; }
	string Name { get; set; }
	List<string> Statuses { get; set; }
	List<string> UserIds { get; set; }
}