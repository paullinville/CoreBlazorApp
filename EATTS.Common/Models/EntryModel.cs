using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class EntryDeleteModel
{
	public virtual int EntryRef { get; set; }
}

public class EntryGetModel : EntryPostModel
{
	public EntryGetModel()
	{ }

	public EntryGetModel(IEntry values) : base(values)
	{
		EntryRef = values.EntryRef;
	}

	public int EntryRef { get; set; }

	public override EATTS.Common.Dto.EntryDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.EntryDto();
		createdItem.ErrorTypeRef = ErrorTypeRef;
		createdItem.GenericDescription = GenericDescription;
		createdItem.Key = Key;
		createdItem.OccurrenceCount = OccurrenceCount;
		createdItem.EntryRef = EntryRef;
		createdItem.LastEntryOccurrenceDate = LastEntryOccurrenceDate;
		createdItem.LastEntryOccurrenceRef = LastEntryOccurrenceRef;
		return createdItem;
	}

	#region

	public override bool Equals(object obj)
	{
		if (obj is EntryGetModel item)
		{
			return item.EntryRef == EntryRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return EntryRef;
	}

	#endregion
}

public class EntryPutModel
{
	public EntryPutModel()
	{ }

	public EntryPutModel(IEntry values)
	{
		EntryRef = values.EntryRef;
		Body = new EntryPostModel(values);
	}

	public virtual EntryPostModel Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int EntryRef { get; set; }

	#region

	public override bool Equals(object obj)
	{
		if (obj is EntryPutModel item)
		{
			return item.EntryRef == EntryRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return EntryRef;
	}

	#endregion
}

public class EntryPostModel
{
	public EntryPostModel()
	{ }

	public EntryPostModel(IEntry values)
	{
		if (values == null) return;
		ErrorTypeRef = values.ErrorTypeRef;
		GenericDescription = values.GenericDescription;
		Key = values.Key;
		OccurrenceCount = values.OccurrenceCount;
		LastEntryOccurrenceDate = values.LastEntryOccurrenceDate;
		LastEntryOccurrenceRef = values.LastEntryOccurrenceRef;
	}

	public int ErrorTypeRef { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(512)]
	public string GenericDescription { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(1024)]
	public string Key { get; set; }

	[Range(typeof(DateTime), "1/1/1775", "12/31/9999 11:59AM")]
	public DateTime? LastEntryOccurrenceDate { get; set; }

	public int LastEntryOccurrenceRef { get; set; }

	public int OccurrenceCount { get; set; }

	public virtual EATTS.Common.Dto.EntryDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.EntryDto();
		createdItem.ErrorTypeRef = ErrorTypeRef;
		createdItem.GenericDescription = GenericDescription;
		createdItem.Key = Key;
		createdItem.OccurrenceCount = OccurrenceCount;
		createdItem.LastEntryOccurrenceDate = LastEntryOccurrenceDate;
		createdItem.LastEntryOccurrenceRef = LastEntryOccurrenceRef;
		return createdItem;
	}
}