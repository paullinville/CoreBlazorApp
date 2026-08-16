namespace Midland.Core.Api;

public interface IServiceApiHelper : IRestApiHelper
{
	List<string> GetConsulAddresses(string apiName);

	HttpClient MakeHttpClient(ApiDefinition api, string host);

	HttpClient MakeHttpClient(string apiName, string host);
}