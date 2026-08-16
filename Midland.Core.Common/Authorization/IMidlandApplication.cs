namespace Midland.Core.ApplicationSecurity;

public interface IMidlandApplication
{
    int ApplicationRef { get; set; }
    string Description { get; set; }
    Guid Guid { get; set; }
    bool IsLoaded { get; set; }
    string Name { get; set; }
    string Slug { get; set; }
    string VirtualDirectory { get; set; }
}