using SecurityModel.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecurityModel.Common.Models;

public class UserRolesDetailAuditModel : UserRolesDetailModel
{
	public UserRolesDetailAuditModel()
	{
	}

	public UserRolesDetailAuditModel(IMidlandUser midlandUser, IEnumerable<IApplicationUserRoleAction> role, AuditModel audit) : base(midlandUser, role)
	{
		AddInformation(audit);
	}

	public List<AuditInformation> Information { get; set; } = new List<AuditInformation>();

	public void AddInformation(AuditModel audit)
	{
		var info = new AuditInformation();
		if (audit.AuditData != null)
		{
			info.Description = audit.Description;
			info.Action = audit.GetAuditData<object>().AuditAction.ToString();
		}
		else
		{
			info.Description = Regex.Replace(audit.Description, "<.*?>", string.Empty);
		}
		info.DateOf = audit.CreateDate;

		Information.Add(info);
	}

	public class AuditInformation
	{
		public string Action { get; set; }
		public DateTime DateOf { get; set; }
		public string Description { get; set; }
	}
}

public class UserRolesDetailModel : EmployeeSimple
{
	public UserRolesDetailModel()
	{ }

	public UserRolesDetailModel(IMidlandUser midlandUser, IEnumerable<IApplicationUserRoleAction> role) : base(midlandUser)
	{
		if (role.IsEmpty()) return;
		Roles = new List<UserRoleView>();
		Application = new ApplicationSummary(role.First());

		var roles = role.GroupTo(r => r.RoleRef);
		foreach (var roleGroupKey in roles.Keys)
		{
			Roles.Add(new UserRoleView(roles[roleGroupKey].First()));
			Roles.Last().Actions = roles[roleGroupKey].Select(r => new ActionViewModel(r)).ToList();
		}
	}

	public ApplicationSummary Application { get; set; }
	public bool IsActive { get => ((IEmployeeSimple)this).Active; }
	public List<UserRoleView> Roles { get; set; }
}