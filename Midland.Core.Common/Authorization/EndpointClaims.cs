namespace Midland.Core.Authorization.Reporting;

public class EndpointClaims
{
	public string Path { get; set; }
	public ActionGroupDictionary Claims { get; set; }
}