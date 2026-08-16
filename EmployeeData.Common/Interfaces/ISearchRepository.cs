using EmployeeData.Common.Models;
using Midland.Core.Common;
using System.Collections.Generic;

namespace EmployeeData.Common.Interfaces;

public interface ISearchRepository
{
	PageResultsModel<MidlandUserGeneralModel> FilterUsers(MidlandUserCriteria crit);

	IEnumerable<IMidlandUser> GetCostCenterUsers(int costCenter);

	IEnumerable<IMidlandUser> GetDepartmentUsers(int deptRef);

	IEnumerable<IMidlandUser> GetUserList(MidlandUserListCriteria model);

	PageResultsModel<MidlandUserGeneralModel> PageUsers(PagedUserSearchCriteria crit);

	List<MidlandUserGeneralModel> SearchUsers(IUserSearchCriteria crit);
}