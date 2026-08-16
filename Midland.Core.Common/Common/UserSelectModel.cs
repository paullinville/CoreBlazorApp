using System.ComponentModel.DataAnnotations;

namespace Midland.Core.Common;

public class UserSelectModel
{
    public string FullName { get; set; }

    public string LastNameFirst { get; set; }

    /// <summary>
    /// The unique identifier.
    /// </summary>
    public int UserRef { get; set; }
}