namespace BlazorApp.Common;

public class MovingAveragePoint
{
    public DateTime Timestamp { get; set; }
    public double RawValue { get; set; }
    public double MovingAverage { get; set; }
}