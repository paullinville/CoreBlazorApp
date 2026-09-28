using BlazorApp.Common;
using BlazorApp.Data;
using EATTS.Common.Models;
using EmployeeData.Common.Models;
using Microsoft.AspNetCore.Components;
using SecurityModel.Common.Models;
using Telerik.Blazor.Components;

namespace BlazorApp.Pages;

public partial class Search
{
    [Inject]
    public ClientSettings Settings { get; set; } = default!;

    [Inject]
    public IEattsApiRepository EattsApiRepository { get; set; } = default!;

    private string PageTitleText => FormatPageTitle("Search");

    private bool IsSearchCriteriaExpanded { get; set; } = true;

    private bool IsResultsExpanded { get; set; } = false;

    private bool IsResultsLoading { get; set; }

    private bool ShowResultsGrid { get; set; }

    private const int ResultsPanelLoadIndicatorMs = 650;

    private EntryOccurrenceSearchCriteria CriteriaInput { get; } = new();

    private List<ApplicationSummary> ApplicationOptions { get; set; } = [];

    private int? EmailsSentUserRef { get; set; }

    private List<SearchResultItem> GridData { get; } = [];

    private TelerikGrid<SearchResultItem>? SearchResultsGrid { get; set; }

    private bool ExportAllPages { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ApplicationOptions = (await EattsApiRepository.GetAllApplicationOptions())
            .Select(x => new ApplicationSummary
            {
                ApiName = x.ApiName
            })
            .ToList();
    }

    private Task OnEmailsSentUserChanged(UserSelectModelExpanded? selectedUser)
    {
        CriteriaInput.EmailsSent = selectedUser?.Email;
        return Task.CompletedTask;
    }

    private async Task ExportCurrentPageAsync()
    {
        ExportAllPages = false;
        if (SearchResultsGrid is null)
        {
            return;
        }

        await SearchResultsGrid.SaveAsExcelFileAsync();
    }

    private async Task ExportAllPagesAsync()
    {
        ExportAllPages = true;
        if (SearchResultsGrid is null)
        {
            return;
        }

        await SearchResultsGrid.SaveAsExcelFileAsync();
    }

    private Task OnSearchCriteriaExpandedChanged(bool value)
    {
        IsSearchCriteriaExpanded = value;
        return Task.CompletedTask;
    }

    private async Task OnSearchClickedAsync()
    {
        IsSearchCriteriaExpanded = false;
        await OnResultsExpandedChanged(true);
        await InvokeAsync(StateHasChanged);
    }

    private Task OnResultsExpandedChanged(bool value)
    {
        IsResultsExpanded = value;

        if (!value)
        {
            ShowResultsGrid = false;
            IsResultsLoading = false;
            return Task.CompletedTask;
        }

        IsResultsLoading = true;
        ShowResultsGrid = false;
        _ = ShowResultsGridAfterDelayAsync();

        return Task.CompletedTask;
    }

    private async Task ShowResultsGridAfterDelayAsync()
    {
        await Task.Delay(ResultsPanelLoadIndicatorMs);
        ShowResultsGrid = true;
        IsResultsLoading = false;
        await InvokeAsync(StateHasChanged);
    }

    private string FormatPageTitle(string pageTitle) => string.IsNullOrWhiteSpace(Settings.ApplicationName)
        ? pageTitle
        : $"{Settings.ApplicationName} - {pageTitle}";

    private class SearchResultItem
    {
        public string Primary { get; set; } = string.Empty;

        public string Secondary { get; set; } = string.Empty;
    }
}
