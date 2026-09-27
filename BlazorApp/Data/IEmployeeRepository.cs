using EmployeeData.Common.Models;
using Midland.Core.Blazor;

namespace BlazorApp.Common;

public interface IEmployeeRepository : IUsers
{
    Task<List<MidlandUserGeneralModel>> GetActiveUsers();

    Task<List<UserSelectModelExpanded>> GetUsersBy(string name);

    Task<MidlandUserGeneralModel> GetUser(int userRef);

    Task<MidlandUserGeneralModel> CurrentUser { get; }
}