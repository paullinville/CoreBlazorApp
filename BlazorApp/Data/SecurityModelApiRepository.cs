using BlazorApp.Common;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using SecurityModel.Client;
using SecurityModel.Common.Models;

namespace BlazorApp.Data;

public class SecurityModelApiRepository : BlazorClientRepositoryBase, ISecurityModelApiRepository
{
    public SecurityModelApiRepository(HttpClient httpClient, IEventChannelBus eventBus, ClientSettings clientSettings)
    : base(httpClient, eventBus, clientSettings)
    {
    }

    public async Task<string> ApiToken()
    {
        var response = await RestClient.For<ISecurityModelApiClient>(_httpClient).GetApplicationApiTokenv2();
        //var found = ProcessResponse(response).Values().ToList();
        return response.StringContent ?? "";
    }

    public async Task<List<ApplicationSummary>> GetApplications()
    {
        var response = await RestClient.For<ISecurityModelApiClient>(_httpClient).GetApplicationSummaryList(null);
        var found = (await ProcessResponseAsync(response)).Values().ToList();
        return found;
    }
}