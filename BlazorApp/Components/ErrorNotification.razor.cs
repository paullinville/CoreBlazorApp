using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

namespace BlazorApp.Components;

public partial class ErrorNotification : ISubscriber
{
	[Parameter]
	public ErrorResponse Error { get; set; }

	public TelerikNotification Notification { get; set; }

	[Inject]
	private IEventChannelBus EventChannelBus { get; set; } = default!;

	public void ChannelNotification(IChannelEvent Evt)
	{
		if (Evt is ApiValidationEvent validation)
		{
			ShowErrors(validation.Value);
		}
	}

	public void ChannelNotification<T>(IChannelEvent<T> Evt)
	{
		if (Evt is ApiValidationEvent validation)
		{
			ShowErrors(validation.Value);
		}
	}

	public Task ChannelNotificationAsync(IChannelEvent Evt)
	{
		ChannelNotification(Evt);
		return Task.CompletedTask;
	}

	public Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
	{
		throw new NotImplementedException();
	}

	public int NotificationOrder()
	{
		return 0;
	}

	public async Task ShowErrors(ErrorResponse Error)
	{
		foreach (var message in Error.Messages.Values())
		{
			Notification.Show(new NotificationModel
			{
				Text = message,
				ThemeColor = "warning",
				CloseAfter = 0
			});
		}
		foreach (var error in Error.Errors.Values())
		{
			Notification.Show(new NotificationModel
			{
				Text = $"{error.Name}({error.Type}): {error.Value}",
				ThemeColor = "error",
				CloseAfter = 0
			});
		}
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