//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;
namespace EATTS.Common.Dto;

public class ApplicationOptionsDto : IApplicationOptions 
{
    public ApplicationOptionsDto(IApplicationOptions values)
    {
        values?.MapTo(this);
    }


    public ApplicationOptionsDto() {}

    public int CreatedBy { get; set; }

    [Range(typeof(DateTime),  "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime CreatedDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(512)]
    public string EntryEmail { get; set; }

    public int ApplicationOptionsRef { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(90)]
    public string ApplicationSlug { get; set; }

}