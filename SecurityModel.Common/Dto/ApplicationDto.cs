//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using SecurityModel.Common.Interfaces;

namespace SecurityModel.Common.Dto;

public class ApplicationDto : IApplication 
{
    public ApplicationDto(IApplication values)
    {
        values?.MapTo(this);
    }

    public ApplicationDto()
    { }

    [StringLength(150)]
    public string ApiName { get; set; }

    public int ApplicationRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(500)]
    public string ConnectionString { get; set; }

    [StringLength(255)]
    public string ConnectionString1 { get; set; }

    [StringLength(500)]
    public string ConnectionString2 { get; set; }

    [Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
    public DateTime? CreateDate { get; set; }

    public int? CreateUserRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(400)]
    public string Description { get; set; }

    [StringLength(150)]
    public string EmailFrom { get; set; }

    public Guid Guid { get; set; }

    public bool IsActiveFlag { get; set; }

    public int IsLoadedFlag { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(150)]
    public string Name { get; set; }

    [StringLength(90)]
    public string Slug { get; set; }

    public int TypeRef { get; set; }

    [StringLength(250)]
    public string VirtualDirectory { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is IApplication agh)
        {
            return agh.ApplicationRef == ApplicationRef ;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ApplicationRef;
    }
}