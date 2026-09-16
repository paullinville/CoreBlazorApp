using BlazorApp.Common;
using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Midland.Core.Common;
using SecurityModel.Common.Models;

namespace BlazorApp.Pages;

public partial class LogPivotTable
{
    [Inject] public ClientSettings Settings { get; set; } = default!;
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;
    [Inject] public ISecurityModelApiRepository SecurityModelRepo { get; set; } = default!;

    private List<ApplicationSummary> Applications { get; set; } = [];
    private LogPivotTableCriteriaInput CriteriaInput { get; set; } = new();
    private List<ApiLogDataPivotModel> LogDataResults { get; set; } = [];

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Log Pivot Table"
        : $"{Settings.ApplicationName} - Log Pivot Table";

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

        var results = found.Values()
                          .Select(x => new ApiLogDataPivotModel(x))
                          .ToList();

        LogDataResults = results;
    }
}