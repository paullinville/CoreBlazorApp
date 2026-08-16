//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IApplicationOptions
{

    int CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    string EntryEmail { get; set; }
    int ApplicationOptionsRef { get; set; }
    int? UpdatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
    string ApplicationSlug { get; set; }

    public static void Map(IApplicationOptions fromData, IApplicationOptions toData)
    {
        if (fromData == null || toData == null) return;
        toData.CreatedBy = fromData.CreatedBy;
        toData.CreatedDate = fromData.CreatedDate;
        toData.EntryEmail = fromData.EntryEmail;
        toData.ApplicationOptionsRef = fromData.ApplicationOptionsRef;
        toData.UpdatedBy = fromData.UpdatedBy;
        toData.UpdatedDate = fromData.UpdatedDate;
        toData.ApplicationSlug = fromData.ApplicationSlug;
    }

    public void MapTo(IApplicationOptions toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApplicationOptions fromData)
    {
        Map(fromData, this);
    }

    public void Update(IApplicationOptions fromData)
    {
        var currentRef = this.ApplicationOptionsRef;
        Map(fromData, this);
        this.ApplicationOptionsRef = currentRef;
    }

}