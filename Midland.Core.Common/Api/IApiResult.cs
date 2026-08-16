using System.Net;
using System.Net.Http.Headers;

namespace Midland.Core.Api;

public interface IApiResult
{
	List<string> Errors { get; }
	string RawResults { get; set; }
	HttpStatusCode StatusCode { get; set; }
	HttpResponseHeaders Headers { get; set; }
}

public interface IApiResult<T> : IApiResult
{
	T Result { get; set; }
}