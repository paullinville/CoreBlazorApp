using Midland.Core.Authorization.Reporting;
using Midland.Core.Common;
using Midland.Core.Validation.ClientRules;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using EATTS.Common.Models;

namespace EATTS.Client;

public partial interface IEATTSApiClient
{
#region Actions
	///<summary>
	///Reads the log files and imports them into the database
	///Authorization Groups
	/// Standard: "*"
	/// Composite Authorization Api Caller Or Action Authorization: "Either APIs (subjectType:20) OR users that have the required actions can call this endpoint -- Actions: Error Dev Page * Edit Info"
	///</summary>
	[Post("/v1/action/import-log-file")]
	Task<Response<MidlandResult<List<String>>>> PostActionImportLogFile();

#endregion Actions

#region Api
	///<summary>
	///The required actions/claims needed to call end points
	///</summary>
	[Get("/api/claimz")]
	Task<Response<MidlandResult<List<PathClaimGroups>>>> GetAllApiClaimzList();

	///<summary>
	///The required actions/claims needed to call end points
	///</summary>
	[Get("/api/claimz/{path}")]
	Task<Response<MidlandResult<PathClaimGroups>>> GetApiClaimz([Path] string path);

	///<summary>
	///</summary>
	[Get("/api/rulez")]
	Task<Response<MidlandResult<ApiRuleSet>>> GetApiRulez();

	///<summary>
	///</summary>
	[Get("/api/rulez/{modelName}")]
	Task<Response<MidlandResult<ClientRules>>> GetApiRulez([Path] string modelName);

#endregion Api

#region ApplicationOptions
	///<summary>
	///Authorization Groups
	/// Standard: "Options Edit"
	///</summary>
	[Delete("/v1/application/options/{applicationOptionsRef}")]
	Task<Response<dynamic>> DeleteApplicationOptions([Path] int applicationOptionsRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Options Edit"
	///</summary>
	[Get("/v1/application/options")]
	Task<Response<MidlandResult<List<ApplicationOptionsGetModel>>>> GetAllApplicationOptionsList();

	///<summary>
	///Authorization Groups
	/// Standard: "Options Edit"
	///</summary>
	[Get("/v1/application/options/{applicationOptionsRef}")]
	Task<Response<MidlandResult<ApplicationOptionsGetModel>>> GetApplicationOptions([Path] int applicationOptionsRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Options Edit"
	///</summary>
	[Post("/v1/application/options")]
	Task<Response<MidlandResult<ApplicationOptionsGetModel>>> PostApplicationOptions([Body] ApplicationOptionsPostModel applicationOptionsPostModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Options Edit"
	///</summary>
	[Put("/v1/application/options/{applicationOptionsRef}")]
	Task<Response<MidlandResult<ApplicationOptionsGetModel>>> PutApplicationOptions([Path] int applicationOptionsRef, [Body] ApplicationOptionsPostModel applicationOptionsPostModel);

#endregion ApplicationOptions

#region Entry
	///<summary>
	///Authorization Groups
	/// Standard: "Delete Entry","Error History Page * Edit Info"
	///</summary>
	[Delete("/v1/entry/{entryRef}")]
	Task<Response<dynamic>> DeleteEntry([Path] int entryRef);

	///<summary>
	///Entry edit model
	///Authorization Groups
	/// Standard: "Error History Page * Edit Info"
	///</summary>
	[Get("/v1/entry/{entryRef}")]
	Task<Response<MidlandResult<EntryGetModel>>> GetEntry([Path] int entryRef);

	///<summary>
	///Entry detail. Includes occurrences and notes.
	///Authorization Groups
	/// Standard: "Entry Search"
	///</summary>
	[Get("/v1/entry/view/{entryRef}/detail")]
	Task<Response<MidlandResult<EntryDetailModel>>> GetEntryViewDetail([Path] int entryRef);

	///<summary>
	///Search for the latest entries.
	///Authorization Groups
	/// Standard: "Entry Search"
	///</summary>
	[Get("/v1/entry/view/summary")]
	Task<Response<PageResultsModel<EntrySummaryModel>>> GetEntryViewSummaryPaged([RawQueryString] string EntrySearchCriteria);

	///<summary>
	///Authorization Groups
	/// Standard: "Error History Page * Edit Info"
	///</summary>
	[Patch("/v1/entry/{entryRef}")]
	Task<Response<MidlandResult<EntryGetModel>>> PatchEntry([Path] int entryRef, [Body] EntryPatchBody entryPatchBody);

#endregion Entry

#region EntryNote
	///<summary>
	///Authorization Groups
	/// Standard: "Error History Page * Edit Info"
	///</summary>
	[Delete("/v1/entry-note/{entryNoteRef}")]
	Task<Response<dynamic>> DeleteEntryNote([Path] int entryNoteRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Error History Page * Edit Info"
	///</summary>
	[Get("/v1/entry-note/{entryNoteRef}")]
	Task<Response<MidlandResult<EntryNoteGetModel>>> GetEntryNote([Path] int entryNoteRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Error History Page * Edit Info"
	///</summary>
	[Post("/v1/entry-note")]
	Task<Response<MidlandResult<EntryNoteGetModel>>> PostEntryNote([Body] EntryNotePostModel entryNotePostModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Error History Page * Edit Info"
	///</summary>
	[Put("/v1/entry-note/{entryNoteRef}")]
	Task<Response<MidlandResult<EntryNoteGetModel>>> PutEntryNote([Path] string entryNoteRef, [Body] EntryNotePutModel entryNotePutModel);

#endregion EntryNote

#region EntryOccurrence
	///<summary>
	///Authorization Groups
	/// Standard: "Delete Entry","Error History Page * Edit Info"
	///</summary>
	[Delete("/v1/entry/occurrence/{entryOccurrenceRef}")]
	Task<Response<dynamic>> DeleteEntryOccurrence([Path] int entryOccurrenceRef);

	///<summary>
	///Returns the detailed occurrence for the specified occurrence.
	///Authorization Groups
	/// Standard: "Entry Search"
	///</summary>
	[Get("/v1/entry/occurrence/view/{occurrenceRef}/detail")]
	Task<Response<MidlandResult<EntryOccurrenceDetailModel>>> GetEntryOccurrenceViewDetail([Path] int occurrenceRef);

	///<summary>
	///Search for entry occurrences. Returns paged entry occurrences summaries.
	///Authorization Groups
	/// Standard: "Entry Search"
	///</summary>
	[Get("/v1/entry/occurrence/view")]
	Task<Response<PageResultsModel<EntryOccurrenceSummaryModel>>> GetEntryOccurrenceViewPaged([RawQueryString] string EntryOccurrenceSearchCriteria);

	///<summary>
	///Returns the detailed EATTS entry for the specified occurrence.
	///Authorization Groups
	/// Standard: "Error History Page * Edit Info"
	///</summary>
	[Patch("/v1/entry/occurrence/{entryOccurrenceRef}")]
	Task<Response<MidlandResult<EntryOccurrenceDetailModel>>> PatchEntryOccurrence([Path] int entryOccurrenceRef, [Body] EntryOccurrencePatchBody entryOccurrencePatchBody);

#endregion EntryOccurrence

#region ErrorStatus
	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Delete("/v1/error-status/{errorStatusRef}")]
	Task<Response<dynamic>> DeleteErrorStatus([Path] string errorStatusRef, [Body] ErrorStatusDeleteModel errorStatusDeleteModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Get("/v1/error-status")]
	Task<Response<MidlandResult<List<ErrorStatusGetModel>>>> GetAllErrorStatusList();

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Get("/v1/error-status/{errorStatusRef}")]
	Task<Response<MidlandResult<ErrorStatusGetModel>>> GetErrorStatus([Path] int errorStatusRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Post("/v1/error-status")]
	Task<Response<MidlandResult<ErrorStatusGetModel>>> PostErrorStatus([Body] ErrorStatusPostModel errorStatusPostModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Put("/v1/error-status/{errorStatusRef}")]
	Task<Response<MidlandResult<ErrorStatusGetModel>>> PutErrorStatus([Path] string errorStatusRef, [Body] ErrorStatusPutModel errorStatusPutModel);

#endregion ErrorStatus

#region ErrorType
	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Delete("/v1/errortype/{errorTypeRef}")]
	Task<Response<dynamic>> DeleteErrortype([Path] string errorTypeRef, [Body] ErrorTypeDeleteModel errorTypeDeleteModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Get("/v1/errortype")]
	Task<Response<MidlandResult<List<ErrorTypeGetModel>>>> GetAllErrortypeList();

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Get("/v1/errortype/{errorTypeRef}")]
	Task<Response<MidlandResult<ErrorTypeGetModel>>> GetErrortype([Path] int errorTypeRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Post("/v1/errortype")]
	Task<Response<MidlandResult<ErrorTypeGetModel>>> PostErrortype([Body] ErrorTypePostModel errorTypePostModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Settings Admin * Edit Info"
	///</summary>
	[Put("/v1/errortype/{errorTypeRef}")]
	Task<Response<MidlandResult<ErrorTypeGetModel>>> PutErrortype([Path] string errorTypeRef, [Body] ErrorTypePutModel errorTypePutModel);

#endregion ErrorType

#region Healthz
	///<summary>
	///Has the application started.
	///</summary>
	[Get("/v1/healthz")]
	Task<Response<dynamic>> GetHealthz();

	///<summary>
	///Check status of application and database connections.
	///</summary>
	[Get("/v1/healthz/expanded")]
	Task<Response<HealthModel>> GetHealthzExpanded();

#endregion Healthz

#region Log
	///<summary>
	///Authorization Groups
	/// Standard: "*"
	/// Composite Authorization Api Caller Or Action Authorization: "Either APIs (subjectType:20) OR users that have the required actions can call this endpoint -- Actions: Error Search Page"
	///</summary>
	[Get("/v1/log")]
	Task<Response<PageResultsModel<ApiLogDataModel>>> GetLogPaged([RawQueryString] string ApiLogCriteria);

	///<summary>
	///Authorization Groups
	/// Standard: "*"
	///</summary>
	[Post("/v1/log")]
	Task<Response<MidlandResult<EattsEntryResultModel>>> PostLog([Body] EattsEntryModel eattsEntryModel);

#endregion Log

#region Support
	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Delete("/v1/support/contact/{supportDefaultContactRef}")]
	Task<Response<dynamic>> DeleteSupportContact([Path] int supportDefaultContactRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Get("/v1/support/contact")]
	Task<Response<MidlandResult<List<SupportDefaultContactEditModel>>>> GetAllSupportContactList();

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Post("/v1/support/contact")]
	Task<Response<MidlandResult<SupportDefaultContactEditModel>>> PostSupportContact([Body] SupportDefaultContactAddModel supportDefaultContactAddModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Put("/v1/support/contact")]
	Task<Response<MidlandResult<SupportDefaultContactEditModel>>> PutSupportContact([Body] SupportDefaultContactEditModel supportDefaultContactEditModel);

#endregion Support

#region SupportOption
	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Get("/v1/support/option")]
	Task<Response<MidlandResult<SupportOptionsEditModel>>> GetSupportOption();

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Put("/v1/support/option")]
	Task<Response<MidlandResult<SupportOptionsEditModel>>> PutSupportOption([Body] SupportOptionsEditModel supportOptionsEditModel);

#endregion SupportOption

#region SupportOptionsOverride
	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Delete("/v1/support/option-override/{supportOptionsOverrideRef}")]
	Task<Response<dynamic>> DeleteSupportOptionOverride([Path] int supportOptionsOverrideRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Get("/v1/support/option-override")]
	Task<Response<MidlandResult<List<SupportOptionsOverrideGetModel>>>> GetAllSupportOptionOverrideList();

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Get("/v1/support/option-override/{supportOptionsOverrideRef}")]
	Task<Response<MidlandResult<SupportOptionsOverrideGetModel>>> GetSupportOptionOverride([Path] int supportOptionsOverrideRef);

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Post("/v1/support/option-override")]
	Task<Response<MidlandResult<SupportOptionsOverrideGetModel>>> PostSupportOptionOverride([Body] SupportOptionsOverridePostModel supportOptionsOverridePostModel);

	///<summary>
	///Authorization Groups
	/// Standard: "Application Admin Page * Edit Info"
	///</summary>
	[Put("/v1/support/option-override/{supportOptionsOverrideRef}")]
	Task<Response<MidlandResult<SupportOptionsOverrideGetModel>>> PutSupportOptionOverride([Path] int supportOptionsOverrideRef, [Body] SupportOptionsOverridePostModel supportOptionsOverridePostModel);

#endregion SupportOptionsOverride


}