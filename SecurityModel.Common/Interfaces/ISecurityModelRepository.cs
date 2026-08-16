using Midland.Core.Database;
using Midland.Core.Validation;
using SecurityModel.Common.Dto;
using SecurityModel.Common.Models;
using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Interfaces;

public delegate int NewEntityRef();

public partial interface ISecurityModelRepository : IRepository, IValidationData
{
	NewEntityRef AddAction(IAction data);

	Dictionary<string, ApplicationDto> ApplicationSlugDic();

	int DeleteRolesActionGroups(int roleRef);

	int DeleteRolesActions(int roleRef);

	List<IAction> GetActionGroupActions(int actionGroupRef);

	List<IActionActionGroupHolder> GetActionGroupHolders(int actionGroupRef);

	IEnumerable<IMidlandUser> GetAllUsers();

	IApiToken GetApiTokenForApplication(int applicatoinRef);

	IApplication GetApplication(Guid ApplicationGuid);

	List<IActionGroup> GetApplicationActionGroups(int applicationRef);

	IEnumerable<IApplicationUserAction> GetApplicationActionsUsers(string applicationSlug, List<string> actionNames);

	IEnumerable<IApplicationUserAction> GetApplicationActionUsers(string applicationSlug, string actionName);

	IContext GetApplicationContext(int applicationRef);

	IEnumerable<IApplicationContextRoleUserHolder> GetApplicationContextRoleUserHolders(int applicationRef, int UserRef);

	IEnumerable<IApplication> GetApplications(IEnumerable<string> slugs);

	IEnumerable<IActionGroup> GetApplicationsActionGroups(int applicationRef);

	IEnumerable<IApplicationAction> GetApplicationsActions(int applicationRef, bool? active = true);

	IDictionary<Guid, List<IApplicationUserAction>> GetApplicationsUserActions(IEnumerable<Guid> appId, int userRef);

	IDictionary<Guid, List<IApplicationUserAction>> GetApplicationsUserActions(IEnumerable<string> applicationSlugs, int userRef);

	IDictionary<Guid, List<IApplicationUserAction>> GetApplicationsUserActions(IEnumerable<int> applicationRefs, int userRef);

	IEnumerable<IApplicationUserAction> GetApplicationUserActions(Guid appId, int userRef);

	IApplication GetApplicationViaApiName(string apiName);

	IEnumerable<IApplication> GetDefaultApplications();

	Employee GetEmployee(int? userRef);

	IEnumerable<AuditModel> GetLastLatesestUsersFromAudits(int applicationRef, int take, int? lastAuditRef);

	IEnumerable<IRoleActionHolder> GetRoleActionHolders(int roleRef);

	IEnumerable<IApplicationUserRoleHolder> GetRoleApplicationUserRoleHolder(int roleRef);

	IEnumerable<IApplicationUserRoleHolder> GetRoleApplicationUserRoleHolder(int applicationRef, int userRef);

	IEnumerable<IRoleActionGroupHolder> GetRolesActionGroupHolders(int roleRef);

	List<UserRoleModel> GetRoleUsers(ApplicationUserRoleCriteria criteria);

	IEnumerable<IServiceTokenOwner> GetServiceTokenOwners(Guid Service_Token_Id);

	IMidlandUser GetUser(int userRef);

	IServiceToken GetUsersServiceToken(int userRef, Guid tokenId);

	IEnumerable<IServiceToken> GetUsersServiceTokens(int userRef);

	IEnumerable<IActionGroup> SearchActionGroups(ActionGroupCriteria crit);
}