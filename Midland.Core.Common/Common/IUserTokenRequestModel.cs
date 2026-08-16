namespace Midland.Core.Common;

public interface IUserTokenRequestModel
{
    List<string> OtherApplications { get; set; }
    List<string> PrimaryApplications { get; set; }
}