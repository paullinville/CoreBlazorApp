using System;

namespace SecurityModel.Common.Models;

public class ApplicationUserRoleCriteria : ApplicationUserRoleCriteriaBase
{
	public ApplicationUserRoleCriteria() : base()
	{
	}

	public ApplicationUserRoleCriteria(ApplicationUserRoleCriteriaBase crit) : base()
	{
		Include = crit.Include;
		SortBy = crit.SortBy;
		SortByDir = SortByDir;

		Description = crit.Description;
		FullName = crit.FullName;
		LastNameFirst = crit.LastNameFirst;
		Name = crit.Name;
		RoleAssignedDateEnd = crit.RoleAssignedDateEnd;
		RoleAssignedDateStart = crit.RoleAssignedDateStart;
		UserRef = crit.UserRef;
	}

	[FilterProperty($"{nameof(IApplicationUserRole.ApplicationApiName)}", Comparison = "")]
	public string ApiName { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.ApplicationName)}", Comparison = "")]
	public string ApplicationName { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.ApplicationRef)}", Comparison = "")]
	public int? ApplicationRef { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.ApplicationGuid)}", Comparison = "")]
	public Guid? Guid { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.RoleRef)}", Comparison = "")]
	public int? RoleRef { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.ApplicationSlug)}", Comparison = "")]
	public string Slug { get; set; }
}

public class ApplicationUserRoleCriteriaBase : SortAndIncludeFilter
{
	public ApplicationUserRoleCriteriaBase()
	{
		IncludeField = nameof(IRole.RoleRef);
		DefaultSortField = nameof(IApplicationUserRole.UserLastNameFirst);
	}

	[FilterProperty($"{nameof(IApplicationUserRole.RoleDescription)}", Comparison = "")]
	public string Description { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.UserFullName)}", Comparison = "")]
	public string FullName { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.UserLastNameFirst)}", Comparison = "")]
	public string LastNameFirst { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.RoleName)}", Comparison = "")]
	public string Name { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.HolderCreateDate)}", Comparison = "<=")]
	public DateTime? RoleAssignedDateEnd { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.HolderCreateDate)}", Comparison = ">=")]
	public DateTime? RoleAssignedDateStart { get; set; }

	[FilterProperty($"{nameof(IApplicationUserRole.UserRef)}", Comparison = "")]
	public int? UserRef { get; set; }
}