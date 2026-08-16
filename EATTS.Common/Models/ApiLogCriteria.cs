using Midland.Core.Common;
using System;
using System.Collections.Generic;

namespace EATTS.Common.Models;

public class ApiLogCriteria : BasicSortedIncludePageRequest
{
	public ApiLogCriteria()
	{
		DefaultIncludeField = nameof(IApiLog.ApiLogRef);
		DefaultSortField = nameof(IApiLog.LogDate);
	}

	[FilterProperty($"{nameof(IApiLog.ApiLogRef)}", Comparison = "")]
	public int? ApiLogRef { get; set; }

	[FilterProperty($"{nameof(IApiLog.ApiName)}", Comparison = "")]
	public string ApiSlug { get; set; }

	#region daterange

	[FilterProperty($"{nameof(IApiLog.LogDate)}", Comparison = ">=")]
	public DateTime? BeginDate { get; set; }

	[FilterProperty($"{nameof(IApiLog.LogDate)}", Comparison = "<=")]
	public DateTime? EndDate { get; set; }

	#endregion daterange

	[FilterProperty($"{nameof(IApiLog.Error)}", Comparison = "")]
	public bool? Error { get; set; }

	[FilterProperty($"{nameof(IApiLog.LogData)}", Comparison = "")]
	public string LogData { get; set; }

	[FilterProperty($"{nameof(IApiLog.RequestId)}", Comparison = "")]
	public Guid? RequestId { get; set; }

	[FilterProperty($"{nameof(IApiLog.Server)}", Comparison = "")]
	public string Server { get; set; }
}