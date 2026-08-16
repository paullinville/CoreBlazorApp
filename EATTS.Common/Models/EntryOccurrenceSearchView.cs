using System.ComponentModel.DataAnnotations;
using System;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Models;

public class EntryOccurrenceSearchView : IEntryOccurrenceSearch
{
	public EntryOccurrenceSearchView()
	{ }

	public EntryOccurrenceSearchView(IEntryOccurrenceSearch values)
	{
		values?.MapTo(this);
	}

	public int EntryErrorTypeRef { get; set; }

	[Required]
	[StringLength(512)]
	public string EntryGenericDescription { get; set; }

	[Required]
	[StringLength(1024)]
	public string EntryKey { get; set; }

	[Required]
	[StringLength(50)]
	public string EntryOccurrenceCallerId { get; set; }

	public int EntryOccurrenceCount { get; set; }

	public DateTime EntryOccurrenceDate { get; set; }

	[Required]
	[StringLength(512)]
	public string EntryOccurrenceDescription { get; set; }

	[Required]
	[StringLength(1024)]
	public string EntryOccurrenceEmailsSent { get; set; }

	[Required]
	[StringLength(2147483647)]
	public string EntryOccurrenceErrorResponse { get; set; }

	[Required]
	[StringLength(100)]
	public string EntryOccurrenceOrigin { get; set; }

	public int EntryOccurrenceRef { get; set; }

	public int EntryOccurrenceUserRef { get; set; }

	public int EntryRef { get; set; }

	[StringLength(50)]
	public string ErrorTypeDescription { get; set; }

	public bool? IsError { get; set; }

	public DateTime? LastEntryOccurrenceDate { get; set; }

	public int LastEntryOccurrenceRef { get; set; }

	public Guid RequestId { get; set; }

	[Required]
	[StringLength(256)]
	public string TokenSubject { get; set; }

	public int TokenSubjectType { get; set; }

	public EATTS.Common.Dto.EntryOccurrenceSearchDto CreateDto()
	{
		var createdItem = new EATTS.Common.Dto.EntryOccurrenceSearchDto();
		createdItem.EntryErrorTypeRef = EntryErrorTypeRef;
		createdItem.EntryGenericDescription = EntryGenericDescription;
		createdItem.EntryKey = EntryKey;
		createdItem.EntryOccurrenceCallerId = EntryOccurrenceCallerId;
		createdItem.EntryOccurrenceCount = EntryOccurrenceCount;
		createdItem.EntryOccurrenceDate = EntryOccurrenceDate;
		createdItem.EntryOccurrenceDescription = EntryOccurrenceDescription;
		createdItem.EntryOccurrenceEmailsSent = EntryOccurrenceEmailsSent;
		createdItem.EntryOccurrenceErrorResponse = EntryOccurrenceErrorResponse;
		createdItem.EntryOccurrenceOrigin = EntryOccurrenceOrigin;
		createdItem.EntryOccurrenceRef = EntryOccurrenceRef;
		createdItem.EntryOccurrenceUserRef = EntryOccurrenceUserRef;
		createdItem.EntryRef = EntryRef;
		createdItem.ErrorTypeDescription = ErrorTypeDescription;
		createdItem.IsError = IsError;
		createdItem.LastEntryOccurrenceDate = LastEntryOccurrenceDate;
		createdItem.LastEntryOccurrenceRef = LastEntryOccurrenceRef;
		createdItem.RequestId = RequestId;
		createdItem.TokenSubject = TokenSubject;
		createdItem.TokenSubjectType = TokenSubjectType;
		return createdItem;
	}
}