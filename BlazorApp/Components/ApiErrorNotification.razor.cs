using BlazorApp.Common;
using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorApp.Components;

public partial class ApiErrorNotification : ISubscriber
{
    [Parameter]
    public ErrorResponse Error { get; set; } = new();

    public TelerikNotification Notification { get; set; } = default!;

    private ErrorResponse? LatestErrorResponse { get; set; }

    [Inject]
    private IEventChannelBus EventChannelBus { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private ErrorReportState ErrorReportState { get; set; } = default!;

    public void ChannelNotification<T>(IChannelEvent<T> Evt)
    {
        if (Evt.Value is ErrorResponse errorResponse)
        {
            _ = ShowErrors(errorResponse);
        }
    }

    public Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
    {
        ChannelNotification(Evt);
        return Task.CompletedTask;
    }

    public int NotificationOrder()
    {
        return 1;
    }

    public async Task ShowErrors(ErrorResponse errorResponse)
    {
        LatestErrorResponse = errorResponse;
        await InvokeAsync(StateHasChanged);

        if (errorResponse.Code == ErrorCodes.ApplicationUnhandledException)
        {
            Notification.Show(new NotificationModel
            {
                Text = errorResponse.Description,
                ThemeColor = AppConstants.WarningColor,
                CloseAfter = 0,
                ShowIcon = false
            });
        }
        else
        {
            foreach (var error in errorResponse.Errors.Values())
            {
                Notification.Show(new NotificationModel
                {
                    Text = $"{error.Name}({error.Type}): {error.Value}",
                    ThemeColor = AppConstants.ErrorColor,
                    CloseAfter = 0,
                    ShowIcon = false
                });
            }
        }

        foreach (var message in errorResponse.Messages.Values())
        {
            Notification.Show(new NotificationModel
            {
                Text = message,
                ThemeColor = AppConstants.InfoColor,
                CloseAfter = 0,
                ShowIcon = false
            });
        }
    }

    private void ReportCurrentError(NotificationModel notificationModel)
    {
        if (LatestErrorResponse is null)
        {
            return;
        }

        Notification.Hide(notificationModel);
        ErrorReportState.SetPendingError(LatestErrorResponse);
        NavigationManager.NavigateTo("/report-error");
    }

    protected override void OnInitialized()
    {
        EventChannelBus.Subscribe((IChannelEvent)new ApiErrorEvent(), this);
        base.OnInitialized();
    }
}