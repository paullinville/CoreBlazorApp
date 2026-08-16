using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class UserTokenRequestBySlugModel
{
    /// <summary>
    /// List of Api Ids for the APIs you want limited access for. User actions will not be included
    /// and only endpoints with Authenticated User ("*") claim can be accessed. The Api Id can be
    /// found by calling the APIs healthz/expanded endpoint. (In earlier versions use the Api Name.)
    /// </summary>
    public List<string> OtherApplications { get; set; }

    /// <summary>
    /// List of Api Ids for the APIs you want to include the user's list of actions assigned to them
    /// for the Application/API specified. The Api Id can be found by calling the APIs
    /// healthz/expanded endpoint. (In earlier versions use the Api Name.)
    /// </summary>
    public List<string> PrimaryApplications { get; set; }

    public List<string> AllRequestedSlugs()
    {
        return OtherApplications.Values().Concat(PrimaryApplications.Values()).ToList();
    }
}