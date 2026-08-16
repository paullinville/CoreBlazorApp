namespace SecurityModel.Common.Models;

public class ContextTypeEditModel : ContextTypeAddModel
{
	public ContextTypeEditModel()
	{ }

	public ContextTypeEditModel(IContextType values) : base(values)
	{
		ContextTypeRef = values.ContextTypeRef;
	}

	public int ContextTypeRef { get; set; }

	public override SecurityModel.Common.Dto.ContextTypeDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ContextTypeDto();
		createdItem.ApplicationRef = ApplicationRef;
		createdItem.CreateDate = CreateDate;
		createdItem.Description = Description;
		createdItem.Name = Name;
		createdItem.ContextTypeRef = ContextTypeRef;
		return createdItem;
	}
}
