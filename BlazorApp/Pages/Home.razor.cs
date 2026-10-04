using BlazorApp.Common;
using BlazorApp.Data;
using EATTS.Common.Models;
using EmployeeData.Common.Models;
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
        private int? SelectedUserRef { get; set; }

        private string FormatPageTitle(string pageTitle) => string.IsNullOrWhiteSpace(Settings.ApplicationName)
            ? pageTitle
            : $"{Settings.ApplicationName} - {pageTitle}";

        private TelerikGrid<EntryOccurrenceSummaryModel>? ReportGrid { get; set; }

        private EntryOccurrenceDetailModel? SelectedOccurrenceDetail { get; set; }

        private IReadOnlyList<int> OccurrenceRefsForWindow { get; set; } = [];

        private bool IsOccurrenceWindowVisible { get; set; }

        private SupportOptionsOverrideGetModel SupportOptionsOverride { get; set; } = new();

        private int? SelectedEntryRefForSupportOptions { get; set; }

        private bool IsSupportOptionsWindowVisible { get; set; }

        private bool IsSupportOptionsLoading { get; set; }

        private List<UserSelectModelExpanded> ActiveSelectionUsers { get; set; } = [];

        private List<int> SelectedFloodEmailUserRefs { get; set; } = [];

        private List<int> SelectedOtherEmailUserRefs { get; set; } = [];

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

        private async Task OpenSupportOptionsWindowAsync(int entryRef)
        {
            if (entryRef <= 0)
            {
                return;
            }

            SelectedEntryRefForSupportOptions = entryRef;
            IsSupportOptionsWindowVisible = true;
            IsSupportOptionsLoading = true;

            SupportOptionsOverride = await EattsApiRepository.GetSupportOptionOverrideByEntryRef(entryRef)
                ?? new SupportOptionsOverrideGetModel() { EntryRef = entryRef };

            await EnsureActiveSelectionUsersAsync();
            SelectedFloodEmailUserRefs = ResolveUserRefsByEmail(SupportOptionsOverride.FloodEmail);
            SelectedOtherEmailUserRefs = ResolveUserRefsByEmail(SupportOptionsOverride.OtherEmail);

            IsSupportOptionsLoading = false;
        }

        private async Task SaveSupportOptionsAsync()
        {
            var model = new SupportOptionsOverridePostModel
            {
                EntryRef = SupportOptionsOverride.EntryRef,
                DoNotSendEmail = SupportOptionsOverride.DoNotSendEmail,
                FloodCount = SupportOptionsOverride.FloodCount,
                FloodTime = SupportOptionsOverride.FloodTime,
                FloodEmail = SupportOptionsOverride.FloodEmail,
                OtherEmail = SupportOptionsOverride.OtherEmail,
                Reason = SupportOptionsOverride.Reason
            };

            var updated = SupportOptionsOverride.SupportOptionsOverrideRef > 0
                ? await EattsApiRepository.PutSupportOptionOverride(SupportOptionsOverride.SupportOptionsOverrideRef, model)
                : await EattsApiRepository.PostSupportOptionOverride(model);

            SupportOptionsOverride = updated ?? SupportOptionsOverride;
            await CancelSupportOptionsWindowAsync();
        }

        private Task CancelSupportOptionsWindowAsync()
        {
            IsSupportOptionsWindowVisible = false;
            IsSupportOptionsLoading = false;
            SelectedEntryRefForSupportOptions = null;
            SelectedFloodEmailUserRefs = [];
            SelectedOtherEmailUserRefs = [];
            return Task.CompletedTask;
        }

        private Task OnSupportOptionsWindowVisibleChanged(bool isVisible)
        {
            if (!isVisible)
            {
                return CancelSupportOptionsWindowAsync();
            }

            IsSupportOptionsWindowVisible = true;
            return Task.CompletedTask;
        }

        private async Task EnsureActiveSelectionUsersAsync()
        {
            if (ActiveSelectionUsers.Count > 0)
            {
                return;
            }

            ActiveSelectionUsers = (await EmployeeRepository.GetActiveSelectionUsers())
                .Values()
                .Where(x => x.UserRef > 0 && x.Email.IsNotNullOrBlank())
                .GroupBy(x => x.UserRef)
                .Select(x => x.First())
                .OrderBy(x => x.FullName)
                .ToList();
        }

        private List<int> ResolveUserRefsByEmail(string? emails)
        {
            if (emails.IsNullOrBlank())
            {
                return [];
            }

            var selectedEmails = emails
                .Split([';', ','], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            return ActiveSelectionUsers
                .Where(x => x.Email.IsNotNullOrBlank() && selectedEmails.Contains(x.Email))
                .Select(x => x.UserRef)
                .Distinct()
                .ToList();
        }

        private void OnFloodEmailUsersChanged(List<UserSelectModelExpanded> selectedUsers)
        {
            SelectedFloodEmailUserRefs = selectedUsers?.Values().Select(x => x.UserRef).Distinct().ToList() ?? [];
            SupportOptionsOverride.FloodEmail = string.Join(";", selectedUsers
                .Values()
                .Select(x => x.Email)
                .Where(x => x.IsNotNullOrBlank())
                .Distinct(StringComparer.OrdinalIgnoreCase));
        }

        private void OnOtherEmailUsersChanged(List<UserSelectModelExpanded> selectedUsers)
        {
            SelectedOtherEmailUserRefs = selectedUsers?.Values().Select(x => x.UserRef).Distinct().ToList() ?? [];
            SupportOptionsOverride.OtherEmail = string.Join(";", selectedUsers
                .Values()
                .Select(x => x.Email)
                .Where(x => x.IsNotNullOrBlank())
                .Distinct(StringComparer.OrdinalIgnoreCase));
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
            OccurrenceRefsForWindow = ReportGridData
                .Select(x => x.EntryOccurrenceRef)
                .Where(x => x > 0)
                .Distinct()
                .ToList();
            IsOccurrenceWindowVisible = true;
        }

        private Task OnOccurrenceWindowVisibleChanged(bool isVisible)
        {
            IsOccurrenceWindowVisible = isVisible;
            return Task.CompletedTask;
        }
    }
}