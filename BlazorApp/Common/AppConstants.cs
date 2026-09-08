using CsvHelper.Configuration.Attributes;
using Midland.Core.Api;
using Midland.Core.Common;

namespace BlazorApp.Common;

public static class AppConstants
{
    public const string InfoColor = "info";
    public const string SuccessColor = "success";
    public const string WarningColor = "warning";
    public const string ErrorColor = "error";

    public const string MidlandOrange = "#dc6b12";

    public static string ToThemeColor(NotificationThemeColor themeColor)
    {
        return themeColor switch
        {
            NotificationThemeColor.Info => InfoColor,
            NotificationThemeColor.Success => SuccessColor,
            NotificationThemeColor.Warning => WarningColor,
            NotificationThemeColor.Error => ErrorColor,
            _ => InfoColor
        };
    }
}

public enum NotificationThemeColor
{
    Info,
    Success,
    Warning,
    Error
}