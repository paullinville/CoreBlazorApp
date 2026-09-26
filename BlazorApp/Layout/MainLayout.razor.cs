namespace BlazorApp.Layout;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using BlazorApp.Data;
using BlazorApp.Common;
using Midland.Core.Client;
using System.Text.Json;
using System.Text.Json.Nodes;

public partial class MainLayout : IDisposable
{
    private static readonly JsonSerializerOptions PrettyPrintJsonOptions = new()
    {
        WriteIndented = true
    };

    [Inject] public ThemeService ThemeService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IJSRuntime JsRuntime { get; set; }
    [Inject] public ClientSettings ClientSettings { get; set; }
    [Inject] public IEmployeeRepository EmployeeRepository { get; set; }
    [Inject] public ISecurityModelToken SecurityModelToken { get; set; }

    public string? WelcomeText { get; set; }

    public bool IsWelcomeWindowVisible { get; set; }

    public string DecodedTokenJson { get; set; } = string.Empty;

    public List<TokenTreeItem> DecodedTokenTreeItems { get; set; } = [];

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

    public List<ReportMenuItem> SettingsMenuItems { get; } =
    [
        new() { Text = "Parameters", Url = "/settings/parameters" }
    ];

    public bool IsReportMenuOpen { get; set; }

    public bool IsSettingsMenuOpen { get; set; }

    public double ReportMenuTop { get; set; }

    public double ReportMenuLeft { get; set; }

    public double SettingsMenuTop { get; set; }

    public double SettingsMenuLeft { get; set; }

    private ElementReference ReportIconElement { get; set; }

    private ElementReference SettingsIconElement { get; set; }

    private DotNetObjectReference<MainLayout>? ReportMenuDotNetReference { get; set; }

    private bool RegisterOutsideClickHandler { get; set; }

    private string OutsideClickMenuSelector { get; set; } = "#report-menu";

    private string OutsideClickTriggerSelector { get; set; } = "#report-icon";

    public string SelectedTheme { get; set; } = "meridian";

    public bool IsDarkTheme => SelectedTheme == "meridian-dark";

    public string? EnvironmentBannerText => ClientSettings.Environment?.Trim().ToLowerInvariant() switch
    {
        AppConstants.DevelopmentEnvironment => "Development",
        "deployment" => "UAT",
        _ => null
    };

    public string EnvironmentBannerColor => ClientSettings.Environment?.Trim().ToLowerInvariant() switch
    {
        AppConstants.DevelopmentEnvironment => "#99FF99",
        "deployment" => "#9999FF",
        _ => string.Empty
    };

    public bool ShowEnvironmentFrame => !string.IsNullOrEmpty(EnvironmentBannerText);

    public string EnvironmentFrameStyle => ShowEnvironmentFrame
        ? $"--env-accent-color:{EnvironmentBannerColor}; --env-background-color:{(IsDarkTheme ? "#000000" : "#ffffff")};"
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
            var hasStoredTheme = !storedTheme.IsNullOrBlank();

            SelectedTheme = hasStoredTheme
                ? storedTheme!
                : await ThemeService.GetSystemThemeAsync();

            await ThemeService.SetThemeAsync(SelectedTheme, hasStoredTheme);
            StateHasChanged();
        }

        if (RegisterOutsideClickHandler && (IsReportMenuOpen || IsSettingsMenuOpen))
        {
            ReportMenuDotNetReference ??= DotNetObjectReference.Create(this);
            await JsRuntime.InvokeVoidAsync("appLayoutHelper.registerOutsideClick", ReportMenuDotNetReference, OutsideClickMenuSelector, OutsideClickTriggerSelector);
            RegisterOutsideClickHandler = false;
        }
    }

    private async Task OnThemeChanged(bool value)
    {
        CloseReportMenu();
        SelectedTheme = value ? "meridian-dark" : "meridian";
        await ThemeService.SetThemeAsync(SelectedTheme);
    }

    private async Task OnWelcomeClicked()
    {
        CloseReportMenu();
        IsWelcomeWindowVisible = true;

        try
        {
            var securityToken = await SecurityModelToken.GetSecurityToken();
            UpdateDecodedTokenDisplay(securityToken.Payload, "Decoded Token");
        }
        catch (Exception ex)
        {
            UpdateDecodedTokenDisplay(new { Error = ex.Message }, "Token Error");
        }
    }

    private void UpdateDecodedTokenDisplay(object payload, string rootLabel)
    {
        var jsonNode = JsonSerializer.SerializeToNode(payload, PrettyPrintJsonOptions);
        DecodedTokenJson = jsonNode?.ToJsonString(PrettyPrintJsonOptions) ?? string.Empty;
        DecodedTokenTreeItems = jsonNode is null
            ? []
            : [BuildTreeItem(rootLabel, jsonNode)];
    }

    private static TokenTreeItem BuildTreeItem(string text, JsonNode? node)
    {
        if (node is null)
        {
            return new TokenTreeItem { Text = $"{text}: null" };
        }

        if (node is JsonObject jsonObject)
        {
            return new TokenTreeItem
            {
                Text = text,
                Items = [.. jsonObject.Select(property => BuildTreeItem(property.Key, property.Value))]
            };
        }

        if (node is JsonArray jsonArray)
        {
            return new TokenTreeItem
            {
                Text = text,
                Items = [.. jsonArray.Select((item, index) => BuildTreeItem($"[{index}]", item))]
            };
        }

        return new TokenTreeItem
        {
            Text = $"{text}: {FormatNodeValue(node)}"
        };
    }

    private static string FormatNodeValue(JsonNode node)
    {
        if (node is JsonValue jsonValue)
        {
            if (jsonValue.TryGetValue<string>(out var stringValue))
            {
                return stringValue;
            }

            if (jsonValue.TryGetValue<bool>(out var boolValue))
            {
                return boolValue.ToString();
            }

            if (jsonValue.TryGetValue<int>(out var intValue))
            {
                return intValue.ToString();
            }

            if (jsonValue.TryGetValue<long>(out var longValue))
            {
                return longValue.ToString();
            }

            if (jsonValue.TryGetValue<double>(out var doubleValue))
            {
                return doubleValue.ToString();
            }

            if (jsonValue.TryGetValue<decimal>(out var decimalValue))
            {
                return decimalValue.ToString();
            }
        }

        return node.ToJsonString();
    }

    private Task OnWelcomeWindowVisibleChanged(bool visible)
    {
        IsWelcomeWindowVisible = visible;
        return Task.CompletedTask;
    }

    private async Task OnCopyTokenClicked()
    {
        await JsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", DecodedTokenJson ?? string.Empty);
    }

    private Task OnCloseWelcomeWindowClicked()
    {
        IsWelcomeWindowVisible = false;
        return Task.CompletedTask;
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

    private void OnSearchClicked()
    {
        CloseReportMenu();
        NavigationManager.NavigateTo("/search");
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

        IsSettingsMenuOpen = false;
        IsReportMenuOpen = true;
        OutsideClickMenuSelector = "#report-menu";
        OutsideClickTriggerSelector = "#report-icon";
        RegisterOutsideClickHandler = true;
    }

    private async Task ToggleSettingsMenu()
    {
        if (IsSettingsMenuOpen)
        {
            CloseReportMenu();
            return;
        }

        var rect = await JsRuntime.InvokeAsync<ElementRect>("appLayoutHelper.getElementRect", SettingsIconElement);
        if (rect is not null)
        {
            SettingsMenuTop = rect.Bottom + 4;
            SettingsMenuLeft = rect.Left;
        }

        IsReportMenuOpen = false;
        IsSettingsMenuOpen = true;
        OutsideClickMenuSelector = "#settings-menu";
        OutsideClickTriggerSelector = "#settings-icon";
        RegisterOutsideClickHandler = true;
    }

    private void CloseReportMenu()
    {
        IsReportMenuOpen = false;
        IsSettingsMenuOpen = false;
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

    private void OnSettingsMenuItemClicked(ReportMenuItem item)
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

    public class TokenTreeItem
    {
        public string Text { get; set; }

        public List<TokenTreeItem> Items { get; set; } = [];
    }
}
