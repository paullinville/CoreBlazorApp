namespace Midland.Core.Validation;

public interface IBrokenRules : IEnumerable<IBrokenRule>
{
    IBrokenRule Add(object objectBroke, string description, ValidationSeverity severity = ValidationSeverity.Critical);

    void Add(IBrokenRule rule);

    void AddIfNotFound(IEnumerable<IBrokenRule> rules);

    void AddRange(IEnumerable<IBrokenRule> rules);

    bool AnyCritical();

    IBrokenRules GetCritical();

    IBrokenRules GetInformation();

    void Set(IEnumerable<IBrokenRule> rules);
}