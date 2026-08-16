//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Dto;

public class ActionGroupDto : IActionGroup 
{
    public ActionGroupDto(IActionGroup values)
    {
        values?.MapTo(this);
    }

    public ActionGroupDto()
    { }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime ActionCreateDate { get; set; }

    public int ActionGroupRef { get; set; }

    public int ApplicationRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string Name { get; set; }

}