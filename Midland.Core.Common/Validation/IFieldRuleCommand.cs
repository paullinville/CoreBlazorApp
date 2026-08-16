using System.Reflection;

namespace Midland.Core.Validation.ClientRules;

public interface IFieldRuleCommand
{
	public IEnumerable<IFieldRule> Execute(PropertyInfo prop);
}