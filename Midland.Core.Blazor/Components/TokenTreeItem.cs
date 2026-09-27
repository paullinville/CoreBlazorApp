namespace Midland.Core.Blazor.Components;

public class TokenTreeItem
{
    public string Text { get; set; } = string.Empty;

    public List<TokenTreeItem> Items { get; set; } = [];
}
