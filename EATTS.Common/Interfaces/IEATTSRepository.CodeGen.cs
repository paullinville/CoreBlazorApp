using System;
using System.Collections.Generic;

namespace EATTS.Common.Interfaces;

public partial interface IEATTSRepository
{
	#region Interface "IApiLog" operations 6/12/2023 8:53 AM

	NewEntityRef AddApiLog(IApiLog data);

	#endregion Interface "IApiLog" operations 6/12/2023 8:53 AM

	#region Interface "IApplication" operations 1/3/2023 10:23 AM

	NewEntityRef AddApplication(IApplication data);

	void DeleteApplication(IApplication data);

	IEnumerable<IApplication> GetAllApplications();

	IApplication GetApplication(int ApplicationRef);

	void UpdateApplication(IApplication data);

	#endregion Interface "IApplication" operations 1/3/2023 10:23 AM

	#region Interface "IApplicationManagementItem" operations 1/3/2023 10:23 AM

	NewEntityRef AddApplicationManagementItem(IApplicationManagementItem data);

	void DeleteApplicationManagementItem(IApplicationManagementItem data);

	IEnumerable<IApplicationManagementItem> GetAllApplicationManagementItems();

	IApplicationManagementItem GetApplicationManagementItem(int ApplicationManagementItemRef);

	void UpdateApplicationManagementItem(IApplicationManagementItem data);

	#endregion Interface "IApplicationManagementItem" operations 1/3/2023 10:23 AM

	#region Interface "IAudit" operations 1/3/2023 10:23 AM

	NewEntityRef AddAudit(IAudit data);

	void DeleteAudit(IAudit data);

	IEnumerable<IAudit> GetAllAudits();

	IAudit GetAudit(int AuditRef);

	void UpdateAudit(IAudit data);

	#endregion Interface "IAudit" operations 1/3/2023 10:23 AM

	#region Interface "IError" operations 1/3/2023 10:23 AM

	NewEntityRef AddError(IError data);

	void DeleteError(IError data);

	IEnumerable<IError> GetAllErrors();

	IError GetError(int ErrorRef);

	void UpdateError(IError data);

	#endregion Interface "IError" operations 1/3/2023 10:23 AM

	#region Interface "IErrorAdditionalInfo" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorAdditionalInfo(IErrorAdditionalInfo data);

	void DeleteErrorAdditionalInfo(IErrorAdditionalInfo data);

	IEnumerable<IErrorAdditionalInfo> GetAllErrorAdditionalInfos();

	IErrorAdditionalInfo GetErrorAdditionalInfo(int ErrorAdditionalInfoRef);

	void UpdateErrorAdditionalInfo(IErrorAdditionalInfo data);

	#endregion Interface "IErrorAdditionalInfo" operations 1/3/2023 10:23 AM

	#region Interface "IErrorCategory" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorCategory(IErrorCategory data);

	void DeleteErrorCategory(IErrorCategory data);

	IEnumerable<IErrorCategory> GetAllErrorCategories();

	IErrorCategory GetErrorCategory(int ErrorCategoryRef);

	void UpdateErrorCategory(IErrorCategory data);

	#endregion Interface "IErrorCategory" operations 1/3/2023 10:23 AM

	#region Interface "IErrorDocument" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorDocument(IErrorDocument data);

	void DeleteErrorDocument(IErrorDocument data);

	IEnumerable<IErrorDocument> GetAllErrorDocuments();

	IErrorDocument GetErrorDocument(int ErrorDocumentRef);

	void UpdateErrorDocument(IErrorDocument data);

	#endregion Interface "IErrorDocument" operations 1/3/2023 10:23 AM

	#region Interface "IErrorEmail" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorEmail(IErrorEmail data);

	void DeleteErrorEmail(IErrorEmail data);

	IEnumerable<IErrorEmail> GetAllErrorEmails();

	IErrorEmail GetErrorEmail(int ErrorEmailRef);

	void UpdateErrorEmail(IErrorEmail data);

	#endregion Interface "IErrorEmail" operations 1/3/2023 10:23 AM

	#region Interface "IErrorFlood" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorFlood(IErrorFlood data);

	void DeleteErrorFlood(IErrorFlood data);

	IEnumerable<IErrorFlood> GetAllErrorFloods();

	IErrorFlood GetErrorFlood(int ErrorFloodRef);

	void UpdateErrorFlood(IErrorFlood data);

	#endregion Interface "IErrorFlood" operations 1/3/2023 10:23 AM

	#region Interface "IErrorHistory" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorHistory(IErrorHistory data);

	void DeleteErrorHistory(IErrorHistory data);

	IEnumerable<IErrorHistory> GetAllErrorHistorys();

	IErrorHistory GetErrorHistory(int ErrorHistoryRef);

	void UpdateErrorHistory(IErrorHistory data);

	#endregion Interface "IErrorHistory" operations 1/3/2023 10:23 AM

	#region Interface "IErrorImportance" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorImportance(IErrorImportance data);

	void DeleteErrorImportance(IErrorImportance data);

	IEnumerable<IErrorImportance> GetAllErrorImportances();

	IErrorImportance GetErrorImportance(int ErrorImportanceRef);

	void UpdateErrorImportance(IErrorImportance data);

	#endregion Interface "IErrorImportance" operations 1/3/2023 10:23 AM

	#region Interface "IErrorOccurence" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorOccurence(IErrorOccurence data);

	void DeleteErrorOccurence(IErrorOccurence data);

	IEnumerable<IErrorOccurence> GetAllErrorOccurences();

	IErrorOccurence GetErrorOccurence(int ErrorOccurenceRef);

	void UpdateErrorOccurence(IErrorOccurence data);

	#endregion Interface "IErrorOccurence" operations 1/3/2023 10:23 AM

	#region Interface "IErrorSolution" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorSolution(IErrorSolution data);

	void DeleteErrorSolution(IErrorSolution data);

	IEnumerable<IErrorSolution> GetAllErrorSolutions();

	IErrorSolution GetErrorSolution(int ErrorSolutionRef);

	void UpdateErrorSolution(IErrorSolution data);

	#endregion Interface "IErrorSolution" operations 1/3/2023 10:23 AM

	#region Interface "IErrorStatus" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorStatus(IErrorStatus data);

	void DeleteErrorStatus(IErrorStatus data);

	IEnumerable<IErrorStatus> GetAllErrorStatus();

	IErrorStatus GetErrorStatus(int ErrorStatusRef);

	void UpdateErrorStatus(IErrorStatus data);

	#endregion Interface "IErrorStatus" operations 1/3/2023 10:23 AM

	#region Interface "IErrorType" operations 1/3/2023 10:23 AM

	NewEntityRef AddErrorType(IErrorType data);

	void DeleteErrorType(IErrorType data);

	IEnumerable<IErrorType> GetAllErrorTypes();

	IErrorType GetErrorType(int ErrorTypeRef);

	void UpdateErrorType(IErrorType data);

	#endregion Interface "IErrorType" operations 1/3/2023 10:23 AM

	#region Interface "IManagementItem" operations 1/3/2023 10:23 AM

	NewEntityRef AddManagementItem(IManagementItem data);

	void DeleteManagementItem(IManagementItem data);

	IEnumerable<IManagementItem> GetAllManagementItems();

	IManagementItem GetManagementItem(int ManagementItemRef);

	void UpdateManagementItem(IManagementItem data);

	#endregion Interface "IManagementItem" operations 1/3/2023 10:23 AM

	#region Interface "IPage" operations 1/3/2023 10:23 AM

	NewEntityRef AddPage(IPage data);

	void DeletePage(IPage data);

	IEnumerable<IPage> GetAllPages();

	IPage GetPage(int PageRef);

	void UpdatePage(IPage data);

	#endregion Interface "IPage" operations 1/3/2023 10:23 AM

	#region Interface "IUserApplicationManagementItemHolder" operations 1/3/2023 10:23 AM

	NewEntityRef AddUserApplicationManagementItemHolder(IUserApplicationManagementItemHolder data);

	void DeleteUserApplicationManagementItemHolder(IUserApplicationManagementItemHolder data);

	IEnumerable<IUserApplicationManagementItemHolder> GetAllUserApplicationManagementItemHolders();

	IUserApplicationManagementItemHolder GetUserApplicationManagementItemHolder(int UserApplicationManagementItemHolderRef);

	void UpdateUserApplicationManagementItemHolder(IUserApplicationManagementItemHolder data);

	#endregion Interface "IUserApplicationManagementItemHolder" operations 1/3/2023 10:23 AM

	#region Interface "IUserManagementItemHolder" operations 1/3/2023 10:23 AM

	NewEntityRef AddUserManagementItemHolder(IUserManagementItemHolder data);

	void DeleteUserManagementItemHolder(IUserManagementItemHolder data);

	IEnumerable<IUserManagementItemHolder> GetAllUserManagementItemHolders();

	IUserManagementItemHolder GetUserManagementItemHolder(int UserManagementItemHolderRef);

	void UpdateUserManagementItemHolder(IUserManagementItemHolder data);

	#endregion Interface "IUserManagementItemHolder" operations 1/3/2023 10:23 AM

	#region Interface "IVisit" operations 1/3/2023 10:23 AM

	NewEntityRef AddVisit(IVisit data);

	void DeleteVisit(IVisit data);

	IEnumerable<IVisit> GetAllVisits();

	IVisit GetVisit(int VisitRef);

	void UpdateVisit(IVisit data);

	#endregion Interface "IVisit" operations 1/3/2023 10:23 AM

	IApplication GetApplication(string virtualDir);

	IEnumerable<IErrorHistory> GetErrorsHistory(int errorRef);

	#region Interface "IEntry" operations 10/9/2023 11:04 AM

	NewEntityRef AddEntry(IEntry data);

	void DeleteEntry(IEntry data);

	IEnumerable<IEntry> GetAllEntrys();

	IEntry GetEntry(int EntryRef);

	void UpdateEntry(IEntry data);

	#endregion Interface "IEntry" operations 10/9/2023 11:04 AM

	#region Interface "IEntryOccurrence" operations 10/19/2023 1:57 PM

	NewEntityRef AddEntryOccurrence(IEntryOccurrence data);

	void DeleteEntryOccurrence(IEntryOccurrence data);

	IEnumerable<IEntryOccurrence> GetAllEntryOccurrences();

	IEnumerable<IEntry> GetEntries(string key);

	IEntryOccurrence GetEntryOccurrence(int EntryOccurrenceRef);

	void UpdateEntryOccurrence(IEntryOccurrence data);

	#endregion Interface "IEntryOccurrence" operations 10/19/2023 1:57 PM

	#region Interface "IEntryNote" operations 10/23/2023 8:24 AM

	void AddEntryNote(IEntryNote data);

	void DeleteEntryNote(IEntryNote data);

	IEnumerable<IEntryNote> GetAllEntryNotes();

	IEntryNote GetEntryNote(int EntryNoteRef);

	void UpdateEntryNote(IEntryNote data);

	#endregion Interface "IEntryNote" operations 10/23/2023 8:24 AM

	#region Interface "ISupportDefaultContact" operations 10/23/2023 8:24 AM

	NewEntityRef AddSupportDefaultContact(ISupportDefaultContact data);

	void DeleteSupportDefaultContact(ISupportDefaultContact data);

	IEnumerable<ISupportDefaultContact> GetAllSupportDefaultContacts();

	ISupportDefaultContact GetSupportDefaultContact(int SupportDefaultContactRef);

	void UpdateSupportDefaultContact(ISupportDefaultContact data);

	#endregion Interface "ISupportDefaultContact" operations 10/23/2023 8:24 AM

	#region Interface "ISupportOptions" operations 10/23/2023 8:24 AM

	NewEntityRef AddSupportOptions(ISupportOptions data);

	ISupportOptions GetSupportOptions();

	void UpdateSupportOptions(ISupportOptions data);

	#endregion Interface "ISupportOptions" operations 10/23/2023 8:24 AM

	#region Interface "ISupportOptionsOverride" operations 10/23/2023 8:24 AM

	void AddApiLogs(List<IApiLog> data);

	NewEntityRef AddSupportOptionsOverride(ISupportOptionsOverride data);

	void DeleteSupportOptionsOverride(ISupportOptionsOverride data);

	IEnumerable<ISupportOptionsOverride> GetAllSupportOptionsOverrides();

	IEnumerable<IEntryNote> GetEntryNotes(int entryRef);

	IEnumerable<IEntryNote> GetEntryNotes(int entryRef, int occurrenceRef);

	IEnumerable<IEntryNote> GetOccurrenceNotes(int occurrenceRef);

	IEnumerable<IEntryOccurrence> GetOccurrencesForEntry(int entryRef);

	ISupportOptionsOverride GetSupportOptionsOverride(int SupportOptionsOverrideRef);

	void UpdateSupportOptionsOverride(ISupportOptionsOverride data);

	#endregion Interface "ISupportOptionsOverride" operations 10/23/2023 8:24 AM

	//start

	#region Interface "IApplicationOptions" operations 7/30/2025 9:57 AM

	NewEntityRef AddApplicationOptions(IApplicationOptions data);

	void DeleteApplicationOptions(IApplicationOptions data);

	IEnumerable<IApplicationOptions> GetAllApplicationOptions();

	IApplicationOptions GetApplicationOptions(int applicationOptionsRef);

	IEnumerable<IApplicationOptions> GetApplicationOptions(List<int> applicationOptionsRefs);

	void UpdateApplicationOptions(IApplicationOptions data);

	#endregion Interface "IApplicationOptions" operations 7/30/2025 9:57 AM

	#region Interface "IApplication" operations 7/30/2025 9:52 AM

	IEnumerable<IApplication> GetApplications(List<int> applicationRefs);

	IEnumerable<IEntryOccurrence> GetOccurrencesForEntry(int entryRef, int count);
	void DeleteEntryOccurrences(DateTime cutoffDate);

	#endregion Interface "IApplication" operations 7/30/2025 9:52 AM
}