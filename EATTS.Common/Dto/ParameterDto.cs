//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;
namespace EATTS.Common.Dto;

public class ParameterDto : IParameter 
{
    public ParameterDto(IParameter values)
    {
        values?.MapTo(this);
    }


    public ParameterDto() {}

    [Range(typeof(DateTime),  "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime CreateDate { get; set; }

    public int CreateUserRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string DataType { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(1000)]
    public string Description { get; set; }

    public bool Encrypted { get; set; }

    public bool IsDropDownList { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(100)]
    public string Name { get; set; }

    public int ParameterRef { get; set; }

    public bool System { get; set; }

    [Range(typeof(DateTime),  "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime UpdateDate { get; set; }

    public int UpdateUserRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2147483647)]
    public string Value { get; set; }

}