using System;
using System.Collections.Generic;

public class ApplicationCriteria : FilterCriteriaBase
{
	public ApplicationCriteria()
	{
	}

	[FilterProperty($"{nameof(IApplication.ApiName)}", Comparison = "")]
	public List<string> ApiName { get; set; }

	[SortAndFilterIgnore]
	public List<int> ApplicationRef { get; set; }

	[FilterProperty($"{nameof(IApplication.CreateDate)}", Comparison = "<=")]
	public DateTime? CreateDateEnd { get; set; }

	[FilterProperty($"{nameof(IApplication.CreateDate)}", Comparison = ">=")]
	public DateTime? CreateDateStart { get; set; }

	[FilterProperty($"{nameof(IApplication.Description)}", Comparison = "")]
	public string Description { get; set; }

	[FilterProperty($"{nameof(IApplication.Guid)}", Comparison = "")]
	public Guid? Guid { get; set; }

	[FilterProperty($"{nameof(IApplication.IsActiveFlag)}", Comparison = "")]
	public bool? IsActive { get; set; }

	[SortAndFilterIgnore]
	public bool? IsLoaded { get; set; }

	[FilterProperty($"{nameof(IApplication.Name)}", Comparison = "")]
	public List<string> Name { get; set; }

	[FilterProperty($"{nameof(IApplication.Slug)}", Comparison = "")]
	public List<string> Slug { get; set; }

	[SortAndFilterIgnore]
	public string SortBy { get; set; }

	[SortAndFilterIgnore]
	public string SortByDir { get; set; }

	[FilterProperty($"{nameof(IApplication.TypeRef)}", Comparison = "")]
	public int? TypeRef { get; set; }

	[FilterProperty($"{nameof(IApplication.VirtualDirectory)}", Comparison = "")]
	public string VirtualDirectory { get; set; }

	public override List<Filter> GetFilters()
	{
		var filters = base.GetFilters();
		if (IsLoaded.HasValue)
		{
			filters.Add(new Filter { Field = nameof(IApplication.IsLoadedFlag), Value = IsLoaded.Value ? "1" : "0" });
		}

		return filters;
	}

	public override Include GetInclude()
	{
		var include = new Include { Field = nameof(IApplication.ApplicationRef), Values = ApplicationRef };
		if (include.Values.IsNotEmpty())
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
			return new SortOrderField { Asc = !(SortByDir + "").StartsWith("d", StringComparison.OrdinalIgnoreCase), Field = nameof(IApplication.Name) }; ;
		}
		else
		{
			return new SortOrderField { Asc = !(SortByDir + "").StartsWith("d", StringComparison.OrdinalIgnoreCase), Field = SortBy };
		}
	}
}