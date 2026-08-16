using Midland.Core.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Midland.Core.User;

public class MidlandUser : IMidlandUser
{
	public MidlandUser(IMidlandUser values)
	{
		values?.MapTo(this);
	}

	public MidlandUser()
	{ }

	[StringLength(250)]
	public string AlternateLocation { get; set; }

	public DateTime? BirthDate { get; set; }

	public int? CostCenterNumber { get; set; }

	[StringLength(50)]
	public string CostCenterCode { get; set; }

	[StringLength(250)]
	public string CostCenterName { get; set; }

	public int? CostCenterRef { get; set; }

	public DateTime? CustomTerminationDate { get; set; }

	[StringLength(250)]
	public string CustomTerminationReason { get; set; }

	[StringLength(50)]
	public string DepartmentCode { get; set; }

	[StringLength(250)]
	public string DepartmentName { get; set; }

	public int? DepartmentRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime? DigitalCertificateDateIssued { get; set; }

	public bool DigitalCertIsActive { get; set; }

	public bool DisplayBirthDate { get; set; }

	public bool DisplayedHomeNumber { get; set; }

	public bool DisplayHireDate { get; set; }
	public bool DisplayMobileNumber { get; set; }

	[StringLength(50)]
	public string DivisionCode { get; set; }

	[StringLength(250)]
	public string DivisionName { get; set; }

	public int? DivisionRef { get; set; }

	[StringLength(50)]
	public string Email { get; set; }

	public int? EmployeeId { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(10)]
	public string EmployeeTypeCode { get; set; }

	[StringLength(20)]
	public string ExternalNumber { get; set; }

	[StringLength(20)]
	public string FaxNumber { get; set; }

	[StringLength(30)]
	public string FirstName { get; set; }

	[StringLength(100)]
	public string FullName { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(100)]
	public string FullNameTermDate { get; set; }

	public DateTime? HireDate { get; set; }

	[StringLength(20)]
	public string HomeNumber { get; set; }

	public bool IsHuman { get; set; }

	[StringLength(45)]
	public string LastName { get; set; }

	[StringLength(100)]
	public string LastNameFirst { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(100)]
	public string LastNameFirstTermDate { get; set; }

	[StringLength(50)]
	public string LocationCode { get; set; }

	[StringLength(250)]
	public string LocationName { get; set; }

	public int? ManagerEmployeeId { get; set; }

	[StringLength(100)]
	public string ManagerName { get; set; }

	public int? ManagerUserRef { get; set; }

	[StringLength(20)]
	public string MobileNumber { get; set; }

	[StringLength(20)]
	public string PagerNumber { get; set; }

	[StringLength(50)]
	public string PayClass { get; set; }

	[StringLength(50)]
	public string PayGroupName { get; set; }

	[StringLength(20)]
	public string PhoneNumber { get; set; }

	[StringLength(250)]
	public string RankName { get; set; }

	public int? RankRef { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(10)]
	public string ScheduleTypeCode { get; set; }

	[StringLength(1)]
	public string Status { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime? TeamEffectiveDate { get; set; }

	public decimal? TeamId { get; set; }

	[StringLength(60)]
	public string TeamName { get; set; }

	public DateTime? TerminationDate { get; set; }

	[StringLength(250)]
	public string Title { get; set; }

	[StringLength(15)]
	public string UserId { get; set; }

	public int UserRef { get; set; }
}