namespace BlazorApp.Common;

using System.ComponentModel.DataAnnotations;

public class LogAnalysisCriteriaInput : IValidatableObject
{
    [Required(ErrorMessage = "Application Summary is required")]
    public string SelectedApplicationSummary { get; set; } = string.Empty;

    [Required(ErrorMessage = "From date is required")]
    public DateTime? FromDate { get; set; } = DateTime.Today.AddDays(-7);

    [Required(ErrorMessage = "To date is required")]
    public DateTime? ToDate { get; set; } = DateTime.Today;

    [EnumDataType(typeof(WindowUnit), ErrorMessage = "Window Unit is invalid")]
    public WindowUnit WindowUnit { get; set; } = WindowUnit.Days;

    [Range(1, int.MaxValue, ErrorMessage = "Window Size must be greater than 0")]
    public int WindowSize { get; set; } = 1;

    [Range(1, int.MaxValue, ErrorMessage = "Action Count must be greater than 0")]
    public int ActionCountToAnalyze { get; set; } = 5;

    [Range(2, 5, ErrorMessage = "Moving Average Window Count must be between 2 and 5")]
    public int MovingAverageWindowCount { get; set; } = 3;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FromDate.HasValue && ToDate.HasValue && FromDate.Value > ToDate.Value)
        {
            yield return new ValidationResult("From date must be less than or equal to To date", [nameof(FromDate), nameof(ToDate)]);
        }
    }
}