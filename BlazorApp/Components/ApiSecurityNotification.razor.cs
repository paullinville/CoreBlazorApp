using BlazorApp.Common;
using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

namespace BlazorApp.Components;

public partial class ApiSecurityNotification : ISubscriber
{
    public TelerikNotification Notification { get; set; } = default!;

    [Inject]
    private IEventChannelBus EventChannelBus { get; set; } = default!;

    public void ChannelNotification<T>(IChannelEvent<T> Evt)
    {
        if (Evt.Value is ErrorResponse errorResponse)
        {
            _ = ShowValidationErrors(errorResponse);
        }
    }

    public Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
    {
        ChannelNotification(Evt);
        return Task.CompletedTask;
    }

    public int NotificationOrder()
    {
        return 12;
    }

    public async Task ShowValidationErrors(ErrorResponse errorResponse)
    {
        await InvokeAsync(StateHasChanged);

        foreach (var error in errorResponse.Errors.Values())
        {
            Notification.Show(new NotificationModel
            {
                Text = $"{error.Name}({error.Type}): {error.Value}",
                ThemeColor = AppConstants.WarningColor,
                CloseAfter = 0,
                ShowIcon = false
            });
        }
    }

    protected override void OnInitialized()
    {
        EventChannelBus.Subscribe((IChannelEvent)new ActionsMissingEvent(), this);
        EventChannelBus.Subscribe((IChannelEvent)new SecurityErrorEvent(), this);
        base.OnInitialized();
    }
}