using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class ErrorExceptionDisplay
{
    [Parameter] public string Title { get; set; } = "Exception Details";
    [Parameter] public string Width { get; set; } = "100%";
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter] public ErrorExceptionDetailDataModel? DetailData { get; set; }

    private IReadOnlyList<Detail> AllExceptionDetails => DetailData?.Details?.Values().ToList() ?? [];
    private IReadOnlyList<string> StackTraceLines => DetailData?.StackTrace?.Values().ToList() ?? [];
    private IReadOnlyList<string> Headers => DetailData?.Headers?.Values().ToList() ?? [];

    private bool HasStackTrace => StackTraceLines.Count > 0;
    private bool HasHeaders => Headers.Count > 0;
    private int StackTraceWidth => Headers.Count > 0 ? 3 : 4;
}