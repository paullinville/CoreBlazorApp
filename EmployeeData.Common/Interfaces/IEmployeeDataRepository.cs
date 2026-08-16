using Midland.Core.Common;
using Midland.Core.Database;
using System.Collections.Generic;

namespace EmployeeData.Common.Interfaces;

public delegate int NewEntityRef();

public partial interface IEmployeeDataRepository : IRepository
{
	void AddUKGCandidateImport(IUKGCandidatesImport dto);

	void AddUKGOpportunityImport(IUKGOpportunitiesImport dto);

	void DeleteParameter(string name);

	IEnumerable<ILocation> GetAllLocations();

	IEnumerable<IMidlandUser> GetAllMidlandUsers();

	IEnumerable<IMidlandUser> GetApiServiceUsers();

	Employee GetEmployee(int? userRef);

	IMidlandUser GetMidlandUser(int userRef);

	IParameter GetParameter(string parameter);

	void UpdateParameter(IParameter dto);
}