namespace Midland.Core.Authorization;

[AttributeUsage(AttributeTargets.Field)]
public class ClaimActionDescription : Attribute
{
    public ClaimActionDescription(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
}