namespace BlazorApp.Shared;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using BlazorApp.Classes;
using BlazorApp.Data;

public partial class MainLayout : IDisposable
{
    [Inject] public ThemeService ThemeService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IJSRuntime JsRuntime { get; set; }
    [Inject] public ClientSettings ClientSettings { get; set; }
    [Inject] public IEmployeeRepository EmployeeRepository { get; set; }

    public string? WelcomeText { get; set; }

    public List<MenuItem> MenuItems { get; } =
    [
        new() { Text = "Home", Url = "/" },
        new() { Text = "Products", Url = "/products" },
        new() { Text = "Settings", Url = "/settings" }
    ];

    public List<ReportMenuItem> ReportMenuItems { get; } =
    [
        new() { Text = "Sales Summary", Url = "/reports/sales-summary" }
    ];

    public bool IsReportMenuOpen { get; set; }

    public double ReportMenuTop { get; set; }

    public double ReportMenuLeft { get; set; }

    private ElementReference ReportIconElement { get; set; }

    private DotNetObjectReference<MainLayout>? ReportMenuDotNetReference { get; set; }

    private bool RegisterOutsideClickHandler { get; set; }

    public string SelectedTheme { get; set; } = "meridian";

    public bool IsDarkTheme => SelectedTheme == "meridian-dark";

    public string? EnvironmentBannerText => ClientSettings.Environment?.Trim().ToLowerInvariant() switch
    {
        "development" => "Development",
        "deployment" => "UAT",
        _ => null
    };

    public string EnvironmentBannerColor => ClientSettings.Environment?.Trim().ToLowerInvariant() switch
    {
        "development" => "#99FF99",
        "deployment" => "#9999FF",
        _ => string.Empty
    };

    public bool ShowEnvironmentFrame => !string.IsNullOrEmpty(EnvironmentBannerText);

    public string EnvironmentFrameStyle => ShowEnvironmentFrame
        ? $"--env-accent-color:{EnvironmentBannerColor}; --env-background-color:{(IsDarkTheme ? "#6f8094" : "#ffffff")};"
        : string.Empty;

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        var currentUser = await EmployeeRepository.CurrentUser;
        WelcomeText = string.IsNullOrWhiteSpace(currentUser?.FullName) ? null : $"Welcome {currentUser.FullName}";
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

        if (RegisterOutsideClickHandler && IsReportMenuOpen)
        {
            ReportMenuDotNetReference ??= DotNetObjectReference.Create(this);
            await JsRuntime.InvokeVoidAsync("appLayoutHelper.registerOutsideClick", ReportMenuDotNetReference, "#report-menu", "#report-icon");
            RegisterOutsideClickHandler = false;
        }
    }

    private async Task OnThemeChanged(bool value)
    {
        CloseReportMenu();
        SelectedTheme = value ? "meridian-dark" : "meridian";
        await ThemeService.SetThemeAsync(SelectedTheme);
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        CloseReportMenu();
        StateHasChanged();
    }

    private Task OnApplicationNameClicked()
    {
        CloseReportMenu();
        NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        return Task.CompletedTask;
    }

    private async Task OnLockKeyClicked()
    {
        CloseReportMenu();

        // Perform any pre-redirect actions here (logging, auth checks, telemetry, etc.)
        // before the SecurityModel application is opened in a new tab.
        await JsRuntime.InvokeVoidAsync("open", ClientSettings.SecurityModelHost, "_blank");
    }

    private void OnReportErrorClicked()
    {
        CloseReportMenu();
        NavigationManager.NavigateTo("/report-error");
    }

    private async Task ToggleReportMenu()
    {
        if (IsReportMenuOpen)
        {
            CloseReportMenu();
            return;
        }

        var rect = await JsRuntime.InvokeAsync<ElementRect>("appLayoutHelper.getElementRect", ReportIconElement);
        if (rect is not null)
        {
            ReportMenuTop = rect.Bottom + 4;
            ReportMenuLeft = rect.Left;
        }

        IsReportMenuOpen = true;
        RegisterOutsideClickHandler = true;
    }

    private void CloseReportMenu()
    {
        IsReportMenuOpen = false;
        RegisterOutsideClickHandler = false;
        _ = JsRuntime.InvokeVoidAsync("appLayoutHelper.unregisterOutsideClick");
    }

    [JSInvokable]
    public Task HandleOutsideReportMenuClick()
    {
        CloseReportMenu();
        return InvokeAsync(StateHasChanged);
    }

    private void OnReportMenuItemClicked(ReportMenuItem item)
    {
        CloseReportMenu();
        NavigationManager.NavigateTo(item.Url);
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
        ReportMenuDotNetReference?.Dispose();
    }

    public class ReportMenuItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }

    private class ElementRect
    {
        public double Top { get; set; }
        public double Left { get; set; }
        public double Bottom { get; set; }
        public double Right { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class MenuItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
