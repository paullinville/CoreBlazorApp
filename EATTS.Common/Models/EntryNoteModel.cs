using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class EntryNoteDeleteModel
{
	public virtual int EntryNoteRef { get; set; }
}

public class EntryNoteGetModel : EntryNotePostModel
{
	public EntryNoteGetModel()
	{ }

	public EntryNoteGetModel(IEntryNote values) : base(values)
	{
		EntryNoteRef = values.EntryNoteRef;
	}

	public int EntryNoteRef { get; set; }

	public override EATTS.Common.Dto.EntryNoteDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.EntryNoteDto();
		createdItem.Date = Date;
		createdItem.EntryNoteRef = EntryNoteRef;
		createdItem.Text = Text;
		createdItem.UserRef = UserRef;
		createdItem.EntryOccurrenceRef = EntryOccurrenceRef;
		createdItem.EntryRef = EntryRef;
		return createdItem;
	}

	#region

	public override bool Equals(object obj)
	{
		if (obj is EntryNoteGetModel item)
		{
			return item.EntryNoteRef == EntryNoteRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return EntryNoteRef;
	}

	#endregion
}

public class EntryNotePutModel
{
	public EntryNotePutModel()
	{ }

	public EntryNotePutModel(IEntryNote values)
	{
		EntryNoteRef = values.EntryNoteRef;
		Body = new EntryNotePostModel(values);
	}

	public virtual EntryNotePostModel Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int EntryNoteRef { get; set; }

	#region

	public override bool Equals(object obj)
	{
		if (obj is EntryNotePutModel item)
		{
			return item.EntryNoteRef == EntryNoteRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return EntryNoteRef;
	}

	#endregion
}

public class EntryNotePostModel
{
	public EntryNotePostModel()
	{ }

	public EntryNotePostModel(IEntryNote values)
	{
		if (values == null) return;
		Date = values.Date;
		Text = values.Text;
		UserRef = values.UserRef;
		EntryOccurrenceRef = values.EntryOccurrenceRef;
		EntryRef = values.EntryRef;
	}

	[Range(typeof(DateTime), "1/1/1775", "12/31/9999 11:59AM")]
	public DateTime Date { get; set; }

	public int? EntryOccurrenceRef { get; set; }

	public int EntryRef { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string Text { get; set; }

	public int UserRef { get; set; }

	public virtual EATTS.Common.Dto.EntryNoteDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.EntryNoteDto();
		createdItem.Date = Date;
		createdItem.Text = Text;
		createdItem.UserRef = UserRef;
		createdItem.EntryOccurrenceRef = EntryOccurrenceRef;
		createdItem.EntryRef = EntryRef;
		return createdItem;
	}
}