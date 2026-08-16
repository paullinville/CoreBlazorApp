using System.Web;

namespace Midland.Core.Common;

public class MultiFilterPageRequest : PageRequestModel, IFilterPageRequest
{
    public MultiFilterPageRequest()
    { }

    public List<Filter> Filters { get; set; }

    public Include Include { get; set; }

    public List<SortOrderField> Sorting { get; set; }

    public List<Filter> GetFilters()
    {
        return Filters;
    }

    public Include GetInclude()
    {
        return Include;
    }

    public List<SortOrderField> GetSorts()
    {
        return Sorting;
    }
}