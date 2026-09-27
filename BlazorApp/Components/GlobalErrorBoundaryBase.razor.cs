using BlazorApp.Common;
using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Midland.Core.Client;
using Midland.Core.SimpleMessageBus;
using Telerik.Blazor.Components;

public class GlobalErrorBoundaryBase : ErrorBoundary, IDisposable
{
    private string? _lastExceptionSignature;
    private int _consecutiveExceptionCount;

    [Inject] protected NavigationManager Nav { get; set; }
    [Inject] protected IEattsApiRepository EattsRepo { get; set; }
    [Inject] protected IEventChannelBus EventChannelBus { get; set; }
    [Inject] protected ClientSettings ClientSettings { get; set; }
    [Inject] protected IEmployeeRepository EmployeeRepo { get; set; }
    [Inject] protected ErrorReportState ErrorReportState { get; set; }

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
        var exceptionSignature = $"{exception.GetType().FullName}:{exception.Message}";
        if (string.Equals(_lastExceptionSignature, exceptionSignature, StringComparison.Ordinal))
        {
            _consecutiveExceptionCount++;
        }
        else
        {
            _lastExceptionSignature = exceptionSignature;
            _consecutiveExceptionCount = 1;
        }

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

        if (_consecutiveExceptionCount >= 2)
        {
            var exceptionPreview = string.Join(Environment.NewLine,
                                               exception.ToString()
                                                        .Split(["\r\n", "\n", "\r"], StringSplitOptions.RemoveEmptyEntries)
                                                        .Take(3));

            var recurringErrorResponse = new ErrorResponse
            {
                Code = ErrorCodes.ApplicationUnhandledException,
                Title = "Reoccurring exception",
                Description = $"Entry Ref: {eattsResponse.EntryRef}{Environment.NewLine}" +
                              $"Occurrence Ref: {eattsResponse.OccurrenceRef}{Environment.NewLine}" +
                              $"Exception Type: {exception.GetType().FullName}{Environment.NewLine}" +
                              $"Exception Text:{Environment.NewLine}{exceptionPreview}",
                Errors = [],
                Messages = []
            };

            await InvokeAsync(() =>
            {
                _lastExceptionSignature = null;
                _consecutiveExceptionCount = 0;
                ErrorReportState.SetPendingError(recurringErrorResponse,
                                                 $"An exception has occurred, and reported, multiple times for {ClientSettings.ApplicationName}.",
                                                 readOnlySubjectAndDescription: true);
                Nav.NavigateTo("/report-error");
            });

            return;
        }

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