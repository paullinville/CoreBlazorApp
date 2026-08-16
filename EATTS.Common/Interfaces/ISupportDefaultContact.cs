//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface ISupportDefaultContact
{

    bool Active { get; set; }
    int Order { get; set; }
    int SupportDefaultContactRef { get; set; }
    DateTime Updated { get; set; }
    int UpdatedUserRef { get; set; }
    int UserRef { get; set; }

    public static void Map(ISupportDefaultContact fromData, ISupportDefaultContact toData)
    {
        if (fromData == null || toData == null) return;
        toData.Active = fromData.Active;
        toData.Order = fromData.Order;
        toData.SupportDefaultContactRef = fromData.SupportDefaultContactRef;
        toData.Updated = fromData.Updated;
        toData.UpdatedUserRef = fromData.UpdatedUserRef;
        toData.UserRef = fromData.UserRef;
    }

    public void MapTo(ISupportDefaultContact toData)
    {
        Map(this, toData);
    }

    public void MapFrom(ISupportDefaultContact fromData)
    {
        Map(fromData, this);
    }

    public void Update(ISupportDefaultContact fromData)
    {
        var currentRef = this.SupportDefaultContactRef;
        Map(fromData, this);
        this.SupportDefaultContactRef = currentRef;
    }

}