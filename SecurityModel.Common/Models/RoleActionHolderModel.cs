using System;

namespace SecurityModel.Common.Models;

public class RoleActionHolderEditModel : RoleActionHolderAddModel
{
	public RoleActionHolderEditModel()
	{ }

	public RoleActionHolderEditModel(IRoleActionHolder values) : base(values)
	{
		ActionRef = values.ActionRef;
		RoleRef = values.RoleRef;
	}

	public int ActionRef { get; set; }
	public int RoleRef { get; set; }

	public override SecurityModel.Common.Dto.RoleActionHolderDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.RoleActionHolderDto();
		createdItem.ActionRef = ActionRef;
		createdItem.RoleActionGroupHolderCreateDate = RoleActionGroupHolderCreateDate;
		createdItem.RoleRef = RoleRef;
		return createdItem;
	}
}

public class RoleActionHolderAddModel
{
	public RoleActionHolderAddModel()
	{ }

	public RoleActionHolderAddModel(IRoleActionHolder values)
	{
		if (values == null) return;
		RoleActionGroupHolderCreateDate = values.RoleActionGroupHolderCreateDate;
	}

	public virtual SecurityModel.Common.Dto.RoleActionHolderDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.RoleActionHolderDto();
		createdItem.RoleActionGroupHolderCreateDate = RoleActionGroupHolderCreateDate;
		return createdItem;
	}

	public DateTime RoleActionGroupHolderCreateDate { get; set; }
}