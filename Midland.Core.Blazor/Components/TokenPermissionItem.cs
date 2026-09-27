using System.Text.Json.Serialization;

namespace Midland.Core.Blazor.Components;

public class TokenPermissionItem
{
    [JsonPropertyName("applicationName")]
    public string? ApplicationName { get; set; }

    [JsonPropertyName("applicationSlug")]
    public string? ApplicationSlug { get; set; }

    [JsonPropertyName("applicationGuid")]
    public Guid ApplicationGuid { get; set; }

    [JsonPropertyName("actions")]
    public List<string> Actions { get; set; } = [];

    public string DisplayName => string.IsNullOrWhiteSpace(ApplicationName) ? (ApplicationSlug ?? string.Empty) : ApplicationName;
}
