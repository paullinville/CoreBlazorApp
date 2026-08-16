using System.Runtime.InteropServices;

namespace Midland.Core.Validation;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ValidateAsAttribute : Attribute
{
    public ValidateAsAttribute(Type asType)
    {
        ClassType = asType;
    }

    private ValidateAsAttribute()
    {
    }

    public Type ClassType { get; set; }
}