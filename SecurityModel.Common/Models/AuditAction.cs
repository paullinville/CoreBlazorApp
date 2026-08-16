namespace SecurityModel.Common.Models;

public enum AuditAction
{
	AddRole = 0,
	EditRole = 1,
	DeleteRole = 2,
	AddUserToRole = 3,
	RemoveUserFromRole = 4,
	AddActionToRole = 5,
	RemoveActionFromRole = 6,
	AddApiToken = 7,
	ReplaceApiToken = 8,
	ServiceTokenAdded = 9,
	ServiceTokenUpdated = 10,
	AddApplication = 11,
	AddActionGroupToRole = 12,
	RemoveActionGroupFromRole = 13,
	AddActionToActionGroup = 14,
	RemoveActionFromActionGroup = 15,
	UpdateApplication = 16
}