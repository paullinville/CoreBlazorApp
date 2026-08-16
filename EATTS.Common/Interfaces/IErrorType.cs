//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IErrorType
{

    DateTime CreateDate { get; set; }
    string Description { get; set; }
    short IsActiveFlag { get; set; }
    int ErrorTypeRef { get; set; }

    public static void Map(IErrorType fromData, IErrorType toData)
    {
        if (fromData == null || toData == null) return;
        toData.CreateDate = fromData.CreateDate;
        toData.Description = fromData.Description;
        toData.IsActiveFlag = fromData.IsActiveFlag;
        toData.ErrorTypeRef = fromData.ErrorTypeRef;
    }

    public void MapTo(IErrorType toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IErrorType fromData)
    {
        Map(fromData, this);
    }

    public void Update(IErrorType fromData)
    {
        var currentRef = this.ErrorTypeRef;
        Map(fromData, this);
        this.ErrorTypeRef = currentRef;
    }

}