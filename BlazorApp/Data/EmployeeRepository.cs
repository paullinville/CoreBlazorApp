using BlazorApp.Classes;
using EmployeeData.Client;
using EmployeeData.Common.Models;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using SecurityModel.Common;

namespace BlazorApp.Data;

public class EmployeeRepository : ClientRepositoryBase, IEmployeeRepository
{
	private static List<MidlandUserGeneralModel> FullUsers;
	private static List<UserSelectModelExpanded> Users;
	private Task<MidlandUserGeneralModel> _currentUser;

	public EmployeeRepository(HttpClient httpClient, ISecurityModelToken securityModel, IEventChannelBus bus, ClientSettings clientSettings)
		: base(httpClient, securityModel, bus, clientSettings)
	{
	}

	public async Task<List<UserSelectModelExpanded>> GetActiveSelectionUsers()
	{
		if (Users == null)
		{
			await _securityModel.SetAuthorization(_httpClient);
			var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
									.GetUserSummaryList(null);
			Users = ProcessResponse(response) ?? new List<UserSelectModelExpanded>();

			Users = Users.Values().OrderBy(r => r.LastNameFirst).ToList();
		}
		return Users;
	}

	public async Task<List<MidlandUserGeneralModel>> GetActiveUsers()
	{
		if (FullUsers == null)
		{
			await _securityModel.SetAuthorization(_httpClient);
			var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
									.GetUserPaged((new MidlandUserCriteria { Status = 'A', PageNumber = 1, PageSize = int.MaxValue, CostCenterCode = new List<string> { "14130", "12400" } }).ToQueryString());
			FullUsers = ProcessResponse(response).Results ?? new List<MidlandUserGeneralModel>();

			FullUsers = FullUsers.Values().OrderBy(r => r.LastNameFirst).ToList();
		}
		return FullUsers;
	}

	public async Task<List<UserSelectModelExpanded>> GetUsersBy(string name)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
								.GetUserSummaryList((new MidlandUserListCriteria { Name = name }).ToQueryString());

		var model = ProcessResponse(response) ?? new List<UserSelectModelExpanded>();

		return model;
	}

	public Task<MidlandUserGeneralModel> CurrentUser => _currentUser ??= LoadCurrentUserAsync();

	public async Task<MidlandUserGeneralModel> GetUser(int userRef)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEmployeeDataApiClient>(_httpClient)
								.GetUser(userRef);

		return ProcessResponse(response);
	}

	private async Task<MidlandUserGeneralModel> LoadCurrentUserAsync()
	{
		var token = await _securityModel.GetSecurityToken();
		var userRefValue = token?.Claims.FirstOrDefault(claim => string.Equals(claim.Type, "userRef", StringComparison.OrdinalIgnoreCase))?.Value;
		if (!int.TryParse(userRefValue, out var userRef))
		{
			throw new InvalidOperationException("The security token does not contain a valid userRef claim.");
		}

		return await GetUser(userRef);
	}
}
