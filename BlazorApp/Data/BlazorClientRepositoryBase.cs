using BlazorApp.Common;
using Midland.Core.Api;
using Midland.Core.Client;
using Midland.Core.SimpleMessageBus;
using Newtonsoft.Json;

namespace BlazorApp.Data;

public class BlazorClientRepositoryBase<TApi> : ClientRepositoryAsyncBase<TApi>, ISubscriber where TApi : IApiClient
{
    private readonly ClientSettings _clientSettings;
    private readonly IConfiguration _configuration;

    public BlazorClientRepositoryBase(HttpClient httpClient,
                                      IEventChannelBus eventBus,
                                      ClientSettings clientSettings,
                                      JsonSerializerSettings jsonSettings,
                                      IConfiguration configuration) : base(eventBus, jsonSettings, httpClient)
    {
        _clientSettings = clientSettings;
        _configuration = configuration;
        _eventBus.Subscribe(new BeforeApiCallEvent(), (ISubscriber)this);
    }

    /// <summary>
    /// Override this method to handle channel notifications. This method is called when a channel event is published to the event bus.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="evt"></param>
    public void ChannelNotification<T>(IChannelEvent<T> evt)
    {
        if (_clientSettings.Environment?.Trim().ToLowerInvariant() == AppConstants.DevelopmentEnvironment &&
            evt is BeforeApiCallEvent beforeApiCallEvent)
        {
            if (!beforeApiCallEvent.Value.DefaultRequestHeaders.Contains(ApiConstants.DeveloperModeAuthorizationHeader) && _configuration["UseDevMode"] == "true")
            {
                beforeApiCallEvent.Value.DefaultRequestHeaders.Add(ApiConstants.DeveloperModeAuthorizationHeader, "true");
            }

            AddHeaders(beforeApiCallEvent.Value);
        }
    }

    /// <summary>
    /// Override this method to add custom headers to the HttpClient before making API calls. This method is called when a BeforeApiCallEvent is published to the event bus.
    /// </summary>
    /// <param name="client">The HttpClient instance to which custom headers can be added. </param>
    protected virtual void AddHeaders(HttpClient client)
    {
        //Override this method to add custom headers to the HttpClient before making API calls.
    }

    /// <summary>
    /// Override this method to handle channel notifications asynchronously. This method is called when a channel event is published to the event bus.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Evt"></param>
    /// <returns></returns>
    public virtual Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
    {
        return Task.CompletedTask;
    }

    public int NotificationOrder()
    {
        return 0;
    }

    protected virtual string MakeEntryKey()
    {
        return $"Api error with null response {_clientSettings.ApplicationName}";
    }
}