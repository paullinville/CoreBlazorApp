using BlazorApp.Common;
using BlazorApp.Data;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Midland.Core.Common;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Telerik.Blazor.Components;

namespace BlazorApp.Pages;

public partial class ReportError
{
    [Inject] public ClientSettings Settings { get; set; } = default!;

    private string PageTitleText => FormatPageTitle("Report Error");

    private TelerikNotification NotificationRef { get; set; } = default!;

    private ErrorReportModel Report { get; set; } = new();

    private ErrorResponse? PendingErrorResponse { get; set; }

    [Inject] public ILogger<ReportError> Logger { get; set; } = default!;

    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;

    [Inject] public ErrorReportState ErrorReportState { get; set; } = default!;

    protected override void OnInitialized()
    {
        PendingErrorResponse = ErrorReportState.ConsumePendingError();
        if (PendingErrorResponse is not null)
        {
            Report.Subject = string.IsNullOrWhiteSpace(PendingErrorResponse.Code)
                ? "Application Error"
                : $"Application Error ({PendingErrorResponse.Code})";
            Report.Description = BuildDescription(PendingErrorResponse);
            Report.UserCreated = false;
        }
    }

    private async Task SubmitReport()
    {
        var errorResponse = PendingErrorResponse ?? new ErrorResponse
        {
            Code = ErrorCodes.UserCreatedEntry,
            Title = Report.Subject,
            Description = Report.Description,
            Messages = [Report.Description],
            Errors = []
        };

        if (!string.IsNullOrWhiteSpace(Report.AdditionalNotes))
        {
            errorResponse.Messages ??= [];
            errorResponse.Messages.Add($"Additional notes: {Report.AdditionalNotes}");
        }

        var entryKey = !string.IsNullOrWhiteSpace(errorResponse.Key())
            ? errorResponse.Key()
            : Guid.NewGuid().ToString("N");

        var entryModel = new EattsEntryModel(
            ApplicationInventoryRef: null,
            Origin: typeof(ReportError).Assembly.GetName().Name ?? "Application",
            Key: entryKey,
            UserRef: null,
            CallerId: "web-client",
            ErrorResponse: errorResponse);

        try
        {
            await EattsApiRepository.PostLog(entryModel);

            Logger.LogWarning("User error report submitted. Subject: {Subject}, Description: {Description}, AdditionalNotes: {AdditionalNotes}", Report.Subject, Report.Description, Report.AdditionalNotes);

            NotificationRef.Show(new NotificationModel
            {
                Text = "Thank you. Your error report has been submitted.",
                ThemeColor = "success"
            });

            Report = new ErrorReportModel();
            PendingErrorResponse = null;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error report submission failed. Subject: {Subject}", Report.Subject);
            NotificationRef.Show(new NotificationModel
            {
                Text = "Unable to submit error report. Please try again.",
                ThemeColor = "error"
            });
        }
    }

    private string FormatPageTitle(string pageTitle) => string.IsNullOrWhiteSpace(Settings.ApplicationName)
        ? pageTitle
        : $"{Settings.ApplicationName} - {pageTitle}";

    private static string BuildDescription(ErrorResponse errorResponse)
    {
        var descriptionBuilder = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(errorResponse.Description))
        {
            descriptionBuilder.AppendLine(errorResponse.Description);
        }

        foreach (var message in errorResponse.Messages.Values())
        {
            descriptionBuilder.AppendLine($"Message: {message}");
        }

        foreach (var error in errorResponse.Errors.Values())
        {
            descriptionBuilder.AppendLine($"Error: {error.Name} ({error.Type}) - {error.Value}");
        }

        return descriptionBuilder.ToString().Trim();
    }

    public class ErrorReportModel
    {
        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        public string AdditionalNotes { get; set; } = string.Empty;

        public bool UserCreated { get; set; } = true;
    }
}