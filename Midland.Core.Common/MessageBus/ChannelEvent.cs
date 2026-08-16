namespace Midland.Core.SimpleMessageBus;

public class ChannelEvent<T> : IChannelEvent<T>
{
    public ChannelEvent(T value, string? name = null, IPublisher? source = null, string? channelName = null)
    {
        Source = source;
        Name = name;
        Value = value;
        ChannelName = (channelName ?? GetType().FullName);
    }

    public ChannelEvent()
    {
        ChannelName = GetType().FullName ?? "";
        Value = default;
    }

    public Dictionary<string, object>? AdditionalValues { get; set; }
    public string ChannelName { get; } = "";
    public bool Handled { get; set; }
    public bool MustHandle { get; set; }
    public string? Name { get; protected set; }
    public IPublisher? Source { get; protected set; }
    public T Value { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if (obj is IChannelEvent other)
        {
            if (other.ChannelName != ChannelName)
                return false;
            else if (other.Name != Name)
                return false;
            else if (!Source.Equals(other.Source))
                return false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public override string ToString()
    {
        return ChannelName + ":" + Name + Source?.ToString();
    }
}