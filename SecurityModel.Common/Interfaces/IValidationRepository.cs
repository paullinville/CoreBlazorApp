using Midland.Core.ApplicationSecurity;
using Midland.Core.Validation;
using SecurityModel.Common.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SecurityModel.Common.Interfaces;

public interface IValidationRepository : IValidationData
{
    IMidlandTokenUser CurrentUser();

    bool CurrentUserHasApplicationAction(int applicationRef, string action);

    bool CurrentUserHasApplicationActions(int applicationRef, IEnumerable<string> action);

    bool CurrentUserHasApplicationActions(Guid applicationGuid, IEnumerable<string> action);

    bool CurrentUserHasApplicationActions(string slug, IEnumerable<string> action);

    bool CurrentUserHasSecurityModelAction(string claim);

    IAction GetAction(int actionRef);

    IApplication GetActiveApplication(Guid applicationGuid);

    IApplication GetActiveApplication(string applicationSlug);

    IEnumerable<IApplication> GetActiveApplications(IEnumerable<Guid> applicationGuid);

    IEnumerable<IApplication> GetActiveApplications(IEnumerable<string> applicationSlugs);

    IEnumerable<IApplicationAction> GetActiveApplicationsActions(IEnumerable<Guid> applicationGuid);

    IEnumerable<IApplicationAction> GetActiveApplicationsActions(IEnumerable<string> applicationGuid);

    IApiToken GetApiToken(string applicationSlug);

    IApplication GetApplication(int applicationRef);

    IApplication GetApplication(Guid applicationGuid);
	IApplication GetApplication(string slug);
	IEnumerable<IApplicationAction> GetApplicationActions(Guid applicationGuid);

    IEnumerable<IApplicationAction> GetApplicationActions(int applicationRef, List<int> actionRefs);

    IEnumerable<IApplicationAction> GetApplicationActions(int applicationRef);
	IApplication GetApplicationByApiName(string apiName);
	IContext GetApplicationContext(int applicationRef);

    IEnumerable<IApplicationContextRoleUserHolder> GetApplicationContextRoleUserHolders(int roleRef);

    IEnumerable<IRole> GetApplicationRoles(int applicationRef);

    IEnumerable<IApplicationUserAction> GetApplicationUserActions(Guid applicationGuid);

    IEnumerable<IApplicationUserAction> GetApplicationUserActions(int applicationRef);

    IEnumerable<IApplicationUserRoleHolder> GetApplicationUserRoleHolders(int roleRef);

    IEnumerable<IApplicationUserRoleHolder> GetApplicationUserRoleHolders(int applicationRef, int userRef);

    Employee GetEmployee(int userRef);

    IMidlandApplication GetMidlandApplication(int ApplicationRef);

    IRole GetRole(int roleRef);

    IRoleActionHolder GetRoleAction(RoleActionAddModel model);

    IEnumerable<IRoleActionGroupHolder> GetRoleActionGroupHolders(int roleRef);

    IEnumerable<IRoleActionHolder> GetRoleActionHolders(int roleRef);

    IEnumerable<IRoleRoleHolder> GetRoleRoleHoldersAny(int roleRef);

    IEnumerable<IRoleRoleHolder> GetRoleRoleHoldersChildren(int roleRef);

    IEnumerable<IRoleRoleHolder> GetRoleRoleHoldersParents(int roleRef);

    IEnumerable<IRole> GetRoles(List<int> roleRefs);

    IEnumerable<IRole> GetRolesByApplicationForName(RoleAddModel model);

    ICollectionChangeRequest GetRoleUserRequest(RoleUserCollectionModel request);

    List<UserRoleModel> GetRoleUsers(int roleRef);

    IServiceToken GetServiceToken(Guid id);

    ICollectionChangeRequest GetServiceTokenOwnerRequest(ServiceTokenUpdateModel request);

    IEnumerable<IServiceTokenOwner> GetServiceTokenOwners(Guid id);

    IEnumerable<IServiceToken> GetServiceTokens();

    IEnumerable<IServiceToken> GetServiceTokensForName(string name);

    IMidlandUser GetUser(int userRef);

    ICollectionChangeRequest GetUserRoleRequest(UserRoleCollectionModel request);

    List<IApplicationUserRoleHolder> GetUserRolesForApplication(int userRef, int applicationRef);

    List<IMidlandUser> GetUsers(List<int> userRefs);

    bool HasGatewaySubject();

    bool ServiceVersionValid(int version);

    bool TokenHasApplicationActions(int applicationRef, IEnumerable<string> actions);
}