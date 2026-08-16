using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class ServiceTokenOwnerDto : IServiceTokenOwner
{
	public ServiceTokenOwnerDto(IServiceTokenOwner values)
	{
		values?.MapTo(this);
	}

	public ServiceTokenOwnerDto()
	{ }

	public Guid ServiceTokenId { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime Created { get; set; }

	public int CreatedBy { get; set; }

	public int ServiceTokenOwnerRef { get; set; }

	public int UserRef { get; set; }
}