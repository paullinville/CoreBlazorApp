using EmployeeData.Common.Models;

namespace Midland.Core.Blazor;

public interface IUsers
{
    Task<List<UserSelectModelExpanded>> GetActiveSelectionUsers();
}