using Midland.Core.Common;

namespace BlazorApp.Common;

public class ClientSettings
{
    public string ApplicationName { get; set; } = "";
    public string? Environment { get; set; }
    private string? securityModelHost;

    public string ApiHost { get; set; } = "";

    public string SecurityModelHost { get => securityModelHost ?? ApiHost; set => securityModelHost = value; }

    public UserTokenRequestModel? UserTokenRequestModel { get; set; }

    public bool UseMocks { get; set; } = false;
}