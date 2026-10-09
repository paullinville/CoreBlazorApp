using BlazorApp.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages;

public partial class SettingsParameters
{
    [Inject] public ClientSettings Settings { get; set; } = default!;

    private bool HasLogs { get; set; }

    private string LogsTabClass => HasLogs ? "logs-tab-active" : string.Empty;

    private void ToggleHasLogs() => HasLogs = !HasLogs;

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Settings - Parameters"
        : $"{Settings.ApplicationName} - Settings - Parameters";
}
