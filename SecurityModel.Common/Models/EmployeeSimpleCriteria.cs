namespace SecurityModel.Common.Models;

public class EmployeeSimpleCriteria : SortAndIncludeFilter
{
	public EmployeeSimpleCriteria()
	{
		IncludeField = nameof(IEmployeeSimple.UserRef);
		DefaultSortField = nameof(IEmployeeSimple.LastNameFirst);
		SortByDir = "Asc";
	}

	[FilterProperty($"{nameof(IEmployeeSimple.CostCenterCode)}", Comparison = "")]
	public string CostCenterCode { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.CostCenterName)}", Comparison = "")]
	public string CostCenterName { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.DepartmentName)}", Comparison = "")]
	public string DepartmentName { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.DivisionName)}", Comparison = "")]
	public string DivisionName { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.Email)}", Comparison = "")]
	public string Email { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.FirstName)}", Comparison = "")]
	public string FirstName { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.FullName)}", Comparison = "")]
	public string FullName { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.LastName)}", Comparison = "")]
	public string LastName { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.LastNameFirst)}", Comparison = "")]
	public string LastNameFirst { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.LastNameFirstTermDate)}", Comparison = "")]
	public string LastNameFirstTermDate { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.PhoneNumber)}", Comparison = "")]
	public string PhoneNumber { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.Status)}", Comparison = "=")]
	public char? Status { get; set; }

	[FilterProperty($"{nameof(IEmployeeSimple.UserRef)}", Comparison = "")]
	public int? UserRef { get; set; }
}