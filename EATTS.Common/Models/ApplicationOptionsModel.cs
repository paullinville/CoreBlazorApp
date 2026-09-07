using Midland.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EATTS.Common.Models;

public class ApplicationOptionsDeleteModel
{
    public virtual int ApplicationOptionsRef { get; set; }
}

public class ApplicationOptionsGetModel : ApplicationOptionsPostModel
{
    public ApplicationOptionsGetModel()
    { }

    public ApplicationOptionsGetModel(IApplicationOptions values) : base(values)
    {
        ApplicationOptionsRef = values.ApplicationOptionsRef;
    }

    public int ApplicationOptionsRef { get; set; }

    public override EATTS.Common.Dto.ApplicationOptionsDto CreateDto()
    {
        var createdItem = new EATTS.Common.Dto.ApplicationOptionsDto();
        createdItem.EntryEmail = EntryEmail.ListToString(";");
        createdItem.ApplicationOptionsRef = ApplicationOptionsRef;
        createdItem.ApiName = ApiName;
        return createdItem;
    }

    #region

    public override bool Equals(object obj)
    {
        if (obj is ApplicationOptionsGetModel item)
        {
            return item.ApplicationOptionsRef == ApplicationOptionsRef;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ApplicationOptionsRef;
    }

    #endregion
}

public class ApplicationOptionsPutModel
{
    public ApplicationOptionsPutModel()
    { }

    public ApplicationOptionsPutModel(IApplicationOptions values)
    {
        ApplicationOptionsRef = values.ApplicationOptionsRef;
        Body = new ApplicationOptionsPostModel(values);
    }

    [Required, Range(1, int.MaxValue)]
    public virtual int ApplicationOptionsRef { get; set; }

    public virtual ApplicationOptionsPostModel Body { get; set; }
}

public class ApplicationOptionsPostModel
{
    public ApplicationOptionsPostModel()
    { }

    public ApplicationOptionsPostModel(IApplicationOptions values)
    {
        if (values == null) return;

        EntryEmail = values.EntryEmail.Split(";").ToList();
        ApiName = values.ApiName;
    }

    [Required(AllowEmptyStrings = true)]
    [StringLength(90)]
    public string ApiName { get; set; }

    [ListCount(Min = 1, Max = 20)]
    public List<string> EntryEmail { get; set; }

    public virtual EATTS.Common.Dto.ApplicationOptionsDto CreateDto()
    {
        var createdItem = new EATTS.Common.Dto.ApplicationOptionsDto();
        createdItem.EntryEmail = EntryEmail.ListToString(";");
        createdItem.ApiName = ApiName;
        return createdItem;
    }
}