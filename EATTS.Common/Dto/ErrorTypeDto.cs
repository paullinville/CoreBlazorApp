//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class ErrorTypeDto : IErrorType 
{
    public ErrorTypeDto(IErrorType values)
    {
        values?.MapTo(this);
    }

    public ErrorTypeDto()
    { }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime CreateDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string Description { get; set; }

    public int ErrorTypeRef { get; set; }

    public short IsActiveFlag { get; set; }

}