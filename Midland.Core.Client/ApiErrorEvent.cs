using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace Midland.Core.Client;

public class ApiErrorEvent : ChannelEvent<ErrorResponse>
{
    public ApiErrorEvent()
    {
        this.Name = "Api Error";
    }

    public ApiErrorEvent(ErrorResponse data) : this()
    {
        Value = data;
    }
}