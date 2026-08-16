//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;

namespace EmployeeData.Common.Interfaces;

public interface ILocation
{
	string Code { get; set; }
	DateTime EndDate { get; set; }
	string Name { get; set; }
	string NameSource { get; set; }
	int LocationRef { get; set; }
	DateTime StartDate { get; set; }

	public static void Map(ILocation fromData, ILocation toData)
	{
		if (fromData == null || toData == null) return;
		toData.Code = fromData.Code;
		toData.EndDate = fromData.EndDate;
		toData.Name = fromData.Name;
		toData.NameSource = fromData.NameSource;
		toData.LocationRef = fromData.LocationRef;
		toData.StartDate = fromData.StartDate;
	}

	public void MapTo(ILocation toData)
	{
		Map(this, toData);
	}

	public void MapFrom(ILocation fromData)
	{
		Map(fromData, this);
	}

	public void Update(ILocation fromData)
	{
		var currentRef = this.LocationRef;
		Map(fromData, this);
		this.LocationRef = currentRef;
	}
}