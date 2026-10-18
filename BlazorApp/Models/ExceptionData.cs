namespace BlazorApp.Models;

public class ExceptionData
{
    public ExceptionData()
    {
    }

    public ExceptionData(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; set; }
    public string Value { get; set; }
}
