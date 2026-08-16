using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class TokenAddModel
{
    /// <summary>
    /// The list of application slugs that only need authenticated user access. Must be a valid application
    /// </summary>
    public IEnumerable<string> OtherApplications { get; set; }

    /// <summary>
    /// The list of actions/claims the service will be given.
    /// </summary>
    public IEnumerable<TokenPermission> Permissions { get; set; }
}