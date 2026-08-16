using System;

namespace EATTS.Common.Models;

public class EntryOccurrenceSummaryModel : EntrySummaryModelBase
{
	public EntryOccurrenceSummaryModel()
	{ }

	public EntryOccurrenceSummaryModel(Interfaces.IEntryOccurrenceSearch value) : base(value)
	{
		EntryOccurrenceRef = value.EntryOccurrenceRef;

		EmailsSent = value.EntryOccurrenceEmailsSent;
		UserRef = value.EntryOccurrenceUserRef;
		OccurrenceDescription = value.EntryOccurrenceDescription;
		ErrorType = value.ErrorTypeDescription;
	}

	public string EmailsSent { get; set; }
}