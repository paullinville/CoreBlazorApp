namespace Midland.Core.Common;

public class EmployeeSimple : IEmployeeSimple
{
	public EmployeeSimple()
	{ }

	public EmployeeSimple(IEmployeeSimple midlandUser)
	{
		if (midlandUser == null) return;

		Status = midlandUser.Status;
		UserRef = midlandUser.UserRef;
		DepartmentName = midlandUser.DepartmentName;
		CostCenterName = midlandUser.CostCenterName;
		CostCenterCode = midlandUser.CostCenterCode;
		Email = midlandUser.Email;
		DivisionName = midlandUser.DivisionName;
		FirstName = midlandUser.FirstName;
		LastName = midlandUser.LastName;
		LastNameFirst = midlandUser.LastNameFirst;
		LastNameFirstTermDate = midlandUser.LastNameFirstTermDate;
		FullName = midlandUser.FullName;
		PhoneNumber = midlandUser.PhoneNumber;
	}

	public int UserRef { get; set; }
	public string Status { get; set; }
	public string CostCenterCode { get; set; }
	public string CostCenterName { get; set; }
	public string DepartmentName { get; set; }
	public string DivisionName { get; set; }
	public string Email { get; set; }
	public string FirstName { get; set; }
	public string FullName { get; set; }
	public string LastName { get; set; }
	public string LastNameFirst { get; set; }
	public string LastNameFirstTermDate { get; set; }
	public string PhoneNumber { get; set; }
}