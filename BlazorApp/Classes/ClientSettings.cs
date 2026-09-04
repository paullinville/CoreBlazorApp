using Midland.Core.Common;

namespace BlazorApp.Classes;

public class ClientSettings
{
    public required string ApplicationName { get; set; }
    public string? Environment { get; set; }
    private string? securityModelHost;

    public required string ApiHost { get; set; }

    public string SecurityModelHost { get => securityModelHost ?? ApiHost; set => securityModelHost = value; }

    public UserTokenRequestModel? UserTokenRequestModel { get; set; }

    public bool UseMocks { get; set; } = false;
}
