using EmployeeData.Common.Models;
using Midland.Core.Authorization.Reporting;
using Midland.Core.Common;
using Midland.Core.Validation.ClientRules;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeData.Client;

public partial interface IEmployeeDataApiClient
{
	#region Api

	///<summary>
	///The required actions/claims needed to call end points
	///</summary>
	[Get("/api/claimz")]
	Task<Response<MidlandResult<List<PathClaimGroups>>>> GetAllApiClaimzList();

	///<summary>
	///Controllers and dictionary of
	///</summary>
	[Get("/api/claimz/set")]
	Task<Response<MidlandResult<List<ControllerClaim>>>> GetAllApiClaimzSetList();

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

	#region Location

	///<summary>
	///Retrieves all the locations
	///Authorization Groups
	/// Standard: "*"
	///</summary>
	[Get("/v1/location")]
	Task<Response<MidlandResult<List<LocationGetModel>>>> GetAllLocationList();

	#endregion Location

	#region Parameter

	///<summary>
	///Authorization Groups
	/// Standard: "*"
	/// Composite Authorization UKG Admin: "Composite security for Parameters -- Actions: Parameter Admin,UKG Admin"
	///</summary>
	[Put("/v1/parameter")]
	Task<Response<MidlandResult<ParameterEditModel>>> PutParameter([Body] ParameterEditModel parameterEditModel);

	#endregion Parameter

	#region User

	///<summary>
	///Authorization Groups
	/// Standard: "*"
	/// Composite Authorization Api Caller: "-- Actions: Only APIs can call this endpoint."
	///</summary>
	[Get("/v1/user/service")]
	Task<Response<MidlandResult<List<MidlandUserGeneralModel>>>> GetAllUserServiceList();

	///<summary>
	///Authorization Groups
	/// Standard: "*"
	///</summary>
	[Get("/v1/user/{userRef}")]
	Task<Response<MidlandResult<MidlandUserGeneralModel>>> GetUser([Path] int userRef);

	///<summary>
	///Authorization Groups
	/// Standard: "*"
	///</summary>
	[Get("/v1/user")]
	Task<Response<PageResultsModel<MidlandUserGeneralModel>>> GetUserPaged([RawQueryString] string MidlandUserCriteria);

	///<summary>
	///Returns a list of active users ordered by LastNameFirst.
	///Authorization Groups
	/// Standard: "*"
	///</summary>
	[Get("/v1/user-summary")]
	Task<Response<MidlandResult<List<UserSelectModelExpanded>>>> GetUserSummaryList([RawQueryString] string MidlandUserListCriteria);

	#endregion User

	#region Report

	///<summary>
	///Triggers import processing for UKG report data
	///Authorization Groups
	/// Standard: "*"
	///</summary>
	[Post("/v1/report/import-data")]
	Task<Response<MidlandResult<string>>> PostImportReportData();

	#endregion Report
}