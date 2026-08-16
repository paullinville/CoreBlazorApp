//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IActionGroup
{

    DateTime ActionCreateDate { get; set; }
    string Description { get; set; }
    string Name { get; set; }
    int ActionGroupRef { get; set; }
    int ApplicationRef { get; set; }

    public static void Map(IActionGroup fromData, IActionGroup toData)
    {
        if (fromData == null || toData == null) return;
        toData.ActionCreateDate = fromData.ActionCreateDate;
        toData.Description = fromData.Description;
        toData.Name = fromData.Name;
        toData.ActionGroupRef = fromData.ActionGroupRef;
        toData.ApplicationRef = fromData.ApplicationRef;
    }

    public void MapTo(IActionGroup toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IActionGroup fromData)
    {
        Map(fromData, this);
    }

    public void Update(IActionGroup fromData)
    {
        var currentRef = this.ActionGroupRef;
        Map(fromData, this);
        this.ActionGroupRef = currentRef;
    }

}