using System;
using System.ComponentModel.DataAnnotations;
using Midland.Core.Logging;

namespace EATTS.Common.Models;

public class ApiLogDataModel : IApiLogData
{
	public ApiLogDataModel(IApiLogData values)
	{
		values?.MapTo(this);
	}

	public ApiLogDataModel()
	{ }

	public int ApiLogRef { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(250)]
	public string ApiName { get; set; }

	public bool Error { get; set; }
	public LogDataBindingModel LogData { get; set; }

	public DateTime LogDate { get; set; }

	public Guid RequestId { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string Server { get; set; }
}