//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IApplicationUserRoleAction
{

    DateTime ActionCreateDate { get; set; }
    string ActionDescription { get; set; }
    string ActionName { get; set; }
    int ActionRef { get; set; }
    string ApplicationApiName { get; set; }
    DateTime? ApplicationCreateDate { get; set; }
    int? ApplicationCreateUserRef { get; set; }
    string ApplicationDescription { get; set; }
    Guid ApplicationGuid { get; set; }
    bool ApplicationIsActiveFlag { get; set; }
    int ApplicationIsLoadedFlag { get; set; }
    string ApplicationName { get; set; }
    int ApplicationRef { get; set; }
    string ApplicationSlug { get; set; }
    DateTime ApplicationUserRoleHolderCreateDate { get; set; }
    string ApplicationVirtualDirectory { get; set; }
    int? ContextTypeRef { get; set; }
    DateTime RoleCreateDate { get; set; }
    int? RoleCreateUserRef { get; set; }
    string RoleDescription { get; set; }
    bool RoleIsActiveFlag { get; set; }
    string RoleName { get; set; }
    int RoleRef { get; set; }
    DateTime? RoleUpdateDate { get; set; }
    int? RoleUpdateUserRef { get; set; }
    string UserFullName { get; set; }
    int UserRef { get; set; }
    char? UserStatus { get; set; }

    public static void Map(IApplicationUserRoleAction fromData, IApplicationUserRoleAction toData)
    {
        if (fromData == null || toData == null) return;
        toData.ActionCreateDate = fromData.ActionCreateDate;
        toData.ActionDescription = fromData.ActionDescription;
        toData.ActionName = fromData.ActionName;
        toData.ActionRef = fromData.ActionRef;
        toData.ApplicationApiName = fromData.ApplicationApiName;
        toData.ApplicationCreateDate = fromData.ApplicationCreateDate;
        toData.ApplicationCreateUserRef = fromData.ApplicationCreateUserRef;
        toData.ApplicationDescription = fromData.ApplicationDescription;
        toData.ApplicationGuid = fromData.ApplicationGuid;
        toData.ApplicationIsActiveFlag = fromData.ApplicationIsActiveFlag;
        toData.ApplicationIsLoadedFlag = fromData.ApplicationIsLoadedFlag;
        toData.ApplicationName = fromData.ApplicationName;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.ApplicationSlug = fromData.ApplicationSlug;
        toData.ApplicationUserRoleHolderCreateDate = fromData.ApplicationUserRoleHolderCreateDate;
        toData.ApplicationVirtualDirectory = fromData.ApplicationVirtualDirectory;
        toData.ContextTypeRef = fromData.ContextTypeRef;
        toData.RoleCreateDate = fromData.RoleCreateDate;
        toData.RoleCreateUserRef = fromData.RoleCreateUserRef;
        toData.RoleDescription = fromData.RoleDescription;
        toData.RoleIsActiveFlag = fromData.RoleIsActiveFlag;
        toData.RoleName = fromData.RoleName;
        toData.RoleRef = fromData.RoleRef;
        toData.RoleUpdateDate = fromData.RoleUpdateDate;
        toData.RoleUpdateUserRef = fromData.RoleUpdateUserRef;
        toData.UserFullName = fromData.UserFullName;
        toData.UserRef = fromData.UserRef;
        toData.UserStatus = fromData.UserStatus;
    }

    public void MapTo(IApplicationUserRoleAction toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApplicationUserRoleAction fromData)
    {
        Map(fromData, this);
    }

}