using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class ServiceTokenDto : IServiceToken
{
	public ServiceTokenDto(IServiceToken values)
	{
		values?.MapTo(this);
	}

	public ServiceTokenDto()
	{ }

	public bool Active { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string Body { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime Created { get; set; }

	public int CreatedBy { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(512)]
	public string Description { get; set; }

	public Guid Id { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(250)]
	public string Name { get; set; }
}