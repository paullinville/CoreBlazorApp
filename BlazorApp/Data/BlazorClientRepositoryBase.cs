using BlazorApp.Common;
using Midland.Core.Api;
using Midland.Core.Client;
using Midland.Core.SimpleMessageBus;
using Newtonsoft.Json;
using RestEase;

namespace BlazorApp.Data;

public class BlazorClientRepositoryBase<TApi> : ClientRepositoryAsyncBase<TApi> where TApi : IApiClient
{
    private readonly ClientSettings _clientSettings;

    public BlazorClientRepositoryBase(HttpClient httpClient,
                                      IEventChannelBus eventBus,
                                      ClientSettings clientSettings,
                                      JsonSerializerSettings jsonSettings) : base(eventBus, jsonSettings, httpClient)
    {
        _clientSettings = clientSettings;
    }

    protected virtual string MakeEntryKey()
    {
        return $"Api error with null response {_clientSettings.ApplicationName}";
    }
}