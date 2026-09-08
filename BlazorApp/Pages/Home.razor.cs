using BlazorApp.Common;
using BlazorApp.Data;
using EATTS.Common.Models;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace BlazorApp.Pages
{
    public partial class Home
    {
        [Inject]
        public ClientSettings Settings { get; set; } = default!;

        [Inject]
        public IEattsApiRepository EattsApiRepository { get; set; } = default!;

        [Inject]
        public IEmployeeRepository EmployeeRepository { get; set; } = default!;

        private string PageTitleText => FormatPageTitle("Home");

        private List<EntryOccurrenceSummaryModel> ReportGridData { get; set; } = [];

        private TelerikGrid<EntryOccurrenceSummaryModel>? ReportGrid { get; set; }

        private string CurrentUserEmail { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var currentUser = await EmployeeRepository.CurrentUser;
            CurrentUserEmail = currentUser?.Email ?? string.Empty;

            if (CurrentUserEmail.IsNullOrBlank())
            {
                ReportGridData = [];
            }
        }

        private async Task ReadReportGridAsync(GridReadEventArgs args)
        {
            if (CurrentUserEmail.IsNullOrBlank())
            {
                ReportGridData = [];
                args.Data = ReportGridData;
                args.Total = 0;
                return;
            }

            var criteria = new EntryOccurrenceSearchCriteria
            {
                EmailsSent = CurrentUserEmail,
                PageNumber = args.Request.Page,
                PageSize = args.Request.PageSize,
                IsError = true
            };

            var page = await EattsApiRepository.GetEntryOccurrenceDetail(criteria);
            ReportGridData = page?.Results ?? [];
            args.Data = ReportGridData;
            args.Total = page?.PageInfo?.NumberOfRecords ?? 0;
        }

        private async Task RefreshGridAsync()
        {
            if (ReportGrid is null)
            {
                return;
            }

            var state = ReportGrid.GetState();
            state.Page = 1;
            state.Skip = 0;
            state.SortDescriptors?.Clear();
            await ReportGrid.SetStateAsync(state);
        }

        private string FormatPageTitle(string pageTitle) => Settings.ApplicationName.IsNullOrBlank()
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