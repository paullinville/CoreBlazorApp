//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class SupportOptionsDto : ISupportOptions 
{
    public SupportOptionsDto(ISupportOptions values)
    {
        values?.MapTo(this);
    }

    public SupportOptionsDto()
    { }

    [Required(AllowEmptyStrings = true)]
    [StringLength(256)]
    public string EmailSubject { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2147483647)]
    public string EmailTemplate { get; set; }

    public int FloodCount { get; set; }

    public int FloodTime { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(512)]
    public string OtherEmail { get; set; }

    public int SupportOptionsRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime Updated { get; set; }

    public int UpdatedUserRef { get; set; }

}