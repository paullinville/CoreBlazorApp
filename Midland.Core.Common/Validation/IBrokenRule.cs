namespace Midland.Core.Validation;

public interface IBrokenRule : IRule
{
	ValidationSeverity Severity { get; set; }

    string Identifier();
    string ValidationModelErrorKey();
}