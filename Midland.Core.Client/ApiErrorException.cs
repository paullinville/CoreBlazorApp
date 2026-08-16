using Midland.Core.Common;

namespace Midland.Core.Client;

public class ApiErrorException : Exception
{
    public ApiErrorException(ErrorResponse error) : base($"Error calling API. {error.Code} {error.RequestId} {error.RequestPath}")
    {
        Error = error;
    }

    public ErrorResponse Error { get; private set; }
}