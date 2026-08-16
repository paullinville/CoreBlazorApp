using System;

namespace SecurityModel.Common.Models;

public class ContextDeleteModel
{
	public int ContextRef { get; set; }
}

public class ContextEditModel : ContextAddModel
{
	public ContextEditModel()
	{ }

	public ContextEditModel(IContext values) : base(values)
	{
		ContextRef = values.ContextRef;
	}

	public int ContextRef { get; set; }

	public override SecurityModel.Common.Dto.ContextDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ContextDto();
		createdItem.ApplicationContextRef = ApplicationContextRef;
		createdItem.ApplicationRef = ApplicationRef;
		createdItem.CreateDate = CreateDate;
		createdItem.ContextRef = ContextRef;
		createdItem.TypeRef = TypeRef;
		return createdItem;
	}
}

public class ContextAddModel
{
	public ContextAddModel()
	{ }

	public ContextAddModel(IContext values)
	{
		if (values == null) return;
		ApplicationContextRef = values.ApplicationContextRef;
		ApplicationRef = values.ApplicationRef;
		CreateDate = values.CreateDate;
		TypeRef = values.TypeRef;
	}

	public int ApplicationContextRef { get; set; }
	public int ApplicationRef { get; set; }
	public DateTime CreateDate { get; set; }
	public int TypeRef { get; set; }

	public virtual SecurityModel.Common.Dto.ContextDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ContextDto();
		createdItem.ApplicationContextRef = ApplicationContextRef;
		createdItem.ApplicationRef = ApplicationRef;
		createdItem.CreateDate = CreateDate;
		createdItem.TypeRef = TypeRef;
		return createdItem;
	}
}