using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ServiceTokenActiveModel
{
	/// <summary>
	/// The Guid that identifies the service token. It is the the jti claim for the created token.
	/// </summary>
	[Required]
	public Guid Id { get; set; }

	/// <summary>
	/// If false the token validation will fail.
	/// </summary>
	public bool Active { get; set; }
}