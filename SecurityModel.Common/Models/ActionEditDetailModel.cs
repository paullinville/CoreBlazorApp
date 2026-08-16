using System;

namespace SecurityModel.Common.Models;

public class ActionEditDetailModel : ActionEditModel
{
	public ActionEditDetailModel()
	{ }

	public ActionEditDetailModel(IApplicationAction action)
	{
		ActionRef = action.ActionRef;
		ApplicationRef = action.ApplicationRef;
		Name = action.ActionName;
		Description = action.ActionDescription;
		CreateDate = action.ActionCreateDate;
	}

	public ActionEditDetailModel(IAction action)
	{
		ActionRef = action.ActionRef;
		ApplicationRef = action.ApplicationRef;
		Name = action.Name;
		Description = action.Description;
		CreateDate = action.CreateDate;
	}

	public string Name { get; set; }
	public int ApplicationRef { get; set; }
	public DateTime CreateDate { get; set; }
}