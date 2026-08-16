//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IEntryOccurrence
{

    string CallerId { get; set; }
    DateTime Date { get; set; }
    string Description { get; set; }
    string EmailsSent { get; set; }
    string ErrorResponse { get; set; }
    bool? IsError { get; set; }
    string Origin { get; set; }
    int EntryOccurrenceRef { get; set; }
    string TokenSubject { get; set; }
    int TokenSubjectType { get; set; }
    int UserRef { get; set; }
    int EntryRef { get; set; }
    Guid RequestId { get; set; }

    public static void Map(IEntryOccurrence fromData, IEntryOccurrence toData)
    {
        if (fromData == null || toData == null) return;
        toData.CallerId = fromData.CallerId;
        toData.Date = fromData.Date;
        toData.Description = fromData.Description;
        toData.EmailsSent = fromData.EmailsSent;
        toData.ErrorResponse = fromData.ErrorResponse;
        toData.IsError = fromData.IsError;
        toData.Origin = fromData.Origin;
        toData.EntryOccurrenceRef = fromData.EntryOccurrenceRef;
        toData.TokenSubject = fromData.TokenSubject;
        toData.TokenSubjectType = fromData.TokenSubjectType;
        toData.UserRef = fromData.UserRef;
        toData.EntryRef = fromData.EntryRef;
        toData.RequestId = fromData.RequestId;
    }

    public void MapTo(IEntryOccurrence toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IEntryOccurrence fromData)
    {
        Map(fromData, this);
    }

    public void Update(IEntryOccurrence fromData)
    {
        var currentRef = this.EntryOccurrenceRef;
        Map(fromData, this);
        this.EntryOccurrenceRef = currentRef;
    }

}