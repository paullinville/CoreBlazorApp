namespace Midland.Core.Common;

public class BasicIncludePageRequest : SimplePageRequest
{
    protected static List<string> IgnoredProperties = new List<string> {nameof(PageNumber),
                                                                      nameof(PageSize)};

    public BasicIncludePageRequest()
    {
    }

    public BasicIncludePageRequest(string defaultIncludeField)
    {
        DefaultIncludeField = defaultIncludeField;
    }

    [SortAndFilterIgnore]
    public List<int> Include { get; set; }

    protected virtual string DefaultIncludeField { get; set; }

    public override Include GetInclude()
    {
        var include = new Include { Field = DefaultIncludeField, Values = Include };
        if (include.Values.IsNotEmpty() && include.Field.IsNotNullOrBlank())
        {
            return include;
        }
        else
        {
            return null;
        }
    }
}