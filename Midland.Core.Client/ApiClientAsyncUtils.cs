using Midland.Core.Common;
using RestEase;
using System.Net;
using System.Text.Json;

namespace Midland.Core.Client;

public static class ApiClientAsyncUtils
{
	private static readonly TaskFactory _taskFactory = new(CancellationToken.None, TaskCreationOptions.None,
		TaskContinuationOptions.None, TaskScheduler.Default);

	public static MidlandResult<TResult> GetMidlandResultSync<TResult>(this Task<Response<MidlandResult<TResult>>> task)
	{
		var result = GetSync(() => task);

		return result.GetContent();
	}

	public static Response<TResult> GetRestEaseResponseSync<TResult>(this Task<Response<TResult>> task)
	{
		var result = GetSync(() => task);

		return result;
	}

	public static List<T> ProcessPagedListSync<T>(this Task<Response<PageResultsModel<T>>> task)
	{
		var response = GetSync(() => task);

		if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode <= (int)HttpStatusCode.IMUsed)
		{
			var content = response.GetContent();
			return content.Results;
		}
		else
		{
			CheckForErrors(response);
			return default;
		}
	}

	public static PageResultsModel<T> ProcessPagedResponseSync<T>(this Task<Response<PageResultsModel<T>>> task)
	{
		var response = GetSync(() => task);

		if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode <= (int)HttpStatusCode.IMUsed)
		{
			var content = response.GetContent();
			return content;
		}
		else
		{
			CheckForErrors(response);
			return default;
		}
	}

	public static TResult ProcessResponseSync<TResult>(this Task<Response<MidlandResult<TResult>>> task)
	{
		var result = GetSync(() => task);

		return ProcessResponse(result);
	}

	private static void CheckForErrors<T>(Response<T> response)
	{
		if ((int)response.ResponseMessage.StatusCode == (int)HttpStatusCode.NotFound) return;

		if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.BadRequest)
		{
			var stringContent = response.StringContent;
			ErrorResponse error = JsonSerializer.Deserialize<ErrorResponse>(stringContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
			throw new ApiErrorException(error);
		}
	}

	private static TResult GetSync<TResult>(this Func<Task<TResult>> task) => _taskFactory.StartNew(task).Unwrap().GetAwaiter().GetResult();

	private static T ProcessResponse<T>(Response<MidlandResult<T>> response)
	{
		if ((int)response.ResponseMessage.StatusCode >= (int)HttpStatusCode.OK && (int)response.ResponseMessage.StatusCode <= (int)HttpStatusCode.IMUsed)
		{
			var content = response.GetContent();
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
}