using System;

/// <summary>
/// Default sort field is Name and include field is RoleRef
/// </summary>
public class RoleCriteriaBindingModel : SortAndIncludeFilter
{
	public RoleCriteriaBindingModel()
	{
		IncludeField = nameof(IRole.RoleRef);
		DefaultSortField = nameof(IRole.Name);
		SortByDir = "Asc";
	}

	[FilterProperty($"{nameof(IRole.CreateDate)}", Comparison = "<=")]
	public DateTime? CreateDateEnd { get; set; }

	[FilterProperty($"{nameof(IRole.CreateDate)}", Comparison = ">=")]
	public DateTime? CreateDateStart { get; set; }

	[FilterProperty($"{nameof(IRole.CreateUserRef)}", Comparison = "")]
	public int? CreateUserRef { get; set; }

	[FilterProperty($"{nameof(IRole.Description)}", Comparison = "")]
	public string Description { get; set; }

	[FilterProperty($"{nameof(IRole.Name)}", Comparison = "")]
	public string Name { get; set; }

	[FilterProperty($"{nameof(IRole.RoleRef)}", Comparison = "")]
	public int? RoleRef { get; set; }

	[FilterProperty($"{nameof(IRole.UpdateDate)}", Comparison = "<=")]
	public DateTime? UpdateDateEnd { get; set; }

	[FilterProperty($"{nameof(IRole.UpdateDate)}", Comparison = ">=")]
	public DateTime? UpdateDateStart { get; set; }

	[FilterProperty($"{nameof(IRole.UpdateUserRef)}", Comparison = "")]
	public int? UpdateUserRef { get; set; }
}

public class RoleCriteriaModel : RoleCriteriaBindingModel
{
	public RoleCriteriaModel()
	{ }

	public RoleCriteriaModel(RoleCriteriaBindingModel crit, int applicationRef)
	{
		ApplicationRef = applicationRef;
		CreateDateEnd = crit.CreateDateEnd;
		CreateDateStart = crit.CreateDateStart;
		CreateUserRef = crit.CreateUserRef;
		Description = crit.Description;
		Name = crit.Name;
		RoleRef = crit.RoleRef;
		UpdateDateEnd = crit.UpdateDateEnd;
		UpdateDateStart = crit.UpdateDateStart;
		UpdateUserRef = crit.UpdateUserRef;
		Include = crit.Include;
		SortBy = crit.SortBy;
		SortByDir = crit.SortByDir;
	}

	[FilterProperty($"{nameof(IRole.ApplicationRef)}", Comparison = "")]
	public int? ApplicationRef { get; set; }
}