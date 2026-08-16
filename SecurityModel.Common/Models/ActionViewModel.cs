namespace SecurityModel.Common.Models;

public class ActionViewModel
{
	public ActionViewModel()
	{ }

	public ActionViewModel(IAction action)
	{
		Description = action.Description;
		ActionRef = action.ActionRef;
		Name = action.Name;
	}

	public ActionViewModel(IApplicationAction action)
	{
		Description = action.ActionDescription;
		ActionRef = action.ActionRef;
		Name = action.ActionName;
	}

	public ActionViewModel(IApplicationUserRoleAction action)
	{
		Description = action.ActionDescription;
		ActionRef = action.ActionRef;
		Name = action.ActionName;
	}

	public string Description { get; set; }
	public int ActionRef { get; set; }
	public string Name { get; set; }
}