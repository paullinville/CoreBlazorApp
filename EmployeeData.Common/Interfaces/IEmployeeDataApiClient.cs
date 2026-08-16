using Midland.Core.Api;
using RestEase;

namespace EmployeeData.Client;

[AllowAnyStatusCode]
[ApiName("EmployeeData")]
public partial interface IEmployeeDataApiClient : IApiClient
{
}