using BlazorApp.Classes;
using BlazorApp.Models;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using System.Net;
using System.Text.Json;

namespace BlazorApp.Data;

public class ClientRepositoryBase
{
	protected readonly IEventChannelBus _eventBus;
	protected readonly HttpClient _httpClient;
	protected readonly ISecurityModelToken _securityModel;

	public ClientRepositoryBase(HttpClient httpClient, ISecurityModelToken securityModel, IEventChannelBus eventBus, ClientSettings clientSettings)
	{
		_httpClient = httpClient;
		_securityModel = securityModel;
		_securityModel.ApiListRequest = clientSettings.UserTokenRequestModel;
		_eventBus = eventBus;
	}

	protected void CheckForErrors<T>(Response<T> response)
	{
		if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.IMUsed)
		{
			var x = response.ResponseMessage;
			var y = response.StringContent;
			ErrorResponse error = JsonSerializer.Deserialize<ErrorResponse>(y, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
			if (error.Code == ErrorCodes.ValidationFailure || error.Code == ErrorCodes.CompositeValidationFailed)
			{
				_eventBus.Publish(new ApiValidationEvent(error));
			}
			else if (error.Code == ErrorCodes.UserMissingActionClaims)
			{
				_eventBus.Publish(new ActionsMissingEvent(error));
			}
			else if (IsSecurityError(error.Code))
			{
				_eventBus.Publish(new SecurityErrorEvent(error));
			}
			else
			{
				_eventBus.Publish(new ApiErrorEvent(error));
			}
		}
	}

	protected T? ProcessResponse<T>(Response<MidlandResult<T>> response)
	{
		if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode <= (int)HttpStatusCode.IMUsed)
		{
			var content = response.GetContent();
			if (content.Messages.IsNotEmpty())
			{
				_eventBus.Publish(new ResultsMessageEvent(content));
			}
			return content.Results.As<T>();
		}
		else
		{
			CheckForErrors(response);
			return default;
		}
	}

	protected PageResultsModel<T?> ProcessResponse<T>(Response<PageResultsModel<T>> response)
	{
		if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode <= (int)HttpStatusCode.IMUsed)
		{
			var content = response.GetContent();
			if (content.Messages.IsNotEmpty())
			{
				_eventBus.Publish(new ResultsMessageEvent(content));
			}
			return content;
		}
		else
		{
			CheckForErrors(response);
			return default;
		}
	}

	protected async Task SetAuth()
	{
		await _securityModel.SetAuthorization(_httpClient);
	}

	private bool IsSecurityError(string code)
	{
		return code == ErrorCodes.TokenIssuerInvalid ||
			   code == ErrorCodes.UserIdentityOrIdentityClaimsNotSet ||
			   code == ErrorCodes.ApplicationTokenInvalid ||
			   code == ErrorCodes.ServiceTokenInvalid ||
			   code == ErrorCodes.ServiceTokenNotActive ||
			   code == ErrorCodes.TokenNotFound ||
			   code == ErrorCodes.UserMissingActionClaims
			   ;
	}
}