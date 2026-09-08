using BlazorApp.Common;
using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

public class GlobalErrorBoundaryBase : ErrorBoundary, IDisposable
{
    [Inject] protected NavigationManager Nav { get; set; }
    [Inject] protected IEattsApiRepository EattsRepo { get; set; }
    [Inject] protected IEventChannelBus EventChannelBus { get; set; }
    [Inject] protected ClientSettings ClientSettings { get; set; }
    [Inject] protected IEmployeeRepository EmployeeRepo { get; set; }

    // Dialog state
    protected bool ShowEattsDialog { get; set; }

    protected EattsEntryResultModel? EattsResponse { get; set; }
    protected string? EattsErrorMessage { get; set; }

    protected override void OnInitialized()
    {
        Nav.LocationChanged += OnLocationChanged;
    }

    protected override async Task OnErrorAsync(Exception exception)
    {
        var errorResponse = new ErrorResponse
        {
            Code = ErrorCodes.ApplicationUnhandledException,
            Description = exception.Message,
            Details = new ErrorException(exception),
            Errors = [],
            Messages = [exception.Message]
        };
        var currentUser = await EmployeeRepo.CurrentUser;
        var eattsResponse = await EattsRepo.PostLog(new EattsEntryModel(null,
                                                                          ClientSettings.ApplicationName,
                                                                          $"Unhandled Exception {exception.GetType().Name} in {ClientSettings.ApplicationName}",
                                                                          currentUser.UserRef,
                                                                          "",
                                                                          errorResponse));
        await EventChannelBus.PublishAsync(new ApplicationErrorEvent(errorResponse));

        // Update UI to show dialog — must be done on renderer thread
        await InvokeAsync(() =>
        {
            EattsResponse = eattsResponse;
            EattsErrorMessage = "Unknown error occurred.";
            ShowEattsDialog = true;
            StateHasChanged();
        });
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

    protected void CloseDialog()
    {
        ShowEattsDialog = false;
        EattsResponse = null;
        EattsErrorMessage = null;
        Recover();
    }
}