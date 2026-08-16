//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class AuditDto : IAudit 
{
    public AuditDto(IAudit values)
    {
        values?.MapTo(this);
    }

    public AuditDto()
    { }

    public int AuditRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime CreateDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(1000)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(100)]
    public string LookUpValue { get; set; }

    public int? UserRef { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is IAudit agh)
        {
            return agh.AuditRef == AuditRef ;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return $"Audit{AuditRef}".GetHashCode();
    }

}