namespace Midland.Core.Validation.ClientRules;

public interface IFieldRule
{
	string Name { get; set; }
	string Message { get; set; }
	string Operation { get; set; }
	object Value { get; set; }
}