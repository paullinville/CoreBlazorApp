//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class ApiLogDto : IApiLog 
{
    public ApiLogDto(IApiLog values)
    {
        values?.MapTo(this);
    }

    public ApiLogDto()
    { }

    public int ApiLogRef { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(250)]
    public string ApiName { get; set; }

    public bool Error { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(2147483647)]
    public string LogData { get; set; }

    public DateTime LogDate { get; set; }

    public Guid LogId { get; set; }

    public int LogLevel { get; set; }

    public Guid RequestId { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(50)]
    public string Server { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is IApiLog agh)
        {
            return agh.ApiLogRef == ApiLogRef ;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return $"ApiLog{ApiLogRef}".GetHashCode();
    }

}