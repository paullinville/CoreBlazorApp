namespace Midland.Core.Common;

public class BasicSortedIncludePageRequest : BasicIncludePageRequest
{
	private string sortByField;

	public BasicSortedIncludePageRequest()
	{
	}

	public BasicSortedIncludePageRequest(string defaultSortField)
	{
		DefaultSortField = defaultSortField;
	}

	public BasicSortedIncludePageRequest(string defaultSortField, string defaultIncludeField) : base(defaultIncludeField)
	{
		DefaultSortField = defaultSortField;
	}

	[SortAndFilterIgnore]
	public string SortBy { get => sortByField.IsNullOrBlank(DefaultSortField); set => sortByField = value; }

	[SortAndFilterIgnore]
	public string SortByDir { get; set; }

	protected virtual string DefaultSortField { get; set; }

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

		return new SortOrderField { Asc = !(SortByDir + "").StartsWith("d", StringComparison.OrdinalIgnoreCase), Field = SortBy };
	}
}