using System.ComponentModel.DataAnnotations;

namespace EATTS.Common.Models;

public class ErrorCategoryDeleteModel
{ public int ErrorCategoryRef { get; set; } }

public class ErrorCategoryEditModel : ErrorCategoryAddModel
{
	public ErrorCategoryEditModel()
	{ }

	public ErrorCategoryEditModel(IErrorCategory values) : base(values)
	{
		ErrorCategoryRef = values.ErrorCategoryRef;
	}

	public int ErrorCategoryRef { get; set; }

	public override EATTS.Common.Dto.ErrorCategoryDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ErrorCategoryDto();

		createdItem.Description = Description;
		createdItem.IsActiveFlag = (short)(Active ? 1 : 0);
		createdItem.ErrorCategoryRef = ErrorCategoryRef;
		return createdItem;
	}

	#region

	public override bool Equals(object? obj)
	{
		if (obj is ErrorCategoryEditModel item)
		{
			return item.ErrorCategoryRef == ErrorCategoryRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ErrorCategoryRef;
	}

	#endregion
}

public class ErrorCategoryAddModel
{
	public ErrorCategoryAddModel()
	{ }

	public ErrorCategoryAddModel(IErrorCategory values)
	{
		if (values == null) return;
		Description = values.Description + "";
		Active = values.IsActiveFlag == 1;
	}

	public bool Active { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(250)]
	public string Description { get; set; }

	public virtual EATTS.Common.Dto.ErrorCategoryDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ErrorCategoryDto();

		createdItem.Description = Description;
		createdItem.IsActiveFlag = (short)(Active ? 1 : 0);
		return createdItem;
	}
}