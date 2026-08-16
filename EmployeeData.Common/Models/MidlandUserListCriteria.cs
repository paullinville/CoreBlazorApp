using System.Collections.Generic;

namespace EmployeeData.Common.Models;

public class MidlandUserListCriteria
{
	/// <summary>
	/// The list of userRefs that will be included regardless of status.
	/// </summary>
	public List<int> Include { get; set; }

	public bool? IncludeTerminated { get; set; }

	//Filter using contains
	public string Name { get; set; }
}