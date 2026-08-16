using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class ActionGroupViewModel : ActionGroupGetModel
{
	public ActionGroupViewModel()
	{ }

	public ActionGroupViewModel(IActionGroup values) : base(values)
	{
	}

	public ActionGroupViewModel(IActionGroup values, IEnumerable<IAction> actions) : base(values)
	{
		Actions = actions.Values()
						 .Select(r => new ActionEditDetailModel(r))
						 .OrderBy(r => r.Name)
						 .ToList();
	}

	public List<ActionEditDetailModel> Actions { get; set; }
}