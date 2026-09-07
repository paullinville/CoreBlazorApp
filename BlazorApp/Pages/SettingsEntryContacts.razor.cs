using System.Linq;
using BlazorApp.Common;
using BlazorApp.Data;
using BlazorApp.Models;
using EATTS.Common.Models;
using EmployeeData.Common.Models;
using Microsoft.AspNetCore.Components;
using SecurityModel.Common.Models;
using Telerik.Blazor.Components;

namespace BlazorApp.Pages;

public partial class SettingsEntryContacts
{
    [Inject] public ClientSettings Settings { get; set; } = default!;
    [Inject] public IEattsApiRepository EattsApiRepository { get; set; } = default!;
    [Inject] public IEmployeeRepository EmployeeRepository { get; set; } = default!;
    [Inject] public ISecurityModelApiRepository SecurityModelApiRepository { get; set; } = default!;

    private List<ContactModel> EntryContactsGridData { get; set; } = new List<ContactModel>();
    private List<ApplicationOptionsModel> ApiOptionsGridData { get; set; } = new List<ApplicationOptionsModel>();
    private List<ApplicationSummary> ActiveApis { get; set; } = new List<ApplicationSummary>();
    private List<UserSelectModelExpanded> ActiveSelectionUsers { get; set; } = new List<UserSelectModelExpanded>();
    private List<UserSelectModelExpanded> SelectableContacts { get; set; } = new List<UserSelectModelExpanded>();

    private string PageTitleText => Settings.ApplicationName.IsNullOrBlank()
        ? "Settings - Contacts"
        : $"{Settings.ApplicationName} - Settings - Contacts";

    protected override async Task OnInitializedAsync()
    {
        await LoadContactsAsync();
        await LoadActiveSelectionUsersAsync();
        await LoadApiOptionsAsync();
        await LoadActiveApisAsync();
    }

    private async Task OnContactCreateAsync(GridCommandEventArgs args)
    {
        var contactModel = args.Items?.OfType<ContactModel>().FirstOrDefault();
        if (contactModel is null)
        {
            return;
        }

        ApplySelectedUserName(contactModel);

        await EattsApiRepository.ContactAdd(contactModel);
        await LoadContactsAsync();
    }

    private async Task OnContactUpdateAsync(GridCommandEventArgs args)
    {
        var contactModel = args.Items?.OfType<ContactModel>().FirstOrDefault();
        if (contactModel is null)
        {
            return;
        }

        ApplySelectedUserName(contactModel);

        await EattsApiRepository.ContactUpdate(contactModel);
        await LoadContactsAsync();
    }

    private Task OnContactDeleteAsync(GridCommandEventArgs args)
    {
        var contactModel = args.Items?.OfType<ContactModel>().FirstOrDefault();
        if (contactModel is null)
        {
            return Task.CompletedTask;
        }

        EattsApiRepository.ContactDelete(contactModel);
        EntryContactsGridData = EntryContactsGridData.Where(x => x.SupportDefaultContactRef != contactModel.SupportDefaultContactRef).ToList();
        return Task.CompletedTask;
    }

    private async Task OnApiOptionCreateAsync(GridCommandEventArgs args)
    {
        var apiOptionModel = args.Items?.OfType<ApplicationOptionsModel>().FirstOrDefault();
        if (apiOptionModel is null)
        {
            return;
        }

        apiOptionModel.EntryEmail = BuildEntryEmailsFromSelectedContacts(apiOptionModel.SelectedContactUserRefs);

        await EattsApiRepository.ApplicationOptionAdd(new ApplicationOptionsPostModel
        {
            ApiName = apiOptionModel.ApiName,
            EntryEmail = apiOptionModel.EntryEmail
        });

        await LoadApiOptionsAsync();
    }

    private async Task OnApiOptionUpdateAsync(GridCommandEventArgs args)
    {
        var apiOptionModel = args.Items?.OfType<ApplicationOptionsModel>().FirstOrDefault();
        if (apiOptionModel is null)
        {
            return;
        }

        apiOptionModel.EntryEmail = BuildEntryEmailsFromSelectedContacts(apiOptionModel.SelectedContactUserRefs);

        await EattsApiRepository.ApplicationOptionUpdate(apiOptionModel);
        await LoadApiOptionsAsync();
    }

    private async Task OnApiOptionDeleteAsync(GridCommandEventArgs args)
    {
        var apiOptionModel = args.Items?.OfType<ApplicationOptionsModel>().FirstOrDefault();
        if (apiOptionModel is null)
        {
            return;
        }

        EattsApiRepository.ApplicationOptionDelete(apiOptionModel);
        await LoadApiOptionsAsync();
    }

    private async Task LoadContactsAsync()
    {
        try
        {
            EntryContactsGridData = await EattsApiRepository.GetSupportDefaultContactEdit() ?? new List<ContactModel>();
        }
        catch
        {
            EntryContactsGridData = new List<ContactModel>();
        }
    }

    private async Task LoadApiOptionsAsync()
    {
        try
        {
            var options = await EattsApiRepository.GetAllApplicationOptions() ?? new List<ApplicationOptionsGetModel>();
            ApiOptionsGridData = options.Select(x => new ApplicationOptionsModel(x, ActiveSelectionUsers)).ToList();
        }
        catch
        {
            ApiOptionsGridData = new List<ApplicationOptionsModel>();
        }
    }

    private async Task LoadActiveSelectionUsersAsync()
    {
        try
        {
            ActiveSelectionUsers = (await EmployeeRepository.GetActiveSelectionUsers()).Values().ToList();
        }
        catch
        {
            ActiveSelectionUsers = new List<UserSelectModelExpanded>();
        }

        SelectableContacts = ActiveSelectionUsers
            .Where(x => x.UserRef > 0)
            .GroupBy(x => x.UserRef)
            .Select(x => x.First())
            .OrderBy(x => x.FullName)
            .ToList();
    }

    private async Task LoadActiveApisAsync()
    {
        try
        {
            ActiveApis = await SecurityModelApiRepository.GetApis() ?? new List<ApplicationSummary>();
        }
        catch
        {
            ActiveApis = ApiOptionsGridData
                .Where(x => !string.IsNullOrWhiteSpace(x.ApiName))
                .Select(x => new ApplicationSummary { ApiName = x.ApiName })
                .GroupBy(x => x.ApiName, StringComparer.OrdinalIgnoreCase)
                .Select(x => x.First())
                .OrderBy(x => x.ApiName)
                .ToList();
        }
    }

    private List<string> BuildEntryEmailsFromSelectedContacts(IEnumerable<int>? selectedUserRefs)
    {
        if (selectedUserRefs is null)
        {
            return new List<string>();
        }

        var selectedRefSet = selectedUserRefs.Where(x => x > 0).Distinct().ToHashSet();
        if (selectedRefSet.Count == 0)
        {
            return new List<string>();
        }

        return SelectableContacts
            .Where(x => x is not null && selectedRefSet.Contains(x.UserRef))
            .Select(x => x.Email)
            .Where(x => x.IsNotNullOrBlank())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private string GetContactNames(ApplicationOptionsModel option)
    {
        if (option?.SelectedContactUserRefs is null || option.SelectedContactUserRefs.Count == 0)
        {
            return string.Empty;
        }

        var selectedRefSet = option.SelectedContactUserRefs.Where(x => x > 0).Distinct().ToHashSet();

        var selectedNames = SelectableContacts
            .Where(x => x is not null && selectedRefSet.Contains(x.UserRef))
            .Select(x => x.FullName)
            .Where(x => x.IsNotNullOrBlank())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        return string.Join(", ", selectedNames);
    }

    private void OnApiOptionContactsChanged(ApplicationOptionsModel option, IEnumerable<int> selectedUserRefs)
    {
        if (option is null)
        {
            return;
        }

        option.SelectedContactUserRefs = selectedUserRefs?.Where(x => x > 0).Distinct().ToList() ?? new List<int>();
        option.EntryEmail = BuildEntryEmailsFromSelectedContacts(option.SelectedContactUserRefs);
    }

    private void ApplySelectedUserName(ContactModel contactModel)
    {
        var selectedUser = ActiveSelectionUsers.FirstOrDefault(x => x.UserRef == contactModel.UserRef);
        if (selectedUser is null)
        {
            return;
        }

        contactModel.FullName = selectedUser.FullName;
    }

    private List<ApplicationSummary> GetAvailableApis(ApplicationOptionsModel currentOption)
    {
        var currentApiName = currentOption?.ApiName?.Trim();

        var usedApiNames = ApiOptionsGridData
            .Where(x => x != currentOption)
            .Select(x => x.ApiName?.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return ActiveApis
            .Where(x => !string.IsNullOrWhiteSpace(x.ApiName))
            .Where(x => !usedApiNames.Contains(x.ApiName.Trim()) || string.Equals(x.ApiName.Trim(), currentApiName, StringComparison.OrdinalIgnoreCase))
            .OrderBy(x => x.ApiName)
            .ToList();
    }
}