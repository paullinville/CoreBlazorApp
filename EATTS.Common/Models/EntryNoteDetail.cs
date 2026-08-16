using Midland.Core.Common;
using System;

namespace EATTS.Common.Models;

public class EntryNoteDetail
{
	public EntryNoteDetail(IEntryNote values)
	{
		if (values == null) return;
		EntryNoteRef = values.EntryNoteRef;
		Date = values.Date;
		Text = values.Text + "";
		EntryOccurrenceRef = values.EntryOccurrenceRef;
		EntryRef = values.EntryRef;
	}

	public DateTime Date { get; set; }
	public int EntryNoteRef { get; set; }
	public int? EntryOccurrenceRef { get; set; }
	public int EntryRef { get; set; }
	public string Text { get; set; }
	public EmployeeSimple User { get; set; }
}