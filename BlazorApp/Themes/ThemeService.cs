using Microsoft.JSInterop;

public class ThemeService
{
    private readonly IJSRuntime _js;

    public ThemeService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetThemeAsync(string theme, bool savePreference = true)
    {
        await _js.InvokeVoidAsync("telerikThemeSwitcher.setTheme", theme, savePreference);
    }

    public async Task<string?> GetStoredThemeAsync()
    {
        return await _js.InvokeAsync<string?>("telerikThemeSwitcher.getStoredTheme");
    }

    public async Task<string> GetSystemThemeAsync()
    {
        return await _js.InvokeAsync<string>("telerikThemeSwitcher.getSystemTheme");
    }
}
