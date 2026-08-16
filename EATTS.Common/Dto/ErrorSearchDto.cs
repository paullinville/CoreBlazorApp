//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class ErrorSearchDto : IErrorSearch 
{
    public ErrorSearchDto(IErrorSearch values)
    {
        values?.MapTo(this);
    }

    public ErrorSearchDto()
    { }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string ApplicationDescription { get; set; }

    public int? ApplicationRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(250)]
    public string ApplicationVirtualDirectory { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(6000)]
    public string ErrorAdditionalDescription { get; set; }

    public int? ErrorCategoryRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime? ErrorCloseDate { get; set; }

    public int? ErrorCount { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime ErrorCreateDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2000)]
    public string ErrorDescription { get; set; }

    [StringLength(50)]
    public string ErrorErrorNumber { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2000)]
    public string ErrorImportanceAdditionalDescription { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(250)]
    public string ErrorImportanceDescription { get; set; }

    public short ErrorImportanceIsActiveFlag { get; set; }

    public int? ErrorImportanceRef { get; set; }

    public int? ErrorInputUserRef { get; set; }

    public short ErrorIsActiveFlag { get; set; }

    public short ErrorIsStrikeFlag { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(200)]
    public string ErrorPage { get; set; }

    public int? ErrorPrimaryContactUserRef { get; set; }

    public int ErrorRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2000)]
    public string ErrorResolutionDescription { get; set; }

    public int? ErrorSecondaryContactUserRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2000)]
    public string ErrorStatusAdditionalDescription { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string ErrorStatusDescription { get; set; }

    public short ErrorStatusIsActiveFlag { get; set; }

    public int? ErrorStatusRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string ErrorTypeDescription { get; set; }

    public short ErrorTypeIsActiveFlag { get; set; }

    public int? ErrorTypeRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime? LastOccurenceDate { get; set; }

}