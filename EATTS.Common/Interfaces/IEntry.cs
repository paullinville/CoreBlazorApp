//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IEntry
{

    int ErrorTypeRef { get; set; }
    string GenericDescription { get; set; }
    string Key { get; set; }
    int OccurrenceCount { get; set; }
    int EntryRef { get; set; }
    DateTime? LastEntryOccurrenceDate { get; set; }
    int LastEntryOccurrenceRef { get; set; }

    public static void Map(IEntry fromData, IEntry toData)
    {
        if (fromData == null || toData == null) return;
        toData.ErrorTypeRef = fromData.ErrorTypeRef;
        toData.GenericDescription = fromData.GenericDescription;
        toData.Key = fromData.Key;
        toData.OccurrenceCount = fromData.OccurrenceCount;
        toData.EntryRef = fromData.EntryRef;
        toData.LastEntryOccurrenceDate = fromData.LastEntryOccurrenceDate;
        toData.LastEntryOccurrenceRef = fromData.LastEntryOccurrenceRef;
    }

    public void MapTo(IEntry toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IEntry fromData)
    {
        Map(fromData, this);
    }

    public void Update(IEntry fromData)
    {
        var currentRef = this.EntryRef;
        Map(fromData, this);
        this.EntryRef = currentRef;
    }

}