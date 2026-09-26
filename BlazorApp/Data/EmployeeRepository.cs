using BlazorApp.Common;
using EmployeeData.Client;
using EmployeeData.Common.Models;
using Midland.Core.Client;
using Midland.Core.SimpleMessageBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BlazorApp.Data;

public class EmployeeRepository : BlazorClientRepositoryBase<IEmployeeDataApiClient>, IEmployeeRepository
{
    private static List<MidlandUserGeneralModel>? FullUsers;
    private static List<UserSelectModelExpanded>? Users;
    private Task<MidlandUserGeneralModel>? _currentUser;
    private readonly ISecurityModelToken _securityToken;

    public EmployeeRepository(HttpClient httpClient, IEventChannelBus bus, ClientSettings clientSettings, JsonSerializerSettings jsonSettings, ISecurityModelToken securityToken, IConfiguration configuration)
        : base(httpClient, bus, clientSettings, jsonSettings, configuration)
    {
        _securityToken = securityToken;
    }

    public async Task<List<UserSelectModelExpanded>> GetActiveSelectionUsers()
    {
        if (Users == null)
        {
            var response = await Client.GetUserSummaryList(null);
            Users = await ProcessResponseAsync(response) ?? new List<UserSelectModelExpanded>();

            Users = Users.Values().OrderBy(r => r.LastNameFirst).ToList();
        }
        return Users;
    }

    public async Task<List<MidlandUserGeneralModel>> GetActiveUsers()
    {
        if (FullUsers == null)
        {
            var response = await Client.GetUserPaged((new MidlandUserCriteria { Status = 'A', PageNumber = 1, PageSize = int.MaxValue, CostCenterCode = new List<string> { "14130", "12400" } }).ToQueryString());
            FullUsers = (await ProcessResponseAsync(response)).Results ?? new List<MidlandUserGeneralModel>();

            FullUsers = FullUsers.Values().OrderBy(r => r.LastNameFirst).ToList();
        }
        return FullUsers;
    }

    public async Task<List<UserSelectModelExpanded>> GetUsersBy(string name)
    {
        var response = await Client.GetUserSummaryList((new MidlandUserListCriteria { Name = name }).ToQueryString());

        var model = await ProcessResponseAsync(response) ?? new List<UserSelectModelExpanded>();

        return model;
    }

    public Task<MidlandUserGeneralModel> CurrentUser => _currentUser ??= LoadCurrentUserAsync();

    public async Task<MidlandUserGeneralModel> GetUser(int userRef)
    {
        var response = await Client.GetUser(userRef);

        return await ProcessResponseAsync(response);
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