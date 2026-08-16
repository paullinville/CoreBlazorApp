using System.Text.Json.Serialization;

namespace Midland.Core.Api;

//Naming required due to being a result from a Vault API call.
public class VaultResult<T>
{
	[JsonPropertyName("Request_ID")]
	public string RequestId { get; set; }

	[JsonPropertyName("Lease_ID")]
	public string LeaseId { get; set; }

	[JsonPropertyName("Renewable")]
	public bool Renewable { get; set; }

	[JsonPropertyName("Lease_Duration")]
	public int LeaseDuration { get; set; }

	public T Data { get; set; }

	[JsonPropertyName("Wrap_Info")]
	public object WrapInfo { get; set; }

	[JsonPropertyName("Warnings")]
	public object Warnings { get; set; }

	[JsonPropertyName("Auth")]
	public object Auth { get; set; }
}