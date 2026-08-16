//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class EntryOccurrenceDto : IEntryOccurrence 
{
    public EntryOccurrenceDto(IEntryOccurrence values)
    {
        values?.MapTo(this);
    }

    public EntryOccurrenceDto()
    { }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string CallerId { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime Date { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(512)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(1024)]
    public string EmailsSent { get; set; }

    public int EntryOccurrenceRef { get; set; }

    public int EntryRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2147483647)]
    public string ErrorResponse { get; set; }

    public bool? IsError { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(100)]
    public string Origin { get; set; }

    public Guid RequestId { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(256)]
    public string TokenSubject { get; set; }

    public int TokenSubjectType { get; set; }

    public int UserRef { get; set; }

}