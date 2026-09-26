using Midland.Core.SimpleMessageBus;

namespace Midland.Core.Client;

public class BeforeApiCallEvent : ChannelEvent<HttpClient>
{
    public BeforeApiCallEvent()
    {
        this.Name = "Before API Called";
    }

    public BeforeApiCallEvent(HttpClient client)
        : base(client, name: "Before Api Called")
    {
    }
}