using BlazorApp.Common;
using BlazorApp.Data;
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

    private EntryOccurrenceSearchCriteria CriteriaInput { get; } = new();

    private List<ApplicationSummary> ApplicationOptions { get; set; } = [];

    private int? EmailsSentUserRef { get; set; }

    private List<int?> PageSizeOptions { get; } = new() { 10, 20, 35, 50, 100 };

    private List<EntryOccurrenceSearchView> GridData { get; set; } = [];

    private TelerikGrid<EntryOccurrenceSearchView>? SearchResultsGrid { get; set; }

    private bool ExportAllPages { get; set; }

    private EntryOccurrenceDetailModel? SelectedOccurrenceDetail { get; set; }

    private IReadOnlyList<int> OccurrenceRefsForWindow { get; set; } = [];

    private bool IsOccurrenceWindowVisible { get; set; }

    private int? SelectedEntryRefForSupportOptions { get; set; }

    private bool IsSupportOptionsWindowVisible { get; set; }

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

    private async Task OnSearchClickedAsync()
    {
        GridData = await EattsApiRepository.SearchOccurrences(this.CriteriaInput);
        // Change the grid key to force grid reset when new search results arrive
    }

    private async Task OpenOccurrenceDetailsAsync(int occurrenceRef)
    {
        if (occurrenceRef <= 0)
        {
            return;
        }

        SelectedOccurrenceDetail = await EattsApiRepository.GetOccurrenceDetail(occurrenceRef);
        if (SelectedOccurrenceDetail is null)
        {
            IsOccurrenceWindowVisible = false;
            return;
        }

        SelectedOccurrenceDetail.ApiLogData ??= [];
        SelectedOccurrenceDetail.Notes ??= [];
        OccurrenceRefsForWindow = GridData
            .Select(x => x.EntryOccurrenceRef)
            .Where(x => x > 0)
            .Distinct()
            .ToList();
        IsOccurrenceWindowVisible = true;
    }

    private Task OnOccurrenceWindowVisibleChanged(bool isVisible)
    {
        IsOccurrenceWindowVisible = isVisible;
        return Task.CompletedTask;
    }

    private Task OpenSupportOptionsWindowAsync(int entryRef)
    {
        if (entryRef <= 0)
        {
            return Task.CompletedTask;
        }

        SelectedEntryRefForSupportOptions = entryRef;
        IsSupportOptionsWindowVisible = true;
        return Task.CompletedTask;
    }

    private Task OnSupportOptionsWindowVisibleChanged(bool isVisible)
    {
        IsSupportOptionsWindowVisible = isVisible;
        if (!isVisible)
        {
            SelectedEntryRefForSupportOptions = null;
        }

        return Task.CompletedTask;
    }

    private string FormatPageTitle(string pageTitle) => string.IsNullOrWhiteSpace(Settings.ApplicationName)
        ? pageTitle
        : $"{Settings.ApplicationName} - {pageTitle}";

}