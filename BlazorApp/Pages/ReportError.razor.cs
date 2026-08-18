using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Telerik.Blazor.Components;
using BlazorApp.Data;

namespace BlazorApp.Pages;

public partial class ReportError
{
    private TelerikNotification NotificationRef { get; set; }

    private ErrorReportModel Report { get; set; } = new();

    [Inject] public ILogger<ReportError> Logger { get; set; }

    [Inject] public IEattsApiRepository EattsApiRepository { get; set; }

    private void SubmitReport()
    {
        Logger.LogWarning("User error report submitted. Subject: {Subject}, Description: {Description}", Report.Subject, Report.Description);

        NotificationRef.Show(new NotificationModel
        {
            Text = "Thank you. Your error report has been submitted.",
            ThemeColor = "success"
        });

        Report = new ErrorReportModel();
    }

    public class ErrorReportModel
    {
        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}
