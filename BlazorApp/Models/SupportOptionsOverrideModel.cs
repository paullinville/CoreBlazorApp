using EATTS.Common.Models;

namespace BlazorApp.Models;

public class SupportOptionsOverrideModel : SupportOptionsOverrideGetModel
{
    public SupportOptionsOverrideModel()
    { }

    public SupportOptionsOverrideModel(SupportOptionsOverrideGetModel values, IEnumerable<IMidlandUser> users)
    {
        EntryRef = values.EntryRef;
        DoNotSendEmail = values.DoNotSendEmail;
        FloodCount = values.FloodCount;
        FloodEmail = values.FloodEmail;
        FloodTime = values.FloodTime;
        OtherEmail = values.OtherEmail;
        Reason = values.Reason;
        SupportOptionsOverrideRef = values.SupportOptionsOverrideRef;
        SelectedUserRefs = users
            .Where(r => r is not null && (OtherEmail + "").Contains(r.Email))
            .GroupBy(r => r.UserRef)
            .Select(g => g.Key)
            .ToList();
    }

    public List<int> SelectedUserRefs { get; set; } = new List<int>();
}