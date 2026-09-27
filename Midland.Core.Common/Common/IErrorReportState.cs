namespace Midland.Core.Common;

public interface IErrorReportState
{
    void SetPendingError(ErrorResponse errorResponse, string? additionalNotes = null, bool readOnlySubjectAndDescription = false);

    ErrorResponse? ConsumePendingError();

    string? ConsumePendingAdditionalNotes();

    bool ConsumeReadOnlySubjectAndDescription();
}
