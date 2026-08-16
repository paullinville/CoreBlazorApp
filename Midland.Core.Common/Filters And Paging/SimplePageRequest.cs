namespace Midland.Core.Common;

public class SimplePageRequest : PageRequestModel, IFilterPageRequest
{
    public SimplePageRequest()
    {
    }

    public virtual List<Filter> GetFilters()
    {
        return this.CreateFilters();
    }

    public virtual Include GetInclude()
    {
        return null;
    }

    public virtual List<SortOrderField> GetSorts()
    {
        return this.CreateSorts();
    }
}