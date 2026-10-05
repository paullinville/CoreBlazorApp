namespace Midland.Core.Blazor;

public static class AppConstants
{
    public const string InfoColor = "info";
    public const string SuccessColor = "success";
    public const string WarningColor = "warning";
    public const string ErrorColor = "error";

    public const string DevelopmentEnvironment = "development";

    public const string MidlandOrange = "#FF5B00";

    public const string MidlandOrangeCompliment = "#00A6FF";

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