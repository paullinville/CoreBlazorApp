using Midland.Core.Common;
using System;
using System.Collections.Generic;

namespace EATTS.Common.Interfaces;

public interface ISearchRepository
{
	List<IEntryOccurrence> EntryOccurrences(int entryRef, int seconds);

	IEnumerable<IErrorHistory> ErrorHistory(int errorRef);

	IEnumerable<IErrorOccurence> ErrorOccurrence(int errorRef);

	PageResultsModel<ApiLogDataModel> FilterLogs(ApiLogCriteria filter);

	PageResultsModel<EntryOccurrenceSummaryModel> GetEntryOccurrenceSearchSummaries(EntryOccurrenceSearchCriteria pageInfo);

	PageResultsModel<EntrySearchView> GetEntryViews(EntrySearchCriteria pageInfo);
}