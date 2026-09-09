using BlazorApp.Common;
using BlazorApp.Data;
using EATTS.Common.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages;

public partial class OccurrenceDetails
{
    [Inject] public ClientSettings Settings { get; set; } = default!;
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;

    [Parameter] public int OccurenceRef { get; set; }

    private EntryOccurrenceDetailModel? OccurrenceDetail { get; set; }
    private bool IsLoading { get; set; }
    private bool IsOccurrenceWindowVisible { get; set; }

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Occurrence Details"
        : $"{Settings.ApplicationName} - Occurrence Details";

    protected override async Task OnParametersSetAsync()
    {
        if (OccurenceRef <= 0)
        {
            OccurrenceDetail = null;
            return;
        }

        IsLoading = true;
        OccurrenceDetail = await EattsApiRepository.GetOccurrenceDetail(OccurenceRef);

        OccurrenceDetail ??= new EntryOccurrenceDetailModel
        {
            ApiLogData = new List<ApiLogDataModel>(),
            Notes = new List<EntryNoteDetail>()
        };

        OccurrenceDetail.ApiLogData ??= new List<ApiLogDataModel>();
        OccurrenceDetail.Notes ??= new List<EntryNoteDetail>();
        IsLoading = false;
    }

    private void OpenOccurrenceWindow()
    {
        IsOccurrenceWindowVisible = true;
    }

    private Task OnOccurrenceWindowVisibleChanged(bool isVisible)
    {
        IsOccurrenceWindowVisible = isVisible;
        return Task.CompletedTask;
    }
}
