using CsvHelper.Configuration.Attributes;
using System;

namespace EmployeeData.Common.Models;

public class CandidateExcelModel
{
	[Index(0)]
	public string AcceptDate { get; set; }

	[Index(1)]
	public string ActiveInactive { get; set; }

	[Index(2)]
	public string ActualStartDate { get; set; }

	[Index(3)]
	public string ApplicationCreatedBy { get; set; }

	[Index(5)]
	public string ApplicationDeleteBy { get; set; }

	[Index(4)]
	public string ApplicationDeleted { get; set; }

	[Index(6)]
	public string ApplicationDeleteDate { get; set; }

	[Index(7)]
	public string ApplicationID { get; set; }

	[Index(8)]
	public string ApplicationInternalExternal { get; set; }

	[Index(9)]
	public string ApplicationKey { get; set; }

	[Index(10)]
	public string CandidateActiveInactive { get; set; }

	[Index(11)]
	public string CandidateOpportunityKey { get; set; }

	[Index(12)]
	public string CandidateSourceKey { get; set; }

	[Index(13)]
	public string City { get; set; }

	[Index(14)]
	public string CountryCode { get; set; }

	[Index(15)]
	public string DateAchieved { get; set; }

	[Index(16)]
	public string DateApplied { get; set; }

	[Index(17)]
	public string DaysBetweenAcceptAndOfferDates { get; set; }

	[Index(18)]
	public string DaysBetweenAcceptAndStartDates { get; set; }

	[Index(19)]
	public string DaysBetweenHireAndPublishDates { get; set; }

	[Index(20)]
	public string DaysBetweenOfferAndStartDates { get; set; }

	[Index(21)]
	public string DaysBetweenStartAndPublishDates { get; set; }

	[Index(22)]
	public string Description { get; set; }

	[Index(23)]
	public string DispositionNoteKey { get; set; }

	[Index(24)]
	public string DispositionReasonKey { get; set; }

	[Index(25)]
	public string DispositionStatusKey { get; set; }

	[Index(26)]
	public string EmployeeType { get; set; }

	[Index(27)]
	public string FromMonth { get; set; }

	[Index(28)]
	public string FromStep { get; set; }

	[Index(29)]
	public string FromYear { get; set; }

	[Index(30)]
	public string FTE { get; set; }

	[Index(31)]
	public string HireDate { get; set; }

	[Index(32)]
	public string HiringManagerEmailAddress { get; set; }

	[Index(33)]
	public string Important { get; set; }

	[Index(34)]
	public string InternalExternal { get; set; }

	[Index(35)]
	public string LevelOfEducationDegree { get; set; }

	[Index(36)]
	public string LicenseCertificationName { get; set; }

	[Index(37)]
	public string Major { get; set; }

	[Index(38)]
	public string Minor { get; set; }

	[Index(39)]
	public string OfferDate { get; set; }

	[Index(40)]
	public string OpportunityKey { get; set; }

	[Index(41)]
	public string OpportunityTitle { get; set; }

	[Index(42)]
	public string ProcessStepKey { get; set; }

	[Index(43)]
	public string ProfileCreatedKey { get; set; }

	[Index(44)]
	public string Reason { get; set; }

	[Index(45)]
	public string RecruitingHireDate { get; set; }

	[Index(46)]
	public string RequisitionNumber { get; set; }

	[Index(47)]
	public string SalaryType { get; set; }

	[Index(48)]
	public string SchoolName { get; set; }

	[Index(49)]
	public string Source { get; set; }

	[Index(50)]
	public string StartDate { get; set; }

	[Index(51)]
	public string StateProvinceCode { get; set; }

	[Index(52)]
	public string Status { get; set; }

	[Index(53)]
	public string StatusCode { get; set; }

	[Index(54)]
	public string Step { get; set; }

	[Index(55)]
	public string StepChangeDateTime { get; set; }

	[Index(56)]
	public string StepDate { get; set; }

	[Index(57)]
	public string ToMonth { get; set; }

	[Index(58)]
	public string ToStep { get; set; }

	[Index(59)]
	public string ToYear { get; set; }

	[Index(60)]
	public string WillingToRelocate { get; set; }

	[Index(61)]
	public string YearsInSchool { get; set; }
}