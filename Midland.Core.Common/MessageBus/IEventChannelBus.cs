namespace Midland.Core.SimpleMessageBus;

public interface IEventChannelBus
{
    bool Enabled { get; }

    void Disable();

    void Enable();

    void Publish<T>(IChannelEvent<T> evt);

    Task PublishAsync<T>(IChannelEvent<T> evt);

    void Subscribe(IChannelEvent channelEvent, ISubscriber Subscriber);

    void Subscribe(string channelName, ISubscriber subscriber);

    void UnSubscribe(IChannelEvent channelEvent, ISubscriber Subscriber);

    void UnSubscribe(string channelName, ISubscriber Subscriber);

    void UnSubscribeAll(ISubscriber Subscriber);
}