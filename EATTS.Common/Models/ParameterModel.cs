using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class ParameterDeleteModel
{
	public virtual int ParameterRef { get; set; }
}

public class ParameterGetModel : ParameterPostModel
{
	public ParameterGetModel()
	{ }

	public ParameterGetModel(IParameter values) : base(values)
	{
		ParameterRef = values.ParameterRef;
	}

	public int ParameterRef { get; set; }

	public override EATTS.Common.Dto.ParameterDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ParameterDto();
		createdItem.DataType = DataType;
		createdItem.Description = Description;
		createdItem.Encrypted = Encrypted;
		createdItem.IsDropDownList = IsDropDownList;
		createdItem.Name = Name;
		createdItem.ParameterRef = ParameterRef;
		createdItem.System = System;
		createdItem.Value = Value;
		return createdItem;
	}
}

public class ParameterPutModel
{
	public ParameterPutModel()
	{ }

	public ParameterPutModel(IParameter values)
	{
		ParameterRef = values.ParameterRef;
		Body = new ParameterPostModel(values);
	}

	public virtual ParameterPostModel Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int ParameterRef { get; set; }
}

public class ParameterPostModel
{
	public ParameterPostModel()
	{ }

	public ParameterPostModel(IParameter values)
	{
		if (values == null) return;

		DataType = values.DataType;
		Description = values.Description;
		Encrypted = values.Encrypted;
		IsDropDownList = values.IsDropDownList;
		Name = values.Name;
		System = values.System;
		Value = values.Value;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string DataType { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(1000)]
	public string Description { get; set; }

	public bool Encrypted { get; set; }

	public bool IsDropDownList { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(100)]
	public string Name { get; set; }

	public bool System { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string Value { get; set; }

	public virtual EATTS.Common.Dto.ParameterDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.ParameterDto();

		createdItem.DataType = DataType;
		createdItem.Description = Description;
		createdItem.Encrypted = Encrypted;
		createdItem.IsDropDownList = IsDropDownList;
		createdItem.Name = Name;
		createdItem.System = System;
		createdItem.Value = Value;
		return createdItem;
	}
}