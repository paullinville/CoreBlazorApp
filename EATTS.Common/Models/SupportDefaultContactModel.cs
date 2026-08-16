namespace EATTS.Common.Models;

public class SupportDefaultContactDeleteModel
{
	public virtual int SupportDefaultContactRef { get; set; }
}

public class SupportDefaultContactEditModel : SupportDefaultContactAddModel
{
	public SupportDefaultContactEditModel()
	{ }

	public SupportDefaultContactEditModel(ISupportDefaultContact values) : base(values)
	{
		SupportDefaultContactRef = values.SupportDefaultContactRef;
	}

	public int SupportDefaultContactRef { get; set; }

	public override EATTS.Common.Dto.SupportDefaultContactDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.SupportDefaultContactDto();
		createdItem.Active = Active;
		createdItem.Order = Order;
		createdItem.SupportDefaultContactRef = SupportDefaultContactRef;
		createdItem.UserRef = UserRef;
		return createdItem;
	}
}

public class SupportDefaultContactAddModel
{
	public SupportDefaultContactAddModel()
	{ }

	public SupportDefaultContactAddModel(ISupportDefaultContact values)
	{
		if (values == null) return;
		Active = values.Active;
		Order = values.Order;
		UserRef = values.UserRef;
	}

	public bool Active { get; set; }

	public int Order { get; set; }

	public int UserRef { get; set; }

	public virtual EATTS.Common.Dto.SupportDefaultContactDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.SupportDefaultContactDto();
		createdItem.Active = Active;
		createdItem.Order = Order;
		createdItem.UserRef = UserRef;
		return createdItem;
	}
}