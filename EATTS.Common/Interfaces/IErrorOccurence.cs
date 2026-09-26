using System;

namespace EATTS.Common.Interfaces;

public interface IErrorOccurence
{
    DateTime CreateDate { get; set; }
    int ErrorOccurenceRef { get; set; }
    int? ErrorRef { get; set; }
    int? UserRef { get; set; }

    public static void Map(IErrorOccurence fromData, IErrorOccurence toData)
    {
        if (fromData == null || toData == null) return;
        toData.CreateDate = fromData.CreateDate;
        toData.ErrorOccurenceRef = fromData.ErrorOccurenceRef;
        toData.ErrorRef = fromData.ErrorRef;
        toData.UserRef = fromData.UserRef;
    }

    public void MapTo(IErrorOccurence toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IErrorOccurence fromData)
    {
        Map(fromData, this);
    }
}