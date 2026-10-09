using EATTS.Common.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class OccurrenceDetailWindow
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter] public EntryOccurrenceDetailModel? OccurrenceDetail { get; set; }
    [Parameter] public IReadOnlyList<int> OccurrenceRefs { get; set; } = [];
    [Parameter] public EventCallback<int> OccurrenceRefChanged { get; set; }
    [Parameter] public bool IsVisible { get; set; }
    [Parameter] public EventCallback<bool> IsVisibleChanged { get; set; }

    private IReadOnlyList<ApiLogDataModel> LogEntries => OccurrenceDetail?.ApiLogData ?? [];

    private string LogsTabClass => LogEntries.Count > 0 ? "occurrence-logs-tab-active" : string.Empty;

    private string StackTraceText => OccurrenceDetail?.ErrorResponse?.Details?.StackTrace is null
        ? string.Empty
        : string.Join(Environment.NewLine, OccurrenceDetail.ErrorResponse.Details.StackTrace.Values());

    private int CurrentOccurrenceIndex
    {
        get
        {
            if (OccurrenceDetail?.EntryOccurrenceRef is null or <= 0 || OccurrenceRefs.Count == 0)
            {
                return -1;
            }

            for (var i = 0; i < OccurrenceRefs.Count; i++)
            {
                if (OccurrenceRefs[i] == OccurrenceDetail.EntryOccurrenceRef)
                {
                    return i;
                }
            }

            return -1;
        }
    }

    private bool CanGoToPrevious => CurrentOccurrenceIndex > 0;
    private bool CanGoToNext => CurrentOccurrenceIndex >= 0 && CurrentOccurrenceIndex < OccurrenceRefs.Count - 1;

    private async Task OnVisibleChangedAsync(bool isVisible)
    {
        IsVisible = isVisible;
        await IsVisibleChanged.InvokeAsync(isVisible);
    }

    private Task OnPreviousClickedAsync()
    {
        if (!CanGoToPrevious)
        {
            return Task.CompletedTask;
        }

        return OccurrenceRefChanged.InvokeAsync(OccurrenceRefs[CurrentOccurrenceIndex - 1]);
    }

    private Task OnNextClickedAsync()
    {
        if (!CanGoToNext)
        {
            return Task.CompletedTask;
        }

        return OccurrenceRefChanged.InvokeAsync(OccurrenceRefs[CurrentOccurrenceIndex + 1]);
    }

    private Task OnOpenOccurrenceClickedAsync()
    {
        if (OccurrenceDetail?.EntryOccurrenceRef is null or <= 0)
        {
            return Task.CompletedTask;
        }

        NavigationManager.NavigateTo($"/occurrence-details/{OccurrenceDetail.EntryOccurrenceRef}");
        return Task.CompletedTask;
    }
}
