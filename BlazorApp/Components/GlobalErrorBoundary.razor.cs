using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;

public class GlobalErrorBoundaryBase : ErrorBoundary, IDisposable
{
    [Inject] protected NavigationManager Nav { get; set; }
    [Inject] protected ILogger<GlobalErrorBoundaryBase> Logger { get; set; }

    protected override void OnInitialized()
    {
        Nav.LocationChanged += OnLocationChanged;
    }

    protected override Task OnErrorAsync(Exception exception)
    {
        Logger.LogError(exception, "Unhandled exception caught by GlobalErrorBoundary");
        return Task.CompletedTask;
    }

    private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        if (CurrentException != null)
        {
            Recover();
        }
    }

    public void Dispose()
    {
        Nav.LocationChanged -= OnLocationChanged;
    }
}