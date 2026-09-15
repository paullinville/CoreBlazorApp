using BlazorApp.Models;

namespace BlazorApp.Common;

public static class LogDataTimeTakenAnalyzer
{
    public static List<LogDataTimeTakenResult> Analyze(List<ApiLogDataReportingModel> logData, int actionCountToAnalyze)
    {
        return logData.GroupBy(x => x.Action)
                      .Select(g => new LogDataTimeTakenResult
                      {
                          Action = g.Key,
                          Count = g.Count(),
                          AverageTimeElapsed = g.Average(x => x.TimeElapsed),
                          MaxTimeElapsed = g.Max(x => x.TimeElapsed),
                          P95TimeElapsed = Percentile(g.Select(x => x.TimeElapsed), 95)
                      })
                      .OrderByDescending(x => x.P95TimeElapsed)
                      .Take(Math.Max(1, actionCountToAnalyze))
                      .ToList();
    }

    private static double Percentile(IEnumerable<long> sequence, double percentile)
    {
        ArgumentNullException.ThrowIfNull(sequence);

        var sorted = sequence.OrderBy(x => x).ToList();
        if (!sorted.Values().Any()) return 0;

        percentile = Math.Clamp(percentile, 0, 100);

        var position = (sorted.Count - 1) * (percentile / 100.0);
        var lowerIndex = (int)Math.Floor(position);
        var upperIndex = (int)Math.Ceiling(position);

        if (lowerIndex == upperIndex)
        {
            return sorted[lowerIndex];
        }

        var weight = position - lowerIndex;
        return sorted[lowerIndex] * (1 - weight) + sorted[upperIndex] * weight;
    }
}
