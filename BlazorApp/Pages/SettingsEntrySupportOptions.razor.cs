using BlazorApp.Common;
using BlazorApp.Data;
using EATTS.Common.Models;
using Microsoft.AspNetCore.Components;
using Midland.Core.Common;
using Telerik.Blazor.Components;

namespace BlazorApp.Pages;

public partial class SettingsEntrySupportOptions
{
    [Inject] public ClientSettings Settings { get; set; } = default!;
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Settings - Entry Options"
        : $"{Settings.ApplicationName} - Settings - Entry Options";

    private TelerikNotification NotificationRef { get; set; } = default!;
    private SupportOptionsEditModel SupportOptions { get; set; } = new();
    private bool IsLoading { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        await LoadSupportOptionsAsync();
    }

    private async Task LoadSupportOptionsAsync()
    {
        IsLoading = true;
        SupportOptions = await EattsApiRepository.GetSupportOptions() ?? new SupportOptionsEditModel();
        IsLoading = false;
    }

    private async Task SaveSupportOptionsAsync()
    {
        SupportOptions = await EattsApiRepository.UpdateSupportOptions(SupportOptions) ?? new SupportOptionsEditModel();

        NotificationRef.Show(new NotificationModel
        {
            Text = "Support options saved successfully.",
            ThemeColor = "success"
        });
    }
}