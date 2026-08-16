using Midland.Core.Common;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Midland.Core.Validation.ClientRules;

public class ClientRules
{
    private List<FieldRules> _fieldRules;

    public ClientRules()
    { }

    public ClientRules(Type modelType, IEnumerable<IFieldRuleCommand> fieldRuleCommands, IValidationService vs = null)
    {
        ModelType = modelType;
        FieldRuleCommands = fieldRuleCommands;
        ModelName = modelType.Name;

        if (vs != null && vs.ValidationDescriptions.ContainsKey(modelType.FullName))
        {
            ClassRules = vs.ValidationDescriptions[modelType.FullName];
        }
        else
        {
            ClassRules = new List<string> { };
        }
        if (vs != null && vs.FieldRules.ContainsKey(modelType.FullName))
        {
            ValidationClassFieldRules = vs.FieldRules[modelType.FullName];
        }
        else
        {
            ValidationClassFieldRules = new Dictionary<string, List<ClientFieldRule>>();
        }
    }

    public List<string> ClassRules { get; set; }

    [JsonIgnore]
    public IEnumerable<IFieldRuleCommand> FieldRuleCommands { get; }

    public List<FieldRules> FieldRuleList { get => GetRules(); }
    public string ModelName { get; set; }
    private Type ModelType { get; set; }
    private IDictionary<string, List<ClientFieldRule>> ValidationClassFieldRules { get; set; }

    private List<FieldRules> GetRules()
    {
        if (_fieldRules == null)
        {
            _fieldRules = new List<FieldRules>();
            foreach (var prop in ModelType.GetProperties())
            {
                var fieldRule = new FieldRules(prop, FieldRuleCommands);

                if (ValidationClassFieldRules.IsNotEmpty() && ValidationClassFieldRules.ContainsKey(prop.Name))
                {
                    fieldRule.ClientRules.AddRange(ValidationClassFieldRules[prop.Name]);
                }
                if (fieldRule.ClientRules.IsNotEmpty())
                {
                    _fieldRules.Add(fieldRule);
                }
            }
        }
        return _fieldRules;
    }
}