using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

namespace BlazorApp.Components;

public partial class ErrorNotification : ISubscriber
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

	public void ChannelNotification(IChannelEvent Evt)
	{
		if (Evt is ApiValidationEvent validation)
		{
			_ = ShowErrors(validation.Value);
		}
	}

	public void ChannelNotification<T>(IChannelEvent<T> Evt)
	{
		if (Evt is ApiValidationEvent validation)
		{
			_ = ShowErrors(validation.Value);
		}

		if (Evt is ApiErrorEvent error)
		{
			_ = ShowErrors(error.Value);
		}
	}

	public Task ChannelNotificationAsync(IChannelEvent Evt)
	{
		ChannelNotification(Evt);
		return Task.CompletedTask;
	}

	public Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
	{
		ChannelNotification(Evt);
		return Task.CompletedTask;
	}

	public int NotificationOrder()
	{
		return 0;
	}

	public async Task ShowErrors(ErrorResponse errorResponse)
	{
		LatestErrorResponse = errorResponse;
		await InvokeAsync(StateHasChanged);

		foreach (var message in errorResponse.Messages.Values())
		{
			Notification.Show(new NotificationModel
			{
				Text = message,
				ThemeColor = "warning",
				CloseAfter = 0
			});
		}

		foreach (var error in errorResponse.Errors.Values())
		{
			Notification.Show(new NotificationModel
			{
				Text = $"{error.Name}({error.Type}): {error.Value}",
				ThemeColor = "error",
				CloseAfter = 0
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
		EventChannelBus.Subscribe((IChannelEvent)new ApiValidationEvent(), this);
		EventChannelBus.Subscribe((IChannelEvent)new ApiErrorEvent(), this);
		EventChannelBus.Subscribe((IChannelEvent)new ActionsMissingEvent(), this);
		EventChannelBus.Subscribe((IChannelEvent)new SecurityErrorEvent(), this);
		base.OnInitialized();
	}
}
