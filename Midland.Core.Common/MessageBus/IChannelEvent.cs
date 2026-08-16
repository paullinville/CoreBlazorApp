namespace Midland.Core.SimpleMessageBus;

public interface IChannelEvent<T> : IChannelEvent
{
    T Value { get; }
}

public interface IChannelEvent
{
    Dictionary<string, object>? AdditionalValues { get; set; }
    string ChannelName { get; }
    bool Handled { get; set; }
    bool MustHandle { get; set; }
    string Name { get; }
    IPublisher Source { get; }

    bool Equals(object? obj);

    int GetHashCode();

    string ToString();
}