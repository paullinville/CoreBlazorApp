using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class TokenPermission
{
    /// <summary>
    /// The list of actions to grant permissions to. Must be a valid Action for the application.
    /// </summary>
    public List<string> Actions { get; set; }

    /// <summary>
    /// The application slug of the application to give permissions to. Must be a valid and active application.
    /// </summary>
    public string ApplicationSlug { get; set; }
}