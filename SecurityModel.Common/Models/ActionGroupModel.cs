using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ActionGroupDeleteModel
{
	public virtual int ActionGroupRef { get; set; }
}

public class ActionGroupGetModel : ActionGroupPostModel
{
	public ActionGroupGetModel()
	{ }

	public ActionGroupGetModel(IActionGroup values) : base(values)
	{
		ActionGroupRef = values.ActionGroupRef;
	}

	public int ActionGroupRef { get; set; }

	public override SecurityModel.Common.Dto.ActionGroupDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ActionGroupDto();
		createdItem.ActionCreateDate = CreatedDate;
		createdItem.Description = Description;
		createdItem.Name = Name;
		createdItem.ActionGroupRef = ActionGroupRef;
		createdItem.ApplicationRef = ApplicationRef;
		return createdItem;
	}

	public override bool Equals(object obj)
	{
		if (obj is IActionGroup agh)
		{
			return agh.ActionGroupRef == ActionGroupRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return $"ActionGroup{ActionGroupRef}".GetHashCode();
	}
}

public class ActionGroupPutModel
{
	public ActionGroupPutModel()
	{ }

	public ActionGroupPutModel(IActionGroup values)
	{
		ActionGroupRef = values.ActionGroupRef;
		Body = new ActionGroupPostModel(values);
	}

	[Required, Range(1, int.MaxValue)]
	public virtual int ActionGroupRef { get; set; }

	public virtual ActionGroupPostModel Body { get; set; }

	public override bool Equals(object obj)
	{
		if (obj is IActionGroup agh)
		{
			return agh.ActionGroupRef == ActionGroupRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return $"ActionGroup{ActionGroupRef}".GetHashCode();
	}
}

public class ActionGroupPostModel
{
	public ActionGroupPostModel()
	{ }

	public ActionGroupPostModel(IActionGroup values)
	{
		if (values == null) return;
		CreatedDate = values.ActionCreateDate;
		Description = values.Description;
		Name = values.Name;
		ApplicationRef = values.ApplicationRef;
	}

	public int ApplicationRef { get; set; }

	[Range(typeof(DateTime), "1/1/1775", "12/31/9999 11:59AM")]
	public DateTime CreatedDate { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(400)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(150)]
	public string Name { get; set; }

	public virtual SecurityModel.Common.Dto.ActionGroupDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ActionGroupDto();
		createdItem.ActionCreateDate = CreatedDate;
		createdItem.Description = Description;
		createdItem.Name = Name;
		createdItem.ApplicationRef = ApplicationRef;
		return createdItem;
	}
}