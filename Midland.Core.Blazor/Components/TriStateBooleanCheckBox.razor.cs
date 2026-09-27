using Microsoft.AspNetCore.Components;

namespace Midland.Core.Blazor.Components;

public partial class TriStateBooleanCheckBox
{
    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public bool? Value { get; set; }

    [Parameter]
    public EventCallback<bool?> ValueChanged { get; set; }

    [Parameter]
    public bool Enabled { get; set; } = true;

    [Parameter]
    public string? Class { get; set; }

    private bool? CheckBoxValue
    {
        get => Value;
        set
        {
            bool? nextValue;

            if (Value == true)
            {
                nextValue = false;
            }
            else if (Value == false)
            {
                nextValue = null;
            }
            else
            {
                nextValue = true;
            }

            Value = nextValue;
            _ = ValueChanged.InvokeAsync(nextValue);
        }
    }
}
