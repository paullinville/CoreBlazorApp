using System;
using System.Collections.Generic;
using Midland.Core.Common;

namespace EATTS.Common.Models;

public class EntrySearchCriteria : BasicSortedIncludePageRequest
{
	public EntrySearchCriteria()
	{
		DefaultSortField = nameof(IEntrySearch.EntryOccurrenceDate);
		DefaultIncludeField = nameof(IEntrySearch.EntryRef);
		SortByDir = "Asc";
	}

	[SortAndFilterIgnore]
	public string ApiSlug { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryDescription)}", Comparison = "")]
	public string Description { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceRef)}", Comparison = "")]
	public int? EntryOccurrenceRef { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryRef)}", Comparison = "")]
	public int? EntryRef { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.IsError)}", Comparison = "")]
	public bool? IsError { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryKey)}", Comparison = "")]
	public string Key { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.LastEntryOccurrenceDate)}", Comparison = "<=")]
	public DateTime? LastEntryOccurrenceDateEnd { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.LastEntryOccurrenceDate)}", Comparison = ">=")]
	public DateTime? LastEntryOccurrenceDateStart { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.LastEntryOccurrenceRef)}", Comparison = "")]
	public int? LastEntryOccurrenceRef { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceCallerId)}", Comparison = "")]
	public string OccurrenceCallerId { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceCount)}", Comparison = "")]
	public int? OccurrenceCount { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceDate)}", Comparison = "<=")]
	public DateTime? OccurrenceDateEnd { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceDate)}", Comparison = ">=")]
	public DateTime? OccurrenceDateStart { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceDescription)}", Comparison = "")]
	public string OccurrenceDescription { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceEmailsSent)}", Comparison = "")]
	public string OccurrenceEmailsSent { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceOrigin)}", Comparison = "")]
	public string OccurrenceOrigin { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceUserRef)}", Comparison = "")]
	public int? OccurrenceUserRef { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.RequestId)}", Comparison = "")]
	public Guid? RequestId { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.TokenSubject)}", Comparison = "")]
	public string TokenSubject { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.TokenSubjectType)}", Comparison = "")]
	public int? TokenSubjectType { get; set; }

	public override List<Filter> GetFilters()
	{
		var baseFilters = base.GetFilters();
		if (ApiSlug.IsNotNullOrBlank())
		{
			baseFilters.Add(new Filter
			{
				Field = nameof(IEntrySearch.TokenSubjectType),
				Comparison = "=",
				Value = ((int)Midland.Core.Authorization.TokenSubjectType.Api).ToString()
			});

			baseFilters.Add(new Filter
			{
				Field = nameof(IEntrySearch.TokenSubject),
				Comparison = "",
				Value = ApiSlug
			});
		}
		return baseFilters;
	}
}