using System.ComponentModel.DataAnnotations;

namespace EATTS.Common.Models;

public class EntryOccurrencePatchBody
{
	public EntryOccurrencePatchBody()
	{ }

	public EntryOccurrencePatchBody(IEntryOccurrence values)
	{
		if (values == null) return;
		Description = values.Description;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(512)]
	public string Description { get; set; }
}
