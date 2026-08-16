namespace Midland.Core.Common;

public class ErrorResultError
{
    public ErrorResultError(string errorValue)
    {
        Value = errorValue;
        Type = ErrorType.General;
        Name = "";
    }

    public ErrorResultError(string errorValue, string name)
    {
        Value = errorValue;
        Type = ErrorType.General;
        Name = name;
    }

    public ErrorResultError()
    {
    }

    public string Name { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is ErrorResultError)
        {
            return this.ToString() == obj.ToString();
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public override string ToString()
    {
        return $"{Type.ToUpper()}|{Name.ToUpper()}|{Value.ToUpper()}";
    }
}