using Midland.Core.Api;
using RestEase;
using SecurityModel.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityModel.Client;

/// <summary>
/// All calls using RestEase will be Asynchronous
/// </summary>
[AllowAnyStatusCode]
[ApiName("SecurityModel")]
public partial interface ISecurityModelApiClient : IApiClient
{
    [Get("/v1/application")]
    Task<Response<PageResultsModel<ApplicationGetModel>>> GetAllApplicationsAsync([QueryMap(QuerySerializationMethod.Serialized)] IDictionary<string, object> model);

    [Get("/v1/application-summary")]
    Task<Response<MidlandResult<List<ApplicationSummary>>>> GetAllApplicationSummaryAsync();
}