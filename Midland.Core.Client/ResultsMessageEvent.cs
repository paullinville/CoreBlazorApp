using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace Midland.Core.Client;

public class ResultsMessageEvent : ChannelEvent<List<string>>
{
    public ResultsMessageEvent()
    {
        this.Name = "Midland Result Messages";
    }

    public ResultsMessageEvent(IMidlandResult data) : this()
    {
        Value = data.Messages;
    }
}