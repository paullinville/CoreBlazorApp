//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IActionActionGroupHolder
{

    DateTime CreateDate { get; set; }
    int ActionActionGroupHolderRef { get; set; }
    int ActionGroupRef { get; set; }
    int ActionRef { get; set; }

    public static void Map(IActionActionGroupHolder fromData, IActionActionGroupHolder toData)
    {
        if (fromData == null || toData == null) return;
        toData.CreateDate = fromData.CreateDate;
        toData.ActionActionGroupHolderRef = fromData.ActionActionGroupHolderRef;
        toData.ActionGroupRef = fromData.ActionGroupRef;
        toData.ActionRef = fromData.ActionRef;
    }

    public void MapTo(IActionActionGroupHolder toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IActionActionGroupHolder fromData)
    {
        Map(fromData, this);
    }

    public void Update(IActionActionGroupHolder fromData)
    {
        var currentRef = this.ActionActionGroupHolderRef;
        Map(fromData, this);
        this.ActionActionGroupHolderRef = currentRef;
    }

}