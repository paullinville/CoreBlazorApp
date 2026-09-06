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
                PageNumber = args.Request.Page + 1,
                PageSize = args.Request.PageSize,
                IsError = true,
                SortBy = nameof(EntryOccurrenceSummaryModel.OccurrenceDate),
                SortByDir = "Asc"
            };

            var page = await EattsApiRepository.GetEntryOccurrenceDetail(criteria);
            ReportGridData = page?.Results ?? [];
            args.Data = ReportGridData;
            args.Total = page?.PageInfo?.NumberOfRecords ?? 0;
        }

        private string FormatPageTitle(string pageTitle) => Settings.ApplicationName.IsNullOrBlank()
            ? pageTitle
            : $"{Settings.ApplicationName} - {pageTitle}";
    }
}
