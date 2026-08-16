using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace EATTS.Common.Models;

public class EntryDetailModel
{
	public const int Limit = 100;

	public EntryDetailModel(IEntry values)
	{
		if (values == null) return;
		EntryRef = values.EntryRef;
		GenericDescription = values.GenericDescription + "";
		Key = values.Key + "";
		OccurrenceCount = values.OccurrenceCount;
		LastEntryOccurrenceRef = values.LastEntryOccurrenceRef;
	}

	public int EntryRef { get; set; }

	public ErrorTypeCode ErrorTypeCode { get; set; }
	public string GenericDescription { get; set; }
	public string Key { get; set; }
	public int LastEntryOccurrenceRef { get; set; }
	public List<EntryNoteDetail> Notes { get; set; }

	/// <summary>
	/// Total number of occurrences.
	/// </summary>
	public int OccurrenceCount { get; set; }

	public int OccurrenceLimit { get => Limit; }

	/// <summary>
	/// Returns up to the last OccurrenceLimit occurrences for the entry ordered by the date of the occurrence.
	/// </summary>
	public List<OccurrenceDetailModel> Occurrences { get; set; }
}