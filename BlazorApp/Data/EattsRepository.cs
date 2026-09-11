using BlazorApp.Common;
using EATTS.Client;
using Midland.Core.SimpleMessageBus;
using Newtonsoft.Json;

namespace BlazorApp.Data;

public class EattsRepository : BlazorClientRepositoryBase<IEATTSApiClient>, IEattsApiRepository
{
    public EattsRepository(HttpClient httpClient, IEventChannelBus eventBus, ClientSettings clientSettings, JsonSerializerSettings jsonSettings)
        : base(httpClient, eventBus, clientSettings, jsonSettings)
    {
    }

    public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        var response = await Client.PostLog(eattsEntryModel);

        var found = await ProcessResponseAsync(response);

        return found;
    }
}