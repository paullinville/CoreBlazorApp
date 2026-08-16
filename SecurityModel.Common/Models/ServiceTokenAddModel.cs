using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ServiceTokenAddModel : TokenAddModel
{
    /// <summary>
    /// If false the token validation will fail.
    /// </summary>
    public bool Active { get; set; }

    public List<string> AllowedHosts { get; set; } = new List<string>();

    [Required, MaxLength(512), MinLength(5)]
    public string Description { get; set; }

    /// <summary>
    /// If set will be the expires (exp) claim of the token. If set to null the token will not expire.
    /// </summary>
    public DateTime? Expires { get; set; }

    /// <summary>
    /// The name of the organization or individual that the token is for. Will be the "subject"
    /// claim of the token. Will also be the path the token is stored in Vault
    /// (secret/token/{TokenId}) for API tokens and will be used as the Name field of the token as
    /// stored in the ApplicationSecurity database. Must be unique.
    /// </summary>
    [Required]
    [MinLength(1), MaxLength(250)]
    public virtual string Name { get; set; }

    public int PrimaryResponsibleUserRef { get; set; }

    /// <summary>
    /// The users that can retrieve the token from the [GET /v1/Token/Service/{tokenId}] endpoint
    /// </summary>
    public List<int> SecondaryResponsibleUserRefs { get; set; } = new List<int>();
}