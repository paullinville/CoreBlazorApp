global using EmployeeData.Common.Interfaces;
using Midland.Core.Authorization;

namespace EmployeeData.Common;

public class ClaimDefinitions
{
	public const string AuthenticatedUser = AuthConstants.AuthenticatedUser;

	[ClaimActionDescription("This is the base user role needed by all $safeprojectname$ users.")]
	public const string BaseUser = "Base User";

	[ClaimActionDescription("Add a role for a user in the system")]
	public const string EditUserRoles = "(Edit User Roles)";

	[ClaimActionDescription("This will allow the user to edit the parameters in the system.")]
	public const string ParameterAdmin = "Parameter Admin";

	[ClaimActionDescription("Parameters used to manage UKG access for reporting.")]
	public const string UKGAdmin = "UKG Admin";
}