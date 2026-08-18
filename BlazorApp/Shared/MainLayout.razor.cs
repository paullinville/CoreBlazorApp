namespace BlazorApp.Shared;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

public partial class MainLayout : IDisposable
{
    [Inject] public ThemeService ThemeService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public List<MenuItem> MenuItems { get; } =
    [
        new() { Text = "Home", Url = "/" },
        new() { Text = "Products", Url = "/products" },
        new() { Text = "Settings", Url = "/settings" }
    ];

    public string SelectedTheme { get; set; } = "meridian";

    public bool IsDarkTheme => SelectedTheme == "meridian-dark";

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var storedTheme = await ThemeService.GetStoredThemeAsync();
            if (!string.IsNullOrEmpty(storedTheme))
            {
                SelectedTheme = storedTheme;
            }

            await ThemeService.SetThemeAsync(SelectedTheme);
            StateHasChanged();
        }
    }

    private async Task OnThemeChanged(bool value)
    {
        SelectedTheme = value ? "meridian-dark" : "meridian";
        await ThemeService.SetThemeAsync(SelectedTheme);
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e) => StateHasChanged();

    private void OnLockKeyClicked()
    {
        NavigationManager.NavigateTo("/security");
    }

    private void OnReportErrorClicked()
    {
        NavigationManager.NavigateTo("/report-error");
    }

    private string GetMenuItemClass(MenuItem item)
    {
        var relativePath = "/" + NavigationManager.ToBaseRelativePath(NavigationManager.Uri).TrimEnd('/');
        var itemUrl = item.Url.TrimEnd('/');
        if (itemUrl.Length == 0)
        {
            itemUrl = "/";
        }

        return relativePath == itemUrl ? "menu-item-selected" : string.Empty;
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }

    public class MenuItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
