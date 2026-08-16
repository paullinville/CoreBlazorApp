global using Midland.Core.Common;
global using SecurityModel.Common.Interfaces;
global using System.Linq;
using Midland.Core.Authorization;

namespace SecurityModel.Common;

public class ClaimDefinitions
{
	public const string AuthenticatedUser = AuthConstants.AuthenticatedUser;

	#region Service tokens

	[ClaimActionDescription("Allows creation of Service Tokens and assigning them to users.")]
	public const string ServiceTokenCreate = "Service Token Create";

	[ClaimActionDescription("Allows activating/deactivating existing Service Tokens.")]
	public const string ServiceTokenMaintenance = "Service Token Maintenance";

	#endregion Service tokens

	#region Applications

	[ClaimActionDescription("Allow user to administrate applications.")]
	public const string AddApplication = "(Add Application)";

	[ClaimActionDescription("Allow user to edit applications.")]
	public const string EditApplication = "(Edit Application)";

	#endregion Applications

	#region API Tokens

	[ClaimActionDescription("Allows creation of API Tokens.")]
	public const string ApiTokenCreate = "API Token Create";

	#endregion API Tokens

	#region Audit

	[ClaimActionDescription("This action will allow a user to search the audit history within the application.")]
	public const string AuditSearchPageViewAuditSearchScreen = "Security Model Audit Search Page * View Audit Search Results";

	#endregion Audit

	#region Role

	[ClaimActionDescription("This will allow the user to add and remove roles to the application.")]
	public const string AddRole = "(Add Role)";

	[ClaimActionDescription("This will allow the user to view the current roles within the application.")]
	public const string RoleList = "Role List Page * View Role List";

	#region SecurityModel Exclusive

	[ClaimActionDescription("This will allow the user to delete a role from any application.")]
	public const string DeleteRole = "(Delete Role)";

	[ClaimActionDescription("This will allow the user to add a new role to any application.")]
	public const string EditRole = "(Edit Role)";

	#endregion SecurityModel Exclusive

	#endregion Role

	#region Action

	[ClaimActionDescription("This will allow the user to assign actions to roles.")]
	public const string AssignActionsToRoles = "(Assign Actions To Roles)";

	[ClaimActionDescription("This will allow the user to edit the action description.")]
	public const string EditAction = "Edit Action";

	#endregion Action

	#region Users

	[ClaimActionDescription("Add a role for a user in the system.")] public const string AddUserRole = "(Add User Role)";

	[ClaimActionDescription("Add a role for a user in the system")]
	public const string EditUserRoles = "(Edit User Roles)";

	[ClaimActionDescription("Remove a role assigned to a user.")] public const string RemoveUserRole = "(Remove User Role)";

	[ClaimActionDescription("This will allow the user to see actions for other users.")]
	public const string UserActionPageViewUserActions = "User Action Page * View User Actions";

	[ClaimActionDescription("This will allow the user to see the role(s) for other users.")]
	public const string UserRolePageViewUserRoles = "User Role Page * View User Roles";

	#endregion Users
}