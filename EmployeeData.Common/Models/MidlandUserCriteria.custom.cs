using Midland.Core.Common;
using System;
using System.Collections.Generic;

namespace EmployeeData.Common.Models;

public partial class MidlandUserCriteria
{
	[SortAndFilterIgnore]
	public int? TerminatedLookBack { get; set; }

	public override List<Filter> GetFilters()
	{
		var baseFilters = base.GetFilters();
		if (TerminatedLookBack.HasValue)
		{
			baseFilters.Add(new Filter
			{
				Field = nameof(IMidlandUser.TerminationDate),
				Comparison = ">=",
				ListType = typeof(DateTime),
				Value = DateTime.Now.PreviousWorkDay(TerminatedLookBack.Value, new HashSet<DateTime>()).ToShortDateString()
			});
		}
		return baseFilters;
	}
}