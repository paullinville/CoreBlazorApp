//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IApplicationAction
{

    DateTime ActionCreateDate { get; set; }
    string ActionDescription { get; set; }
    string ActionName { get; set; }
    int ActionRef { get; set; }
    string ApplicationApiName { get; set; }
    string ApplicationDescription { get; set; }
    Guid ApplicationGuid { get; set; }
    bool ApplicationIsActiveFlag { get; set; }
    string ApplicationName { get; set; }
    int ApplicationRef { get; set; }
    string ApplicationSlug { get; set; }
    string ApplicationVirtualDirectory { get; set; }

    public static void Map(IApplicationAction fromData, IApplicationAction toData)
    {
        if (fromData == null || toData == null) return;
        toData.ActionCreateDate = fromData.ActionCreateDate;
        toData.ActionDescription = fromData.ActionDescription;
        toData.ActionName = fromData.ActionName;
        toData.ActionRef = fromData.ActionRef;
        toData.ApplicationApiName = fromData.ApplicationApiName;
        toData.ApplicationDescription = fromData.ApplicationDescription;
        toData.ApplicationGuid = fromData.ApplicationGuid;
        toData.ApplicationIsActiveFlag = fromData.ApplicationIsActiveFlag;
        toData.ApplicationName = fromData.ApplicationName;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.ApplicationSlug = fromData.ApplicationSlug;
        toData.ApplicationVirtualDirectory = fromData.ApplicationVirtualDirectory;
    }

    public void MapTo(IApplicationAction toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApplicationAction fromData)
    {
        Map(fromData, this);
    }

}