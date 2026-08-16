namespace Midland.Core.Common;

public interface IMidlandUser : IEmployee
{
	public const string ActiveValue = "A";
	public const string TerminatedValue = "T";

	public IEmployee GetEmployee()
	{
		return new Employee(this);
	}

	public IEmployeeSimple GetEmployeeSimple()
	{
		return new EmployeeSimple(this);
	}

	bool DigitalCertIsActive { get; set; }
	bool DisplayBirthDate { get; set; }
	bool DisplayedHomeNumber { get; set; }
	bool DisplayHireDate { get; set; }
	bool DisplayMobileNumber { get; set; }
	bool IsHuman { get; set; }
	DateTime? BirthDate { get; set; }
	DateTime? CustomTerminationDate { get; set; }
	DateTime? DigitalCertificateDateIssued { get; set; }
	DateTime? HireDate { get; set; }
	DateTime? TeamEffectiveDate { get; set; }
	DateTime? TerminationDate { get; set; }
	decimal? TeamId { get; set; }
	int? ManagerEmployeeId { get; set; }
	int? RankRef { get; set; }
	string AlternateLocation { get; set; }
	string CustomTerminationReason { get; set; }
	string EmployeeTypeCode { get; set; }
	string ExternalNumber { get; set; }
	string FullNameTermDate { get; set; }
	string HomeNumber { get; set; }
	string MobileNumber { get; set; }
	string PagerNumber { get; set; }
	string PayClass { get; set; }
	string PayGroupName { get; set; }
	string RankName { get; set; }
	string ScheduleTypeCode { get; set; }
	string TeamName { get; set; }

	public static void Map(IMidlandUser fromData, IMidlandUser toData)
	{
		if (fromData == null || toData == null) return;
		toData.AlternateLocation = fromData.AlternateLocation;
		toData.BirthDate = fromData.BirthDate;
		toData.CostCenterCode = fromData.CostCenterCode;
		toData.CostCenterName = fromData.CostCenterName;
		toData.CostCenterNumber = fromData.CostCenterNumber;
		toData.CostCenterRef = fromData.CostCenterRef;
		toData.CustomTerminationDate = fromData.CustomTerminationDate;
		toData.CustomTerminationReason = fromData.CustomTerminationReason;
		toData.DepartmentCode = fromData.DepartmentCode;
		toData.DepartmentName = fromData.DepartmentName;
		toData.DepartmentRef = fromData.DepartmentRef;
		toData.DigitalCertificateDateIssued = fromData.DigitalCertificateDateIssued;
		toData.DigitalCertIsActive = fromData.DigitalCertIsActive;
		toData.DisplayBirthDate = fromData.DisplayBirthDate;
		toData.DisplayedHomeNumber = fromData.DisplayedHomeNumber;
		toData.DisplayHireDate = fromData.DisplayHireDate;
		toData.DisplayMobileNumber = fromData.DisplayMobileNumber;
		toData.DivisionCode = fromData.DivisionCode;
		toData.DivisionName = fromData.DivisionName;
		toData.DivisionRef = fromData.DivisionRef;
		toData.Email = fromData.Email;
		toData.EmployeeId = fromData.EmployeeId;
		toData.EmployeeTypeCode = fromData.EmployeeTypeCode + "";
		toData.ExternalNumber = fromData.ExternalNumber;
		toData.FaxNumber = fromData.FaxNumber;
		toData.FirstName = fromData.FirstName;
		toData.FullName = fromData.FullName;
		toData.FullNameTermDate = fromData.FullNameTermDate + "";
		toData.HireDate = fromData.HireDate;
		toData.HomeNumber = fromData.HomeNumber;
		toData.IsHuman = fromData.IsHuman;
		toData.LastName = fromData.LastName;
		toData.LastNameFirst = fromData.LastNameFirst;
		toData.LastNameFirstTermDate = fromData.LastNameFirstTermDate + "";
		toData.LocationCode = fromData.LocationCode;
		toData.LocationName = fromData.LocationName;
		toData.ManagerEmployeeId = fromData.ManagerEmployeeId;
		toData.ManagerName = fromData.ManagerName;
		toData.ManagerUserRef = fromData.ManagerUserRef;
		toData.MobileNumber = fromData.MobileNumber;
		toData.PagerNumber = fromData.PagerNumber;
		toData.PayClass = fromData.PayClass;
		toData.PayGroupName = fromData.PayGroupName;
		toData.PhoneNumber = fromData.PhoneNumber;
		toData.RankName = fromData.RankName;
		toData.RankRef = fromData.RankRef;
		toData.ScheduleTypeCode = fromData.ScheduleTypeCode + "";
		toData.Status = fromData.Status;
		toData.TeamEffectiveDate = fromData.TeamEffectiveDate;
		toData.TeamId = fromData.TeamId;
		toData.TeamName = fromData.TeamName;
		toData.TerminationDate = fromData.TerminationDate;
		toData.Title = fromData.Title;
		toData.UserId = fromData.UserId;
		toData.UserRef = fromData.UserRef;
	}

	public void MapFrom(IMidlandUser fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IMidlandUser toData)
	{
		Map(this, toData);
	}
}