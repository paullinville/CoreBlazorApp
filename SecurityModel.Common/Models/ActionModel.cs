using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ActionEditModel
{
    public ActionEditModel()
    { }

    public ActionEditModel(IApplicationAction fromData)
    {
        if (fromData == null) return;
        ActionRef = fromData.ActionRef;
        Description = fromData.ActionDescription + "";
    }

    public ActionEditModel(IAction values)
    {
        if (values == null) return;
        Description = values.Description + "";
        ActionRef = values.ActionRef;
    }

    public int ActionRef { get; set; }

    [Required()]
    [StringLength(400, MinimumLength = 4)]
    public string Description { get; set; }

    public SecurityModel.Common.Dto.ActionDto CreateDto()
    {
        var createdItem = new SecurityModel.Common.Dto.ActionDto();
        createdItem.Description = Description;
        createdItem.ActionRef = ActionRef;
        return createdItem;
    }
}