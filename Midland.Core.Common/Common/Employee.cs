using System.Text.Json.Serialization;

namespace Midland.Core.Common;

public class Employee : IEmployee
{
	[JsonConstructor]
	public Employee()
	{ }

	public Employee(IEmployee midlandUser)
	{
		if (midlandUser == null) return;
		UserRef = midlandUser.UserRef;
		EmployeeId = midlandUser.EmployeeId;
		FirstName = midlandUser.FirstName;
		LastName = midlandUser.LastName;
		FullName = midlandUser.FullName;
		DepartmentName = midlandUser.DepartmentName;
		DepartmentCode = midlandUser.DepartmentCode;
		DepartmentRef = midlandUser.DepartmentRef;
		LocationName = midlandUser.LocationName;
		CostCenterNumber = midlandUser.CostCenterNumber;
		Status = midlandUser.Status;
		Title = midlandUser.Title;
		ManagerName = midlandUser.ManagerName;
		PhoneNumber = midlandUser.PhoneNumber;
		Email = midlandUser.Email;
		LastNameFirst = midlandUser.LastNameFirst;
		LastNameFirstTermDate = midlandUser.LastNameFirstTermDate;
		ManagerUserRef = midlandUser.ManagerUserRef;
		DivisionName = midlandUser.DivisionName;
		DivisionCode = midlandUser.DivisionCode;
		DivisionRef = midlandUser.DivisionRef;
		CostCenterName = midlandUser.CostCenterName;
		CostCenterCode = midlandUser.CostCenterCode;
		CostCenterRef = midlandUser.CostCenterRef;
		LocationCode = midlandUser.LocationCode;
		UserId = midlandUser.UserId;
		FaxNumber = midlandUser.FaxNumber;
	}

	public string PhoneNumber { get; set; }
	public string Status { get; set; }
	public int? CostCenterNumber { get; set; }
	public string CostCenterCode { get; set; }
	public string CostCenterName { get; set; }
	public int? CostCenterRef { get; set; }
	public string DepartmentCode { get; set; }
	public string DepartmentName { get; set; }
	public int? DepartmentRef { get; set; }
	public string DivisionCode { get; set; }
	public string DivisionName { get; set; }
	public int? DivisionRef { get; set; }
	public string Email { get; set; }
	public int? EmployeeId { get; set; }
	public string FaxNumber { get; set; }
	public string FirstName { get; set; }
	public string FullName { get; set; }
	public string LastName { get; set; }
	public string LastNameFirst { get; set; }
	public string LastNameFirstTermDate { get; set; }
	public string LocationCode { get; set; }
	public string LocationName { get; set; }
	public string ManagerName { get; set; }
	public int? ManagerUserRef { get; set; }
	public string Title { get; set; }
	public string UserId { get; set; }
	public int UserRef { get; set; }
}