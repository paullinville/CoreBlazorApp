using BlazorApp.Common;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace BlazorApp.Pages;

public partial class Search
{
    [Inject]
    public ClientSettings Settings { get; set; } = default!;

    private string PageTitleText => FormatPageTitle("Search");

    private bool IsSearchCriteriaExpanded { get; set; } = true;

    private bool IsResultsExpanded { get; set; } = false;

    private List<SearchResultItem> GridData { get; } = [];

    private TelerikGrid<SearchResultItem>? SearchResultsGrid { get; set; }

    private bool ExportAllPages { get; set; }

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

    private Task OnResultsExpandedChanged(bool value)
    {
        IsResultsExpanded = value;
        return Task.CompletedTask;
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