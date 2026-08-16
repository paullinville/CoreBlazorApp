using Midland.Core.Api;
using Midland.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Midland.Core.Validation.ClientRules;

public class ApiRuleSet
{
    public ApiRuleSet()
    { }

    public ApiRuleSet(Assembly assembly, IEnumerable<IFieldRuleCommand> fieldRules, IValidationService vs)
    {
        if (assembly == null) return;
        Api = assembly.GetName().FullName.BeforeX(".");
        Version = assembly.GetName().Version.ToString();
        RuleDictionary = new Dictionary<string, ClientRules>();
    }

    public string Api { get; set; }

    public Dictionary<string, ClientRules> RuleDictionary { get; set; }

    public List<ClientRules> RuleList { get => RuleDictionary?.Values.Values().ToList(); }
    public string Version { get; set; }
}