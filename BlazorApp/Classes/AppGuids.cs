namespace BlazorApp.Classes;

using System;
using System.Threading.Tasks;

//public class AppGuids
//{
//    public string[] OtherApplications { get; set; }
//    public string[] PrimaryApplications { get; set; }
//}

// Services/LoadingService.cs

public class LoadingService
{
	public event Action<bool> OnLoadingChanged;

	public void Hide()
	{
		OnLoadingChanged?.Invoke(false);
	}

	public async Task RunWithLoader(Func<Task> action)
	{
		Show();
		try
		{
			await action();
		}
		finally
		{
			Hide();
		}
	}

	public void Show()
	{
		OnLoadingChanged?.Invoke(true);
	}
}