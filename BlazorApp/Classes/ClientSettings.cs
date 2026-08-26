using Midland.Core.Common;

namespace BlazorApp.Classes;

public class ClientSettings
{
    public string ApiHost { get; set; }

    public string SecurityModelHost { get; set; }

    public UserTokenRequestModel UserTokenRequestModel { get; set; }
}

public static class MidlandAsyncUtils
{
    private static readonly TaskFactory _taskFactory = new(CancellationToken.None, TaskCreationOptions.None,
        TaskContinuationOptions.None, TaskScheduler.Default);

    /// <summary>
    /// Executes an async Task method which has a void return value synchronously
    /// USAGE: AsyncUtil.RunSync(AsyncMethod());
    /// </summary>
    public static TResult RunSync<TResult>(this Task<TResult> task) => RunSync(() => task);

    /// <summary>
    /// Executes an async Task method which has a void return value synchronously
    /// USAGE: AsyncUtil.RunSync(() =&gt; AsyncMethod());
    /// </summary>
    public static void RunSync(this Func<Task> task) => _taskFactory.StartNew(task).Unwrap().GetAwaiter().GetResult();

    ///<summary>
    /// Executes an async Task<T> method which has a T return type synchronously.
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    /// <param name="task">The Task method to execute</param>
    /// <returns></returns>
    public static TResult RunSync<TResult>(this Func<Task<TResult>> task) => _taskFactory.StartNew(task).Unwrap().GetAwaiter().GetResult();
}