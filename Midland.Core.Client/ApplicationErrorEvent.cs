using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace Midland.Core.Client;

public class ApplicationErrorEvent : ChannelEvent<ErrorResponse>
{
    public ApplicationErrorEvent()
    {
        this.Name = "Application Error";
    }

    public ApplicationErrorEvent(ErrorResponse data) : this()
    {
        Value = data;
    }
}