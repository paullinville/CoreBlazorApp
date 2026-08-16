//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class SupportOptionsOverrideDto : ISupportOptionsOverride 
{
    public SupportOptionsOverrideDto(ISupportOptionsOverride values)
    {
        values?.MapTo(this);
    }

    public SupportOptionsOverrideDto()
    { }

    public bool DoNotSendEmail { get; set; }

    public int EntryRef { get; set; }

    public int? FloodCount { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(512)]
    public string FloodEmail { get; set; }

    public int? FloodTime { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(512)]
    public string OtherEmail { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(1024)]
    public string Reason { get; set; }

    public int SupportOptionsOverrideRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime Updated { get; set; }

    public int UpdatedUserRef { get; set; }

}