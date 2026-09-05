using CsvHelper.Configuration.Attributes;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace BlazorApp.Common;

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