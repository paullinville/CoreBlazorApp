using System;

namespace EATTS.Common.Interfaces;

public interface IApiLogData
{
	int ApiLogRef { get; set; }
	string ApiName { get; set; }
	bool Error { get; set; }
	LogDataBindingModel LogData { get; set; }
	DateTime LogDate { get; set; }
	Guid RequestId { get; set; }
	string Server { get; set; }

	public static void Map(IApiLogData fromData, IApiLogData toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApiLogRef = fromData.ApiLogRef;
		toData.ApiName = fromData.ApiName;
		toData.Error = fromData.Error;
		toData.LogData = fromData.LogData;
		toData.LogDate = fromData.LogDate;
		toData.RequestId = fromData.RequestId;
		toData.Server = fromData.Server;
	}

	public void MapFrom(IApiLogData fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IApiLogData toData)
	{
		Map(this, toData);
	}
}