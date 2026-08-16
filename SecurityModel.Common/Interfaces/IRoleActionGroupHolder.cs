//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
public interface IRoleActionGroupHolder
{

    int ActionGroupRef { get; set; }
    DateTime CreateDate { get; set; }
    int RoleActionGroupHolderRef { get; set; }
    int RoleRef { get; set; }

    public static void Map(IRoleActionGroupHolder fromData, IRoleActionGroupHolder toData)
    {
        if (fromData == null || toData == null) return;
        toData.ActionGroupRef = fromData.ActionGroupRef;
        toData.CreateDate = fromData.CreateDate;
        toData.RoleActionGroupHolderRef = fromData.RoleActionGroupHolderRef;
        toData.RoleRef = fromData.RoleRef;
    }

    public void MapTo(IRoleActionGroupHolder toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IRoleActionGroupHolder fromData)
    {
        Map(fromData, this);
    }

    public void Update(IRoleActionGroupHolder fromData)
    {
        var currentRef = this.RoleActionGroupHolderRef;
        Map(fromData, this);
        this.RoleActionGroupHolderRef = currentRef;
    }

}