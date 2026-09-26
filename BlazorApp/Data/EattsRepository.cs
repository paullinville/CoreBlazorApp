using BlazorApp.Common;
using EATTS.Client;
using Midland.Core.SimpleMessageBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BlazorApp.Data;

public class EattsRepository : BlazorClientRepositoryBase<IEATTSApiClient>, IEattsApiRepository
{
    public EattsRepository(HttpClient httpClient, IEventChannelBus eventBus, ClientSettings clientSettings, JsonSerializerSettings jsonSettings, IConfiguration configuration)
        : base(httpClient, eventBus, clientSettings, jsonSettings, configuration)
    {
    }

    public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        var response = await Client.PostLog(eattsEntryModel);

        var found = await ProcessResponseAsync(response);

        return found;
    }
}