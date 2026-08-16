using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class ErrorStatusDeleteModel
{
	public virtual int ErrorStatusRef { get; set; }
}

public class ErrorStatusGetModel : ErrorStatusPostModel
{
	public ErrorStatusGetModel()
	{ }

	public ErrorStatusGetModel(IErrorStatus values) : base(values)
	{
		ErrorStatusRef = values.ErrorStatusRef;
	}

	public int ErrorStatusRef { get; set; }

	public override EATTS.Common.Dto.ErrorStatusDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ErrorStatusDto();
		createdItem.AdditionalDescription = AdditionalDescription;
		createdItem.Description = Description;
		createdItem.IsActiveFlag = IsActiveFlag;
		createdItem.ErrorStatusRef = ErrorStatusRef;
		return createdItem;
	}

	#region

	public override bool Equals(object obj)
	{
		if (obj is ErrorStatusGetModel item)
		{
			return item.ErrorStatusRef == ErrorStatusRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ErrorStatusRef;
	}

	#endregion
}

public class ErrorStatusPutModel
{
	public ErrorStatusPutModel()
	{ }

	public ErrorStatusPutModel(IErrorStatus values)
	{
		ErrorStatusRef = values.ErrorStatusRef;
		Body = new ErrorStatusPostModel(values);
	}

	public virtual ErrorStatusPostModel Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int ErrorStatusRef { get; set; }

	#region

	public override bool Equals(object obj)
	{
		if (obj is ErrorStatusPutModel item)
		{
			return item.ErrorStatusRef == ErrorStatusRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ErrorStatusRef;
	}

	#endregion
}

public class ErrorStatusPostModel
{
	public ErrorStatusPostModel()
	{ }

	public ErrorStatusPostModel(IErrorStatus values)
	{
		if (values == null) return;
		AdditionalDescription = values.AdditionalDescription;
		Description = values.Description;
		IsActiveFlag = values.IsActiveFlag;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(2000)]
	public string AdditionalDescription { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string Description { get; set; }

	public short IsActiveFlag { get; set; }

	public virtual EATTS.Common.Dto.ErrorStatusDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ErrorStatusDto();
		createdItem.AdditionalDescription = AdditionalDescription;
		createdItem.Description = Description;
		createdItem.IsActiveFlag = IsActiveFlag;
		return createdItem;
	}
}