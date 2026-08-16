using SecurityModel.Common.Dto;
using SecurityModel.Common.Models;
using System.Collections.Generic;

namespace SecurityModel.Common.Interfaces;

public interface ISearchRepository
{
	IEnumerable<IApplicationAction> GetActions(int applicationRef);

	IEnumerable<IApplicationAction> GetActions(List<int> actionRefs);

	IEnumerable<IApplicationUserAction> GetApplicationActionUsers(string slug, string actionName);

	IEnumerable<IApplication> GetApplications(string name);

	List<ApplicationRoleActionDto> SearchActionsRoles(ActionsRolesCriteriaModel criteria);

	List<ApplicationDto> SearchApplications(ApplicationCriteria criteria);

	IEnumerable<IAuditReport> SearchAuditReport(AuditReportCriteria crit);

	List<IRole> SearchRoles(RoleCriteriaModel crit);
}