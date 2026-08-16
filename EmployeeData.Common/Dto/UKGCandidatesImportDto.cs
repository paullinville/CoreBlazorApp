namespace EmployeeData.Common.Dto;

public class UKGCandidatesImportDto : IUKGCandidatesImport
{
	public UKGCandidatesImportDto(IUKGCandidatesImport values)
	{
		values?.MapTo(this);
	}

	public UKGCandidatesImportDto()
	{ }

	public string AcceptDate { get; set; }

	public string ActiveInactive { get; set; }

	public string ActualStartDate { get; set; }

	public string ApplicationCreatedBy { get; set; }

	public string ApplicationDeleteBy { get; set; }

	public string ApplicationDeleted { get; set; }
	public string ApplicationDeleteDate { get; set; }
	public string ApplicationID { get; set; }

	public string ApplicationInternalExternal { get; set; }

	public string ApplicationKey { get; set; }

	public string CandidateActiveInactive { get; set; }

	public string CandidateOpportunityKey { get; set; }

	public string CandidateSourceKey { get; set; }

	public string City { get; set; }

	public string CountryCode { get; set; }

	public string DateAchieved { get; set; }

	public string DateApplied { get; set; }

	public string DaysBetweenAcceptAndOfferDates { get; set; }

	public string DaysBetweenAcceptAndStartDates { get; set; }

	public string DaysBetweenHireAndPublishDates { get; set; }

	public string DaysBetweenOfferAndStartDates { get; set; }

	public string DaysBetweenStartAndPublishDates { get; set; }

	public string Description { get; set; }

	public string DispositionNoteKey { get; set; }

	public string DispositionReasonKey { get; set; }

	public string DispositionStatusKey { get; set; }

	public string EmployeeType { get; set; }

	public string FromMonth { get; set; }

	public string FromStep { get; set; }

	public string FromYear { get; set; }

	public string FTE { get; set; }

	public string HireDate { get; set; }

	public string HiringManagerEmailAddress { get; set; }

	public string Important { get; set; }

	public string InternalExternal { get; set; }

	public string LevelOfEducationDegree { get; set; }

	public string LicenseCertificationName { get; set; }

	public string Major { get; set; }

	public string Minor { get; set; }

	public string OfferDate { get; set; }

	public string OpportunityKey { get; set; }

	public string OpportunityTitle { get; set; }

	public string ProcessStepKey { get; set; }

	public string ProfileCreatedKey { get; set; }

	public string Reason { get; set; }

	public string RecruitingHireDate { get; set; }

	public string RequisitionNumber { get; set; }

	public string SalaryType { get; set; }

	public string SchoolName { get; set; }

	public string Source { get; set; }

	public string StartDate { get; set; }

	public string StateProvinceCode { get; set; }

	public string Status { get; set; }

	public string StatusCode { get; set; }

	public string Step { get; set; }

	public string StepChangeDateTime { get; set; }

	public string StepDate { get; set; }

	public string ToMonth { get; set; }

	public string ToStep { get; set; }

	public string ToYear { get; set; }

	public int UKGCandidatesImportRef { get; set; }

	public string WillingToRelocate { get; set; }

	public string YearsInSchool { get; set; }
}