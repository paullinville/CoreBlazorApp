using System;

namespace SecurityModel.Common.Models;

public class ActionGroupCriteria : ActionGroupCriteriaBase
{
	public ActionGroupCriteria()
	{
	}

	public ActionGroupCriteria(ActionGroupCriteriaBase baseCrit, int applicationRef)
	{
		ActionGroupRef = baseCrit.ActionGroupRef;
		ApplicationRef = applicationRef;
		CreatedDateEnd = baseCrit.CreatedDateEnd;
		CreatedDateStart = baseCrit.CreatedDateStart;
		Name = baseCrit.Name;
		Description = baseCrit.Description;
	}

	[FilterProperty($"{nameof(IActionGroup.ApplicationRef)}")]
	public int ApplicationRef { get; set; }
}

public class ActionGroupCriteriaBase : SortAndIncludeFilter
{
	public ActionGroupCriteriaBase()
	{
		IncludeField = nameof(IActionGroup.ActionGroupRef);
		DefaultSortField = nameof(IActionGroup.ActionGroupRef);
	}

	[FilterProperty($"{nameof(IActionGroup.ActionGroupRef)}", Comparison = "")]
	public int? ActionGroupRef { get; set; }

	[FilterProperty($"{nameof(IActionGroup.ActionCreateDate)}", Comparison = "<=")]
	public DateTime? CreatedDateEnd { get; set; }

	[FilterProperty($"{nameof(IActionGroup.ActionCreateDate)}", Comparison = ">=")]
	public DateTime? CreatedDateStart { get; set; }

	[FilterProperty($"{nameof(IActionGroup.Description)}", Comparison = "")]
	public string Description { get; set; }

	[FilterProperty($"{nameof(IActionGroup.Name)}", Comparison = "")]
	public string Name { get; set; }
}