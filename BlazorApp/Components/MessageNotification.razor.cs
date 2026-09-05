using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

namespace BlazorApp.Components;

public partial class MessageNotification : ISubscriber
{
	public TelerikNotification Notification { get; set; } = default!;

	[Inject]
	private IEventChannelBus EventChannelBus { get; set; } = default!;



	public void ChannelNotification<T>(IChannelEvent<T> Evt)
	{
		if (Evt.Value is Midland.Core.Common.IMidlandResult midlandResult)
		{
			_ = ShowMessages(midlandResult);
		}
	}

	public async Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
	{
		if (Evt.Value is Midland.Core.Common.IMidlandResult midlandResult)
		{
			await ShowMessages(midlandResult);
		}
	}

	public int NotificationOrder()
	{
		return 0;
	}

	public async Task ShowMessages(Midland.Core.Common.IMidlandResult midlandResult)
	{
		foreach (var message in midlandResult.Messages.Values())
		{
			Notification.Show(new NotificationModel
			{
				Text = message,
				ThemeColor = "info",
				CloseAfter = 0,
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