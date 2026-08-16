namespace Midland.Core.Validation.ClientRules;

public class ClientFieldRule : IFieldRule
{
    public ClientFieldRule(IFieldRule fieldRule)
    {
        Name = fieldRule.Name;
        Operation = fieldRule.Operation;
        Value = fieldRule.Value;
        Message = fieldRule.Message;
    }

    public ClientFieldRule()
    { }

    public string Message { get; set; }
    public string Name { get; set; }
    public string Operation { get; set; }
    public object Value { get; set; }
}