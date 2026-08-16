//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IApplicationUserRole
{

    string ApplicationApiName { get; set; }
    DateTime? ApplicationCreateDate { get; set; }
    int? ApplicationCreateUserRef { get; set; }
    string ApplicationDescription { get; set; }
    Guid ApplicationGuid { get; set; }
    bool ApplicationIsActiveFlag { get; set; }
    string ApplicationName { get; set; }
    int ApplicationRef { get; set; }
    string ApplicationSlug { get; set; }
    DateTime HolderCreateDate { get; set; }
    string ApplicationVirtualDirectory { get; set; }
    int? ContextTypeRef { get; set; }
    DateTime RoleCreateDate { get; set; }
    int? RoleCreateUserRef { get; set; }
    string RoleDescription { get; set; }
    byte RoleIsActionGroupFlag { get; set; }
    bool RoleIsActiveFlag { get; set; }
    string RoleName { get; set; }
    int RoleRef { get; set; }
    DateTime? RoleUpdateDate { get; set; }
    int? RoleUpdateUserRef { get; set; }
    string UserFullName { get; set; }
    string UserLastNameFirst { get; set; }
    int? UserRef { get; set; }

    public static void Map(IApplicationUserRole fromData, IApplicationUserRole toData)
    {
        if (fromData == null || toData == null) return;
        toData.ApplicationApiName = fromData.ApplicationApiName;
        toData.ApplicationCreateDate = fromData.ApplicationCreateDate;
        toData.ApplicationCreateUserRef = fromData.ApplicationCreateUserRef;
        toData.ApplicationDescription = fromData.ApplicationDescription;
        toData.ApplicationGuid = fromData.ApplicationGuid;
        toData.ApplicationIsActiveFlag = fromData.ApplicationIsActiveFlag;
        toData.ApplicationName = fromData.ApplicationName;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.ApplicationSlug = fromData.ApplicationSlug;
        toData.HolderCreateDate = fromData.HolderCreateDate;
        toData.ApplicationVirtualDirectory = fromData.ApplicationVirtualDirectory;
        toData.ContextTypeRef = fromData.ContextTypeRef;
        toData.RoleCreateDate = fromData.RoleCreateDate;
        toData.RoleCreateUserRef = fromData.RoleCreateUserRef;
        toData.RoleDescription = fromData.RoleDescription;
        toData.RoleIsActionGroupFlag = fromData.RoleIsActionGroupFlag;
        toData.RoleIsActiveFlag = fromData.RoleIsActiveFlag;
        toData.RoleName = fromData.RoleName;
        toData.RoleRef = fromData.RoleRef;
        toData.RoleUpdateDate = fromData.RoleUpdateDate;
        toData.RoleUpdateUserRef = fromData.RoleUpdateUserRef;
        toData.UserFullName = fromData.UserFullName;
        toData.UserLastNameFirst = fromData.UserLastNameFirst;
        toData.UserRef = fromData.UserRef;
    }

    public void MapTo(IApplicationUserRole toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApplicationUserRole fromData)
    {
        Map(fromData, this);
    }

}