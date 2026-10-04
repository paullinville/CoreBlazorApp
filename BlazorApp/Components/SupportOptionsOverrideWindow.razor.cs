using BlazorApp.Common;
using BlazorApp.Data;
using EATTS.Common.Models;
using EmployeeData.Common.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class SupportOptionsOverrideWindow
{
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;
    [Inject] public IEmployeeRepository EmployeeRepository { get; set; } = default!;

    [Parameter] public int? EntryRef { get; set; }
    [Parameter] public bool IsVisible { get; set; }
    [Parameter] public EventCallback<bool> IsVisibleChanged { get; set; }

    private SupportOptionsOverrideGetModel SupportOptionsOverride { get; set; } = new();
    private bool IsSupportOptionsLoading { get; set; }
    private int? LoadedEntryRef { get; set; }

    private List<UserSelectModelExpanded> ActiveSelectionUsers { get; set; } = [];
    private List<int> SelectedFloodEmailUserRefs { get; set; } = [];
    private List<int> SelectedOtherEmailUserRefs { get; set; } = [];

    protected override async Task OnParametersSetAsync()
    {
        if (!IsVisible || EntryRef is null or <= 0)
        {
            return;
        }

        if (LoadedEntryRef == EntryRef)
        {
            return;
        }

        IsSupportOptionsLoading = true;

        SupportOptionsOverride = await EattsApiRepository.GetSupportOptionOverrideByEntryRef(EntryRef.Value)
            ?? new SupportOptionsOverrideGetModel { EntryRef = EntryRef.Value };

        await EnsureActiveSelectionUsersAsync();
        SelectedFloodEmailUserRefs = ResolveUserRefsByEmail(SupportOptionsOverride.FloodEmail);
        SelectedOtherEmailUserRefs = ResolveUserRefsByEmail(SupportOptionsOverride.OtherEmail);

        LoadedEntryRef = EntryRef;
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

    private async Task CancelSupportOptionsWindowAsync()
    {
        IsSupportOptionsLoading = false;
        LoadedEntryRef = null;
        SelectedFloodEmailUserRefs = [];
        SelectedOtherEmailUserRefs = [];

        IsVisible = false;
        await IsVisibleChanged.InvokeAsync(false);
    }

    private async Task OnWindowVisibleChangedAsync(bool isVisible)
    {
        if (!isVisible)
        {
            await CancelSupportOptionsWindowAsync();
            return;
        }

        IsVisible = true;
        await IsVisibleChanged.InvokeAsync(true);
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
}
