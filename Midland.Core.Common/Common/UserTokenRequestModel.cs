namespace Midland.Core.Common;

/// <summary>
/// The model used to request a application token.
/// </summary>
public class UserTokenRequestModel : IUserTokenRequestModel
{
    public List<string> OtherApplications { get; set; }

    /// <summary>
    /// The guid for the application in the security model.
    /// </summary>
    public List<string> PrimaryApplications { get; set; }
}