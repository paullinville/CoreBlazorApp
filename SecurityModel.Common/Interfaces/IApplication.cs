//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IApplication
{

    string ApiName { get; set; }
    string ConnectionString { get; set; }
    string ConnectionString1 { get; set; }
    string ConnectionString2 { get; set; }
    DateTime? CreateDate { get; set; }
    int? CreateUserRef { get; set; }
    string Description { get; set; }
    string EmailFrom { get; set; }
    Guid Guid { get; set; }
    bool IsActiveFlag { get; set; }
    int IsLoadedFlag { get; set; }
    string Name { get; set; }
    int ApplicationRef { get; set; }
    string Slug { get; set; }
    int TypeRef { get; set; }
    string VirtualDirectory { get; set; }

    public static void Map(IApplication fromData, IApplication toData)
    {
        if (fromData == null || toData == null) return;
        toData.ApiName = fromData.ApiName;
        toData.ConnectionString = fromData.ConnectionString;
        toData.ConnectionString1 = fromData.ConnectionString1;
        toData.ConnectionString2 = fromData.ConnectionString2;
        toData.CreateDate = fromData.CreateDate;
        toData.CreateUserRef = fromData.CreateUserRef;
        toData.Description = fromData.Description;
        toData.EmailFrom = fromData.EmailFrom;
        toData.Guid = fromData.Guid;
        toData.IsActiveFlag = fromData.IsActiveFlag;
        toData.IsLoadedFlag = fromData.IsLoadedFlag;
        toData.Name = fromData.Name;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.Slug = fromData.Slug;
        toData.TypeRef = fromData.TypeRef;
        toData.VirtualDirectory = fromData.VirtualDirectory;
    }

    public void MapTo(IApplication toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApplication fromData)
    {
        Map(fromData, this);
    }

    public void Update(IApplication fromData)
    {
        var currentRef = this.ApplicationRef;
        Map(fromData, this);
        this.ApplicationRef = currentRef;
    }

}