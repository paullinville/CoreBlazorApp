namespace SecurityModel.Common.Models;

public class UserRoleReportView
{
	public int ApplicationRef { get; set; }
	public int UserRef { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string Status { get; set; }
	public string LastNameFirst { get; set; }
	public string Roles { get; set; }
}