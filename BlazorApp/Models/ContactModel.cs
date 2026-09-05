using EATTS.Common.Models;

namespace BlazorApp.Models;

public class ContactModel : SupportDefaultContactEditModel
{
    public ContactModel()
    { }

    public ContactModel(SupportDefaultContactEditModel values)
    {
        UserRef = values.UserRef;
        Order = values.Order;
        Active = values.Active;
        SupportDefaultContactRef = values.SupportDefaultContactRef;
    }

    public string FullName { get; set; } = "";
    #region

    public override bool Equals(object? obj)
    {
        if (obj is ContactModel item)
        {
            return item.SupportDefaultContactRef == SupportDefaultContactRef;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return SupportDefaultContactRef;
    }

    #endregion
}