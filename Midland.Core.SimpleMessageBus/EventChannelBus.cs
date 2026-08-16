namespace Midland.Core.SimpleMessageBus;

public class EventChannelBus : IEventChannelBus
{
    public EventChannelBus()
    {
        Channels = new ChannelDictionary();
    }

    public bool Enabled
    {
        get
        {
            return Channels.Enabled;
        }
    }

    private ChannelDictionary Channels { get; set; }

    public void Disable()
    {
        Channels.Enabled = false;
    }

    public void Enable()
    {
        Channels.Enabled = true;
    }

    public void Publish<T>(IChannelEvent<T> evt)
    {
        if (!Enabled) return;
        NotifySubscribers(evt.ChannelName, evt);
        if (evt.MustHandle && !evt.Handled)
        {
            throw new ApplicationException("Required channel event was not handled.");
        }
    }

    public async Task PublishAsync<T>(IChannelEvent<T> evt)
    {
        if (!Enabled) return;
        await NotifySubscribersAsync(evt.ChannelName, evt);
        if (evt.MustHandle && !evt.Handled)
        {
            throw new ApplicationException("Required channel event was not handled.");
        }
    }

    public void Subscribe(IChannelEvent channel, ISubscriber subscriber)
    {
        SubscribeChannel(channel.ChannelName, subscriber);
    }

    public void Subscribe(string channelName, ISubscriber subscriber)
    {
        SubscribeChannel(channelName, subscriber);
    }

    public void UnSubscribe(IChannelEvent Channel, ISubscriber subscriber)
    {
        if (!Enabled) return;
        if (Channels.ContainsKey(Channel.ChannelName))
        {
            if (Channels[Channel.ChannelName].Contains(subscriber))
            {
                Channels[Channel.ChannelName].Remove(subscriber);
            }
            // delete the list if no subscribers are left
            if (Channels[Channel.ChannelName].Count == 0)
            {
                Channels.Remove(Channel.ChannelName);
            }
        }
    }

    void IEventChannelBus.UnSubscribe(string channelName, ISubscriber subscriber)
    {
        if (!Enabled) return;
        if (Channels.ContainsKey(channelName))
        {
            if (Channels[channelName].Contains(subscriber))
            {
                Channels[channelName].Remove(subscriber);
            }
            // delete the list if no subscribers are left
            if (Channels[channelName].Count == 0)
            {
                Channels.Remove(channelName);
            }
        }
    }

    public void UnSubscribeAll(ISubscriber subscriber)
    {
        if (!Enabled) return;
        List<string> emptyChannelsKeys = new List<string>();
        foreach (string channel in Channels.Keys)
        {
            if (Channels[channel].Contains(subscriber))
            {
                Channels[channel].Remove(subscriber);
            }
            if (Channels[channel].Count == 0)
            {
                emptyChannelsKeys.Add(channel);
            }
        }

        foreach (string channel in emptyChannelsKeys)
        {
            Channels.Remove(channel);
        }
    }

    private void NotifySubscribers<T>(string Channel, IChannelEvent<T> Evt)
    {
        if (!Enabled) return;
        if (Channels.ContainsKey(Channel))
        {
            foreach (ISubscriber sub in Channels[Channel].OrderBy(x => x.NotificationOrder()))
            {
                if (Evt.Handled) { return; }
                sub.ChannelNotification(Evt);
            }
        }
    }

    private async Task NotifySubscribersAsync<T>(string Channel, IChannelEvent<T> Evt)
    {
        if (!Enabled) return;

        if (Channels.ContainsKey(Channel))
        {
            foreach (ISubscriber sub in Channels[Channel].OrderBy(x => x.NotificationOrder()))
            {
                if (Evt.Handled) { return; }
                await sub.ChannelNotificationAsync(Evt);
            }
        }
    }

    private void SubscribeChannel(string Channel, ISubscriber Subscriber)
    {
        if (!Enabled) return;
        if (!Channels.ContainsKey(Channel))
        {
            Channels.Add(Channel, new List<ISubscriber>());
        }
        if (!Channels[Channel].Contains(Subscriber))
        {
            Channels[Channel].Add(Subscriber);
        }
    }
}