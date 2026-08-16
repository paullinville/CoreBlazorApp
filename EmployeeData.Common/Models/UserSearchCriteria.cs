using System.Collections.Generic;

namespace EmployeeData.Common.Models;

public class UserSearchCriteria : IUserSearchCriteria
{
	public string Name { get; set; }

	public List<string> Statuses { get; set; }

	public bool? IncludeNonHuman { get; set; }

	/// <summary>
	/// List of cost center refs the user is assigned to.
	/// </summary>
	public List<int> CostCenters { get; set; }

	/// <summary>
	/// The Employee Ids
	/// </summary>
	public List<int> EmployeeIds { get; set; }

	/// <summary>
	/// Windows user names.
	/// </summary>
	public List<string> UserIds { get; set; }

	public List<int> Divisions { get; set; }

	public List<int> Departments { get; set; }

	/// <summary>
	/// The UserRef of the manager.
	/// </summary>
	public List<int> Managers { get; set; }

	public List<int> Companies { get; set; }

	public List<string> LocationCodes { get; set; }
}