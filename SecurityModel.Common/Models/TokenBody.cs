using Midland.Core.Authorization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SecurityModel.Common.Models;

public class TokenBody
{
	[JsonPropertyName("sub")]
	public string Subject { get; set; }

	[JsonPropertyName("version")]
	public int Version { get; set; }

	[JsonPropertyName("permissions")]
	public List<Permission> Permissions { get; set; }

	[JsonPropertyName("jti")]
	public string JsonTokenIdentifier { get; set; }

	[JsonPropertyName("userId")]
	public string UserId { get; set; }

	[JsonPropertyName("aud")]
	public string[] Audience { get; set; }

	[JsonPropertyName("userRef")]
	public int UserRef { get; set; }

	[JsonPropertyName("email")]
	public string Email { get; set; }

	[JsonPropertyName("userName")]
	public string UserName { get; set; }
}