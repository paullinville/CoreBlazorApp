using EATTS.Common.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class OccurrenceDetailWindow
{
    [Parameter] public EntryOccurrenceDetailModel? OccurrenceDetail { get; set; }
    [Parameter] public bool IsVisible { get; set; }
    [Parameter] public EventCallback<bool> IsVisibleChanged { get; set; }

    private string StackTraceText => OccurrenceDetail?.ErrorResponse?.Details?.StackTrace is null
        ? string.Empty
        : string.Join(Environment.NewLine, OccurrenceDetail.ErrorResponse.Details.StackTrace.Values());

    private async Task OnVisibleChangedAsync(bool isVisible)
    {
        IsVisible = isVisible;
        await IsVisibleChanged.InvokeAsync(isVisible);
    }
}
