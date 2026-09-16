using System.Collections.Generic;
using EATTS.Common.Models;
using Midland.Core.Common;

namespace BlazorApp.Models;

public class ApiLogDataPivotModel
{
    public ApiLogDataPivotModel()
    {
    }

    public ApiLogDataPivotModel(ApiLogDataModel apiLogData)
    {
        MapFrom(apiLogData);
        MapFrom(apiLogData.LogData);
    }

    public string ApiName { get; set; }

    public bool IsError { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public int Day { get; set; }

    public int DayOfYear { get; set; }

    public int Hour { get; set; }

    public string ApiServer { get; set; }

    public string Action { get; set; }

    public string Controller { get; set; }

    public string CostCenter { get; set; }

    public int Level { get; set; }

    public string Route { get; set; }

    public int ProcessId { get; set; }

    public string RecorderId { get; set; }

    public int? StatusCode { get; set; }

    public long TimeElapsed { get; set; }

    public string UserType { get; set; }

    public long WorkingSet { get; set; }

    public void MapFrom(ApiLogDataModel apiLogData)
    {
        if (apiLogData == null)
        {
            return;
        }

        ApiName = apiLogData.ApiName;
        IsError = apiLogData.Error;

        var apiLogDate = apiLogData.LogDate;
        Year = apiLogDate.Year;
        Month = apiLogDate.Month;
        Day = apiLogDate.Day;
        DayOfYear = apiLogDate.DayOfYear;
        Hour = apiLogDate.Hour;

        ApiServer = apiLogData.Server;

        MapFrom(apiLogData.LogData);
    }

    public void MapFrom(LogDataBindingModel logData)
    {
        if (logData == null)
        {
            return;
        }

        Action = logData.Action;
        Controller = logData.Controller;
        CostCenter = logData.CostCenter;
        Level = logData.Level;
        ProcessId = logData.ProcessId;
        RecorderId = logData.RecorderId;
        Route = logData.Route;
        StatusCode = logData.StatusCode;
        TimeElapsed = logData.TimeElapsed;
        UserType = logData.UserType;
    }
}