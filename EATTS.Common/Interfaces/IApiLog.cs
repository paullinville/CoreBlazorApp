//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IApiLog
{

    int ApiLogRef { get; set; }
    string ApiName { get; set; }
    bool Error { get; set; }
    string LogData { get; set; }
    DateTime LogDate { get; set; }
    Guid LogId { get; set; }
    int LogLevel { get; set; }
    Guid RequestId { get; set; }
    string Server { get; set; }

    public static void Map(IApiLog fromData, IApiLog toData)
    {
        if (fromData == null || toData == null) return;
        toData.ApiLogRef = fromData.ApiLogRef;
        toData.ApiName = fromData.ApiName;
        toData.Error = fromData.Error;
        toData.LogData = fromData.LogData;
        toData.LogDate = fromData.LogDate;
        toData.LogId = fromData.LogId;
        toData.LogLevel = fromData.LogLevel;
        toData.RequestId = fromData.RequestId;
        toData.Server = fromData.Server;
    }

    public void MapTo(IApiLog toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApiLog fromData)
    {
        Map(fromData, this);
    }

    public void Update(IApiLog fromData)
    {
        var currentRef = this.ApiLogRef;
        Map(fromData, this);
        this.ApiLogRef = currentRef;
    }

}