namespace Midland.Core.ApplicationSecurity;

public interface IMidlandRoleUser
{
	int RoleRef { get; set; }
	int UserRef { get; set; }
}