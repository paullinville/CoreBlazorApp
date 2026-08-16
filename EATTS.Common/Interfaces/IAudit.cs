//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IAudit
{

    DateTime CreateDate { get; set; }
    string Description { get; set; }
    string LookUpValue { get; set; }
    int AuditRef { get; set; }
    int? UserRef { get; set; }

    public static void Map(IAudit fromData, IAudit toData)
    {
        if (fromData == null || toData == null) return;
        toData.CreateDate = fromData.CreateDate;
        toData.Description = fromData.Description;
        toData.LookUpValue = fromData.LookUpValue;
        toData.AuditRef = fromData.AuditRef;
        toData.UserRef = fromData.UserRef;
    }

    public void MapTo(IAudit toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IAudit fromData)
    {
        Map(fromData, this);
    }

    public void Update(IAudit fromData)
    {
        var currentRef = this.AuditRef;
        Map(fromData, this);
        this.AuditRef = currentRef;
    }

}