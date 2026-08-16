//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using SecurityModel.Common.Interfaces;
namespace SecurityModel.Common.Dto;

public class ApiTokenDto : IApiToken 
{
    public ApiTokenDto(IApiToken values)
    {
        values?.MapTo(this);
    }


    public ApiTokenDto() {}

    public bool Active { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2147483647)]
    public string Body { get; set; }

    public int ApiTokenRef { get; set; }

    public int ApplicationRef { get; set; }

}