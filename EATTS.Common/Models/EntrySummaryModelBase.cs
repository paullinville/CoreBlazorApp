using Newtonsoft.Json.Linq;
using System;

namespace EATTS.Common.Models;

public class EntrySummaryModelBase
{
	public EntrySummaryModelBase()
	{ }

	public EntrySummaryModelBase(Interfaces.IEntrySearch data)
	{
		CallerId = data.EntryOccurrenceCallerId;
		Description = data.EntryDescription;
		EntryOccurrenceRef = data.EntryOccurrenceRef;
		EntryRef = data.EntryRef;
		IsError = data.IsError;
		Key = data.EntryKey;
		LastEntryOccurrenceRef = data.LastEntryOccurrenceRef;
		LastOccurrenceDate = data.LastEntryOccurrenceDate ?? DateTime.Now;
		OccurrenceCount = data.EntryOccurrenceCount;
		OccurrenceDate = data.EntryOccurrenceDate;
		OccurrenceDescription = data.EntryOccurrenceDescription;
		Origin = data.EntryOccurrenceOrigin;
		RequestId = data.RequestId;
		Subject = data.TokenSubject;
		SubjectType = ((TokenSubjectType)data.TokenSubjectType).ToString();
		UserRef = data.EntryOccurrenceUserRef;
	}

	public EntrySummaryModelBase(Interfaces.IEntryOccurrenceSearch data)
	{
		CallerId = data.EntryOccurrenceCallerId;
		Description = data.EntryGenericDescription;
		EntryOccurrenceRef = data.EntryOccurrenceRef;
		EntryRef = data.EntryRef;
		ErrorType = data.ErrorTypeDescription;
		IsError = data.IsError;
		Key = data.EntryKey;
		LastEntryOccurrenceRef = data.LastEntryOccurrenceRef;
		LastOccurrenceDate = data.LastEntryOccurrenceDate ?? DateTime.Now;
		OccurrenceCount = data.EntryOccurrenceCount;
		OccurrenceDate = data.EntryOccurrenceDate;
		OccurrenceDescription = data.EntryOccurrenceDescription;
		Origin = data.EntryOccurrenceOrigin;
		RequestId = data.RequestId;
		Subject = data.TokenSubject;
		SubjectType = ((TokenSubjectType)data.TokenSubjectType).ToString();
		UserRef = data.EntryOccurrenceUserRef;
	}

	public string CallerId { get; set; }
	public string Description { get; set; }
	public int EntryOccurrenceRef { get; set; }
	public int EntryRef { get; set; }
	public string ErrorType { get; set; }
	public bool? IsError { get; set; }
	public string Key { get; set; }
	public int LastEntryOccurrenceRef { get; set; }
	public DateTime LastOccurrenceDate { get; set; }
	public int OccurrenceCount { get; set; }
	public DateTime OccurrenceDate { get; set; }
	public string OccurrenceDescription { get; set; }
	public string Origin { get; set; }
	public Guid RequestId { get; set; }
	public string Subject { get; set; }
	public string SubjectType { get; set; }
	public int UserRef { get; set; }
}