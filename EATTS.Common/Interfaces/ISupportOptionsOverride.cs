//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface ISupportOptionsOverride
{

    int EntryRef { get; set; }
    bool DoNotSendEmail { get; set; }
    int? FloodCount { get; set; }
    string FloodEmail { get; set; }
    int? FloodTime { get; set; }
    string OtherEmail { get; set; }
    string Reason { get; set; }
    int SupportOptionsOverrideRef { get; set; }
    DateTime Updated { get; set; }
    int UpdatedUserRef { get; set; }

    public static void Map(ISupportOptionsOverride fromData, ISupportOptionsOverride toData)
    {
        if (fromData == null || toData == null) return;
        toData.EntryRef = fromData.EntryRef;
        toData.DoNotSendEmail = fromData.DoNotSendEmail;
        toData.FloodCount = fromData.FloodCount;
        toData.FloodEmail = fromData.FloodEmail;
        toData.FloodTime = fromData.FloodTime;
        toData.OtherEmail = fromData.OtherEmail;
        toData.Reason = fromData.Reason;
        toData.SupportOptionsOverrideRef = fromData.SupportOptionsOverrideRef;
        toData.Updated = fromData.Updated;
        toData.UpdatedUserRef = fromData.UpdatedUserRef;
    }

    public void MapTo(ISupportOptionsOverride toData)
    {
        Map(this, toData);
    }

    public void MapFrom(ISupportOptionsOverride fromData)
    {
        Map(fromData, this);
    }

    public void Update(ISupportOptionsOverride fromData)
    {
        var currentRef = this.SupportOptionsOverrideRef;
        Map(fromData, this);
        this.SupportOptionsOverrideRef = currentRef;
    }

}