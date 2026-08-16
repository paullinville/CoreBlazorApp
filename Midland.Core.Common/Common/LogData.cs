namespace Midland.Core.Logging;

public class LogData
{
	public LogData()
	{
	}

	public string Action { get; set; }
	public string Api { get; set; }
	public string CallerContext { get; set; }
	public string ClientIp { get; set; }
	public string Controller { get; set; }
	public string CostCenter { get; set; }

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

	public string Output { get; set; }

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

	private void SetException(Exception exception)
	{
		if (exception != null)
		{
			ExceptionDetail = new ErrorException(exception);
		}
		else
		{
			ExceptionDetail = null;
		}
	}

	#region ?

	public string Query { get; set; }
	public string SourceContext { get; set; }
	public string SpanId { get; set; }
	public string TraceFlags { get; set; }

	#endregion ?
}