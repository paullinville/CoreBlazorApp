using System.Text.Json.Serialization;

namespace Midland.Core.Api;

public class VaultSecretMetaData
{
	[JsonPropertyName("created_time")]
	public DateTime CreatedTime { get; set; }

	[JsonPropertyName("custom_metadata")]
	public object CustomMetadata { get; set; }

	[JsonPropertyName("deletion_time")]
	public string DeletionTime { get; set; }

	[JsonPropertyName("Destroyed")]
	public bool Destroyed { get; set; }

	[JsonPropertyName("Version")]
	public int Version { get; set; }
}