//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IEntrySearch
{

    string EntryDescription { get; set; }
    string EntryKey { get; set; }
    string EntryOccurrenceCallerId { get; set; }
    int EntryOccurrenceCount { get; set; }
    DateTime EntryOccurrenceDate { get; set; }
    string EntryOccurrenceDescription { get; set; }
    string EntryOccurrenceEmailsSent { get; set; }
    string EntryOccurrenceErrorResponse { get; set; }
    string EntryOccurrenceOrigin { get; set; }
    int EntryOccurrenceRef { get; set; }
    int EntryOccurrenceUserRef { get; set; }
    int EntryRef { get; set; }
    bool? IsError { get; set; }
    DateTime? LastEntryOccurrenceDate { get; set; }
    int LastEntryOccurrenceRef { get; set; }
    Guid RequestId { get; set; }
    string TokenSubject { get; set; }
    int TokenSubjectType { get; set; }

    public static void Map(IEntrySearch fromData, IEntrySearch toData)
    {
        if (fromData == null || toData == null) return;
        toData.EntryDescription = fromData.EntryDescription;
        toData.EntryKey = fromData.EntryKey;
        toData.EntryOccurrenceCallerId = fromData.EntryOccurrenceCallerId;
        toData.EntryOccurrenceCount = fromData.EntryOccurrenceCount;
        toData.EntryOccurrenceDate = fromData.EntryOccurrenceDate;
        toData.EntryOccurrenceDescription = fromData.EntryOccurrenceDescription;
        toData.EntryOccurrenceEmailsSent = fromData.EntryOccurrenceEmailsSent;
        toData.EntryOccurrenceErrorResponse = fromData.EntryOccurrenceErrorResponse;
        toData.EntryOccurrenceOrigin = fromData.EntryOccurrenceOrigin;
        toData.EntryOccurrenceRef = fromData.EntryOccurrenceRef;
        toData.EntryOccurrenceUserRef = fromData.EntryOccurrenceUserRef;
        toData.EntryRef = fromData.EntryRef;
        toData.IsError = fromData.IsError;
        toData.LastEntryOccurrenceDate = fromData.LastEntryOccurrenceDate;
        toData.LastEntryOccurrenceRef = fromData.LastEntryOccurrenceRef;
        toData.RequestId = fromData.RequestId;
        toData.TokenSubject = fromData.TokenSubject;
        toData.TokenSubjectType = fromData.TokenSubjectType;
    }

    public void MapTo(IEntrySearch toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IEntrySearch fromData)
    {
        Map(fromData, this);
    }

}