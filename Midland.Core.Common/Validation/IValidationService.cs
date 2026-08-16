using Midland.Core.Validation.ClientRules;

namespace Midland.Core.Validation
{
    public interface IValidationService
    {
        IDictionary<string, IDictionary<string, List<ClientFieldRule>>> FieldRules { get; }

        string PackageName { get; }

        IDictionary<string, List<string>> ValidationDescriptions { get; }

        IEnumerable<IBrokenRule> CheckRules(object obj);

        IEnumerable<IBrokenRule> ValidateDataAnnotations(object model);

        /// <summary>
        /// Checks all the rules for the models type and the models data annotations. If the model
        /// is type IValidated and RulesChecked or DataAnnotationChecked is false they will be
        /// checked again otherwise no rules will be checked. If it is NOT type IValidated then all
        /// rules will be checked regardless.
        /// </summary>
        /// <param name="model">The model to check. Uses the models type.</param>
        IEnumerable<IBrokenRule> ValidateModel(object model);
    }
}