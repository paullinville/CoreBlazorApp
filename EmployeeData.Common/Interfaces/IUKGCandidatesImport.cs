namespace EmployeeData.Common.Interfaces;

public interface IUKGCandidatesImport
{
	string AcceptDate { get; set; }
	string ActiveInactive { get; set; }
	string ActualStartDate { get; set; }
	string ApplicationCreatedBy { get; set; }
	string ApplicationDeleteBy { get; set; }
	string ApplicationDeleted { get; set; }
	string ApplicationDeleteDate { get; set; }
	string ApplicationID { get; set; }
	string ApplicationInternalExternal { get; set; }
	string ApplicationKey { get; set; }
	string CandidateActiveInactive { get; set; }
	string CandidateOpportunityKey { get; set; }
	string CandidateSourceKey { get; set; }
	string City { get; set; }
	string CountryCode { get; set; }
	string DateAchieved { get; set; }
	string DateApplied { get; set; }
	string DaysBetweenAcceptAndOfferDates { get; set; }
	string DaysBetweenAcceptAndStartDates { get; set; }
	string DaysBetweenHireAndPublishDates { get; set; }
	string DaysBetweenOfferAndStartDates { get; set; }
	string DaysBetweenStartAndPublishDates { get; set; }
	string Description { get; set; }
	string DispositionNoteKey { get; set; }
	string DispositionReasonKey { get; set; }
	string DispositionStatusKey { get; set; }
	string EmployeeType { get; set; }
	string FromMonth { get; set; }
	string FromStep { get; set; }
	string FromYear { get; set; }
	string FTE { get; set; }
	string HireDate { get; set; }
	string HiringManagerEmailAddress { get; set; }
	string Important { get; set; }
	string InternalExternal { get; set; }
	string LevelOfEducationDegree { get; set; }
	string LicenseCertificationName { get; set; }
	string Major { get; set; }
	string Minor { get; set; }
	string OfferDate { get; set; }
	string OpportunityKey { get; set; }
	string OpportunityTitle { get; set; }
	string ProcessStepKey { get; set; }
	string ProfileCreatedKey { get; set; }
	string Reason { get; set; }
	string RecruitingHireDate { get; set; }
	string RequisitionNumber { get; set; }
	string SalaryType { get; set; }
	string SchoolName { get; set; }
	string Source { get; set; }
	string StartDate { get; set; }
	string StateProvinceCode { get; set; }
	string Status { get; set; }
	string StatusCode { get; set; }
	string Step { get; set; }
	string StepChangeDateTime { get; set; }
	string StepDate { get; set; }
	string ToMonth { get; set; }
	string ToStep { get; set; }
	string ToYear { get; set; }
	int UKGCandidatesImportRef { get; set; }
	string WillingToRelocate { get; set; }
	string YearsInSchool { get; set; }

	public static void Map(IUKGCandidatesImport fromData, IUKGCandidatesImport toData)
	{
		if (fromData == null || toData == null) return;
		toData.AcceptDate = fromData.AcceptDate;
		toData.ActiveInactive = fromData.ActiveInactive;
		toData.ActualStartDate = fromData.ActualStartDate;
		toData.ApplicationCreatedBy = fromData.ApplicationCreatedBy;
		toData.ApplicationDeleteBy = fromData.ApplicationDeleteBy;
		toData.ApplicationDeleteDate = fromData.ApplicationDeleteDate;
		toData.ApplicationDeleted = fromData.ApplicationDeleted;
		toData.ApplicationID = fromData.ApplicationID;
		toData.ApplicationInternalExternal = fromData.ApplicationInternalExternal;
		toData.ApplicationKey = fromData.ApplicationKey;
		toData.CandidateActiveInactive = fromData.CandidateActiveInactive;
		toData.CandidateOpportunityKey = fromData.CandidateOpportunityKey;
		toData.CandidateSourceKey = fromData.CandidateSourceKey;
		toData.City = fromData.City;
		toData.CountryCode = fromData.CountryCode;
		toData.DateAchieved = fromData.DateAchieved;
		toData.DateApplied = fromData.DateApplied;
		toData.DaysBetweenAcceptAndOfferDates = fromData.DaysBetweenAcceptAndOfferDates;
		toData.DaysBetweenAcceptAndStartDates = fromData.DaysBetweenAcceptAndStartDates;
		toData.DaysBetweenHireAndPublishDates = fromData.DaysBetweenHireAndPublishDates;
		toData.DaysBetweenOfferAndStartDates = fromData.DaysBetweenOfferAndStartDates;
		toData.DaysBetweenStartAndPublishDates = fromData.DaysBetweenStartAndPublishDates;
		toData.Description = fromData.Description;
		toData.DispositionNoteKey = fromData.DispositionNoteKey;
		toData.DispositionReasonKey = fromData.DispositionReasonKey;
		toData.DispositionStatusKey = fromData.DispositionStatusKey;
		toData.EmployeeType = fromData.EmployeeType;
		toData.FromMonth = fromData.FromMonth;
		toData.FromStep = fromData.FromStep;
		toData.FromYear = fromData.FromYear;
		toData.FTE = fromData.FTE;
		toData.HireDate = fromData.HireDate;
		toData.HiringManagerEmailAddress = fromData.HiringManagerEmailAddress;
		toData.Important = fromData.Important;
		toData.InternalExternal = fromData.InternalExternal;
		toData.LevelOfEducationDegree = fromData.LevelOfEducationDegree;
		toData.LicenseCertificationName = fromData.LicenseCertificationName;
		toData.Major = fromData.Major;
		toData.Minor = fromData.Minor;
		toData.OfferDate = fromData.OfferDate;
		toData.OpportunityKey = fromData.OpportunityKey;
		toData.OpportunityTitle = fromData.OpportunityTitle;
		toData.ProcessStepKey = fromData.ProcessStepKey;
		toData.ProfileCreatedKey = fromData.ProfileCreatedKey;
		toData.Reason = fromData.Reason;
		toData.RecruitingHireDate = fromData.RecruitingHireDate;
		toData.RequisitionNumber = fromData.RequisitionNumber;
		toData.SalaryType = fromData.SalaryType;
		toData.SchoolName = fromData.SchoolName;
		toData.Source = fromData.Source;
		toData.StartDate = fromData.StartDate;
		toData.StateProvinceCode = fromData.StateProvinceCode;
		toData.Status = fromData.Status;
		toData.StatusCode = fromData.StatusCode;
		toData.Step = fromData.Step;
		toData.StepChangeDateTime = fromData.StepChangeDateTime;
		toData.StepDate = fromData.StepDate;
		toData.ToMonth = fromData.ToMonth;
		toData.ToStep = fromData.ToStep;
		toData.ToYear = fromData.ToYear;
		toData.UKGCandidatesImportRef = fromData.UKGCandidatesImportRef;
		toData.WillingToRelocate = fromData.WillingToRelocate;
		toData.YearsInSchool = fromData.YearsInSchool;
	}

	public void MapFrom(IUKGCandidatesImport fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IUKGCandidatesImport toData)
	{
		Map(this, toData);
	}
}