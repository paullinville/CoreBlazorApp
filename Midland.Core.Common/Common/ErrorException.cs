namespace Midland.Core.Common;

public sealed class EC
{
    public static string Detail_Separator { get => "|"; }
    public static string Source_Separator { get => ":"; }
}

public class ErrorException : Detail
{
    public ErrorException()
    { }

    public ErrorException(Exception ex) : base(ex)
    {
        if (ex == null) return;
        StackTrace = new StackTrace(ex);
        InnerDetails = new ExceptionDetails(ex);
        Headers = new List<string>();
    }

    public Dictionary<string, string> Data { get; set; }

    internal string FullDescription
    {
        get
        {
            string path = "";
            if (StackTrace.IsNotEmpty())
            {
                path = " " + StackTrace.First().AfterX("at ").BeforeX(" in").Trim();
            }
            return $"{Source}{path}{EC.Source_Separator}{ExceptionType}{EC.Detail_Separator}" +
               $"{InnerDetails.Values().Select(d => d.ToString()).ListToString(EC.Detail_Separator)}";
        }
    }

    public List<string> Headers { get; set; }
    public ExceptionDetails InnerDetails { get; set; }
    public StackTrace StackTrace { get; set; }

    public override string ToString()
    {
        return FullDescription;
    }
}