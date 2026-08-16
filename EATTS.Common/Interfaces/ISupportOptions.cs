//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface ISupportOptions
{

    string EmailSubject { get; set; }
    string EmailTemplate { get; set; }
    int FloodCount { get; set; }
    int FloodTime { get; set; }
    string OtherEmail { get; set; }
    int SupportOptionsRef { get; set; }
    DateTime Updated { get; set; }
    int UpdatedUserRef { get; set; }

    public static void Map(ISupportOptions fromData, ISupportOptions toData)
    {
        if (fromData == null || toData == null) return;
        toData.EmailSubject = fromData.EmailSubject;
        toData.EmailTemplate = fromData.EmailTemplate;
        toData.FloodCount = fromData.FloodCount;
        toData.FloodTime = fromData.FloodTime;
        toData.OtherEmail = fromData.OtherEmail;
        toData.SupportOptionsRef = fromData.SupportOptionsRef;
        toData.Updated = fromData.Updated;
        toData.UpdatedUserRef = fromData.UpdatedUserRef;
    }

    public void MapTo(ISupportOptions toData)
    {
        Map(this, toData);
    }

    public void MapFrom(ISupportOptions fromData)
    {
        Map(fromData, this);
    }

    public void Update(ISupportOptions fromData)
    {
        var currentRef = this.SupportOptionsRef;
        Map(fromData, this);
        this.SupportOptionsRef = currentRef;
    }

}