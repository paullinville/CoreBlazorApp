using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class EntryOccurrenceDeleteModel
{
	public virtual int EntryOccurrenceRef { get; set; }
}

public class EntryOccurrenceGetModel : EntryOccurrencePostModel
{
	public EntryOccurrenceGetModel()
	{ }

	public EntryOccurrenceGetModel(IEntryOccurrence values) : base(values)
	{
		EntryOccurrenceRef = values.EntryOccurrenceRef;
	}

	public int EntryOccurrenceRef { get; set; }

	public override EATTS.Common.Dto.EntryOccurrenceDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.EntryOccurrenceDto();
		createdItem.CallerId = CallerId;
		createdItem.Date = Date;
		createdItem.Description = Description;
		createdItem.EmailsSent = EmailsSent;
		createdItem.ErrorResponse = ErrorResponse;
		createdItem.Origin = Origin;
		createdItem.EntryOccurrenceRef = EntryOccurrenceRef;
		createdItem.UserRef = UserRef;
		createdItem.EntryRef = EntryRef;
		return createdItem;
	}
}

public class EntryOccurrencePutModel
{
	public EntryOccurrencePutModel()
	{ }

	public EntryOccurrencePutModel(IEntryOccurrence values)
	{
		EntryOccurrenceRef = values.EntryOccurrenceRef;
		Body = new EntryOccurrencePostModel(values);
	}

	public virtual EntryOccurrencePostModel Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int EntryOccurrenceRef { get; set; }
}

public class EntryOccurrencePostModel
{
	public EntryOccurrencePostModel()
	{ }

	public EntryOccurrencePostModel(IEntryOccurrence values)
	{
		if (values == null) return;
		CallerId = values.CallerId;
		Date = values.Date;
		Description = values.Description;
		EmailsSent = values.EmailsSent;
		ErrorResponse = values.ErrorResponse;
		Origin = values.Origin;
		UserRef = values.UserRef;
		EntryRef = values.EntryRef;
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(50)]
	public string CallerId { get; set; }

	[Range(typeof(DateTime), "1/1/1775", "12/31/9999 11:59AM")]
	public DateTime Date { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(512)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(1024)]
	public string EmailsSent { get; set; }

	public int EntryRef { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string ErrorResponse { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(100)]
	public string Origin { get; set; }

	public int UserRef { get; set; }

	public virtual EATTS.Common.Dto.EntryOccurrenceDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.EntryOccurrenceDto();
		createdItem.CallerId = CallerId;
		createdItem.Date = Date;
		createdItem.Description = Description;
		createdItem.EmailsSent = EmailsSent;
		createdItem.ErrorResponse = ErrorResponse;
		createdItem.Origin = Origin;
		createdItem.UserRef = UserRef;
		createdItem.EntryRef = EntryRef;
		return createdItem;
	}
}