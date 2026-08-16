namespace Midland.Core.ApplicationSecurity;

public interface IMidlandRole
{
	DateTime CreateDate { get; }
	string Description { get; }
	bool IsActive { get; }
	string Name { get; }
	int RoleRef { get; }
}