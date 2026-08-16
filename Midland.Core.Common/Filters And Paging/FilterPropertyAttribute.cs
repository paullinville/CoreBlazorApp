using System;

namespace Midland.Core.Common;

[AttributeUsage(AttributeTargets.Property)]
public class FilterPropertyAttribute : Attribute
{
    public FilterPropertyAttribute()
    {
    }

    public FilterPropertyAttribute(string field)
    {
        Field = field;
    }

    public FilterPropertyAttribute(string field, int order)
    {
        Field = field;
        Order = order;
    }

    public FilterPropertyAttribute(string field, int order, string comparison)
    {
        Field = field;
        Order = order;
        Comparison = comparison;
    }

    public string Comparison { get; set; }
    public string Field { get; set; }
    public int Group { get; set; }
    public int Order { get; set; }
}