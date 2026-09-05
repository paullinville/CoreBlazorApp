using BlazorApp.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages;

public partial class NotFound
{
    [Inject] public ClientSettings Settings { get; set; } = default!;

    private string PageTitleText => string.IsNullOrWhiteSpace(Settings.ApplicationName)
        ? "Not Found"
        : $"{Settings.ApplicationName} - Not Found";
}
