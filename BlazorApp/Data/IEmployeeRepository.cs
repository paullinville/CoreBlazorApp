using EmployeeData.Common.Models;

namespace BlazorApp.Data;

public interface IEmployeeRepository
{
	Task<List<UserSelectModelExpanded>> GetActiveSelectionUsers();

	Task<List<MidlandUserGeneralModel>> GetActiveUsers();

	Task<List<UserSelectModelExpanded>> GetUsersBy(string name);

	Task<MidlandUserGeneralModel> GetUser(int userRef);

	Task<MidlandUserGeneralModel> CurrentUser { get; }
}
