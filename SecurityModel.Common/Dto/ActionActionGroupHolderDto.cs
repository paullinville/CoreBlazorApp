//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Dto;

public class ActionActionGroupHolderDto : IActionActionGroupHolder 
{
    public ActionActionGroupHolderDto(IActionActionGroupHolder values)
    {
        values?.MapTo(this);
    }

    public ActionActionGroupHolderDto()
    { }

    public int ActionActionGroupHolderRef { get; set; }

    public int ActionGroupRef { get; set; }

    public int ActionRef { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime CreateDate { get; set; }

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