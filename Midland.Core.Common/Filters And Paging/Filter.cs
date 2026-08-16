using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Midland.Core.Tests")]

namespace Midland.Core.Common;

public class Filter : FilterValue
{
    public string Field { get; set; }
    public Type ListType { get; set; }
}

public class FilterValue
{
    public string Comparison { get; set; }
    public int Group { get; set; }
    public string Value { get; set; }
    internal int? Order { get; set; }
}