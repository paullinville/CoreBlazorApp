//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IApplicationRoleAction
{

    string ActionDescription { get; set; }
    string ActionName { get; set; }
    int ActionRef { get; set; }
    string ApplicationApiName { get; set; }
    string ApplicationDescription { get; set; }
    Guid ApplicationGuid { get; set; }
    string ApplicationName { get; set; }
    int ApplicationRef { get; set; }
    string ApplicationSlug { get; set; }
    string ApplicationVirtualDirectory { get; set; }
    string RoleDescription { get; set; }
    bool RoleIsActiveFlag { get; set; }
    string RoleName { get; set; }
    int RoleRef { get; set; }

    public static void Map(IApplicationRoleAction fromData, IApplicationRoleAction toData)
    {
        if (fromData == null || toData == null) return;
        toData.ActionDescription = fromData.ActionDescription;
        toData.ActionName = fromData.ActionName;
        toData.ActionRef = fromData.ActionRef;
        toData.ApplicationApiName = fromData.ApplicationApiName;
        toData.ApplicationDescription = fromData.ApplicationDescription;
        toData.ApplicationGuid = fromData.ApplicationGuid;
        toData.ApplicationName = fromData.ApplicationName;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.ApplicationSlug = fromData.ApplicationSlug;
        toData.ApplicationVirtualDirectory = fromData.ApplicationVirtualDirectory;
        toData.RoleDescription = fromData.RoleDescription;
        toData.RoleIsActiveFlag = fromData.RoleIsActiveFlag;
        toData.RoleName = fromData.RoleName;
        toData.RoleRef = fromData.RoleRef;
    }

    public void MapTo(IApplicationRoleAction toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApplicationRoleAction fromData)
    {
        Map(fromData, this);
    }

}