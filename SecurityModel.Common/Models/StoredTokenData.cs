using Midland.Core.Authorization;
using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class StoredTokenData : TokenData
{
    public List<string> AllowedHosts { get; set; }
    public DateTime? ExpirationDate { get; set; }
}