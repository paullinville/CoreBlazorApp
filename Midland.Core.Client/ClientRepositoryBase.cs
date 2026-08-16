using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;
using System.Net;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Midland.Core.Client;

public abstract class ClientRepositoryBase
{
    protected readonly IEventChannelBus _eventBus;

    protected ClientRepositoryBase(IEventChannelBus eventBus)
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
               code == ErrorCodes.TokenNotFound ||
               code == ErrorCodes.UserMissingActionClaims
               ;
    }

    protected void CheckForErrors<T>(Response<T> response)
    {
        if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.IMUsed)
        {
            var stringResponse = response.StringContent;
            ErrorResponse error = JsonSerializer.Deserialize<ErrorResponse>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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

    protected T ProcessResponse<T>(Response<MidlandResult<T>> response)
    {
        var content = response.GetContent();

        if (content.Messages.IsNotEmpty())
        {
            _eventBus.Publish(new ResultsMessageEvent(content));
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
            CheckForErrors(response);
            return default;
        }
    }

    protected PageResultsModel<T> ProcessResponse<T>(Response<PageResultsModel<T>> response)
    {
        if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode < (int)HttpStatusCode.MultipleChoices)
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
}