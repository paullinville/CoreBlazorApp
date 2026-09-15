using Midland.Core.Common;

namespace BlazorApp.Common;

public class ClientSettings
{
    public string ApplicationName { get; set; } = "";
    public string? Environment { get; set; }
    private string? securityModelHost;

    public string ApiHost { get; set; } = "";

    public string SecurityModelHost { get => securityModelHost ?? ApiHost; set => securityModelHost = value; }

    public UserTokenRequestModel? UserTokenRequestModel { get; set; }

    public bool UseMocks { get; set; } = false;
}

// ------------------------------------------------------------
// Models
// ------------------------------------------------------------
public class MovingAverageTrendResult
{
    public string Action { get; set; }
    public List<MovingAveragePoint> Points { get; set; } = new();
}

public class MovingAveragePoint
{
    public DateTime Timestamp { get; set; }
    public double RawValue { get; set; }
    public double MovingAverage { get; set; }
}