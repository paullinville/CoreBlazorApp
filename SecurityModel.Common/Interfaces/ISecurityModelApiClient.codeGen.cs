using Midland.Core.Abstractions.Security;
using Midland.Core.ApplicationSecurity;
using Midland.Core.Authorization.Reporting;
using Midland.Core.Validation.ClientRules;
using RestEase;
using SecurityModel.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityModel.Client;

public partial interface ISecurityModelApiClient
{
	#region Action

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Action Collection Model Permissions: "(Assign Actions To Roles) -- Actions: (Assign Actions To Roles)"</list>
	///</summary>
	[Delete("/v1/role/{roleRef}/action/{actionRef}")]
	Task<Response<dynamic>> DeleteRoleAction([Path] int roleRef, [Path] int actionRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Action Collection Model Permissions: "(Assign Actions To Roles) -- Actions: (Assign Actions To Roles)"</list>
	///</summary>
	[Delete("/v1/role/action")]
	Task<Response<dynamic>> DeleteRoleAction([Body] RoleActionDeleteModel roleActionDeleteModel);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/action/{actionRef}")]
	Task<Response<MidlandResult<ActionEditModel>>> GetAction([Path] int actionRef);

	///<summary>
	///Returns the users that has at least one of the actions listed in the
	///ApiActionsUsersCriteria.Actions list. It uses the sub claim of the API security token to
	///determine the application to use.
	/// <para>Use <see cref="ApiActionsUsersCriteriaModel">ApiActionsUsersCriteriaModel</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Caller Authorization: "Only APIs (subjectType:20) can call this endpoint"</list>
	///</summary>
	[Get("/v1/action/api/user")]
	Task<Response<MidlandResult<List<UserActionsModel>>>> GetActionApiUserList([RawQueryString] string ApiActionsUsersCriteriaModel);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/action-detail/{actionRef}")]
	Task<Response<MidlandResult<ActionEditDetailModel>>> GetActionDetail([Path] int actionRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/action")]
	Task<Response<MidlandResult<List<ActionEditDetailModel>>>> GetApplicationActionList([Path] int applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Application Slug Caller: "APIs can call this endpoint or those with the 'User Action Page * View User Actions' action. -- Actions: User Action Page * View User Actions"</list>
	///</summary>
	[Get("/v1/application/{applicationSlug}/action/{actionName}/user")]
	Task<Response<MidlandResult<List<UserSelectModel>>>> GetApplicationActionUserList([Path] string applicationSlug, [Path] string actionName);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/user/action")]
	Task<Response<MidlandResult<List<UserActionView>>>> GetApplicationUserActionList([Path] int applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Application Ref Caller: "APIs can call this endpoint or those with the 'User Action Page * View User Actions' action. -- Actions: User Action Page * View User Actions"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/user/{userRef}/action")]
	Task<Response<MidlandResult<List<UserActionView>>>> GetApplicationUserActionList([Path] int userRef, [Path] int applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/role/{roleRef}/action")]
	Task<Response<MidlandResult<List<ActionEditDetailModel>>>> GetRoleActionList([Path] int roleRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Action Add Permissions: "(Assign Actions To Roles) -- Actions: (Assign Actions To Roles)"</list>
	///</summary>
	[Patch("/v1/action/{actionRef}")]
	Task<Response<MidlandResult<ActionEditDetailModel>>> PatchAction([Path] int? actionRef, [Body] ActionEditDetailModel actionEditDetailModel);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Action Add Permissions: "(Assign Actions To Roles) -- Actions: (Assign Actions To Roles)"</list>
	///</summary>
	[Put("/v1/action")]
	Task<Response<MidlandResult<ActionEditDetailModel>>> PutAction([Body] ActionEditModel actionEditModel);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Action Collection Model Permissions: "(Assign Actions To Roles) -- Actions: (Assign Actions To Roles)"</list>
	///</summary>
	[Put("/v1/role/{roleRef}/action/{actionRef}")]
	Task<Response<MidlandResult<RoleActionAddModel>>> PutRoleAction([Path] int roleRef, [Path] int actionRef);

	///<summary>
	///Obsolete Use PUT /v1/role/{roleRef} instead.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Action Collection Model Permissions: "(Assign Actions To Roles) -- Actions: (Assign Actions To Roles)"</list>
	///</summary>
	[Put("/v1/role/{roleRef}/action")]
	[Obsolete]
	Task<Response<MidlandResult<List<ActionEditDetailModel>>>> PutRoleAction([Path] string roleRef, [Body] RoleActionCollectionModel roleActionCollectionModel);

	#endregion Action

	#region ActionGroup

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api User Authorization: "User must be assigned to at least one active role that has at least one action."</list>
	///</summary>
	[Get("/v1/actiongroup/{actionGroupRef}")]
	Task<Response<MidlandResult<ActionGroupGetModel>>> GetActiongroup([Path] int actionGroupRef);

	///<summary>
	/// <para>Use <see cref="ActionGroupCriteriaBase">ActionGroupCriteriaBase</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api User Authorization: "User must be assigned to at least one active role that has at least one action."</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/action-group")]
	Task<Response<MidlandResult<List<ActionGroupViewModel>>>> GetApplicationActionGroupList([RawQueryString] string ActionGroupCriteriaBase, [Path] int applicationRef);

	#endregion ActionGroup

	#region Api

	///<summary>
	///The required actions/claims needed to call end points.
	///</summary>
	[Get("/api/claimz")]
	Task<Response<MidlandResult<List<PathClaimGroups>>>> GetAllApiClaimzList();

	///<summary>
	///The required actions/claims needed to call end points.
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

	#region ApiToken

	///<summary>
	///Gets collection of all API token definitions.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "API Token Create"</list>
	///</summary>
	[Get("/v1/token/api")]
	Task<Response<MidlandResult<List<ApiTokenGetModel>>>> GetAllTokenApiList();

	///<summary>
	///Gets an API token definition.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "API Token Create"</list>
	///</summary>
	[Get("/v1/token/api/{apiTokenRef}")]
	Task<Response<MidlandResult<ApiTokenGetModel>>> GetTokenApi([Path] int apiTokenRef);

	///<summary>
	///Creates an API token definition. Used by APIs to call other APIs. The actual token is
	///created when the API requests it.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "API Token Create"</list>
	///</summary>
	[Post("/v1/token/api")]
	Task<Response<MidlandResult<ApiTokenGetModel>>> PostTokenApi([Body] ApiTokenAddModel apiTokenAddModel);

	///<summary>
	///Updates an API token definition.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "API Token Create"</list>
	///</summary>
	[Put("/v1/token/api/{apiTokenRef}")]
	Task<Response<MidlandResult<ApiTokenGetModel>>> PutTokenApi([Path] int apiTokenRef, [Body] ApiTokenBodyModel apiTokenBodyModel);

	#endregion ApiToken

	#region Application

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}")]
	Task<Response<MidlandResult<ApplicationGetModel>>> GetApplication([Path] int applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Caller: "Only APIs can call this endpoint."</list>
	///</summary>
	[Get("/v1/application/api/information/{applicationGuid}")]
	Task<Response<MidlandResult<MidlandApplicationSecurityModel>>> GetApplicationApiInformation([Path] Guid applicationGuid);

	///<summary>
	///Returns the Security information for the calling API. Uses the sub claim to look up the
	///information via virtual directory.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Caller: "Only APIs can call this endpoint."</list>
	///</summary>
	[Get("/v1/application/api/information")]
	Task<Response<MidlandResult<MidlandApplicationSecurityModel>>> GetApplicationApiInformation();

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Caller: "Only APIs can call this endpoint."</list>
	///</summary>
	[Get("/v1/application/api/token")]
	Task<Response<dynamic>> GetApplicationApiToken();

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Caller: "Only APIs can call this endpoint."</list>
	///</summary>
	[Get("/v2/application/api/token")]
	Task<Response<dynamic>> GetApplicationApiTokenv2();

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application/by-guid/{guid}")]
	Task<Response<MidlandResult<ApplicationGetModel>>> GetApplicationByGuid([Path] Guid guid);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application/by-slug/{applicationSlug}")]
	Task<Response<MidlandResult<ApplicationGetModel>>> GetApplicationBySlug([Path] string applicationSlug);

	///<summary>
	/// <para>Use <see cref="ApplicationPageModel">ApplicationPageModel</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application")]
	Task<Response<PageResultsModel<ApplicationGetModel>>> GetApplicationPaged([RawQueryString] string ApplicationPageModel);

	///<summary>
	///The include field is roleRef. The default sort is Name ascending.
	/// <para>Use <see cref="RoleCriteriaBindingModel">RoleCriteriaBindingModel</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/role")]
	Task<Response<MidlandResult<IEnumerable<RoleDetailModel>>>> GetApplicationRoleList([RawQueryString] string RoleCriteriaBindingModel, [Path] int applicationRef);

	///<summary>
	/// <para>Use <see cref="ApplicationCriteria">ApplicationCriteria</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application-summary")]
	Task<Response<MidlandResult<List<ApplicationSummary>>>> GetApplicationSummaryList([RawQueryString] string ApplicationCriteria);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "(Add Application)"</list>
	///</summary>
	[Post("/v1/application")]
	Task<Response<MidlandResult<ApplicationGetModel>>> PostApplication([Body] ApplicationPostModel applicationPostModel);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Api Caller: "Only APIs can call this endpoint."</list>
	///</summary>
	[Post("/v1/application/api/claim")]
	Task<Response<dynamic>> PostApplicationApiClaim([Body] MidlandApplicationClaimsList midlandApplicationClaimsList);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "(Edit Application)"</list>
	///</summary>
	[Put("/v1/application/{applicationRef}")]
	Task<Response<MidlandResult<ApplicationGetModel>>> PutApplication([Path] int? applicationRef, [Body] ApplicationPutBodyModel applicationPutBodyModel);

	#endregion Application

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

	#region Report

	///<summary>
	/// <para>Use <see cref="AuditReportCriteria">AuditReportCriteria</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Audit Report Permissions: "Security Model Audit Search Page * View Audit Search Results -- Actions: Security Model Audit Search Page * View Audit Search Results"</list>
	///</summary>
	[Get("/report/application-audit")]
	Task<Response<MidlandResult<List<AuditReport>>>> GetReportApplicationAuditList([RawQueryString] string AuditReportCriteria);

	///<summary>
	/// <para>Use <see cref="ApplicationRoleReportCriteria">ApplicationRoleReportCriteria</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization User Report Permissions: "Role List Page * View Role List -- Actions: Role List Page * View Role List"</list>
	///</summary>
	[Get("/report/application-role")]
	Task<Response<MidlandResult<List<ApplicationRoleReport>>>> GetReportApplicationRoleList([RawQueryString] string ApplicationRoleReportCriteria);

	///<summary>
	/// <para>Use <see cref="ApplicationUserReportCriteria">ApplicationUserReportCriteria</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization User Report Permissions: "User Role Page * View User Roles -- Actions: User Role Page * View User Roles"</list>
	///</summary>
	[Get("/report/application-user")]
	Task<Response<MidlandResult<List<UserRoleReportView>>>> GetReportApplicationUserList([RawQueryString] string ApplicationUserReportCriteria);

	#endregion Report

	#region Role

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Delete Permissions: "(Delete Role) -- Actions: (Delete Role)"</list>
	///</summary>
	[Delete("/v1/role/{roleRef}")]
	Task<Response<dynamic>> DeleteRole([Path] int roleRef);

	///<summary>
	/// <para>Use <see cref="ActionsRolesCriteriaBindingModel">ActionsRolesCriteriaBindingModel</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/action/role")]
	Task<Response<MidlandResult<List<RoleViewModel>>>> GetApplicationActionRoleList([RawQueryString] string ActionsRolesCriteriaBindingModel, [Path] int? applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/role/{roleRef}")]
	Task<Response<MidlandResult<RoleDetailModel>>> GetRole([Path] int roleRef);

	///<summary>
	/// <para>Use <see cref="ApplicationUserRoleCriteriaBase">ApplicationUserRoleCriteriaBase</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization View Role User Permission: "User Role Page * View User Roles -- Actions: User Role Page * View User Roles"</list>
	///</summary>
	[Get("/v1/role/{roleRef}/user")]
	Task<Response<MidlandResult<List<UserRoleModel>>>> GetRoleUserList([RawQueryString] string ApplicationUserRoleCriteriaBase, [Path] int roleRef);

	///<summary>
	///Obsolete Use PUT /v1/role/{roleRef} instead.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Edit Permissions: "(Edit Role) -- Actions: (Edit Role)"</list>
	///</summary>
	[Patch("/v1/role/{roleRef}")]
	[Obsolete]
	Task<Response<MidlandResult<RoleDetailModel>>> PatchRole([Path] int roleRef, [Body] RoleEditModel roleEditModel);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Create Permissions: "(Add Role) -- Actions: (Add Role)"</list>
	///</summary>
	[Post("/v1/role")]
	Task<Response<MidlandResult<RoleDetailModel>>> PostRole([Body] RolePostModel rolePostModel);

	///<summary>
	///Update a role including its action and action groups.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Role Edit Permissions: "(Edit Role) -- Actions: (Edit Role)"</list>
	///</summary>
	[Put("/v1/role/{roleRef}")]
	Task<Response<MidlandResult<RoleDetailModel>>> PutRole([Path] int roleRef, [Body] RolePutBodyModel rolePutBodyModel);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Add Role Users Permission: "Add role to user requires (Edit User Roles) -- Actions: (Edit User Roles)"</list>
	///<list type="bullet"> Composite Authorization Remove Role Users Permissions: "Remove role from user requires (Edit User Roles) -- Actions: (Edit User Roles)"</list>
	///</summary>
	[Put("/v1/role/{roleRef}/user")]
	Task<Response<MidlandResult<List<UserRoleModel>>>> PutRoleUser([Path] string roleRef, [Body] RoleUserCollectionModel roleUserCollectionModel);

	#endregion Role

	#region ServiceToken

	///<summary>
	///Returns a list of service tokens for administrative purposes.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "Service Token Maintenance"</list>
	///</summary>
	[Get("/v1/admin/token/service")]
	Task<Response<MidlandResult<List<ServiceTokenAdminListModel>>>> GetAllAdminTokenServiceList();

	///<summary>
	///Returns a list of owned service tokens and their active status for the authenticated user.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/token/service")]
	Task<Response<MidlandResult<List<ServiceTokenView>>>> GetAllTokenServiceList();

	///<summary>
	///Edit model of a service token.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "Service Token Maintenance"</list>
	///</summary>
	[Get("/v1/token/service/{id}")]
	Task<Response<MidlandResult<ServiceTokenGetModel>>> GetTokenService([Path] Guid id);

	///<summary>
	///Detailed view of a service token.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Service Token Detail Authorization: "User must be the service token owner or have action 'Service Token Maintenance' -- Actions: Service Token Maintenance"</list>
	///</summary>
	[Get("/v1/token/service/{id}/detail")]
	Task<Response<MidlandResult<ServiceTokenDetailViewModel>>> GetTokenServiceDetail([Path] Guid id);

	///<summary>
	///Creates a service token using the latest secret version for the token id passed. Only the
	///owner, designated by the ResponsibleUserRef, can retrieve the token. Every time this
	///endpoint is called a new token is generated.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/token/service/{tokenId}/value")]
	Task<Response<MidlandResult<String>>> GetTokenServiceValue([Path] Guid tokenId);

	///<summary>
	///Saves the information needed to create a token for a service. The employee designated by
	///ResponsibleUserRef will be able to generate it from this information by calling the
	////Token/Service/{tokenId} endpoint. The token is not actual generated until that endpoint is
	///called by that user.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "Service Token Create"</list>
	///</summary>
	[Post("/v1/token/service")]
	Task<Response<MidlandResult<Guid>>> PostTokenService([Body] ServiceTokenAddModel serviceTokenAddModel);

	///<summary>
	///Update the service token.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "Service Token Maintenance"</list>
	///</summary>
	[Put("/v1/token/service")]
	Task<Response<dynamic>> PutTokenService([Body] ServiceTokenUpdateModel serviceTokenUpdateModel);

	#endregion ServiceToken

	#region TokenUser

	///<summary>
	///Creates an application token for a user. This endpoint can only be called through the
	///Gateway performs NTLM authentication with the user and that user's id is passed to this
	///endpoint and is used to determine the permissions allowed.
	/// <para>Use <see cref="UserTokenRequestByGuidModel">UserTokenRequestByGuidModel</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v1/token/user")]
	Task<Response<dynamic>> GetTokenUser([RawQueryString] string UserTokenRequestByGuidModel);

	///<summary>
	///Creates an application token for a user. This endpoint can only be called through the
	///Gateway. The Gateway performs NTLM authentication with the user and that user's id is passed
	///to this endpoint and is used to determine the permissions allowed.
	/// <para>Use <see cref="UserTokenRequestBySlugModel">UserTokenRequestBySlugModel</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Get("/v2/token/user")]
	Task<Response<dynamic>> GetTokenUserv2([RawQueryString] string UserTokenRequestBySlugModel);

	///<summary>
	///Refresh an existing v1 user token. Must be a valid token that has not expired.
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///</summary>
	[Post("/v1/token/user")]
	Task<Response<dynamic>> PostTokenUser();

	#endregion TokenUser

	#region User

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization View User Role Permission: "User Role Page * View User Roles -- Actions: User Role Page * View User Roles"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/recent-user")]
	Task<Response<MidlandResult<List<UserRolesDetailAuditModel>>>> GetApplicationRecentUserList([Path] int applicationRef);

	///<summary>
	///Returns all active employees assigned to at least 1 role.
	/// <para>Use <see cref="EmployeeSimpleCriteria">EmployeeSimpleCriteria</see> as the query model.</para>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization View User Role Permission: "User Role Page * View User Roles -- Actions: User Role Page * View User Roles"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/user")]
	Task<Response<MidlandResult<List<EmployeeSimple>>>> GetApplicationUserList([RawQueryString] string EmployeeSimpleCriteria, [Path] int applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization View User Role Permission: "User Role Page * View User Roles -- Actions: User Role Page * View User Roles"</list>
	///</summary>
	[Get("/v1/application/{applicationRef}/user/{userRef}/role")]
	Task<Response<MidlandResult<List<UserRoleModel>>>> GetApplicationUserRoleList([Path] int userRef, [Path] int applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization View User Role Permission: "User Role Page * View User Roles -- Actions: User Role Page * View User Roles"</list>
	///</summary>
	[Get("/v1/user/{userRef}/application/{applicationRef}/view")]
	Task<Response<MidlandResult<UserRolesDetailModel>>> GetUserApplicationView([Path] int userRef, [Path] int applicationRef);

	///<summary>
	///<para><b>Authorization Groups</b></para>
	///<list type="bullet"> Standard: "*"</list>
	///<list type="bullet"> Composite Authorization Add User Roles Permission: "Add roles to user requires (Edit User Roles)"</list>
	///<list type="bullet"> Composite Authorization Remove User Roles Permissions: "Remove roles from user requires (Edit User Roles)"</list>
	///</summary>
	[Put("/v1/user/{userRef}/role")]
	Task<Response<MidlandResult<List<RoleDetailModel>>>> PutUserRole([Path] string userRef, [Body] UserRoleCollectionModel userRoleCollectionModel);

	#endregion User
}