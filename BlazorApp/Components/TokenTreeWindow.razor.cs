using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class TokenTreeWindow
{
    [Parameter]
    public bool Visible { get; set; }

    [Parameter]
    public EventCallback<bool> VisibleChanged { get; set; }

    [Parameter]
    public IReadOnlyCollection<TokenTreeItem> TreeItems { get; set; } = Array.Empty<TokenTreeItem>();

    [Parameter]
    public IReadOnlyCollection<TokenPermissionItem> PermissionItems { get; set; } = Array.Empty<TokenPermissionItem>();

    [Parameter]
    public string Title { get; set; } = "Users Application Information";

    [Parameter]
    public EventCallback CopyClicked { get; set; }

    [Parameter]
    public EventCallback CloseClicked { get; set; }

    private Task OnVisibleChanged(bool visible)
    {
        return VisibleChanged.InvokeAsync(visible);
    }

    private Task OnCopyClicked()
    {
        return CopyClicked.InvokeAsync();
    }

    private Task OnCloseClicked()
    {
        return CloseClicked.InvokeAsync();
    }
}
