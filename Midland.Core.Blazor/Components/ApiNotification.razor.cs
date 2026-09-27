using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

namespace Midland.Core.Blazor.Components;

public partial class ApiNotification : ISubscriber
{
    private const string ReportableMarker = "\u2063";
    private const string InfoColor = "info";
    private const string WarningColor = "warning";
    private const string ErrorColor = "error";

    public TelerikNotification ValidationNotification { get; set; } = default!;

    public TelerikNotification GeneralNotification { get; set; } = default!;

    private ErrorResponse? LatestErrorResponse { get; set; }

    [Inject]
    private IEventChannelBus EventChannelBus { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private IErrorReportState ErrorReportState { get; set; } = default!;

    public void ChannelNotification<T>(IChannelEvent<T> Evt)
    {
        if (Evt.Value is not ErrorResponse errorResponse)
        {
            return;
        }

        _ = Evt switch
        {
            ApiErrorEvent => ShowApiErrors(errorResponse),
            ApiValidationEvent => ShowValidationErrors(errorResponse),
            ActionsMissingEvent or SecurityErrorEvent => ShowSecurityErrors(errorResponse),
            _ => Task.CompletedTask,
        };
    }

    public Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
    {
        if (Evt.Value is not ErrorResponse errorResponse)
        {
            return Task.CompletedTask;
        }

        return Evt switch
        {
            ApiErrorEvent => ShowApiErrors(errorResponse),
            ApiValidationEvent => ShowValidationErrors(errorResponse),
            ActionsMissingEvent or SecurityErrorEvent => ShowSecurityErrors(errorResponse),
            _ => Task.CompletedTask,
        };
    }

    public int NotificationOrder()
    {
        return 0;
    }

    public async Task ShowApiErrors(ErrorResponse errorResponse)
    {
        LatestErrorResponse = errorResponse;
        await InvokeAsync(StateHasChanged);

        foreach (var error in errorResponse.Errors.Values())
        {
            ShowNotification(GeneralNotification, $"{error.Name}({error.Type}): {error.Value}", ErrorColor, isReportable: true);
        }

        foreach (var message in errorResponse.Messages.Values())
        {
            ShowNotification(GeneralNotification, message, InfoColor, isReportable: true);
        }
    }

    public async Task ShowValidationErrors(ErrorResponse errorResponse)
    {
        await InvokeAsync(StateHasChanged);

        foreach (var error in errorResponse.Errors.Values())
        {
            ShowNotification(GeneralNotification, $"{error.Name}: {error.Value}", AppConstants.MidlandOrange);
        }
    }

    public async Task ShowSecurityErrors(ErrorResponse errorResponse)
    {
        await InvokeAsync(StateHasChanged);

        foreach (var error in errorResponse.Errors.Values())
        {
            ShowNotification(GeneralNotification, $"{error.Name}({error.Type}): {error.Value}", WarningColor);
        }
    }

    private static void ShowNotification(TelerikNotification notification, string text, string themeColor, bool isReportable = false)
    {
        notification.Show(new NotificationModel
        {
            Text = isReportable ? MarkAsReportable(text) : text,
            ThemeColor = themeColor,
            CloseAfter = 0,
            ShowIcon = false
        });
    }

    private static string MarkAsReportable(string text)
    {
        return string.Concat(text, ReportableMarker);
    }

    private static string GetDisplayText(string? text)
    {
        return text?.Replace(ReportableMarker, string.Empty, StringComparison.Ordinal) ?? string.Empty;
    }

    private static bool CanReport(NotificationModel notificationModel)
    {
        return notificationModel.Text?.Contains(ReportableMarker, StringComparison.Ordinal) == true;
    }

    private void ReportCurrentError(NotificationModel notificationModel)
    {
        if (LatestErrorResponse is null)
        {
            return;
        }

        GeneralNotification.Hide(notificationModel);
        ErrorReportState.SetPendingError(LatestErrorResponse);
        NavigationManager.NavigateTo("/report-error");
    }

    protected override void OnInitialized()
    {
        EventChannelBus.Subscribe((IChannelEvent)new ApiErrorEvent(), this);
        EventChannelBus.Subscribe((IChannelEvent)new ApiValidationEvent(), this);
        EventChannelBus.Subscribe((IChannelEvent)new ActionsMissingEvent(), this);
        EventChannelBus.Subscribe((IChannelEvent)new SecurityErrorEvent(), this);
        base.OnInitialized();
    }
}