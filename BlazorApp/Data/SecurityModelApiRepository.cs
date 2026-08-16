using BlazorApp.Classes;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using SecurityModel.Client;
using SecurityModel.Common.Models;

namespace BlazorApp.Data;

public class SecurityModelApiRepository : ClientRepositoryBase, ISecurityModelApiRepository
{
	public SecurityModelApiRepository(HttpClient httpClient, ISecurityModelToken securityModel, IEventChannelBus eventBus, ClientSettings clientSettings)
	: base(httpClient, securityModel, eventBus, clientSettings)
	{
	}

	public async Task<string> ApiToken()
	{
		await SetAuth();

		var response = await RestClient.For<ISecurityModelApiClient>(_httpClient).GetApplicationApiTokenv2();
		//var found = ProcessResponse(response).Values().ToList();
		return response.StringContent;
	}

	public async Task<List<ApplicationSummary>> GetApplications()
	{
		await SetAuth();

		var response = await RestClient.For<ISecurityModelApiClient>(_httpClient).GetApplicationSummaryList(null);
		var found = ProcessResponse(response).Values().ToList();
		return found;
	}
}