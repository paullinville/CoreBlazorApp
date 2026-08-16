using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EATTS.Common.Models;

public class ExceptionModel
{
	[JsonConverter(typeof(SafeNullableConverter<List<KeyValueModel>>))]
	public virtual List<KeyValueModel> Data { get; set; }

	public virtual string HelpLink { get; set; }
	public int HResult { get; protected set; }
	public ExceptionModel InnerException { get; set; }
	public virtual string Message { get; set; }
	public virtual string Source { get; set; }
	public virtual string StackTrace { get; set; }
	public string TargetSite { get; set; }
}