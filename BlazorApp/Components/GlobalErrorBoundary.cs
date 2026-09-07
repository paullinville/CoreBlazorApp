using BlazorApp.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Midland.Core.SimpleMessageBus;

namespace BlazorApp.Components;

public class GlobalErrorBoundary : ErrorBoundary
{
    [Inject]
    private IEventChannelBus EventChannelBus { get; set; } = default!;

    protected override async Task OnErrorAsync(Exception exception)
    {
        var errorResponse = new ErrorResponse
        {
            Code = ErrorCodes.ApplicationUnhandledException,
            Description = exception.Message,
            Details = new ErrorException(exception),
            Errors = [],
            Messages = [exception.Message]
        };

        await EventChannelBus.PublishAsync(new ApplicationErrorEvent(errorResponse));
    }
}
