namespace Midland.Core.Api;

public interface IRestApiHelper
{
    ApiOptions Options { get; }

    IApiResult<TReturn> CallApi<TReturn, TDataSent>(string apiName, string endpointName, TDataSent message, string route = "");

    IEnumerable<Header> DefaultHeaders();

    IEnumerable<Header> DefaultHeaders(IEnumerable<Header> endPointHeaders) { return DefaultHeaders(); }

    HttpResponseMessage DeleteResponse<TDataSent>(string url, TDataSent message, IEnumerable<Header> headers, string route = "");

    Task<HttpResponseMessage> DeleteResponseAsync<TDataSent>(string url, TDataSent message, IEnumerable<Header> headers, string route = "");

    string GetApiToken();

    string GetDestination(ApiDefinition api);

    IApiResult<TResult> GetResult<TResult, TDataSent>(ApiDefinition api, EndPoint endpoint, TDataSent message, string route = "");

    IApiResult<TResult> GetResult<TResult>(ApiDefinition api, EndPoint endpoint, string route = "");

    IApiResult<TResult> GetResult<TResult>(string apiName, string endpointName, string route = "");

    IApiResult<TReturn> GetResult<TReturn, TDataSent>(string url, IEnumerable<Header> headers, string method, TDataSent message);

    Task<IApiResult<TReturn>> GetResultAsync<TReturn, TDataSent>(string url, IEnumerable<Header> headers, string method, TDataSent message);

    Task<IApiResult<TResult>> GetResultAsync<TResult, TDataSent>(ApiDefinition api, EndPoint endpoint, TDataSent message, string route = "");

    Task<IApiResult<TResult>> GetResultAsync<TResult>(ApiDefinition api, EndPoint endpoint, string route = "");

    string MakeUrl(string Url, string route);

    string MakeUrl(string Url, string route, object query);

    string MakeUrl<TDataSent>(ApiDefinition api, EndPoint endPoint, string route, TDataSent message);

    HttpResponseMessage PostResponse<TDataSent>(string url, TDataSent message, IEnumerable<Header> headers, string route = "");

    Task<HttpResponseMessage> PostResponseAsync<TDataSent>(string url, TDataSent message, IEnumerable<Header> headers, string route = "");

    HttpResponseMessage PutResponse<TDataSent>(string url, TDataSent message, IEnumerable<Header> headers, string route = "");

    Task<HttpResponseMessage> PutResponseAsync<TDataSent>(string url, TDataSent message, IEnumerable<Header> headers, string route = "");

    void SetEndpointHeaders(EndPoint endPoint);

    bool TryGetConsulAddress(ApiDefinition api, out string vaultAddress);
}