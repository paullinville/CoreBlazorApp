using Midland.Core.Common;

namespace BlazorApp.Data;

public class ErrorReportState
{
    public ErrorResponse? PendingErrorResponse { get; private set; }

    private string? PendingAdditionalNotes { get; set; }
    private bool PendingReadOnlySubjectAndDescription { get; set; }

    public void SetPendingError(ErrorResponse errorResponse, string? additionalNotes = null, bool readOnlySubjectAndDescription = false)
    {
        PendingErrorResponse = errorResponse;
        PendingAdditionalNotes = additionalNotes;
        PendingReadOnlySubjectAndDescription = readOnlySubjectAndDescription;
    }

    public ErrorResponse? ConsumePendingError()
    {
        var pendingError = PendingErrorResponse;
        PendingErrorResponse = null;
        return pendingError;
    }

    public string? ConsumePendingAdditionalNotes()
    {
        var pendingAdditionalNotes = PendingAdditionalNotes;
        PendingAdditionalNotes = null;
        return pendingAdditionalNotes;
    }

    public bool ConsumeReadOnlySubjectAndDescription()
    {
        var pendingReadOnlySubjectAndDescription = PendingReadOnlySubjectAndDescription;
        PendingReadOnlySubjectAndDescription = false;
        return pendingReadOnlySubjectAndDescription;
    }
}
