using EmployeeData.Common;
using EmployeeData.Common.Models;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Midland.Core.Blazor.Components;

public partial class UserMultiSelect
{
    [Inject]
    private IUsers EmployeeRepository { get; set; } = default!;

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public List<int> Value { get; set; } = [];

    [Parameter]
    public EventCallback<List<int>> ValueChanged { get; set; }

    [Parameter]
    public EventCallback<List<UserSelectModelExpanded>> SelectedUsersChanged { get; set; }

    [Parameter]
    public Expression<Func<List<int>>> ValueExpression { get; set; } = default!;

    [Parameter]
    public string Placeholder { get; set; } = "Select users";

    [Parameter]
    public bool Enabled { get; set; } = true;

    private List<UserSelectModelExpanded> Users { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Users = await EmployeeRepository.GetActiveSelectionUsers();
        await base.OnInitializedAsync();
    }

    private async Task OnValueChanged(List<int> value)
    {
        Value = value?.Where(x => x > 0).Distinct().ToList() ?? [];
        var selectedUsers = Users.Where(x => Value.Contains(x.UserRef)).ToList();

        await ValueChanged.InvokeAsync(Value);
        await SelectedUsersChanged.InvokeAsync(selectedUsers);
    }
}
