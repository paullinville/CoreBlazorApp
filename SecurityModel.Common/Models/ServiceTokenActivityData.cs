using SecurityModel.Common.Dto;

namespace SecurityModel.Common.Models;

public class ServiceTokenActivityData
{
	public string Description { get; set; }

	public ServiceTokenDto OldValues { get; set; }

	public ServiceTokenDto NewValues { get; set; }
}