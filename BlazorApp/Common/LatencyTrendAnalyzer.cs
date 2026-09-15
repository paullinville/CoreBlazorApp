using BlazorApp.Models;
using static BlazorApp.Pages.LogAnalysis;

public enum WindowUnit
{
    Minutes,
    Hours,
    Days,
    Weeks,
    Months
}

public class LatencyTrendAnalyzer
{
    public int MovingAverageWindowCount { get; set; } = 3; // default smoothing

    public int WindowSize { get; }
    public WindowUnit Unit { get; }

    public LatencyTrendAnalyzer(int windowSize, WindowUnit unit)
    {
        WindowSize = windowSize;
        Unit = unit;
    }

    // ------------------------------------------------------------
    // Helper: Convert window size + unit into a TimeSpan
    // ------------------------------------------------------------
    private TimeSpan GetWindowSpan()
    {
        return Unit switch
        {
            WindowUnit.Minutes => TimeSpan.FromMinutes(WindowSize),
            WindowUnit.Hours => TimeSpan.FromHours(WindowSize),
            WindowUnit.Days => TimeSpan.FromDays(WindowSize),
            WindowUnit.Weeks => TimeSpan.FromDays(WindowSize * 7),
            WindowUnit.Months => TimeSpan.FromDays(WindowSize * 30),
            _ => TimeSpan.FromDays(WindowSize)
        };
    }

    // ------------------------------------------------------------
    // 1. Rolling Window Trend
    // ------------------------------------------------------------
    public List<RollingWindowTrendResult> ComputeRollingWindowTrend(
        List<ApiLogDataReportingModel> logs,
        int actionCountToAnalyze)
    {
        var now = DateTime.UtcNow;
        var span = GetWindowSpan();

        var windowAStart = now - span;
        var windowBStart = now - (span * 2);

        return logs
            .GroupBy(x => x.Action)
            .Select(g =>
            {
                var windowA = g.Where(x => x.ApiLogDate >= windowAStart && x.ApiLogDate <= now)
                               .Select(x => (double)x.TimeElapsed)
                               .ToList();

                var windowB = g.Where(x => x.ApiLogDate >= windowBStart && x.ApiLogDate < windowAStart)
                               .Select(x => (double)x.TimeElapsed)
                               .ToList();

                double avgA = windowA.Count > 0 ? windowA.Average() : 0;
                double avgB = windowB.Count > 0 ? windowB.Average() : 0;

                double pctChange = (avgB == 0)
                    ? (avgA > 0 ? 100 : 0)
                    : ((avgA - avgB) / avgB) * 100.0;

                return new RollingWindowTrendResult
                {
                    Action = g.Key,
                    RecentAverage = avgA,
                    PreviousAverage = avgB,
                    PercentageChange = pctChange
                };
            })
            .OrderByDescending(x => x.PercentageChange)
            .Take(Math.Max(1, actionCountToAnalyze))
            .ToList();
    }

    // ------------------------------------------------------------
    // 2. Moving Average Trend
    // ------------------------------------------------------------
    public List<MovingAverageTrendResult> ComputeMovingAverageTrend(
     List<ApiLogDataReportingModel> logs,
     int actionCountToAnalyze)
    {
        var span = GetWindowSpan();

        // GLOBAL window boundaries
        var orderedAll = logs.OrderBy(x => x.ApiLogDate).ToList();
        if (!orderedAll.Any())
            return new List<MovingAverageTrendResult>();

        var globalStart = orderedAll.First().ApiLogDate;
        var globalEnd = orderedAll.Last().ApiLogDate;

        var windows = new List<(DateTime Start, DateTime End)>();
        var ws = globalStart;
        var we = ws + span;

        while (ws <= globalEnd)
        {
            windows.Add((ws, we));
            ws = we;
            we = ws + span;
        }

        // First: compute raw window averages (same as WindowedTrend)
        var windowed = logs
            .GroupBy(x => x.Action)
            .Select(g =>
            {
                var actionLogs = g.OrderBy(x => x.ApiLogDate).ToList();
                var rawPoints = new List<(DateTime WindowStart, double Avg)>();

                foreach (var w in windows)
                {
                    var windowLogs = actionLogs
                        .Where(x => x.ApiLogDate >= w.Start && x.ApiLogDate < w.End)
                        .Select(x => (double)x.TimeElapsed)
                        .ToList();

                    double avg = windowLogs.Count > 0 ? windowLogs.Average() : 0;
                    rawPoints.Add((w.Start, avg));
                }

                return new
                {
                    Action = g.Key,
                    RawPoints = rawPoints
                };
            })
            .Take(Math.Max(1, actionCountToAnalyze))
            .ToList();

        // Second: apply moving average smoothing across windows
        var results = new List<MovingAverageTrendResult>();

        foreach (var action in windowed)
        {
            var smoothedPoints = new List<MovingAveragePoint>();
            var raw = action.RawPoints;

            for (int i = 0; i < raw.Count; i++)
            {
                int start = Math.Max(0, i - (MovingAverageWindowCount - 1));
                var slice = raw.Skip(start).Take(i - start + 1).Select(x => x.Avg).ToList();

                double movingAvg = slice.Count > 0 ? slice.Average() : 0;

                smoothedPoints.Add(new MovingAveragePoint
                {
                    Timestamp = raw[i].WindowStart,
                    RawValue = raw[i].Avg,
                    MovingAverage = movingAvg
                });
            }

            results.Add(new MovingAverageTrendResult
            {
                Action = action.Action,
                Points = smoothedPoints
            });
        }

        return results;
    }

    public List<TrendSlopeResult> ComputeTrendSlopes(List<WindowedTrendResult> windowedResults)
    {
        var results = new List<TrendSlopeResult>();

        foreach (var actionTrend in windowedResults)
        {
            var points = actionTrend.Points;

            if (points.Count < 2)
            {
                results.Add(new TrendSlopeResult
                {
                    Action = actionTrend.Action,
                    Slope = 0,
                    Intercept = points.Count == 1 ? points[0].AverageLatency : 0
                });
                continue;
            }

            // X = window index (0, 1, 2, ...)
            var x = Enumerable.Range(0, points.Count).Select(i => (double)i).ToList();
            var y = points.Select(p => p.AverageLatency).ToList();

            double slope = ComputeSlope(x, y);
            double intercept = ComputeIntercept(x, y, slope);

            results.Add(new TrendSlopeResult
            {
                Action = actionTrend.Action,
                Slope = slope,
                Intercept = intercept
            });
        }

        return results
            .OrderByDescending(r => r.Slope)
            .ToList();
    }

    public List<TrendSlopeResult> GenerateTrendSlopes(List<ApiLogDataReportingModel> logs, int actionCountToAnalyze)
    {
        var windowedResults = ComputeWindowedTrend(logs, actionCountToAnalyze);
        return ComputeTrendSlopes(windowedResults)
            .Take(Math.Max(1, actionCountToAnalyze))
            .ToList();
    }

    public List<WindowedTrendResult> ComputeWindowedTrend(List<ApiLogDataReportingModel> logs, int actionCountToAnalyze)
    {
        var span = GetWindowSpan();

        // GLOBAL window boundaries
        var orderedAll = logs.OrderBy(x => x.ApiLogDate).ToList();
        if (!orderedAll.Any())
            return new List<WindowedTrendResult>();

        var globalStart = orderedAll.First().ApiLogDate;
        var globalEnd = orderedAll.Last().ApiLogDate;

        var windows = new List<(DateTime Start, DateTime End)>();
        var ws = globalStart;
        var we = ws + span;

        while (ws <= globalEnd)
        {
            windows.Add((ws, we));
            ws = we;
            we = ws + span;
        }

        // Compute per-action window averages using GLOBAL windows
        return logs
            .GroupBy(x => x.Action)
            .Select(g =>
            {
                var actionLogs = g.OrderBy(x => x.ApiLogDate).ToList();
                var points = new List<WindowedTrendPoint>();

                foreach (var w in windows)
                {
                    var windowLogs = actionLogs
                        .Where(x => x.ApiLogDate >= w.Start && x.ApiLogDate < w.End)
                        .Select(x => (double)x.TimeElapsed)
                        .ToList();

                    double avg = windowLogs.Count > 0 ? windowLogs.Average() : 0;

                    points.Add(new WindowedTrendPoint
                    {
                        WindowStart = w.Start,
                        AverageLatency = avg
                    });
                }

                return new WindowedTrendResult
                {
                    Action = g.Key,
                    Points = points
                };
            })
            .Take(Math.Max(1, actionCountToAnalyze))
            .ToList();
    }

    private double ComputeSlope(List<double> x, List<double> y)
    {
        int n = x.Count;
        double avgX = x.Average();
        double avgY = y.Average();

        double numerator = 0;
        double denominator = 0;

        for (int i = 0; i < n; i++)
        {
            numerator += (x[i] - avgX) * (y[i] - avgY);
            denominator += (x[i] - avgX) * (x[i] - avgX);
        }

        return denominator == 0 ? 0 : numerator / denominator;
    }

    private double ComputeIntercept(List<double> x, List<double> y, double slope)
    {
        double avgX = x.Average();
        double avgY = y.Average();
        return avgY - slope * avgX;
    }
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

public class LogDataTimeTakenResult
{
    public string Action { get; set; }
    public int Count { get; set; }
    public double AverageTimeElapsed { get; set; }
    public long MaxTimeElapsed { get; set; }
    public double P95TimeElapsed { get; set; }
}

public class RollingWindowTrendResult
{
    public string Action { get; set; }
    public double RecentAverage { get; set; }
    public double PreviousAverage { get; set; }
    public double PercentageChange { get; set; }
}

public class TrendSlopeResult
{
    public string Action { get; set; }
    public double Slope { get; set; }
    public double Intercept { get; set; }
}

public class WindowedTrendResult
{
    public string Action { get; set; }

    // One data point per window (Day, Hour, Week, Month, etc.)
    public List<WindowedTrendPoint> Points { get; set; } = new();
}

public class WindowedTrendPoint
{
    // The start timestamp of the window
    public DateTime WindowStart { get; set; }

    // Average latency for that window
    public double AverageLatency { get; set; }
}