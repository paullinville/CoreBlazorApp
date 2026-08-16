using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class UserTokenRequestByGuidModel
{
    /// <summary>
    /// List of App Guids for the APIs you want limited access for. User actions will not be
    /// included and only endpoints with Authenticated User ("*") claim can be accessed. The AppGuid
    /// can be found by calling the APIs healthz/expanded endpoint. (In earlier versions use the Api Name.)
    /// </summary>
    public List<Guid> OtherApplications { get; set; }

    /// <summary>
    /// List of App Guids for the APIs you want to include the user's list of actions assigned to
    /// them for the Application/API. The AppGuid can be found by calling the healthz/expanded
    /// endpoint The AppGuid can be found by calling the APIs healthz/expanded endpoint. (In earlier
    /// versions use the Api Name.)
    /// </summary>
    public List<Guid> PrimaryApplications { get; set; }
}