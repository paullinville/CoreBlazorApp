namespace BlazorApp.Common;

// ------------------------------------------------------------
// Models
// ------------------------------------------------------------
public class MovingAverageTrendResult
{
    public string Action { get; set; }
    public List<MovingAveragePoint> Points { get; set; } = new();
}
