using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Common.Models;

public class LocationDeleteModel
{
	public virtual int LocationRef { get; set; }
}

public class LocationGetModel : LocationPostModel
{
	public LocationGetModel()
	{ }

	public LocationGetModel(ILocation values) : base(values)
	{
		LocationRef = values.LocationRef;
	}

	public int LocationRef { get; set; }

	public override EmployeeData.Common.Dto.LocationDto CreateDto()
	{
		var createdItem = new EmployeeData.Common.Dto.LocationDto();
		createdItem.Code = Code;
		createdItem.EndDate = EndDate;
		createdItem.Name = Name;
		createdItem.NameSource = NameSource;
		createdItem.LocationRef = LocationRef;
		createdItem.StartDate = StartDate;
		return createdItem;
	}
}

public class LocationPutModel
{
	public LocationPutModel()
	{ }

	public LocationPutModel(ILocation values)
	{
		LocationRef = values.LocationRef;
		Body = new LocationPostModel(values);
	}

	public virtual LocationPostModel Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int LocationRef { get; set; }
}

public class LocationPostModel
{
	public LocationPostModel()
	{ }

	public LocationPostModel(ILocation values)
	{
		if (values == null) return;
		Code = values.Code;
		EndDate = values.EndDate;
		Name = values.Name;
		NameSource = values.NameSource;
		StartDate = values.StartDate;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string Code { get; set; }

	public DateTime EndDate { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(250)]
	public string Name { get; set; }

	[StringLength(250)]
	public string NameSource { get; set; }

	public DateTime StartDate { get; set; }

	public virtual EmployeeData.Common.Dto.LocationDto CreateDto()
	{
		var createdItem = new EmployeeData.Common.Dto.LocationDto();
		createdItem.Code = Code;
		createdItem.EndDate = EndDate;
		createdItem.Name = Name;
		createdItem.NameSource = NameSource;
		createdItem.StartDate = StartDate;
		return createdItem;
	}
}