using System;

namespace SecurityModel.Common.Interfaces;

public interface IServiceTokenActivity
{
	string Data { get; set; }
	DateTime Date { get; set; }
	int ServiceTokenActivityRef { get; set; }
	int UserRef { get; set; }
	Guid ServiceTokenId { get; set; }

	public static void Map(IServiceTokenActivity fromData, IServiceTokenActivity toData)
	{
		if (fromData == null || toData == null) return;
		toData.Data = fromData.Data;
		toData.Date = fromData.Date;
		toData.ServiceTokenActivityRef = fromData.ServiceTokenActivityRef;
		toData.UserRef = fromData.UserRef;
		toData.ServiceTokenId = fromData.ServiceTokenId;
	}

	public void MapTo(IServiceTokenActivity toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IServiceTokenActivity fromData)
	{
		Map(fromData, this);
	}
}