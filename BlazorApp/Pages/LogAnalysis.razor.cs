using BlazorApp.Common;
using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Midland.Core.Common;
using SecurityModel.Common.Models;

namespace BlazorApp.Pages;

public partial class LogAnalysis
{
    [Inject] public ClientSettings Settings { get; set; } = default!;
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;
    [Inject] public ISecurityModelApiRepository SecurityModelRepo { get; set; } = default!;
    private List<ApplicationSummary> Applications { get; set; } = [];
    private LogAnalysisCriteriaInput CriteriaInput { get; set; } = new();
    private IEnumerable<WindowUnit> WindowUnits { get; } = Enum.GetValues<WindowUnit>();
    private List<ApiLogDataReportingModel> LogDataResults { get; set; } = [];
    private List<RollingWindowTrendResult> RollingWindowTrendResults { get; set; } = [];
    public List<WindowedTrendResult> WindowedTrendResults { get; private set; } = [];
    public List<TrendSlopeResult> TrendSlopeResults { get; private set; } = [];
    private List<LogDataTimeTakenResult> LogDataTimeTakenResults { get; set; } = [];
    private List<MovingAverageTrendResult> MovingAverageTrendResults { get; set; } = [];
    private LogAnalysisTileInfo ActiveTileInfo { get; set; } = LogAnalysisTileInfo.None;

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Log Analysis"
        : $"{Settings.ApplicationName} - Log Analysis";

    private void ToggleTileInfo(LogAnalysisTileInfo tileInfo)
    {
        ActiveTileInfo = ActiveTileInfo == tileInfo ? LogAnalysisTileInfo.None : tileInfo;
    }

    private string GetTileInfoText(LogAnalysisTileInfo tileInfo) => tileInfo switch
    {
        LogAnalysisTileInfo.Summary => "Summary statistics for the selected criteria.",
        LogAnalysisTileInfo.RollingWindowTrend => "Shows how each API performed recently compared to the previous time window.\r\nA positive percentage means the action got slower; a negative percentage means it improved.",
        LogAnalysisTileInfo.TrendSlope => "Shows the long‑term trend for each API action.\r\nA positive slope means latency is rising over time; a negative slope means it’s improving.",
        LogAnalysisTileInfo.WindowedLatencyTrend => "Displays the average latency for each API action in each time window.\r\nThis chart shows how performance changed over time, window by window.",
        LogAnalysisTileInfo.MovingAverageTrend => "Shows a smoothed latency trend across multiple windows.\r\nThis reduces noise and highlights the overall direction of performance — improving or degrading.",
        LogAnalysisTileInfo.TimeTakenByAction => "Compares count, average, maximum, and p95 time by action.",
        _ => string.Empty
    };

    private enum LogAnalysisTileInfo
    {
        None,
        Summary,
        RollingWindowTrend,
        TrendSlope,
        WindowedLatencyTrend,
        MovingAverageTrend,
        TimeTakenByAction
    }

    protected override async Task OnInitializedAsync()
    {
        Applications = await SecurityModelRepo.GetApplications();
    }

    private async Task OnSubmitAsync()
    {
        var criteria = new EATTS.Common.Models.ApiLogCriteria
        {
            ApiSlug = CriteriaInput.SelectedApplicationSummary,
            BeginDate = CriteriaInput.FromDate,
            EndDate = CriteriaInput.ToDate,
            PageNumber = 1,
            PageSize = int.MaxValue
        };
        var found = await EattsApiRepository.FindApiLogData(criteria);

        LogDataResults = found.Values()
                              .Select(x => new ApiLogDataReportingModel(x))
                              .ToList();
        LogDataTimeTakenResults = LogDataTimeTakenAnalyzer.Analyze(LogDataResults, CriteriaInput.ActionCountToAnalyze);

        var trendAnalyzer = new LatencyTrendAnalyzer(CriteriaInput.WindowSize, CriteriaInput.WindowUnit);

        RollingWindowTrendResults = trendAnalyzer.ComputeRollingWindowTrend(LogDataResults, CriteriaInput.ActionCountToAnalyze);

        WindowedTrendResults = trendAnalyzer.ComputeWindowedTrend(LogDataResults, CriteriaInput.ActionCountToAnalyze);

        TrendSlopeResults = trendAnalyzer.ComputeTrendSlopes(WindowedTrendResults)
                                        .Take(Math.Max(1, CriteriaInput.ActionCountToAnalyze))
                                        .ToList();

        MovingAverageTrendResults = trendAnalyzer.ComputeMovingAverageTrend(LogDataResults, CriteriaInput.ActionCountToAnalyze);
    }
}