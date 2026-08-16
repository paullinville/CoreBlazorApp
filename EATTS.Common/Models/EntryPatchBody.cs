using System.ComponentModel.DataAnnotations;

namespace EATTS.Common.Models;

public class EntryPatchBody
{
	public EntryPatchBody()
	{ }

	public EntryPatchBody(IEntry values)
	{
		if (values == null) return;
		Description = values.GenericDescription;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(512)]
	public string Description { get; set; }
}
