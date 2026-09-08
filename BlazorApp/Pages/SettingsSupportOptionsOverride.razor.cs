using BlazorApp.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages;

public partial class SettingsSupportOptionsOverride
{
    [Inject] public ClientSettings Settings { get; set; } = default!;

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Settings Alt Entry Options"
        : $"{Settings.ApplicationName} - Settings Alt Entry Options";
}