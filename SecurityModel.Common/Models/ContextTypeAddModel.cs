using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ContextTypeAddModel
{
	public ContextTypeAddModel()
	{ }

	public ContextTypeAddModel(IContextType values)
	{
		if (values == null) return;
		ApplicationRef = values.ApplicationRef;
		CreateDate = values.CreateDate;
		Description = values.Description + "";
		Name = values.Name + "";
	}

	public int ApplicationRef { get; set; }
	public DateTime CreateDate { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(500)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(150)]
	public string Name { get; set; }

	public virtual SecurityModel.Common.Dto.ContextTypeDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ContextTypeDto();
		createdItem.ApplicationRef = ApplicationRef;
		createdItem.CreateDate = CreateDate;
		createdItem.Description = Description;
		createdItem.Name = Name;
		return createdItem;
	}
}