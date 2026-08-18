namespace BlazorApp.Shared;

using Microsoft.AspNetCore.Components;

public partial class MainLayout
{
    [Inject] public ThemeService ThemeService { get; set; }

    public List<ThemeOption> Themes = new()
    {
        new ThemeOption("Meridian", "meridian"),
        new ThemeOption("Meridian Dark", "meridian-dark")
    };

    public string SelectedTheme { get; set; } = "meridian";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await ThemeService.SetThemeAsync(SelectedTheme);
        }
    }

    private async Task OnThemeChanged(string value)
    {
        SelectedTheme = value;
        await ThemeService.SetThemeAsync(value);
    }

    public record ThemeOption(string Text, string Value);
}
