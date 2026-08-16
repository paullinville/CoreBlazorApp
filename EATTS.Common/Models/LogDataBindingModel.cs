using Midland.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace EATTS.Common.Models;

public class LogDataBindingModel
{
	private ExceptionModel exception;
	private ErrorException exceptionDetail;

	public string Action { get; set; }
	public string Api { get; set; }
	public string CallerContext { get; set; }
	public string ClientIp { get; set; }
	public string Controller { get; set; }
	public string CostCenter { get; set; }

	public ExceptionModel Exception
	{
		set
		{
			exception = value;
			SetExceptionDetail();
		}
	}

	public ErrorException ExceptionDetail { get => exceptionDetail; set => exceptionDetail = value; }
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

	#region ?

	public string Query { get; set; }
	public string SourceContext { get; set; }
	public string SpanId { get; set; }
	public string TraceFlags { get; set; }

	#endregion ?

	private void SetExceptionDetail()
	{
		if (exceptionDetail == null && exception != null)
		{
			exceptionDetail = new ErrorException()
			{
				ExceptionData = new Dictionary<string, string>(exception.Data.Values().Select(kv => new KeyValuePair<string, string>(kv.Key, kv.Value))),
				ExceptionMessage = exception.Message,
				ExceptionProperties = null,
				ExceptionType = null,
				Headers = null,
				Source = exception.Source,
				Target = exception.TargetSite,
				StackTrace = new StackTrace(exception.StackTrace)
			};
		}
	}
}