using BlazorApp.Common;
using Midland.Core.Api;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using System.Net;
using System.Text.Json;

namespace BlazorApp.Data;

public class BlazorClientRepositoryBase : ClientRepositoryAsyncBase
{
    private readonly ClientSettings _clientSettings;
    protected readonly HttpClient _httpClient;

    public BlazorClientRepositoryBase(HttpClient httpClient,
                                      IEventChannelBus eventBus,
                                      ClientSettings clientSettings) : base(eventBus)
    {
        _httpClient = httpClient;

        _clientSettings = clientSettings;
    }

    protected override Task HandleErrorResponse(ErrorResponse errorResponse)
    {
        _eventBus.Publish(new ApplicationErrorEvent(errorResponse));

        return Task.CompletedTask;
    }

    protected virtual string MakeEntryKey()
    {
        return $"Api error with null response {_clientSettings.ApplicationName}";
    }
}