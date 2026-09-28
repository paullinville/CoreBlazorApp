using EmployeeData.Common;
using EmployeeData.Common.Models;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Midland.Core.Blazor.Components;

public partial class UserSelect
{
    [Inject]
    private IUsers EmployeeRepository { get; set; } = default!;

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public int? Value { get; set; }

    [Parameter]
    public EventCallback<int?> ValueChanged { get; set; }

    [Parameter]
    public EventCallback<UserSelectModelExpanded?> SelectedUserChanged { get; set; }

    [Parameter]
    public Expression<Func<int?>> ValueExpression { get; set; } = default!;

    [Parameter]
    public string Placeholder { get; set; } = "Select a user";

    [Parameter]
    public bool Enabled { get; set; } = true;

    private List<UserSelectModelExpanded> Users { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Users = await EmployeeRepository.GetActiveSelectionUsers();
        await base.OnInitializedAsync();
    }

    private async Task OnValueChanged(int? value)
    {
        Value = value;
        var selectedUser = Users.FirstOrDefault(x => x.UserRef == value);
        await ValueChanged.InvokeAsync(value);
        await SelectedUserChanged.InvokeAsync(selectedUser);
    }
}
