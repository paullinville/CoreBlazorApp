namespace Midland.Core.Common;

public class EattsOptions
{
    /// <summary>
    /// The ref of the application in Application Inventory. Used to determine the tech support contacts
    /// </summary>
    public int? ApplicationInventoryRef { get; set; }

    /// <summary>
    /// If true will record errors via EATTS api.
    /// </summary>
    public bool Record { get; set; } = true;
}