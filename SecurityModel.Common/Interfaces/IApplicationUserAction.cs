//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IApplicationUserAction
{

    string ActionName { get; set; }
    int ActionRef { get; set; }
    string ApplicationApiName { get; set; }
    Guid ApplicationGuid { get; set; }
    bool ApplicationIsActiveFlag { get; set; }
    string ApplicationName { get; set; }
    int ApplicationRef { get; set; }
    string ApplicationSlug { get; set; }
    string ApplicationVirtualDirectory { get; set; }
    string UserFullName { get; set; }
    int UserRef { get; set; }

    public static void Map(IApplicationUserAction fromData, IApplicationUserAction toData)
    {
        if (fromData == null || toData == null) return;
        toData.ActionName = fromData.ActionName;
        toData.ActionRef = fromData.ActionRef;
        toData.ApplicationApiName = fromData.ApplicationApiName;
        toData.ApplicationGuid = fromData.ApplicationGuid;
        toData.ApplicationIsActiveFlag = fromData.ApplicationIsActiveFlag;
        toData.ApplicationName = fromData.ApplicationName;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.ApplicationSlug = fromData.ApplicationSlug;
        toData.ApplicationVirtualDirectory = fromData.ApplicationVirtualDirectory;
        toData.UserFullName = fromData.UserFullName;
        toData.UserRef = fromData.UserRef;
    }

    public void MapTo(IApplicationUserAction toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApplicationUserAction fromData)
    {
        Map(fromData, this);
    }

}