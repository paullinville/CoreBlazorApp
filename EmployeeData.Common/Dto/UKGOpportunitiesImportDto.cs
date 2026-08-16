namespace EmployeeData.Common.Dto;

public class UKGOpportunitiesImportDto : IUKGOpportunitiesImport
{
	public UKGOpportunitiesImportDto(IUKGOpportunitiesImport values)
	{
		values?.MapTo(this);
	}

	public UKGOpportunitiesImportDto()
	{ }

	public string ApprovalStatus { get; set; }

	public string ApprovalStatusDate { get; set; }

	public string BudgetedFTE { get; set; }

	public string City { get; set; }

	public string ClosedDate { get; set; }

	public string ClosingReasonName { get; set; }

	public string Comment { get; set; }

	public string CompanyCode { get; set; }

	public string ContinuousOpening { get; set; }

	public string CountryCode { get; set; }

	public string CreatedDate { get; set; }

	public string CurrentProcessStepKey { get; set; }

	public string DaysBetweenAcceptAndOfferDates { get; set; }

	public string Degree { get; set; }

	public string Deleted { get; set; }

	public string DeletedByKey { get; set; }

	public string DeletedDate { get; set; }

	public string DispositionNoteKey { get; set; }

	public string DispositionReasonKey { get; set; }

	public string DispositionStatusKey { get; set; }

	public string EducationRequired { get; set; }

	public string Featured { get; set; }

	public string FilledFTE { get; set; }

	public string FirstPublishedDate { get; set; }

	public string FullTimePartTime { get; set; }

	public string HiredHeadcount { get; set; }

	public string HiringManager { get; set; }

	public string HoursPerShift { get; set; }

	public string HoursPerWeek { get; set; }

	public string ImpactToStaffingPlan { get; set; }

	public string IsOpeningBudgeted { get; set; }

	public string JobFamily { get; set; }

	public string JobKey { get; set; }

	public string LastDayWorked { get; set; }

	public string LicenseCertification { get; set; }

	public string LicensesAndCertificationsRequired { get; set; }

	public string LocationName { get; set; }

	public string Major { get; set; }

	public string MaximumHeadcount { get; set; }

	public string MaximumYears { get; set; }

	public string MinimumYears { get; set; }

	public string OpportunityCandidateKey { get; set; }

	public string OpportunityID { get; set; }

	public string OpportunityKey { get; set; }

	public string OpportunityStatus { get; set; }

	public string OpportunityTitle { get; set; }

	public string OrgLevel1 { get; set; }

	public string OrgLevel3 { get; set; }

	public string OrgLevel4 { get; set; }

	public string Priority { get; set; }

	public string ProcessKey { get; set; }

	public string ReasonForOpening { get; set; }

	public string Related { get; set; }

	public string RemainingFTE { get; set; }

	public string RemainingHeadcount { get; set; }

	public string RequisitionNumber { get; set; }

	public string SalaryHourly { get; set; }

	public string ShortDescription { get; set; }

	public string SourceJob { get; set; }

	public string SourceJobCode { get; set; }

	public string StateProvinceCode { get; set; }

	public string Supervisor { get; set; }

	public string SupervisorVisibility { get; set; }

	public string TargetStartDate { get; set; }

	public string TravelDetails { get; set; }

	public string TravelRequired { get; set; }

	public int UKGOpportunitiesImportRef { get; set; }

	public string WorkDescription { get; set; }

	public string WorkExperienceRequired { get; set; }

	public string WorkLocationKey { get; set; }
}