namespace BlazorApp.Common;

using System.ComponentModel.DataAnnotations;

public class LogPivotTableCriteriaInput : IValidatableObject
{
    public string SelectedApplicationSummary { get; set; } = string.Empty;

    [Required(ErrorMessage = "From date is required")]
    public DateTime? FromDate { get; set; } = DateTime.Today.AddDays(-7);

    [Required(ErrorMessage = "To date is required")]
    public DateTime? ToDate { get; set; } = DateTime.Today;

    public bool? IsError { get; set; } = null;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FromDate.HasValue && ToDate.HasValue && FromDate.Value > ToDate.Value)
        {
            yield return new ValidationResult("From date must be less than or equal to To date", [nameof(FromDate), nameof(ToDate)]);
        }
    }
}