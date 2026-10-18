using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class DetailDisplay
{
    [Parameter] public Detail? DetailModel { get; set; }
    [Parameter] public string Title { get; set; } = "Detail";
    [Parameter] public string Width { get; set; } = "100%";
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? AdditionalAttributes { get; set; }

    private IReadOnlyList<ExceptionData> ExceptionData => GetDataEntries();
    private IReadOnlyList<KeyValuePair<string, string?>> ExceptionPropertiesEntries => DetailModel?.ExceptionProperties?.Select(item => new KeyValuePair<string, string?>(item.Key, item.Value)).ToList() ?? [];

    private string ErrorDetailLabelColumnWidth
    {
        get
        {
            var labels = new List<string> { "Source", "Target", "Message" };
            labels.AddRange(ExceptionPropertiesEntries.Values().Select(entry => entry.Key).Where(key => key.IsNotNullOrBlank()));

            var maxLength = labels.Values().Select(label => label.Length).DefaultIfEmpty(0).Max();
            return maxLength > 0 ? $"{maxLength + 1}ch" : "75px";
        }
    }

    private bool HasData => ExceptionData.Count > 0;

    private IReadOnlyList<ExceptionData> GetDataEntries()
    {
        return DetailModel?.ExceptionData?.Select(item => new ExceptionData(item.Key, item.Value)).ToList() ?? [];
    }

    private static string DisplayText(string? value) => value.IsNullOrBlank() ? "(none)" : value;
}