using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace Midland.Core.Client;

public class SecurityErrorEvent : ChannelEvent<ErrorResponse>
{
    public SecurityErrorEvent()
    {
        this.Name = "Security Error";
    }

    public SecurityErrorEvent(ErrorResponse data) : this()
    {
        Value = data;
    }
}