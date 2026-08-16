namespace Midland.Core.SimpleMessageBus;

public class ChannelDictionary : Dictionary<string, List<ISubscriber>>
{
    public ChannelDictionary()
    {
    }

    public bool Enabled { get; set; } = true;
}