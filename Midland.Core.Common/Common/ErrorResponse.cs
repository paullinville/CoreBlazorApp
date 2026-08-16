namespace Midland.Core.Common;

public class ErrorResponse : IMidlandResult
{

    public ErrorResponse() { }

    public string Code { get; set; } = "";

    public string Description { get; set; }

    public ErrorException Details { get; set; }

    public List<ErrorResultError> Errors { get; set; }

    public List<string> Messages { get; set; }

    public string RequestId { get; set; }

    public string RequestPath { get; set; }

    public string RequestQuery { get; set; }

    public string Title { get; set; }

    public string TraceId { get; set; }

    public ErrorResponse Diffs(ErrorResponse other)
    {
        var diff = new ErrorResponse() { Code = null };

        if (Code != other.Code) diff.Code = other.Code;
        if (Title != other.Title) diff.Title = other.Title;
        if (RequestQuery != other.RequestQuery) diff.RequestQuery = other.RequestQuery;
        if (Description != other.Description) diff.Description = other.Description;
        if (RequestPath != other.RequestPath) diff.RequestPath = other.RequestPath;
        if (RequestId != other.RequestId) diff.RequestId = other.RequestId;
        if (TraceId != other.TraceId) diff.TraceId = other.TraceId;
        var diffErrors = other.Errors.Values().Except(Errors.Values());
        if (diffErrors.IsNotEmpty()) diff.Errors = diffErrors.ToList();

        var diffMessages = other.Messages.Values().Except(Messages.Values()).ToList();
        if (diffMessages.IsNotEmpty()) diff.Messages = diffMessages.ToList();

        return diff;
    }

    public string Key()
    {
        return $"{RequestPath}|{Details?.FullDescription}";
    }
}