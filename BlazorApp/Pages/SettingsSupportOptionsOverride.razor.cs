using BlazorApp.Common;
using BlazorApp.Data;
using BlazorApp.Models;
using EATTS.Common.Models;
using EmployeeData.Common.Models;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace BlazorApp.Pages;

public partial class SettingsSupportOptionsOverride
{
    [Inject] public ClientSettings Settings { get; set; } = default!;
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;
    [Inject] public IEmployeeRepository EmployeeRepository { get; set; } = default!;

    private List<SupportOptionsOverrideModel> SupportOptionsOverrideGridData { get; set; } = new List<SupportOptionsOverrideModel>();
    private List<UserSelectModelExpanded> ActiveSelectionUsers { get; set; } = new List<UserSelectModelExpanded>();

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Settings Alt Entry Options"
        : $"{Settings.ApplicationName} - Settings Alt Entry Options";

    protected override async Task OnInitializedAsync()
    {
        await LoadActiveSelectionUsersAsync();
        await LoadSupportOptionsOverrideGridDataAsync();
    }

    private async Task OnSupportOptionOverrideCreateAsync(GridCommandEventArgs args)
    {
        var item = args.Item as SupportOptionsOverrideModel;
        if (item is null)
        {
            return;
        }

        var created = await EattsApiRepository.PostSupportOptionOverride(ToPostModel(item));
        if (created is not null)
        {
            item.SupportOptionsOverrideRef = created.SupportOptionsOverrideRef;
        }

        await LoadSupportOptionsOverrideGridDataAsync();
    }

    private async Task OnSupportOptionOverrideUpdateAsync(GridCommandEventArgs args)
    {
        var item = args.Item as SupportOptionsOverrideModel;
        if (item is null)
        {
            return;
        }

        await EattsApiRepository.PutSupportOptionOverride(item.SupportOptionsOverrideRef, ToPostModel(item));
        await LoadSupportOptionsOverrideGridDataAsync();
    }

    private async Task OnSupportOptionOverrideDeleteAsync(GridCommandEventArgs args)
    {
        var item = args.Item as SupportOptionsOverrideModel;
        if (item is null)
        {
            return;
        }

        await EattsApiRepository.DeleteSupportOptionOverride(item.SupportOptionsOverrideRef);
        await LoadSupportOptionsOverrideGridDataAsync();
    }

    private async Task LoadSupportOptionsOverrideGridDataAsync()
    {
        var supportOptionsOverrideList = await EattsApiRepository.GetAllSupportOptionOverrideList() ?? new List<SupportOptionsOverrideGetModel>();

        SupportOptionsOverrideGridData = supportOptionsOverrideList
            .Values()
            .Select(ToEditModel)
            .ToList();
    }

    private async Task LoadActiveSelectionUsersAsync()
    {
        ActiveSelectionUsers = (await EmployeeRepository.GetActiveSelectionUsers())
            .Values()
            .Where(x => x.UserRef > 0)
            .GroupBy(x => x.UserRef)
            .Select(x => x.First())
            .OrderBy(x => x.FullName)
            .ToList();
    }

    private SupportOptionsOverrideModel ToEditModel(SupportOptionsOverrideGetModel item)
    {
        return new SupportOptionsOverrideModel
        {
            SupportOptionsOverrideRef = item.SupportOptionsOverrideRef,
            EntryRef = item.EntryRef,
            DoNotSendEmail = item.DoNotSendEmail,
            FloodCount = item.FloodCount,
            FloodTime = item.FloodTime,
            FloodEmail = item.FloodEmail,
            OtherEmail = item.OtherEmail,
            Reason = item.Reason,
            SelectedUserRefs = BuildSelectedUserRefs(item.OtherEmail)
        };
    }

    private List<int> BuildSelectedUserRefs(string? otherEmail)
    {
        if (otherEmail.IsNullOrBlank())
        {
            return new List<int>();
        }

        return ActiveSelectionUsers
            .Where(x => x.Email.IsNotNullOrBlank() && otherEmail.Contains(x.Email, StringComparison.OrdinalIgnoreCase))
            .Select(x => x.UserRef)
            .Distinct()
            .ToList();
    }

    private static SupportOptionsOverridePostModel ToPostModel(SupportOptionsOverrideModel item)
    {
        return new SupportOptionsOverridePostModel
        {
            EntryRef = item.EntryRef,
            DoNotSendEmail = item.DoNotSendEmail,
            FloodCount = item.FloodCount,
            FloodTime = item.FloodTime,
            FloodEmail = item.FloodEmail,
            OtherEmail = item.OtherEmail,
            Reason = item.Reason
        };
    }

    private void OnOtherEmailUsersChanged(SupportOptionsOverrideModel option, IEnumerable<int> selectedUserRefs)
    {
        if (option is null)
        {
            return;
        }

        option.SelectedUserRefs = selectedUserRefs?.Where(x => x > 0).Distinct().ToList() ?? new List<int>();

        option.OtherEmail = string.Join(",",
            ActiveSelectionUsers
                .Where(x => option.SelectedUserRefs.Contains(x.UserRef))
                .Select(x => x.Email)
                .Where(x => x.IsNotNullOrBlank())
                .Distinct(StringComparer.OrdinalIgnoreCase));
    }

    private string GetOtherEmailDisplay(SupportOptionsOverrideModel option)
    {
        if (option?.SelectedUserRefs is null || option.SelectedUserRefs.Count == 0)
        {
            return string.Empty;
        }

        var selectedNames = ActiveSelectionUsers
            .Where(x => option.SelectedUserRefs.Contains(x.UserRef))
            .Select(x => x.FullName)
            .Where(x => x.IsNotNullOrBlank())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        return string.Join(", ", selectedNames);
    }
}
