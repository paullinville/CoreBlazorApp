namespace Midland.Core.Common;

/// <summary>
/// Filter criteria class that includes default sort and include fields. Not designed for paged
/// results as it does not have the page number and size properties.
/// </summary>
public class SortAndIncludeFilter : FilterCriteriaBase
{
	private string sortByField;

	public SortAndIncludeFilter()
	{
	}

	public SortAndIncludeFilter(string defaultSortField, string includeField)
	{
		IncludeField = includeField;
		DefaultSortField = defaultSortField;
	}

	[SortAndFilterIgnore]
	public List<int> Include { get; set; }

	[SortAndFilterIgnore]
	public string SortBy { get => sortByField.IsNullOrBlank(DefaultSortField); set => sortByField = value; }

	[SortAndFilterIgnore]
	public string SortByDir { get; set; }

	protected string DefaultSortField { get; set; }
	protected string IncludeField { get; set; }

	public override Include GetInclude()
	{
		var include = new Include { Field = IncludeField, Values = Include };
		if (include.Values.IsNotEmpty() && include.Field.IsNotNullOrBlank())
		{
			return include;
		}
		else
		{
			return null;
		}
	}

	public override List<SortOrderField> GetSorts()
	{
		var list = base.GetSorts();
		if (list.IsEmpty())
		{
			var sortOrder = GetDefaultSortOrder();
			if (sortOrder != null)
			{
				list.Add(sortOrder);
			}
		}
		return list;
	}

	protected virtual SortOrderField GetDefaultSortOrder()
	{
		if (SortBy.IsNullOrBlank())
		{
			return null;
		}
		else
		{
			return new SortOrderField { Asc = !(SortByDir + "").StartsWith("d", StringComparison.OrdinalIgnoreCase), Field = SortBy };
		}
	}
}