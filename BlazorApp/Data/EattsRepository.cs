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
    private readonly IEmployeeRepository _empRepo;

    public EattsRepository(HttpClient httpClient, ISecurityModelToken securityModel, IEmployeeRepository empRepo, IEventChannelBus eventBus, ClientSettings clientSettings, IEattsApiRepository eattsRepo)
        : base(httpClient, securityModel, eventBus, clientSettings, eattsRepo, empRepo)
    {
        _empRepo = empRepo;
    }

    public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        await _securityToken.SetAuthorization(_httpClient);

        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostLog(eattsEntryModel);

        var found = await ProcessResponse(response);

        return found;
    }
}