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

        private List<EntryOccurrenceSummaryModel> ReportGridData { get; set; } = new List<EntryOccurrenceSummaryModel>();

        private TelerikGrid<EntryOccurrenceSummaryModel>? ReportGrid { get; set; }

        private EntryOccurrenceDetailModel? SelectedOccurrenceDetail { get; set; }

        private bool IsOccurrenceWindowVisible { get; set; }

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

        private async Task OpenOccurrenceDetailsAsync(int occurrenceRef)
        {
            if (occurrenceRef <= 0)
            {
                return;
            }

            SelectedOccurrenceDetail = await EattsApiRepository.GetOccurrenceDetail(occurrenceRef);
            if (SelectedOccurrenceDetail is null)
            {
                IsOccurrenceWindowVisible = false;
                return;
            }

            SelectedOccurrenceDetail.ApiLogData ??= [];
            SelectedOccurrenceDetail.Notes ??= [];
            IsOccurrenceWindowVisible = true;
        }

        private Task OnOccurrenceWindowVisibleChanged(bool isVisible)
        {
            IsOccurrenceWindowVisible = isVisible;
            return Task.CompletedTask;
        }

        private string FormatPageTitle(string pageTitle) => Settings.ApplicationName.IsNullOrBlank()
            ? pageTitle
            : $"{Settings.ApplicationName} - {pageTitle}";
    }
}