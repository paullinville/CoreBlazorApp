using BlazorApp.Data;
using EmployeeData.Common.Models;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace BlazorApp.Components;

public partial class UserSelect
{
    [Inject]
    private IEmployeeRepository EmployeeRepository { get; set; } = default!;

    [Parameter]
    public int? Value { get; set; }

    [Parameter]
    public EventCallback<int?> ValueChanged { get; set; }

    [Parameter]
    public Expression<Func<int?>>? ValueExpression { get; set; }

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

    private Task OnValueChanged(int? value)
    {
        Value = value;
        return ValueChanged.InvokeAsync(value);
    }
}
