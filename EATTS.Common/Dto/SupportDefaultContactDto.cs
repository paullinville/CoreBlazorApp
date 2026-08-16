//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class SupportDefaultContactDto : ISupportDefaultContact 
{
    public SupportDefaultContactDto(ISupportDefaultContact values)
    {
        values?.MapTo(this);
    }

    public SupportDefaultContactDto()
    { }

    public bool Active { get; set; }

    public int Order { get; set; }

    public int SupportDefaultContactRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime Updated { get; set; }

    public int UpdatedUserRef { get; set; }

    public int UserRef { get; set; }

}