using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ServiceTokenBaseModel
{
	/// <summary>
	/// If false the token validation will fail.
	/// </summary>
	public bool Active { get; set; }

	/// <summary>
	/// List of hosts that calls can originate from.
	/// </summary>
	public List<string> AllowedHosts { get; set; } = new List<string>();

	[Required, MaxLength(512), MinLength(5)]
	public string Description { get; set; }

	/// <summary>
	/// If set will be the expires (exp) claim of the token. If set to null the token will not expire.
	/// </summary>
	public DateTime? Expires { get; set; }

	/// <summary>
	/// The Guid that identifies the service token. It is the the jti claim for the created token.
	/// </summary>
	[Required]
	public Guid Id { get; set; }

	[Required]
	[MinLength(1), MaxLength(250)]
	public string Name { get; set; }

	public int PrimaryResponsibleUserRef { get; set; }

	public List<int> SecondaryResponsibleUserRefs { get; set; }
}

public class ServiceTokenUpdateModel : ServiceTokenBaseModel
{
	public List<string> AdditionalOtherApplications { get; set; } = [];

	/// <summary>
	/// The list of actions/claims the service will be given.
	/// </summary>
	public List<TokenPermission> AdditionalPermissions { get; set; } = [];
}

public class ServiceTokenGetModel : ServiceTokenBaseModel
{
	public List<string> OtherApplications { get; set; } = [];

	/// <summary>
	/// The list of actions/claims the service will be given.
	/// </summary>
	public List<TokenPermission> Permissions { get; set; } = [];
}