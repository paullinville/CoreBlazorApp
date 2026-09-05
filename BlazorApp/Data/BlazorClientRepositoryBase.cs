using BlazorApp.Common;
using Midland.Core.Api;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using System.Net;
using System.Text.Json;

namespace BlazorApp.Data;

public class BlazorClientRepositoryBase : ClientRepositoryAsyncBase
{
    private readonly ClientSettings _clientSettings;
    private readonly IEattsApiRepository _eATTSApiClient;
    protected readonly HttpClient _httpClient;
    protected readonly ISecurityModelToken _securityToken;
    protected readonly IEmployeeRepository _empRepository;

    public BlazorClientRepositoryBase(HttpClient httpClient,
                                      ISecurityModelToken securityToken,
                                      IEventChannelBus eventBus,
                                      ClientSettings clientSettings,
                                      IEattsApiRepository eATTSApiClient,
                                      IEmployeeRepository empRepository) : base(eventBus)
    {
        _httpClient = httpClient;
        _securityToken = securityToken;
        _securityToken.ApiListRequest = clientSettings.UserTokenRequestModel;
        _clientSettings = clientSettings;
        _eATTSApiClient = eATTSApiClient;
        _empRepository = empRepository;
    }

    protected override async Task HandleErrorResponse(ErrorResponse errorResponse)
    {
        errorResponse.Code = ErrorCodes.ApplicationUnhandledException;
        var code = await _eATTSApiClient.PostLog(new EattsEntryModel(null, _clientSettings.ApplicationName, MakeEntryKey(), _empRepository.CurrentUser.Result.UserRef, "", errorResponse));
        errorResponse.Description = $"Application Unhandled Error and has been reported with Occurrence Id {code.OccurrenceRef}.";
    }

    protected virtual string MakeEntryKey()
    {
        return $"Api error with null response {_clientSettings.ApplicationName}";
    }

    protected async Task SetAuth()
    {
        await _securityToken.SetAuthorization(_httpClient);
    }
}