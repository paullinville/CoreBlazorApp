using System.Runtime.Serialization.Json;

namespace EATTS.Common.Models;

public class EntrySummaryModel : EntrySummaryModelBase
{
	public EntrySummaryModel()
	{ }

	public EntrySummaryModel(IEntrySearch data) : base(data)
	{
		LastOccurrenceDescription = data.EntryOccurrenceDescription;
	}

	public string LastOccurrenceDescription { get; set; }
}