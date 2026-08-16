namespace EmployeeData.Common.Interfaces;

public interface IUKGOpportunitiesImport
{
	string ApprovalStatus { get; set; }
	string ApprovalStatusDate { get; set; }
	string BudgetedFTE { get; set; }
	string City { get; set; }
	string ClosedDate { get; set; }
	string ClosingReasonName { get; set; }
	string Comment { get; set; }
	string CompanyCode { get; set; }
	string ContinuousOpening { get; set; }
	string CountryCode { get; set; }
	string CreatedDate { get; set; }
	string CurrentProcessStepKey { get; set; }
	string DaysBetweenAcceptAndOfferDates { get; set; }
	string Degree { get; set; }
	string Deleted { get; set; }
	string DeletedByKey { get; set; }
	string DeletedDate { get; set; }
	string DispositionNoteKey { get; set; }
	string DispositionReasonKey { get; set; }
	string DispositionStatusKey { get; set; }
	string EducationRequired { get; set; }
	string Featured { get; set; }
	string FilledFTE { get; set; }
	string FirstPublishedDate { get; set; }
	string FullTimePartTime { get; set; }
	string HiredHeadcount { get; set; }
	string HiringManager { get; set; }
	string HoursPerShift { get; set; }
	string HoursPerWeek { get; set; }
	string ImpactToStaffingPlan { get; set; }
	string IsOpeningBudgeted { get; set; }
	string JobFamily { get; set; }
	string JobKey { get; set; }
	string LastDayWorked { get; set; }
	string LicenseCertification { get; set; }
	string LicensesAndCertificationsRequired { get; set; }
	string LocationName { get; set; }
	string Major { get; set; }
	string MaximumHeadcount { get; set; }
	string MaximumYears { get; set; }
	string MinimumYears { get; set; }
	string OpportunityCandidateKey { get; set; }
	string OpportunityID { get; set; }
	string OpportunityKey { get; set; }
	string OpportunityStatus { get; set; }
	string OpportunityTitle { get; set; }
	string OrgLevel1 { get; set; }
	string OrgLevel3 { get; set; }
	string OrgLevel4 { get; set; }
	string Priority { get; set; }
	string ProcessKey { get; set; }
	string ReasonForOpening { get; set; }
	string Related { get; set; }
	string RemainingFTE { get; set; }
	string RemainingHeadcount { get; set; }
	string RequisitionNumber { get; set; }
	string SalaryHourly { get; set; }
	string ShortDescription { get; set; }
	string SourceJob { get; set; }
	string SourceJobCode { get; set; }
	string StateProvinceCode { get; set; }
	string Supervisor { get; set; }
	string SupervisorVisibility { get; set; }
	string TargetStartDate { get; set; }
	string TravelDetails { get; set; }
	string TravelRequired { get; set; }
	int UKGOpportunitiesImportRef { get; set; }
	string WorkDescription { get; set; }
	string WorkExperienceRequired { get; set; }
	string WorkLocationKey { get; set; }

	public static void Map(IUKGOpportunitiesImport fromData, IUKGOpportunitiesImport toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApprovalStatus = fromData.ApprovalStatus;
		toData.ApprovalStatusDate = fromData.ApprovalStatusDate;
		toData.BudgetedFTE = fromData.BudgetedFTE;
		toData.City = fromData.City;
		toData.ClosedDate = fromData.ClosedDate;
		toData.ClosingReasonName = fromData.ClosingReasonName;
		toData.Comment = fromData.Comment;
		toData.CompanyCode = fromData.CompanyCode;
		toData.ContinuousOpening = fromData.ContinuousOpening;
		toData.CountryCode = fromData.CountryCode;
		toData.CreatedDate = fromData.CreatedDate;
		toData.CurrentProcessStepKey = fromData.CurrentProcessStepKey;
		toData.DaysBetweenAcceptAndOfferDates = fromData.DaysBetweenAcceptAndOfferDates;
		toData.Degree = fromData.Degree;
		toData.Deleted = fromData.Deleted;
		toData.DeletedByKey = fromData.DeletedByKey;
		toData.DeletedDate = fromData.DeletedDate;
		toData.DispositionNoteKey = fromData.DispositionNoteKey;
		toData.DispositionReasonKey = fromData.DispositionReasonKey;
		toData.DispositionStatusKey = fromData.DispositionStatusKey;
		toData.EducationRequired = fromData.EducationRequired;
		toData.Featured = fromData.Featured;
		toData.FilledFTE = fromData.FilledFTE;
		toData.FirstPublishedDate = fromData.FirstPublishedDate;
		toData.FullTimePartTime = fromData.FullTimePartTime;
		toData.HiredHeadcount = fromData.HiredHeadcount;
		toData.HiringManager = fromData.HiringManager;
		toData.HoursPerShift = fromData.HoursPerShift;
		toData.HoursPerWeek = fromData.HoursPerWeek;
		toData.ImpactToStaffingPlan = fromData.ImpactToStaffingPlan;
		toData.IsOpeningBudgeted = fromData.IsOpeningBudgeted;
		toData.JobFamily = fromData.JobFamily;
		toData.JobKey = fromData.JobKey;
		toData.LastDayWorked = fromData.LastDayWorked;
		toData.LicenseCertification = fromData.LicenseCertification;
		toData.LicensesAndCertificationsRequired = fromData.LicensesAndCertificationsRequired;
		toData.LocationName = fromData.LocationName;
		toData.Major = fromData.Major;
		toData.MaximumHeadcount = fromData.MaximumHeadcount;
		toData.MaximumYears = fromData.MaximumYears;
		toData.MinimumYears = fromData.MinimumYears;
		toData.OpportunityCandidateKey = fromData.OpportunityCandidateKey;
		toData.OpportunityID = fromData.OpportunityID;
		toData.OpportunityKey = fromData.OpportunityKey;
		toData.OpportunityStatus = fromData.OpportunityStatus;
		toData.OpportunityTitle = fromData.OpportunityTitle;
		toData.OrgLevel1 = fromData.OrgLevel1;
		toData.OrgLevel3 = fromData.OrgLevel3;
		toData.OrgLevel4 = fromData.OrgLevel4;
		toData.Priority = fromData.Priority;
		toData.ProcessKey = fromData.ProcessKey;
		toData.ReasonForOpening = fromData.ReasonForOpening;
		toData.Related = fromData.Related;
		toData.RemainingFTE = fromData.RemainingFTE;
		toData.RemainingHeadcount = fromData.RemainingHeadcount;
		toData.RequisitionNumber = fromData.RequisitionNumber;
		toData.SalaryHourly = fromData.SalaryHourly;
		toData.ShortDescription = fromData.ShortDescription;
		toData.SourceJob = fromData.SourceJob;
		toData.SourceJobCode = fromData.SourceJobCode;
		toData.StateProvinceCode = fromData.StateProvinceCode;
		toData.Supervisor = fromData.Supervisor;
		toData.SupervisorVisibility = fromData.SupervisorVisibility;
		toData.TargetStartDate = fromData.TargetStartDate;
		toData.TravelDetails = fromData.TravelDetails;
		toData.TravelRequired = fromData.TravelRequired;
		toData.UKGOpportunitiesImportRef = fromData.UKGOpportunitiesImportRef;
		toData.WorkDescription = fromData.WorkDescription;
		toData.WorkExperienceRequired = fromData.WorkExperienceRequired;
		toData.WorkLocationKey = fromData.WorkLocationKey;
	}

	public void MapFrom(IUKGOpportunitiesImport fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IUKGOpportunitiesImport toData)
	{
		Map(this, toData);
	}
}