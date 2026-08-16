using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace Midland.Core.Client;

public class ResultsMessageEvent : ChannelEvent<IMidlandResult>
{
    public ResultsMessageEvent()
    {
        this.Name = "Midland Result Messages";
    }

    public ResultsMessageEvent(IMidlandResult data) : this()
    {
        Value = data;
    }
}