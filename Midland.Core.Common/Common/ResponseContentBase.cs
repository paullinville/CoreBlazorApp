using System.Net;

namespace Midland.Core.Common;

public class ResponseContentBase
{
	public string Address { get; set; }
	public bool IsJson { get; set; }
	public HttpStatusCode StatusCode { get; set; }
}