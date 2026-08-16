using SecurityModel.Common.Dto;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class AuditData<T>
{
	public ActionDto Action { get; set; }
	public ActionGroupDto ActionGroup { get; set; }
	public AuditAction AuditAction { get; set; }
	public SerializedData<T> Detail { get; set; }
	public RoleDto Role { get; set; }
	public List<Employee> Users { get; set; }

	public string Description(IMidlandUser actor, IApplication app)
	{
		switch (AuditAction)
		{
			case AuditAction.AddActionToRole:
				{
					return $"Action '{Action?.Name}' added to role '{Role?.Name}' by {actor?.FullName} for '{app?.Name}'.";
				}

			case AuditAction.RemoveActionFromRole:
				{
					return $"Action '{Action?.Name}' removed from role '{Role?.Name}' by {actor?.FullName} for '{app?.Name}'.";
				}
			case AuditAction.AddUserToRole:
				{
					return $"User(s) {Users.Values().Select(r => r?.FullName).ListToString(", ")} added to role '{Role?.Name}' by {actor?.FullName} for '{app?.Name}'.";
				}
			case AuditAction.RemoveUserFromRole:
				{
					return $"User(s) {Users.Values().Select(r => r?.FullName).ListToString(", ")} removed from role '{Role?.Name}' by {actor?.FullName} for '{app?.Name}'.";
				}
			case AuditAction.AddRole:
				{
					return $"Role '{Role?.Name}' added by {actor?.FullName} for '{app?.Name}'.";
				}
			case AuditAction.DeleteRole:
				{
					return $"Role '{Role?.Name}' deleted by {actor?.FullName} for '{app?.Name}'.";
				}
			case AuditAction.EditRole:
				{
					return $"Role '{Role?.Name}' edited by {actor?.FullName} for '{app?.Name}'.";
				}
			case AuditAction.AddApiToken:
				{
					return $"API Token for {Detail?.Title} added.";
				}
			case AuditAction.ReplaceApiToken:
				{
					return $"API Token for {Detail?.Title} updated.";
				}
			case AuditAction.ServiceTokenAdded:
				{
					return $"Service Token with subject {Detail?.Title} added with responsible users of {Users.Values().Select(r => r?.FullName).ListToString(", ")}.";
				}
			case AuditAction.AddApplication:
				{
					return $"Application '{app?.Name}' added by {actor?.FullName}.";
				}
			case AuditAction.AddActionGroupToRole:
				{
					return $"Action '{Action?.Name}' added to role '{Role?.Name}' by {actor?.FullName} for '{app?.Name}' via Action Group.";
				}
			case AuditAction.RemoveActionGroupFromRole:
				{
					return $"Action '{Action?.Name}' remove from role '{Role?.Name}' by {actor?.FullName} for '{app?.Name}' via Action Group removal.";
				}
		}

		return $"{AuditAction} ";
	}
}

public class SerializedData<T>
{
	private string theDataType;

	public SerializedData()
	{ }

	public SerializedData(T data)
	{
		Data = data;
	}

	public T Data { get; set; }

	public string Title { get; set; }

	public string TypeOfData
	{
		get
		{
			if (Data != null)
			{
				theDataType = Data.GetType().FullName;
			}
			else
			{
				theDataType = null;
			}
			return theDataType;
		}
		set
		{
			theDataType = value;
		}
	}
}