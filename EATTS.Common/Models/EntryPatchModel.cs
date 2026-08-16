using System.ComponentModel.DataAnnotations;

namespace EATTS.Common.Models;

public class EntryPatchModel
{
	public EntryPatchModel()
	{ }

	public EntryPatchModel(IEntry values)
	{
		EntryRef = values.EntryRef;
		Body = new EntryPatchBody(values);
	}

	public virtual EntryPatchBody Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int EntryRef { get; set; }
}