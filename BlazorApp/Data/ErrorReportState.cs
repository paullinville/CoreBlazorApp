using Midland.Core.Common;

namespace BlazorApp.Data;

public class ErrorReportState
{
    public ErrorResponse? PendingErrorResponse { get; private set; }

    public void SetPendingError(ErrorResponse errorResponse)
    {
        PendingErrorResponse = errorResponse;
    }

    public ErrorResponse? ConsumePendingError()
    {
        var pendingError = PendingErrorResponse;
        PendingErrorResponse = null;
        return pendingError;
    }
}
