using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class ErrorTypeDeleteModel
{
	public virtual int ErrorTypeRef { get; set; }
}

public class ErrorTypeGetModel : ErrorTypePostModel
{
	public ErrorTypeGetModel()
	{ }

	public ErrorTypeGetModel(IErrorType values) : base(values)
	{
		ErrorTypeRef = values.ErrorTypeRef;
	}

	public int ErrorTypeRef { get; set; }

	public override EATTS.Common.Dto.ErrorTypeDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ErrorTypeDto();
		createdItem.CreateDate = CreateDate;
		createdItem.Description = Description;
		createdItem.IsActiveFlag = IsActiveFlag;
		createdItem.ErrorTypeRef = ErrorTypeRef;
		return createdItem;
	}

	#region

	public override bool Equals(object obj)
	{
		if (obj is ErrorTypeGetModel item)
		{
			return item.ErrorTypeRef == ErrorTypeRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ErrorTypeRef;
	}

	#endregion
}

public class ErrorTypePutModel
{
	public ErrorTypePutModel()
	{ }

	public ErrorTypePutModel(IErrorType values)
	{
		ErrorTypeRef = values.ErrorTypeRef;
		Body = new ErrorTypePostModel(values);
	}

	public virtual ErrorTypePostModel Body { get; set; } = new ErrorTypePostModel();

	[Required, Range(1, int.MaxValue)]
	public virtual int ErrorTypeRef { get; set; }

	#region

	public override bool Equals(object obj)
	{
		if (obj is ErrorTypePutModel item)
		{
			return item.ErrorTypeRef == ErrorTypeRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ErrorTypeRef;
	}

	#endregion
}

public class ErrorTypePostModel
{
	public ErrorTypePostModel()
	{ }

	public ErrorTypePostModel(IErrorType values)
	{
		if (values == null) return;
		CreateDate = values.CreateDate;
		Description = values.Description;
		IsActiveFlag = values.IsActiveFlag;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string Description { get; set; }

	public short IsActiveFlag { get; set; }

	[Range(typeof(DateTime), "1/1/1775", "12/31/9999 11:59AM")]
	protected DateTime CreateDate { get; set; }

	public virtual EATTS.Common.Dto.ErrorTypeDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ErrorTypeDto();
		createdItem.CreateDate = CreateDate;
		createdItem.Description = Description;
		createdItem.IsActiveFlag = IsActiveFlag;
		return createdItem;
	}
}