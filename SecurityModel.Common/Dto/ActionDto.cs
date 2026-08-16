//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Dto;

public class ActionDto : IAction 
{
    public ActionDto(IAction values)
    {
        values?.MapTo(this);
    }

    public ActionDto()
    { }

    public int ActionRef { get; set; }

    public int ApplicationRef { get; set; }

    public int ContextTypeRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime CreateDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string Name { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserRef { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is IAction agh)
        {
            return agh.ActionRef == ActionRef;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ActionRef;
    }
}