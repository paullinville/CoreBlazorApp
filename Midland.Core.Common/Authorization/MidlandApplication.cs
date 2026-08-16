using System;

namespace Midland.Core.ApplicationSecurity;

public class MidlandApplication : IMidlandApplication
{
    public int ApplicationRef { get; set; }
    public string Description { get; set; }
    public Guid Guid { get; set; }
    public bool IsLoaded { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string VirtualDirectory { get; set; }
}