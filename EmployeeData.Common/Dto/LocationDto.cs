//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Common.Dto;

public class LocationDto : ILocation
{
	public LocationDto(ILocation values)
	{
		values?.MapTo(this);
	}

	public LocationDto()
	{ }

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string Code { get; set; }

	public DateTime EndDate { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(250)]
	public string Name { get; set; }

	[StringLength(250)]
	public string NameSource { get; set; }

	public int LocationRef { get; set; }

	public DateTime StartDate { get; set; }
}