//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IAction
{

    DateTime CreateDate { get; set; }
    string Description { get; set; }
    string Name { get; set; }
    int ActionRef { get; set; }
    DateTime? UpdateDate { get; set; }
    int? UpdateUserRef { get; set; }
    int ApplicationRef { get; set; }
    int ContextTypeRef { get; set; }

    public static void Map(IAction fromData, IAction toData)
    {
        if (fromData == null || toData == null) return;
        toData.CreateDate = fromData.CreateDate;
        toData.Description = fromData.Description;
        toData.Name = fromData.Name;
        toData.ActionRef = fromData.ActionRef;
        toData.UpdateDate = fromData.UpdateDate;
        toData.UpdateUserRef = fromData.UpdateUserRef;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.ContextTypeRef = fromData.ContextTypeRef;
    }

    public void MapTo(IAction toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IAction fromData)
    {
        Map(fromData, this);
    }

    public void Update(IAction fromData)
    {
        var currentRef = this.ActionRef;
        Map(fromData, this);
        this.ActionRef = currentRef;
    }

}