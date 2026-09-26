using BlazorApp.Common;
using Midland.Core.SimpleMessageBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestEase;
using SecurityModel.Client;
using SecurityModel.Common.Models;

namespace BlazorApp.Data;

public class SecurityModelApiRepository : BlazorClientRepositoryBase<ISecurityModelApiClient>, ISecurityModelApiRepository
{
    public SecurityModelApiRepository(HttpClient httpClient, IEventChannelBus eventBus, ClientSettings clientSettings, JsonSerializerSettings jsonSettings, IConfiguration configuration)
    : base(httpClient, eventBus, clientSettings, jsonSettings, configuration)
    {
    }

    public async Task<List<ApplicationSummary>> GetApplications()
    {
        var r = await Client.GetApplicationSummaryList(null);
        var found = (await ProcessResponseAsync(r)).Values().ToList();
        return found;
    }

    public async Task<List<ApplicationSummary>> GetApis()
    {
        var response = await RestClient.For<ISecurityModelApiClient>(_httpClient).GetApplicationSummaryList(null);
        var found = (await ProcessResponseAsync(response)).Values().ToList();
        return found.Where(r => r.ApiName.IsNotEmpty()).ToList();
    }
}