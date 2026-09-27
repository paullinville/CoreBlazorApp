using Midland.Core.Common;

namespace BlazorApp.Common;

public class ClientSettings
{
    public string ApplicationName { get; set; } = "";
    public string ApplicationOrigin { get => applicationOrigin ?? ApplicationName; set => applicationOrigin = value; }
    public string? Environment { get; set; }
    private string? securityModelHost;
    private string applicationOrigin;

    public string ApiHost { get; set; } = "";

    public string SecurityModelHost { get => securityModelHost ?? ApiHost; set => securityModelHost = value; }

    public UserTokenRequestModel? UserTokenRequestModel { get; set; }

    public bool UseMocks { get; set; } = false;
}