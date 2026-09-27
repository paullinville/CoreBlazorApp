using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeData.Common.Models;
using Midland.Core.Common;

namespace EmployeeData.Common;

public interface IEmployeeRepository
{
    Task<List<UserSelectModelExpanded>> GetActiveSelectionUsers();

    Task<List<MidlandUserGeneralModel>> GetActiveUsers();

    Task<List<UserSelectModelExpanded>> GetUsersBy(string name);

    Task<MidlandUserGeneralModel> GetUser(int userRef);

    Task<MidlandUserGeneralModel> CurrentUser { get; }
}
