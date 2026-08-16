using System.Text.Json.Serialization;

namespace Midland.Core.Validation;

public class Validated : IValidated
{
    [JsonIgnore]
    public bool DataAnnotationChecked { get; set; }

    [JsonIgnore]
    public IBrokenRules InvalidRules { get; set; }

    [JsonIgnore]
    public bool RulesChecked { get; set; }

    public void MarkUnchecked()
    {
        InvalidRules = null;
        RulesChecked = false;
        DataAnnotationChecked = false;
    }
}

public interface IValidated
{
    public bool DataAnnotationChecked { get; set; }

    [JsonIgnore]
    public bool? Invalid
    {
        get
        {
            if (InvalidRules == null)
            {
                return null;
            }
            else
            {
                return InvalidRules.AnyCritical();
            }
        }
    }

    [JsonIgnore]
    public IBrokenRules InvalidRules { get; set; }

    [JsonIgnore]
    public bool RulesChecked { get; set; }

    public void MarkUnchecked()
    {
        InvalidRules = null;
        RulesChecked = false;
        DataAnnotationChecked = false;
    }
}