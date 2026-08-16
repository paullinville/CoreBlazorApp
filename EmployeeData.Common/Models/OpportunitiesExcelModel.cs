using CsvHelper.Configuration.Attributes;
using System;

namespace EmployeeData.Common.Models;

public class OpportunitiesExcelModel
{
	[Index(0)]
	public string ApprovalStatus { get; set; }

	[Index(1)]
	public string ApprovalStatusDate { get; set; }

	[Index(2)]
	public string BudgetedFTE { get; set; }

	[Index(3)]
	public string City { get; set; }

	[Index(4)]
	public string ClosedDate { get; set; }

	[Index(5)]
	public string ClosingReasonName { get; set; }

	[Index(6)]
	public string Comment { get; set; }

	[Index(7)]
	public string CompanyCode { get; set; }

	[Index(8)]
	public string ContinuousOpening { get; set; }

	[Index(9)]
	public string CountryCode { get; set; }

	[Index(10)]
	public string CreatedDate { get; set; }

	[Index(11)]
	public string CurrentProcessStepKey { get; set; }

	[Index(12)]
	public string DaysBetweenAcceptAndOfferDates { get; set; }

	[Index(13)]
	public string Degree { get; set; }

	[Index(14)]
	public string Deleted { get; set; }

	[Index(15)]
	public string DeletedByKey { get; set; }

	[Index(16)]
	public string DeletedDate { get; set; }

	[Index(17)]
	public string DispositionNoteKey { get; set; }

	[Index(18)]
	public string DispositionReasonKey { get; set; }

	[Index(19)]
	public string DispositionStatusKey { get; set; }

	[Index(20)]
	public string EducationRequired { get; set; }

	[Index(21)]
	public string Featured { get; set; }

	[Index(22)]
	public string FilledFTE { get; set; }

	[Index(23)]
	public string FirstPublishedDate { get; set; }

	[Index(24)]
	public string FullTimePartTime { get; set; }

	[Index(25)]
	public string HiredHeadcount { get; set; }

	[Index(26)]
	public string HiringManager { get; set; }

	[Index(27)]
	public string HoursPerShift { get; set; }

	[Index(28)]
	public string HoursPerWeek { get; set; }

	[Index(29)]
	public string ImpactToStaffingPlan { get; set; }

	[Index(30)]
	public string IsOpeningBudgeted { get; set; }

	[Index(31)]
	public string JobFamily { get; set; }

	[Index(32)]
	public string JobKey { get; set; }

	[Index(33)]
	public string LastDayWorked { get; set; }

	[Index(34)]
	public string LicenseCertification { get; set; }

	[Index(35)]
	public string LicensesCertificationsRequired { get; set; }

	[Index(36)]
	public string LocationName { get; set; }

	[Index(37)]
	public string Major { get; set; }

	[Index(38)]
	public string MaximumHeadcount { get; set; }

	[Index(40)]
	public string MaximumYears { get; set; }

	[Index(39)]
	public string MinimumYears { get; set; }

	[Index(41)]
	public string OpportunityCandidateKey { get; set; }

	[Index(42)]
	public string OpportunityID { get; set; }

	[Index(43)]
	public string OpportunityIDRecruiting { get; set; }

	[Index(44)]
	public string OpportunityKey { get; set; }

	[Index(45)]
	public string OpportunityStatus { get; set; }

	[Index(46)]
	public string OpportunityTitle { get; set; }

	[Index(47)]
	public string OrgLevel1 { get; set; }

	[Index(48)]
	public string OrgLevel3 { get; set; }

	[Index(49)]
	public string OrgLevel4 { get; set; }

	[Index(50)]
	public string Priority { get; set; }

	[Index(51)]
	public string ProcessKey { get; set; }

	[Index(52)]
	public string ReasonForOpening { get; set; }

	[Index(53)]
	public string Related { get; set; }

	[Index(54)]
	public string RemainingFTE { get; set; }

	[Index(55)]
	public string RemainingHeadcount { get; set; }

	[Index(56)]
	public string RequisitionNumber { get; set; }

	[Index(57)]
	public string SalaryHourly { get; set; }

	[Index(58)]
	public string ShortDescription { get; set; }

	[Index(59)]
	public string SourceJob { get; set; }

	[Index(60)]
	public string SourceJobCode { get; set; }

	[Index(61)]
	public string StateProvinceCode { get; set; }

	[Index(62)]
	public string Supervisor { get; set; }

	[Index(63)]
	public string SupervisorVisibility { get; set; }

	[Index(64)]
	public string TargetStartDate { get; set; }

	[Index(65)]
	public string TravelDetails { get; set; }

	[Index(66)]
	public string TravelRequired { get; set; }

	[Index(67)]
	public string WorkDescription { get; set; }

	[Index(68)]
	public string WorkExperienceRequired { get; set; }

	[Index(69)]
	public string WorkLocationKey { get; set; }
}