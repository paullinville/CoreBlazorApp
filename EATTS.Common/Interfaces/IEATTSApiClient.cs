using Midland.Core.Api;
using RestEase;

namespace EATTS.Client;

[AllowAnyStatusCode]
[ApiName("EATTS")]
public partial interface IEATTSApiClient : IApiClient
{
}