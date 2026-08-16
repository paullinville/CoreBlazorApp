//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class EntryNoteDto : IEntryNote 
{
    public EntryNoteDto(IEntryNote values)
    {
        values?.MapTo(this);
    }

    public EntryNoteDto()
    { }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime Date { get; set; }

    public int EntryNoteRef { get; set; }

    public int? EntryOccurrenceRef { get; set; }

    public int EntryRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2147483647)]
    public string Text { get; set; }

    public int UserRef { get; set; }

}