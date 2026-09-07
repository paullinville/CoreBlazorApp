using BlazorApp.Common;
using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

namespace BlazorApp.Components;

public partial class ApiMessageNotification : ISubscriber
{
    public TelerikNotification Notification { get; set; } = default!;

    [Inject]
    private IEventChannelBus EventChannelBus { get; set; } = default!;

    public void ChannelNotification<T>(IChannelEvent<T> Evt)
    {
        if (Evt.Value is List<string> messages)
        {
            _ = ShowMessages(messages);
        }
    }

    public async Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
    {
        if (Evt.Value is List<string> messages)
        {
            await ShowMessages(messages);
        }
    }

    public int NotificationOrder()
    {
        return 5;
    }

    public async Task ShowMessages(List<string> messages)
    {
        messages.Reverse();
        foreach (var message in messages)
        {
            Notification.Show(new NotificationModel
            {
                Text = message,
                ThemeColor = AppConstants.InfoColor,
                CloseAfter = 10000,
                ShowIcon = false,
            });
        }
    }

    protected override void OnInitialized()
    {
        EventChannelBus.Subscribe(new ResultsMessageEvent(), this);
        base.OnInitialized();
    }
}