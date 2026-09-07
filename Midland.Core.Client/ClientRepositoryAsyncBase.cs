using Midland.Core.Api;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using System.Net;
using System.Text.Json;

namespace Midland.Core.Client;

public abstract class ClientRepositoryAsyncBase
{
    protected readonly IEventChannelBus _eventBus;

    protected ClientRepositoryAsyncBase(IEventChannelBus eventBus)
    {
        _eventBus = eventBus;
    }

    public static bool IsSecurityError(string code)
    {
        return code == ErrorCodes.TokenIssuerInvalid ||
               code == ErrorCodes.UserIdentityOrIdentityClaimsNotSet ||
               code == ErrorCodes.ApplicationTokenInvalid ||
               code == ErrorCodes.ServiceTokenInvalid ||
               code == ErrorCodes.ServiceTokenNotActive ||
               code == ErrorCodes.TokenNotFound;
    }

    protected virtual async Task CheckForErrorsAsync<T>(Response<T> response)
    {
        if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.IMUsed)
        {
            ErrorResponse error = JsonSerializer.Deserialize<ErrorResponse>(response.StringContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (error == null)
            {
                await HandleNullErrorResponseAsync(response);
            }
            else
            {
                if (error.Code == ErrorCodes.ValidationFailure || error.Code == ErrorCodes.CompositeValidationFailed)
                {
                    await _eventBus.PublishAsync(new ApiValidationEvent(error));
                }
                else if (error.Code == ErrorCodes.UserMissingActionClaims)
                {
                    await _eventBus.PublishAsync(new ActionsMissingEvent(error));
                }
                else if (IsSecurityError(error.Code))
                {
                    await _eventBus.PublishAsync(new SecurityErrorEvent(error));
                }
                else
                {
                    await _eventBus.PublishAsync(new ApiErrorEvent(error));
                }
            }
        }
    }

    protected virtual async Task HandleNullErrorResponseAsync<T>(Response<T> response)
    {
        var errorResponse = new ErrorResponse()
        {
            Code = $"{ErrorCodes.UnhandledException}",
            Description = "An unhandled exception occurred and the error response could not be de-serialized.",
            Details = new ErrorException(new NullReferenceException("An unhandled exception occurred, the error response could not be de-serialized."))
            {
                ExceptionMessage = "The error response could not be de-serialized.",
            },
            RequestId = response.ResponseMessage.Headers.GetValues(ApiConstants.MidlandRequestIdHeader).FirstOrDefault(),
            RequestPath = response.ResponseMessage?.RequestMessage?.RequestUri?.AbsolutePath,
            RequestQuery = response.ResponseMessage?.RequestMessage?.RequestUri?.Query,
            Title = "Unhandled Exception",
        };
        errorResponse.Errors.Add(
            new ErrorResultError
            {
                Type = ErrorType.General,
                Name = "UnhandledException",
                Value = "An error occurred calling an API. Error Response could not be de-serialized."
            });

        await OnHandleErrorResponseAsync(errorResponse);
        await _eventBus.PublishAsync(new ApiErrorEvent(errorResponse));
    }

    protected virtual async Task OnHandleErrorResponseAsync(ErrorResponse errorResponse)
    {
    }

    protected virtual async Task<T> ProcessResponseAsync<T>(Response<MidlandResult<T>> response)
    {
        var content = response.GetContent();

        if (content.Messages.IsNotEmpty())
        {
            await _eventBus.PublishAsync(new ResultsMessageEvent(content));
        }

        if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode < (int)HttpStatusCode.MultipleChoices)
        {
            return content.Results.As<T>();
        }
        else if (response.ResponseMessage.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }
        else
        {
            await CheckForErrorsAsync(response);
            return default;
        }
    }

    protected virtual async Task<PageResultsModel<T>> ProcessResponseAsync<T>(Response<PageResultsModel<T>> response)
    {
        if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode < (int)HttpStatusCode.MultipleChoices)
        {
            var content = response.GetContent();
            if (content.Messages.IsNotEmpty())
            {
                await _eventBus.PublishAsync(new ResultsMessageEvent(content));
            }
            return content;
        }
        else
        {
            await CheckForErrorsAsync(response);
            return default;
        }
    }
}