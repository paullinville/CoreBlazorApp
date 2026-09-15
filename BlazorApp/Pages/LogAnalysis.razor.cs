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

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Log Analysis"
        : $"{Settings.ApplicationName} - Log Analysis";

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