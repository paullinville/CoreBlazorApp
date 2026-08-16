using System;
using Midland.Core.Common;

namespace EATTS.Common.Models;

public class EntryOccurrenceCriteria : BasicSortedIncludePageRequest
{
	public EntryOccurrenceCriteria()
	{
		DefaultSortField = nameof(IEntrySearch.EntryOccurrenceDate);
	}

	[FilterProperty($"{nameof(IEntrySearch.EntryDescription)}", Comparison = "")]
	public string EntryDescription { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryKey)}", Comparison = "")]
	public string EntryKey { get; set; }

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

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceOrigin)}", Comparison = "=")]
	public string OccurrenceOrigin { get; set; }

	[FilterProperty($"{nameof(IEntrySearch.EntryOccurrenceUserRef)}", Comparison = "")]
	public int? OccurrenceUserRef { get; set; }
}