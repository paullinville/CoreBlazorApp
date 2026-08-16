using Midland.Core.Common;
using System;
using System.Collections.Generic;

namespace EATTS.Common.Models;

public class EntryOccurrenceSearchCriteria : BasicSortedIncludePageRequest
{
	public EntryOccurrenceSearchCriteria()
	{
		DefaultIncludeField = nameof(IEntryOccurrenceSearch.EntryOccurrenceRef);
		DefaultSortField = nameof(IEntryOccurrenceSearch.EntryOccurrenceDate);
		SortByDir = "DESC";
	}

	[SortAndFilterIgnore]
	public string ApiSlug { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceCallerId)}", Comparison = "")]
	public string CallerId { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryGenericDescription)}", Comparison = "")]
	public string Description { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceEmailsSent)}", Comparison = "")]
	public string EmailsSent { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryRef)}", Comparison = "")]
	public int? EntryRef { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceErrorResponse)}", Comparison = "")]
	public string ErrorResponse { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.ErrorTypeDescription)}", Comparison = "")]
	public string ErrorType { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryErrorTypeRef)}", Comparison = "")]
	public int? ErrorTypeRef { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.IsError)}", Comparison = "")]
	public bool? IsError { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryKey)}", Comparison = "")]
	public string Key { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.LastEntryOccurrenceDate)}", Comparison = "<=")]
	public DateTime? LastOccurrenceDateEnd { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.LastEntryOccurrenceDate)}", Comparison = ">=")]
	public DateTime? LastOccurrenceDateStart { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.LastEntryOccurrenceRef)}", Comparison = "")]
	public int? LastOccurrenceRef { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceCount)}", Comparison = "")]
	public int? OccurrenceCount { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceDate)}", Comparison = "<=")]
	public DateTime? OccurrenceDateEnd { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceDate)}", Comparison = ">=")]
	public DateTime? OccurrenceDateStart { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceDescription)}", Comparison = "")]
	public string OccurrenceDescription { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceRef)}", Comparison = "")]
	public int? OccurrenceRef { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceUserRef)}", Comparison = "")]
	public int? OccurrenceUserRef { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.EntryOccurrenceOrigin)}", Comparison = "")]
	public string Origin { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.RequestId)}", Comparison = "")]
	public Guid? RequestId { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.TokenSubject)}", Comparison = "")]
	public string TokenSubject { get; set; }

	[FilterProperty($"{nameof(IEntryOccurrenceSearch.TokenSubjectType)}", Comparison = "")]
	public int? TokenSubjectType { get; set; }

	public override List<Filter> GetFilters()
	{
		var baseFilters = base.GetFilters();
		if (ApiSlug.IsNotNullOrBlank())
		{
			baseFilters.Add(new Filter
			{
				Field = nameof(IEntryOccurrenceSearch.TokenSubjectType),
				Comparison = "=",
				Value = ((int)Midland.Core.Authorization.TokenSubjectType.Api).ToString()
			});

			baseFilters.Add(new Filter
			{
				Field = nameof(IEntryOccurrenceSearch.TokenSubject),
				Comparison = "",
				Value = ApiSlug
			});
		}
		return baseFilters;
	}
}