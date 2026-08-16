using System.Web;

namespace Midland.Core.Common;

public interface IFilterRequest
{
    List<Filter> GetFilters();

    Include GetInclude();

    List<SortOrderField> GetSorts();

    public string QueryString()
    {
        var query = "";

        var i = 0;
        var filters = GetFilters();
        var sorting = GetSorts();
        var include = GetInclude();
        foreach (var filter in filters.Values().Where(f => f.Field.IsNotNullOrBlank() && f.Value != null))
        {
            query += $"&{nameof(filters)}[{i}].{nameof(Filter.Field)}={filter.Field}&{nameof(filters)}[{i}].{nameof(Filter.Value)}={HttpUtility.UrlEncode(filter.Value)}";
            if (filter.Comparison.IsNotNullOrBlank())
            {
                query += $"&{nameof(filters)}[{i}].{nameof(filter.Comparison)}={HttpUtility.UrlEncode(filter.Comparison)}";
            }
            i++;
        }

        i = 0;
        foreach (var sort in sorting.Values().Where(s => s.Field.IsNotNullOrBlank()))
        {
            query += $"&{nameof(sorting)}[{i}].{nameof(sort.Field)}={sort.Field}&{nameof(sorting)}[{i}].{nameof(sort.Asc)}={sort.Asc}";
            i++;
        }

        if (include != null && include.Field.IsNotNullOrBlank() && include.Values.IsNotEmpty())
        {
            query += $"&{nameof(include)}.{nameof(include.Field)}={include.Field}";
            foreach (var value in include.Values)
            {
                query += $"&{nameof(include)}.{nameof(include.Values)}={value}";
            }
        }

        return query;
    }
}
