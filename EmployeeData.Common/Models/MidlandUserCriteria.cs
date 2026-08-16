using Midland.Core.Common;
using System;
using System.Collections.Generic;

namespace EmployeeData.Common.Models;

public partial class MidlandUserCriteria : BasicSortedIncludePageRequest
{
	public MidlandUserCriteria()
	{
		SortBy = nameof(MidlandUserCriteria.LastNameFirst);
		DefaultIncludeField = nameof(MidlandUserCriteria.UserRef);
	}

	[FilterProperty($"{nameof(IMidlandUser.CostCenterCode)}", Comparison = "")]
	public List<string> CostCenterCode { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.CostCenterNumber)}", Comparison = "")]
	public List<int> CostCenterNumber { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.CostCenterRef)}", Comparison = "")]
	public List<int> CostCenterRef { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.DepartmentCode)}", Comparison = "", Group = 1)]
	public List<string> DepartmentCode { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.DepartmentName)}", Comparison = "")]
	public List<string> DepartmentName { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.DepartmentRef)}", Comparison = "")]
	public List<int> DepartmentRef { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.DivisionCode)}", Comparison = "")]
	public List<string> DivisionCode { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.DivisionName)}", Comparison = "")]
	public List<string> DivisionName { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.DivisionRef)}", Comparison = "")]
	public List<int> DivisionRef { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.Email)}", Comparison = "")]
	public string Email { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.EmployeeId)}", Comparison = "")]
	public int? EmployeeId { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.EmployeeTypeCode)}", Comparison = "")]
	public List<string> EmployeeTypeCode { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.FirstName)}", Comparison = "")]
	public string FirstName { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.HireDate)}", Comparison = "")]
	public DateTime? HireDate { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.IsHuman)}", Comparison = "")]
	public bool? IsHuman { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.LastName)}", Comparison = "")]
	public string LastName { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.LastNameFirst)}", Comparison = "")]
	public string LastNameFirst { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.LocationCode)}", Comparison = "")]
	public string LocationCode { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.LocationName)}", Comparison = "")]
	public string LocationName { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.ManagerEmployeeId)}", Comparison = "")]
	public int? ManagerEmployeeId { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.ManagerName)}", Comparison = "")]
	public string ManagerName { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.ManagerUserRef)}", Comparison = "")]
	public int? ManagerUserRef { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.Status)}", Comparison = "=")]
	public char? Status { get; set; } = 'A';

	[FilterProperty($"{nameof(IMidlandUser.TerminationDate)}", Comparison = "<=")]
	public DateTime? TerminationDateEnd { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.TerminationDate)}", Comparison = ">=")]
	public DateTime? TerminationDateStart { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.Title)}", Comparison = "=")]
	public string Title { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.UserId)}", Comparison = "=")]
	public string UserId { get; set; }

	[FilterProperty($"{nameof(IMidlandUser.UserRef)}", Comparison = "")]
	public List<int> UserRef { get; set; }
}