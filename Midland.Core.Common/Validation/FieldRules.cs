using Midland.Core.Common;
using System.Collections.Generic;
using System.Reflection;

namespace Midland.Core.Validation.ClientRules;

public class FieldRules
{
    public FieldRules()
    {
    }

    public FieldRules(PropertyInfo propertyInfo, IEnumerable<IFieldRuleCommand> fieldRuleCommands) : this()
    {
        Field = propertyInfo.Name;
        FieldType = propertyInfo.PropertyTypeName();
        ClientRules = new List<ClientFieldRule>();

        fieldRuleCommands.ForEach(cmd => { ClientRules.AddRange(cmd.Execute(propertyInfo).Select(r => new ClientFieldRule(r))); });
    }

    public List<ClientFieldRule> ClientRules { get; set; }
    public string Field { get; set; }
    public string FieldType { get; set; }
}