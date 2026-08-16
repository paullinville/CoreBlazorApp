namespace Midland.Core.Api;

[AttributeUsage(validOn: AttributeTargets.Interface, AllowMultiple = false)]
public class ApiNameAttribute : Attribute
{
    public ApiNameAttribute()
    { }

    public ApiNameAttribute(string name)
    { Name = name; }

    public string Name { get; set; }
}