namespace BlazorApp.Models;

public class ErrorExceptionDetailDataModel
{
    public ErrorExceptionDetailDataModel(ErrorException? errorException)
    {
        if (errorException == null) return;
        StackTrace = errorException.StackTrace;
        Headers = errorException.Headers;
        TopException = errorException;

        Details = [TopException, .. errorException.InnerDetails.Values()];

        if (TopException.ExceptionData == null)
        {
            TopException.ExceptionData = new Dictionary<string, string>();
        }

        foreach (var key in errorException.Data.Keys)
        {
            if (!TopException.ExceptionData.ContainsKey(key))
            {
                TopException.ExceptionData.Add(key, errorException.Data[key]);
            }
            else
            {
                TopException.ExceptionData.Add($"Data-{key}", errorException.Data[key]);
            }
        }
    }

    public Detail TopException { get; }
    public List<Detail> Details { get; }
    public List<string> Headers { get; }
    public StackTrace StackTrace { get; }

    private static IReadOnlyList<ExceptionData> BuildExceptionData(ErrorException? errorException)
    {
        if (errorException is null)
        {
            return [];
        }

        var data = new List<ExceptionData>();

        if (errorException.ExceptionData.IsNotEmpty())
        {
            data.AddRange(errorException.ExceptionData.Values().Select(item => new ExceptionData(item.Key, item.Value)));
        }

        if (errorException.Data.IsNotEmpty())
        {
            data.AddRange(errorException.Data.Values().Select(item => new ExceptionData(item.Key, item.Value)));
        }

        return data;
    }
}