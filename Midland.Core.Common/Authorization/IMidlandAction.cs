namespace Midland.Core.ApplicationSecurity;

public interface IMidlandAction
{
	int ActionRef { get; }
	DateTime CreateDate { get; }
	string Description { get; }
	string Name { get; }
}