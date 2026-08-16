using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ServiceTokenActivityDeleteModel
{ public int ServiceTokenActivityRef { get; set; } }

public class ServiceTokenActivityEditModel : ServiceTokenActivityAddModel
{
	public ServiceTokenActivityEditModel()
	{ }

	public ServiceTokenActivityEditModel(IServiceTokenActivity values) : base(values)
	{
		ServiceTokenActivityRef = values.ServiceTokenActivityRef;
	}

	public int ServiceTokenActivityRef { get; set; }

	public override SecurityModel.Common.Dto.ServiceTokenActivityDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ServiceTokenActivityDto();
		createdItem.Data = Data;
		createdItem.Date = Date;
		createdItem.ServiceTokenActivityRef = ServiceTokenActivityRef;
		createdItem.UserRef = UserRef;
		createdItem.ServiceTokenId = ServiceTokenId;
		return createdItem;
	}
}

public class ServiceTokenActivityAddModel
{
	public ServiceTokenActivityAddModel()
	{ }

	public ServiceTokenActivityAddModel(IServiceTokenActivity values)
	{
		if (values == null) return;
		Data = values.Data + "";
		Date = values.Date;
		UserRef = values.UserRef;
		ServiceTokenId = values.ServiceTokenId;
	}

	public virtual SecurityModel.Common.Dto.ServiceTokenActivityDto CreateDto()
	{
		var createdItem = new SecurityModel.Common.Dto.ServiceTokenActivityDto();
		createdItem.Data = Data;
		createdItem.Date = Date;
		createdItem.UserRef = UserRef;
		createdItem.ServiceTokenId = ServiceTokenId;
		return createdItem;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string Data { get; set; }

	public DateTime Date { get; set; }
	public int UserRef { get; set; }
	public Guid ServiceTokenId { get; set; }
}