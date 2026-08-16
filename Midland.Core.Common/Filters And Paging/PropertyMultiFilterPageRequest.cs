namespace Midland.Core.Common;

public class PropertyMultiFilterPageRequest : BasicSortedIncludePageRequest
{
    public PropertyMultiFilterPageRequest()
    {
    }

    [SortAndFilterIgnore]
    public List<Filter> Filters { get; set; }

    [SortAndFilterIgnore]
    public List<SortOrderField> Sorting { get; set; }

    public override List<Filter> GetFilters()
    {
        var filters = base.GetFilters();

        Filters.Values().Where(f => f.Field.IsNotNullOrBlank() && f.Value != null).ForEach(f => filters.Add(f));

        return filters;
    }

    public override List<SortOrderField> GetSorts()
    {
        var list = base.GetSorts();
        list.AddRange(Sorting.Values().Where(s => s.Field.IsNotNullOrBlank()));
        return list;
    }
}