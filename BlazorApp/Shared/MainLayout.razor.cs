namespace BlazorApp.Shared;

using Microsoft.AspNetCore.Components;

public partial class MainLayout
{
    [Inject] public ThemeService ThemeService { get; set; }

    public List<MenuItem> MenuItems { get; } =
    [
        new() { Text = "Home", Url = "/" },
        new() { Text = "Products", Url = "/products" },
        new() { Text = "Settings", Url = "/settings" }
    ];

    public string SelectedTheme { get; set; } = "meridian";

    public bool IsDarkTheme => SelectedTheme == "meridian-dark";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await ThemeService.SetThemeAsync(SelectedTheme);
        }
    }

    private async Task OnThemeChanged(bool value)
    {
        SelectedTheme = value ? "meridian-dark" : "meridian";
        await ThemeService.SetThemeAsync(SelectedTheme);
    }

    public class MenuItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
