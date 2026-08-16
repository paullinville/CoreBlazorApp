using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class ServiceTokenActivityDto : IServiceTokenActivity
{
	public ServiceTokenActivityDto(IServiceTokenActivity values)
	{
		values?.MapTo(this);
	}

	public ServiceTokenActivityDto()
	{ }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string Data { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime Date { get; set; }

	public int ServiceTokenActivityRef { get; set; }

	public int UserRef { get; set; }

	public Guid ServiceTokenId { get; set; }
}