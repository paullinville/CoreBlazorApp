//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IEntryNote
{

    DateTime Date { get; set; }
    int EntryNoteRef { get; set; }
    string Text { get; set; }
    int UserRef { get; set; }
    int? EntryOccurrenceRef { get; set; }
    int EntryRef { get; set; }

    public static void Map(IEntryNote fromData, IEntryNote toData)
    {
        if (fromData == null || toData == null) return;
        toData.Date = fromData.Date;
        toData.EntryNoteRef = fromData.EntryNoteRef;
        toData.Text = fromData.Text;
        toData.UserRef = fromData.UserRef;
        toData.EntryOccurrenceRef = fromData.EntryOccurrenceRef;
        toData.EntryRef = fromData.EntryRef;
    }

    public void MapTo(IEntryNote toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IEntryNote fromData)
    {
        Map(fromData, this);
    }

    public void Update(IEntryNote fromData)
    {
        var currentRef = this.EntryNoteRef;
        Map(fromData, this);
        this.EntryNoteRef = currentRef;
    }

}