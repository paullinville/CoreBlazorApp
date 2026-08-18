using Microsoft.JSInterop;

public class ThemeService
{
    private readonly IJSRuntime _js;

    public ThemeService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetThemeAsync(string theme)
    {
        await _js.InvokeVoidAsync("telerikThemeSwitcher.setTheme", theme);
    }
}
