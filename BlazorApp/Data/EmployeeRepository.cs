using BlazorApp.Common;
using EmployeeData.Client;
using EmployeeData.Common.Models;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using SecurityModel.Common;

namespace BlazorApp.Data;

public class EmployeeRepository : BlazorClientRepositoryBase, IEmployeeRepository
{
    private static List<MidlandUserGeneralModel>? FullUsers;
    private static List<UserSelectModelExpanded>? Users;
    private Task<MidlandUserGeneralModel>? _currentUser;
    private readonly ISecurityModelToken _securityToken;

    public EmployeeRepository(HttpClient httpClient, IEventChannelBus bus, ClientSettings clientSettings, ISecurityModelToken securityToken)
        : base(httpClient, bus, clientSettings)
    {
        _securityToken = securityToken;
    }

    public async Task<List<UserSelectModelExpanded>> GetActiveSelectionUsers()
    {
        if (Users == null)
        {
            var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
                                    .GetUserSummaryList(null);
            Users = await ProcessResponse(response) ?? new List<UserSelectModelExpanded>();

            Users = Users.Values().OrderBy(r => r.LastNameFirst).ToList();
        }
        return Users;
    }

    public async Task<List<MidlandUserGeneralModel>> GetActiveUsers()
    {
        if (FullUsers == null)
        {
            var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
                                    .GetUserPaged((new MidlandUserCriteria { Status = 'A', PageNumber = 1, PageSize = int.MaxValue, CostCenterCode = new List<string> { "14130", "12400" } }).ToQueryString());
            FullUsers = (await ProcessResponse(response)).Results ?? new List<MidlandUserGeneralModel>();

            FullUsers = FullUsers.Values().OrderBy(r => r.LastNameFirst).ToList();
        }
        return FullUsers;
    }

    public async Task<List<UserSelectModelExpanded>> GetUsersBy(string name)
    {
        var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
                                .GetUserSummaryList((new MidlandUserListCriteria { Name = name }).ToQueryString());

        var model = await ProcessResponse(response) ?? new List<UserSelectModelExpanded>();

        return model;
    }

    public Task<MidlandUserGeneralModel> CurrentUser => _currentUser ??= LoadCurrentUserAsync();

    public async Task<MidlandUserGeneralModel> GetUser(int userRef)
    {
        var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
                                .GetUser(userRef);

        return await ProcessResponse(response);
    }

    private async Task<MidlandUserGeneralModel> LoadCurrentUserAsync()
    {
        var token = await _securityToken.GetSecurityToken();
        var userRefValue = token?.Claims.FirstOrDefault(claim => string.Equals(claim.Type, "userRef", StringComparison.OrdinalIgnoreCase))?.Value;
        if (!int.TryParse(userRefValue, out var userRef))
        {
            throw new InvalidOperationException("The security token does not contain a valid userRef claim.");
        }

        return await GetUser(123);
    }
}