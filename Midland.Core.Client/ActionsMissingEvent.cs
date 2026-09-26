using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;

namespace Midland.Core.Client;

public class ActionsMissingEvent : ChannelEvent<ErrorResponse>
{
    public ActionsMissingEvent()
    {
        this.Name = "User Actions Missing";
    }

    public ActionsMissingEvent(ErrorResponse data) : this()
    {
        Value = data;
    }
}