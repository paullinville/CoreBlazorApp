using BlazorApp.Common;
using BlazorApp.Models;
using EATTS.Client;
using EATTS.Common.Models;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;

namespace BlazorApp.Data;

public class EattsRepository : BlazorClientRepositoryBase, IEattsApiRepository
{
    public EattsRepository(HttpClient httpClient, IEventChannelBus eventBus, ClientSettings clientSettings)
        : base(httpClient, eventBus, clientSettings)
    {
    }

    public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostLog(eattsEntryModel);

        var found = await ProcessResponseAsync(response);

        return found;
    }
}