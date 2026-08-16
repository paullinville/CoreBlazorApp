using Midland.Core.Authorization;
using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class ApiTokenStorageModel
{
    public ApiTokenBodyModel EditModel { get; set; }

    public List<Permission> Permissions { get; set; }   
    public List<Guid> Other {  get; set; }
}