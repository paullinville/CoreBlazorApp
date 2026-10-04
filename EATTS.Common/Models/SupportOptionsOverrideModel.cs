using System.ComponentModel.DataAnnotations;
using System;

namespace EATTS.Common.Models;

public class SupportOptionsOverrideDeleteModel
{
    public virtual int SupportOptionsOverrideRef { get; set; }
}

public class SupportOptionsOverrideGetModel : SupportOptionsOverridePostModel
{
    public SupportOptionsOverrideGetModel()
    { }

    public SupportOptionsOverrideGetModel(ISupportOptionsOverride values) : base(values)
    {
        SupportOptionsOverrideRef = values.SupportOptionsOverrideRef;
    }

    public int SupportOptionsOverrideRef { get; set; }

    public override EATTS.Common.Dto.SupportOptionsOverrideDto CreateDto()
    {
        var createdItem = new EATTS.Common.Dto.SupportOptionsOverrideDto();
        createdItem.EntryRef = EntryRef;
        createdItem.DoNotSendEmail = DoNotSendEmail ?? false;
        createdItem.FloodCount = FloodCount;
        createdItem.FloodEmail = FloodEmail + "";
        createdItem.FloodTime = FloodTime;
        createdItem.OtherEmail = OtherEmail + "";
        createdItem.Reason = Reason + "";
        createdItem.SupportOptionsOverrideRef = SupportOptionsOverrideRef;
        return createdItem;
    }

    #region

    public override bool Equals(object obj)
    {
        if (obj is SupportOptionsOverrideGetModel item)
        {
            return item.SupportOptionsOverrideRef == SupportOptionsOverrideRef;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return SupportOptionsOverrideRef;
    }

    #endregion
}

public class SupportOptionsOverridePutModel
{
    public SupportOptionsOverridePutModel()
    { }

    public SupportOptionsOverridePutModel(ISupportOptionsOverride values)
    {
        SupportOptionsOverrideRef = values.SupportOptionsOverrideRef;
        Body = new SupportOptionsOverridePostModel(values);
    }

    public virtual SupportOptionsOverridePostModel Body { get; set; }

    [Required, Range(1, int.MaxValue)]
    public virtual int SupportOptionsOverrideRef { get; set; }

    #region

    public override bool Equals(object obj)
    {
        if (obj is SupportOptionsOverridePutModel item)
        {
            return item.SupportOptionsOverrideRef == SupportOptionsOverrideRef;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return SupportOptionsOverrideRef;
    }

    #endregion
}

public class SupportOptionsOverridePostModel
{
    public SupportOptionsOverridePostModel()
    { }

    public SupportOptionsOverridePostModel(ISupportOptionsOverride values)
    {
        if (values == null) return;
        EntryRef = values.EntryRef;
        DoNotSendEmail = values.DoNotSendEmail;
        FloodCount = values.FloodCount;
        FloodEmail = values.FloodEmail;
        FloodTime = values.FloodTime;
        OtherEmail = values.OtherEmail;
        Reason = values.Reason;
    }

    public bool? DoNotSendEmail { get; set; }

    public int EntryRef { get; set; }

    [Range(1, 1000)]
    public int? FloodCount { get; set; }

    [StringLength(512)]
    public string FloodEmail { get; set; }

    [Range(1, 86400)]
    public int? FloodTime { get; set; }

    [StringLength(512)]
    public string OtherEmail { get; set; }

    [StringLength(1024), MinLength(8), Required]
    public string Reason { get; set; }

    public virtual EATTS.Common.Dto.SupportOptionsOverrideDto CreateDto()
    {
        var createdItem = new EATTS.Common.Dto.SupportOptionsOverrideDto();
        createdItem.EntryRef = EntryRef;
        createdItem.DoNotSendEmail = DoNotSendEmail ?? false;
        createdItem.FloodCount = FloodCount;
        createdItem.FloodEmail = FloodEmail;
        createdItem.FloodTime = FloodTime;
        createdItem.OtherEmail = OtherEmail;
        createdItem.Reason = Reason;
        return createdItem;
    }
}