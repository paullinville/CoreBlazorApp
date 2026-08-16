using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

namespace BlazorApp.Components;

public partial class MessageNotification : ISubscriber
{
	public TelerikNotification Notification { get; set; }

	[Inject]
	private IEventChannelBus EventChannelBus { get; set; } = default!;

	public void ChannelNotification(IChannelEvent Evt)
	{
		if (Evt is ResultsMessageEvent messageEvent)
		{
			ShowMessages(messageEvent.Value);
		}
	}

	public void ChannelNotification<T>(IChannelEvent<T> Evt)
	{
		if (Evt is ResultsMessageEvent messageEvent)
		{
			ShowMessages(messageEvent.Value);
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

	public async Task ShowMessages(IMidlandResult MidlandResult)
	{
		foreach (var message in MidlandResult.Messages)
		{
			Notification.Show(new NotificationModel
			{
				Text = message,
				ThemeColor = "info",
				CloseAfter = 0
			});
		}
	}

	protected override void OnInitialized()
	{
		EventChannelBus.Subscribe((IChannelEvent)new ResultsMessageEvent(), this);
		base.OnInitialized();
	}
}