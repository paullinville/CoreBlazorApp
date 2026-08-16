using System;
using System.Collections.Generic;

namespace EATTS.Common.Models;

public class EntryOccurrenceDetailModel : OccurrenceDetailModel
{
	public EntryOccurrenceDetailModel()
	{ }

	public EntryOccurrenceDetailModel(IEntry entry, IEntryOccurrence values, List<ApiLogDataModel> logs) : base(values)
	{
		if (values == null) return;
		EntryRef = values.EntryRef;
		GenericDescription = entry.GenericDescription + "";
		Key = entry.Key + "";
		OccurrenceCount = entry.OccurrenceCount;
		LastEntryOccurrenceRef = entry.LastEntryOccurrenceRef;
		ApiLogData = logs;
		TokenSubject = values.TokenSubject;
		TokenType = ((TokenSubjectType)values.TokenSubjectType).ToString();
		if (((TokenSubjectType)values.TokenSubjectType) == TokenSubjectType.Api)
		{
			ApiSlug = TokenSubject;
		}
		Error = values.IsError;
	}

	public List<ApiLogDataModel> ApiLogData { get; set; }
	public string ApiSlug { get; set; }
	public int EntryRef { get; set; }
	public bool? Error { get; set; }
	public ErrorTypeCode ErrorTypeCode { get; set; }
	public string GenericDescription { get; set; }
	public string Key { get; set; }
	public int LastEntryOccurrenceRef { get; set; }
	public int OccurrenceCount { get; set; }
	public string TokenSubject { get; set; }
	public string TokenType { get; set; }
}