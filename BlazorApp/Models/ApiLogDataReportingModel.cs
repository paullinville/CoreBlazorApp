using System;
using System.Collections.Generic;
using EATTS.Common.Models;
using Midland.Core.Common;

namespace BlazorApp.Models;

public class ApiLogDataReportingModel
{
    public ApiLogDataReportingModel()
    {
    }

    public ApiLogDataReportingModel(ApiLogDataModel apiLogData)
    {
        MapFrom(apiLogData);
        MapFrom(apiLogData.LogData);
    }

    public int ApiLogRef { get; set; }

    public string ApiName { get; set; }

    public bool ApiError { get; set; }

    public DateTime ApiLogDate { get; set; }

    public Guid ApiRequestId { get; set; }

    public string ApiServer { get; set; }

    public string Action { get; set; }

    public string Api { get; set; }

    public string CallerContext { get; set; }

    public string ClientIp { get; set; }

    public string Controller { get; set; }

    public string CostCenter { get; set; }

    public ExceptionModel Exception { get; set; }

    public ErrorException ExceptionDetail { get; set; }

    public Dictionary<string, string> Input { get; set; }

    public int Level { get; set; }

    public string LogId { get; set; }

    public string Message { get; set; }

    public string NomadAllocId { get; set; }

    public string NomadDatacenter { get; set; }

    public string NomadJobName { get; set; }

    public string NomadNodeName { get; set; }

    public string NomadTaskName { get; set; }

    public object Output { get; set; }

    public int ProcessId { get; set; }

    public string RecorderId { get; set; }

    public string RequestId { get; set; }

    public string Route { get; set; }

    public string Server { get; set; }

    public int? StatusCode { get; set; }

    public long TimeElapsed { get; set; }

    public string TimeStamp { get; set; }

    public string TraceId { get; set; }

    public string UserType { get; set; }

    public string Query { get; set; }

    public string SourceContext { get; set; }

    public string SpanId { get; set; }

    public string TraceFlags { get; set; }

    public long WorkingSet { get; set; }

    public void MapFrom(ApiLogDataModel apiLogData)
    {
        if (apiLogData == null)
        {
            return;
        }

        ApiLogRef = apiLogData.ApiLogRef;
        ApiName = apiLogData.ApiName;
        ApiError = apiLogData.Error;
        ApiLogDate = apiLogData.LogDate;
        ApiRequestId = apiLogData.RequestId;
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
        Api = logData.Api;
        CallerContext = logData.CallerContext;
        ClientIp = logData.ClientIp;
        Controller = logData.Controller;
        CostCenter = logData.CostCenter;
        Exception = null;
        ExceptionDetail = logData.ExceptionDetail;
        Input = logData.Input;
        Level = logData.Level;
        LogId = logData.LogId;
        Message = logData.Message;
        NomadAllocId = logData.NomadAllocId;
        NomadDatacenter = logData.NomadDatacenter;
        NomadJobName = logData.NomadJobName;
        NomadNodeName = logData.NomadNodeName;
        NomadTaskName = logData.NomadTaskName;
        Output = logData.Output;
        ProcessId = logData.ProcessId;
        RecorderId = logData.RecorderId;
        RequestId = logData.RequestId;
        Route = logData.Route;
        Server = logData.Server;
        StatusCode = logData.StatusCode;
        TimeElapsed = logData.TimeElapsed;
        TimeStamp = logData.TimeStamp;
        TraceId = logData.TraceId;
        UserType = logData.UserType;
        Query = logData.Query;
        SourceContext = logData.SourceContext;
        SpanId = logData.SpanId;
        TraceFlags = logData.TraceFlags;
    }
}