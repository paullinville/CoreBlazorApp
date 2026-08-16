using SecurityModel.Common.Models;
using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Interfaces;

public partial interface ISecurityModelRepository
{
	#region Interface "IApplicationUserAction" operations 2/10/2023 7:40 AM

	IEnumerable<IApplicationUserAction> GetAllApplicationUserActions();

	#endregion Interface "IApplicationUserAction" operations 2/10/2023 7:40 AM

	#region Interface "IServiceToken" operations 2/10/2023 9:15 AM

	void AddServiceToken(IServiceToken data);

	void DeleteServiceToken(IServiceToken data);

	IEnumerable<IServiceToken> GetAllServiceTokens();

	IServiceToken GetServiceToken(Guid Id);

	void UpdateServiceToken(IServiceToken data);

	#endregion Interface "IServiceToken" operations 2/10/2023 9:15 AM

	#region Interface "IApplication" operations 2/13/2023 8:31 AM

	IEnumerable<IApplication> GetAllApplications();

	IApplication GetApplication(int ApplicationRef);

	#endregion Interface "IApplication" operations 2/13/2023 8:31 AM

	#region Interface "IApplicationAction" operations 6/9/2023 9:32 AM

	IEnumerable<IApplicationAction> GetAllApplicationsAndActions();

	#endregion Interface "IApplicationAction" operations 6/9/2023 9:32 AM

	#region Interface "IServiceTokenOwner" operations 6/12/2023 8:18 AM

	NewEntityRef AddServiceTokenOwner(IServiceTokenOwner data);

	void DeleteServiceTokenOwner(IServiceTokenOwner data);

	IEnumerable<IServiceTokenOwner> GetAllServiceTokenOwners();

	IServiceTokenOwner GetServiceTokenOwner(Guid Id);

	void UpdateServiceTokenOwner(IServiceTokenOwner data);

	#endregion Interface "IServiceTokenOwner" operations 6/12/2023 8:18 AM

	#region Interface "IServiceTokenActivity" operations 6/12/2023 9:16 AM

	NewEntityRef AddServiceTokenActivity(IServiceTokenActivity data);

	void DeleteServiceTokenActivity(IServiceTokenActivity data);

	IEnumerable<IServiceTokenActivity> GetAllServiceTokenActivities();

	IServiceTokenActivity GetServiceTokenActivity(int ServiceTokenActivityRef);

	void UpdateServiceTokenActivity(IServiceTokenActivity data);

	#endregion Interface "IServiceTokenActivity" operations 6/12/2023 9:16 AM

	#region Interface "IAction" operations 11/7/2023 2:13 PM

	IAction GetAction(int ActionRef);

	IEnumerable<IAction> GetActions(List<int> ActionRefs);

	void UpdateAction(IAction data);

	#endregion Interface "IAction" operations 11/7/2023 2:13 PM

	#region Interface "IApplication" operations 11/7/2023 2:13 PM

	NewEntityRef AddApplication(IApplication data);

	void DeleteApplication(IApplication data);

	void UpdateApplication(IApplication data);

	#endregion Interface "IApplication" operations 11/7/2023 2:13 PM

	#region Interface "IApplicationUserRoleHolder" operations 11/7/2023 2:13 PM

	NewEntityRef AddApplicationUserRoleHolder(IApplicationUserRoleHolder data);

	void DeleteApplicationUserRoleHolder(IApplicationUserRoleHolder data);

	IApplicationUserRoleHolder GetApplicationUserRoleHolder(int ApplicationUserRoleHolderRef);

	void UpdateApplicationUserRoleHolder(IApplicationUserRoleHolder data);

	#endregion Interface "IApplicationUserRoleHolder" operations 11/7/2023 2:13 PM

	#region Interface "IRole" operations 11/7/2023 2:13 PM

	NewEntityRef AddRole(IRole data);

	void DeleteRole(IRole data);

	IEnumerable<IRole> GetApplicationRoles(int applicationRef);

	IRole GetRole(int RoleRef);

	void UpdateRole(IRole data);

	#endregion Interface "IRole" operations 11/7/2023 2:13 PM

	#region Interface "IRoleActionHolder" operations 11/7/2023 2:13 PM

	void AddRoleActionHolder(IRoleActionHolder data);

	void DeleteRoleActionHolder(IRoleActionHolder data);

	IRoleActionHolder GetRoleActionHolder(int ActionRef, int roleRef);

	#endregion Interface "IRoleActionHolder" operations 11/7/2023 2:13 PM

	#region Interface "IContext" operations 11/7/2023 2:51 PM

	NewEntityRef AddContext(IContext data);

	void DeleteContext(IContext data);

	IEnumerable<IContext> GetAllContexts();

	IContext GetContext(int ContextRef);

	void UpdateContext(IContext data);

	#endregion Interface "IContext" operations 11/7/2023 2:51 PM

	#region Interface "IContextType" operations 11/7/2023 2:51 PM

	NewEntityRef AddContextType(IContextType data);

	void DeleteContextType(IContextType data);

	IEnumerable<IContextType> GetAllContextTypes();

	IContextType GetContextType(int ContextTypeRef);

	void UpdateContextType(IContextType data);

	#endregion Interface "IContextType" operations 11/7/2023 2:51 PM

	#region Interface "IApplicationContextRoleUserHolder" operations 12/22/2023 3:55 PM

	NewEntityRef AddApplicationContextRoleUserHolder(IApplicationContextRoleUserHolder data);

	void DeleteApplicationContextRoleUserHolder(IApplicationContextRoleUserHolder data);

	IApplicationContextRoleUserHolder GetApplicationContextRoleUserHolder(int ApplicationContextRoleUserHolderRef);

	IEnumerable<IApplicationContextRoleUserHolder> GetApplicationContextRoleUserHoldersForRole(int roleRef);

	IEnumerable<IApplicationContextRoleUserHolder> GetApplicationContextRoleUserHoldersForRole(int roleRef, int userRef);

	void UpdateApplicationContextRoleUserHolder(IApplicationContextRoleUserHolder data);

	#endregion Interface "IApplicationContextRoleUserHolder" operations 12/22/2023 3:55 PM

	#region Interface "IAudit" operations 12/23/2023 9:08 PM

	NewEntityRef AddAudit(IAudit data);

	void DeleteAudit(IAudit data);

	IAudit GetAudit(int AuditRef);

	void UpdateAudit(IAudit data);

	#endregion Interface "IAudit" operations 12/23/2023 9:08 PM

	#region Interface "IApplicationUserRole" operations 12/23/2023 10:30 PM

	IEnumerable<IApplicationUserRole> GetAllApplicationUserRoles();

	IEnumerable<IApplicationUserAction> GetApplicationUserActions(int appId, int userRef);

	IEnumerable<IApplicationUserRole> GetApplicationUserRoles(int applicationRef, int userRef);

	IEnumerable<IApplicationUserRole> GetApplicationUserRolesForRole(int roleRef);

	#endregion Interface "IApplicationUserRole" operations 12/23/2023 10:30 PM

	#region Interface "IApplicationUserRoleAction" operations 1/10/2024 2:44 PM

	IEnumerable<IApplicationUserRoleAction> GetAllApplicationUserRoleActions();

	IEnumerable<IApplicationUserRoleAction> GetApplicationUserRoleActions(int applicationRef, int userRef);

	IEnumerable<IApplicationUserRoleHolder> GetApplicationUserRoleHolderForApplication(int applicationRef);

	IEnumerable<IApplicationUserRole> GetApplicationUserRoles(ApplicationUserReportCriteria criteria);

	IEnumerable<IApplicationUserRole> GetApplicationUserRolesForApplication(int applicationRef);

	#endregion Interface "IApplicationUserRoleAction" operations 1/10/2024 2:44 PM

	#region Interface "IApplicationRoleAction" operations 2/1/2024 1:41 PM

	IEnumerable<IApplicationRoleAction> GetAllApplicationRoleActions();

	IEnumerable<IApplicationRoleAction> GetApplicationRoleActions(int applicationRef);

	#endregion Interface "IApplicationRoleAction" operations 2/1/2024 1:41 PM

	#region Interface "IAuditReport" operations 2/2/2024 10:41 AM

	IEnumerable<IAction> GetActionForApplication(int applicationRef);

	IEnumerable<IAuditReport> GetAllAuditReports();

	IApplication GetApplication(string applicationSlug);

	List<IMidlandUser> GetUsers(List<int> userRefs);

	#endregion Interface "IAuditReport" operations 2/2/2024 10:41 AM

	#region Interface "IActionGroup" operations 2/20/2026 8:53 AM

	NewEntityRef AddActionGroup(IActionGroup data);

	void DeleteActionGroup(IActionGroup data);

	IActionGroup GetActionGroup(int actionGroupRef);

	IEnumerable<IActionGroup> GetActionGroups(List<int> actionGroupRefs);

	IEnumerable<IActionGroup> GetAllActionGroups();

	void UpdateActionGroup(IActionGroup data);

	#endregion Interface "IActionGroup" operations 2/20/2026 8:53 AM

	#region Interface "IRoleActionGroupHolder" operations 2/19/2026 2:01 PM

	NewEntityRef AddRoleActionGroupHolder(IRoleActionGroupHolder data);

	void DeleteRoleActionGroupHolder(IRoleActionGroupHolder data);

	IEnumerable<IRoleActionGroupHolder> GetAllRoleActionGroupHolders();

	IRoleActionGroupHolder GetRoleActionGroupHolder(int roleActionGroupHolderRef);

	IEnumerable<IRoleActionGroupHolder> GetRoleActionGroupHolders(List<int> roleActionGroupHolderRefs);

	void UpdateRoleActionGroupHolder(IRoleActionGroupHolder data);

	#endregion Interface "IRoleActionGroupHolder" operations 2/19/2026 2:01 PM

	#region Interface "IActionActionGroupHolder" operations 2/19/2026 2:01 PM

	NewEntityRef AddActionActionGroupHolder(IActionActionGroupHolder data);

	void DeleteActionActionGroupHolder(IActionActionGroupHolder data);

	IActionActionGroupHolder GetActionActionGroupHolder(int actionActionGroupHolderRef);

	IEnumerable<IActionActionGroupHolder> GetActionActionGroupHolders(List<int> actionActionGroupHolderRefs);

	IEnumerable<IActionActionGroupHolder> GetAllActionActionGroupHolders();

	void UpdateActionActionGroupHolder(IActionActionGroupHolder data);

	#endregion Interface "IActionActionGroupHolder" operations 2/19/2026 2:01 PM

	#region Interface "IApiToken" operations 4/1/2025 11:13 AM

	NewEntityRef AddApiToken(IApiToken data);

	void DeleteApiToken(IApiToken data);

	IEnumerable<IApiToken> GetAllApiTokens();

	IApiToken GetApiToken(int apiTokenRef);

	IEnumerable<IApiToken> GetApiTokens(List<int> apiTokenRefs);

	void UpdateApiToken(IApiToken data);

	#endregion Interface "IApiToken" operations 4/1/2025 11:13 AM

	//start
}