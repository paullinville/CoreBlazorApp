using Midland.Core.Common;

namespace BlazorApp.Classes;

public class ClientSettings
{
    private string securityModelHost;

    public string ApiHost { get; set; }

    public string SecurityModelHost { get => securityModelHost ?? ApiHost; set => securityModelHost = value; }

    public UserTokenRequestModel UserTokenRequestModel { get; set; }

    public bool UseMocks { get; set; } = false;
}
