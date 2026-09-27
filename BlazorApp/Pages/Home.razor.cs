using BlazorApp.Common;
using Microsoft.AspNetCore.Components;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace BlazorApp.Pages
{
    public partial class Home
    {
        [Inject]
        public ClientSettings Settings { get; set; } = default!;

        [Inject]
        public IEventChannelBus EventChannelBus { get; set; } = default!;

        private string PageTitleText => FormatPageTitle("Home");

        private int? SelectedUserRef { get; set; }

        private string FormatPageTitle(string pageTitle) => string.IsNullOrWhiteSpace(Settings.ApplicationName)
            ? pageTitle
            : $"{Settings.ApplicationName} - {pageTitle}";

        private static Task OnAppErrorClickedAsync() => throw new InvalidOperationException("App error button clicked.");

        private async Task OnApiErrorClickedAsync()
        {
            EventChannelBus.Publish(new ApiErrorEvent(new ErrorResponse
            {
                Code = ErrorCodes.UnhandledException,
                Description = "This is a simulated API error for testing purposes.",
                Errors = [new ErrorResultError { Type = ErrorType.General, Name = "ApiError", Value = "Simulated error" }],
            }));
        }

        private async Task OnApiValidationErrorClickedAsync()
        {
            EventChannelBus.Publish(new ApiValidationEvent(new ErrorResponse
            {
                Code = ErrorCodes.ValidationFailure,
                Description = "This is a simulated API validation error for testing purposes.",
                Errors = [new ErrorResultError { Type = ErrorType.General, Name = "Validation Error", Value = "Simulated broken rule" }],
            }));
        }

        private async Task OnMessageErrorClickedAsync()
        {
            EventChannelBus.Publish(new ResultsMessageEvent(new ErrorResponse
            {
                Code = ErrorCodes.ValidationFailure,
                Description = "This is a simulated API validation error for testing purposes.",
                Messages = ["This is a simulated API validation error for testing purposes.", "On other message."]
            }));
        }

        private async Task OnSecurityErrorClickedAsync()
        {
            EventChannelBus.Publish(new SecurityErrorEvent(new ErrorResponse
            {
                Code = ErrorCodes.ServiceTokenInvalid,
                Description = "This is a simulated API validation error for testing purposes.",
                Messages = ["This is a simulated API validation error for testing purposes with a very long message.", "On other message."],
                Errors = [new ErrorResultError { Type = ErrorType.General, Name = "Security Error", Value = "Not allowed." }],
            }));
        }
    }
}