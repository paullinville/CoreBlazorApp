using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace Midland.Core.Client;

public class ApiValidationEvent : ChannelEvent<ErrorResponse>
{
    public ApiValidationEvent()
    {
        this.Name = "Api Validation Failure";
    }

    public ApiValidationEvent(ErrorResponse data) : this()
    {
        Value = data;
    }
}