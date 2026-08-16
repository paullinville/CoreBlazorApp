using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class EntryOccurrencePatchModel
{
	public EntryOccurrencePatchModel()
	{ }

	public EntryOccurrencePatchModel(IEntryOccurrence values)
	{
		EntryOccurrenceRef = values.EntryOccurrenceRef;
		Body = new EntryOccurrencePatchBody(values);
	}

	public virtual EntryOccurrencePatchBody Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int EntryOccurrenceRef { get; set; }
}
