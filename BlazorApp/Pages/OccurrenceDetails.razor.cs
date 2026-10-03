using BlazorApp.Common;
using BlazorApp.Data;
using EATTS.Common.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages;

public partial class OccurrenceDetails
{
    [Inject] public ClientSettings Settings { get; set; } = default!;
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;
    [Inject] public IEmployeeRepository EmployeeRepository { get; set; } = default!;

    [Parameter] public int OccurrenceRef { get; set; }

    private EntryOccurrenceDetailModel? OccurrenceDetail { get; set; }
    private bool IsLoading { get; set; }
    private bool IsOccurrenceWindowVisible { get; set; }
    private string? SelectedOccurrenceAction { get; set; }
    private List<string> ComboItems { get; set; } = [];
    private string CurrentUserEmail { get; set; } = string.Empty;

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Occurrence Details"
        : $"{Settings.ApplicationName} - Occurrence Details";

    protected override async Task OnParametersSetAsync()
    {
        await LoadOccurrenceRefsAsync();

        if (OccurrenceRef > 0)
        {
            SelectedOccurrenceAction = OccurrenceRef.ToString();
        }

        if (!SelectedOccurrenceAction.IsNullOrBlank() && !ComboItems.Contains(SelectedOccurrenceAction))
        {
            ComboItems.Insert(0, SelectedOccurrenceAction);
        }

        await LoadOccurrenceDetailAsync(OccurrenceRef);
    }

    private async Task OnOccurrenceRefChanged(object value)
    {
        SelectedOccurrenceAction = value?.ToString();
        await LoadOccurrenceDetailForSelectionAsync();
    }

    private async Task OnOccurrenceRefBlur()
    {
        await LoadOccurrenceDetailForSelectionAsync();
    }

    private async Task LoadOccurrenceDetailForSelectionAsync()
    {
        if (!int.TryParse(SelectedOccurrenceAction, out var selectedOccurrenceRef) || selectedOccurrenceRef <= 0)
        {
            OccurrenceDetail = null;
            return;
        }

        await LoadOccurrenceDetailAsync(selectedOccurrenceRef);
    }

    private async Task LoadOccurrenceDetailAsync(int occurrenceRef)
    {
        if (occurrenceRef <= 0)
        {
            OccurrenceDetail = null;
            return;
        }

        IsLoading = true;
        OccurrenceDetail = await EattsApiRepository.GetOccurrenceDetail(occurrenceRef);

        OccurrenceDetail ??= new EntryOccurrenceDetailModel
        {
            ApiLogData = new List<ApiLogDataModel>(),
            Notes = new List<EntryNoteDetail>()
        };

        OccurrenceDetail.ApiLogData ??= new List<ApiLogDataModel>();
        OccurrenceDetail.Notes ??= new List<EntryNoteDetail>();
        IsLoading = false;
    }

    private async Task LoadOccurrenceRefsAsync()
    {
        var currentUser = await EmployeeRepository.CurrentUser;
        CurrentUserEmail = currentUser?.Email ?? string.Empty;

        if (CurrentUserEmail.IsNullOrBlank())
        {
            ComboItems = [];
            return;
        }

        var criteria = new EntryOccurrenceSearchCriteria
        {
            EmailsSent = CurrentUserEmail,
            PageNumber = 1,
            PageSize = 25,
            IsError = true
        };

        var page = await EattsApiRepository.GetEntryOccurrenceDetail(criteria);
        ComboItems = page?.Results?
            .Select(r => r.EntryOccurrenceRef.ToString())
            .Where(r => !r.IsNullOrBlank())
            .Distinct()
            .ToList() ?? [];
    }

    private Task OnOccurrenceWindowVisibleChanged(bool isVisible)
    {
        IsOccurrenceWindowVisible = isVisible;
        return Task.CompletedTask;
    }
}