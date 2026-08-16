global using EATTS.Common.Dto;
global using EATTS.Common.Interfaces;
global using EATTS.Common.Models;
global using Midland.Core.Authorization;

namespace EATTS.Common;

public class ClaimDefinitions
{
	[ClaimActionDescription("This will allow the user to view the current action groups within the application.")]
	public const string ActionGroupPageViewActionGroupList = "Action Group Page * View Action Group List";

	[ClaimActionDescription("This will allow the user to add a new action group to the application.")]
	public const string AddActionGroup = "(Add Action Group)";

	[ClaimActionDescription("This will allow the user add additional info for an error.")]
	public const string AddAdditionalInfo = "(Add Additional Info)";

	[ClaimActionDescription("This will allow the user to view the application page.")]
	public const string ApplicationAdminPage = "Application Admin Page";

	[ClaimActionDescription("This will allow the user to edit the application page.")]
	public const string ApplicationAdminPageEditInfo = "Application Admin Page * Edit Info";

	[ClaimActionDescription("This will allow the user to view the application management page.")]
	public const string ApplicationManagementPage = "Application Management Page";

	[ClaimActionDescription("Audit Search")]
	public const string AuditSearchPage = "Audit Search Page";

	public const string AuthenticatedUser = AuthConstants.AuthenticatedUser;

	[ClaimActionDescription("Add a role for a user in the system")]
	public const string EditUserRoles = "(Edit User Roles)";

	[ClaimActionDescription("This will allow the user to delete entries and their occurrences and change the status the error.")]
	public const string EntryDelete = "Delete Entry";

	[ClaimActionDescription("This will allow the user to search entries and their occurrences and view the results.")]
	public const string EntrySearch = "Entry Search";

	[ClaimActionDescription("This will allow the user to view the additional error info page.")]
	public const string ErrorAdditionalInfoPage = "Error Additional Info Page";

	[ClaimActionDescription("This will allow the user to view general information about the error.")]
	public const string ErrorAssignmentPage = "Error Assignment Page";

	[ClaimActionDescription("This will allow the user to edit general information about the error.")]
	public const string ErrorAssignmentPageEditInfo = "Error Assignment Page * Edit Info";

	[ClaimActionDescription("This will allow the user to view solutions for the error.")]
	public const string ErrorDevPage = "Error Dev Page";

	[ClaimActionDescription("This will allow the user to solutions to the error.")]
	public const string ErrorDevPageEditInfo = "Error Dev Page * Edit Info";

	[ClaimActionDescription("This will allow the user to view comments and audit history about the error.")]
	public const string ErrorHistoryPage = "Error History Page";

	[ClaimActionDescription("This will allow the user to enter comments and change the status the error.")]
	public const string ErrorHistoryPageEditInfo = "Error History Page * Edit Info";

	[ClaimActionDescription("Error History Page * View Audit History")]
	public const string ErrorHistoryPageViewAuditHistory = "Error History Page * View Audit History";

	[ClaimActionDescription("This will allow the user to view the error listing.")]
	public const string ErrorListingPage = "Error Listing Page";

	[ClaimActionDescription("This will allow the user to view the occurrence history for the error.")]
	public const string ErrorOccurrencePage = "Error Occurence Page";

	[ClaimActionDescription("This will allow the user to search for errors.")]
	public const string ErrorSearchPage = "Error Search Page";

	[ClaimActionDescription("This will allow the user to view the management start page.")]
	public const string ManagementStartPage = "Management Start Page";

	[ClaimActionDescription("User can edit support and entry options.")]
	public const string Options = "Options Edit";

	[ClaimActionDescription("Search Page")]
	public const string SearchPage = "Search Page";

	[ClaimActionDescription("This action will allow a user to search the audit history of the security model reguarding the application.")]
	public const string SecurityModelAuditSearchPageViewAuditSearchResults = "Security Model Audit Search Page * View Audit Search Results";

	[ClaimActionDescription("This will allow the user to edit the application page.")]
	public const string SettingsAdminEditInfo = "Settings Admin * Edit Info";

	[ClaimActionDescription("User")]
	public const string User = "General User. Read lists etc.";

	[ClaimActionDescription("The user will be allowed to view the other users in the system.")]
	public const string UserListPageViewUserList = "User List Page * View User List";

	[ClaimActionDescription("This will allow the user to see the role(s) for other users.")]
	public const string UserRolePageViewUserRoles = "User Role Page * View User Roles";
}