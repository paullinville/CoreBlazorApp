namespace Midland.Core.SimpleMessageBus;

public interface ISubscriber
{
    void ChannelNotification<T>(IChannelEvent<T> Evt);

    Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt);

    int NotificationOrder();
}