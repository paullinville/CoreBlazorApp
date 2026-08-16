namespace SecurityModel.Common.Models;

public class ApplicationRoleReport
{
	public string ApplicationName { get; set; }
	public string RoleName { get; set; }
	public string Description { get; set; }
	public bool Removable { get; set; }
	public string ActionName { get; set; }
}