//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class EntrySearchDto : Interfaces.IEntrySearch 
{
    public EntrySearchDto(Interfaces.IEntrySearch values)
    {
        values?.MapTo(this);
    }

    public EntrySearchDto()
    { }

    [Required(AllowEmptyStrings = true)]
    [StringLength(512)]
    public string EntryDescription { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(1024)]
    public string EntryKey { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string EntryOccurrenceCallerId { get; set; }

    public int EntryOccurrenceCount { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime EntryOccurrenceDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(512)]
    public string EntryOccurrenceDescription { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(1024)]
    public string EntryOccurrenceEmailsSent { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2147483647)]
    public string EntryOccurrenceErrorResponse { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(100)]
    public string EntryOccurrenceOrigin { get; set; }

    public int EntryOccurrenceRef { get; set; }

    public int EntryOccurrenceUserRef { get; set; }

    public int EntryRef { get; set; }

    public bool? IsError { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime? LastEntryOccurrenceDate { get; set; }

    public int LastEntryOccurrenceRef { get; set; }

    public Guid RequestId { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(256)]
    public string TokenSubject { get; set; }

    public int TokenSubjectType { get; set; }

}