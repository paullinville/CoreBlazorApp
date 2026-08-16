using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ApiTokenAddModel : ApiTokenBodyModel
{
    [Required]
    public string ApplicationSlug { get; set; }
}

public class ApiTokenGetModel : ApiTokenBodyModel
{
    public virtual int ApiTokenRef { get; set; }

    public string ApplicationName { get; set; }
}

public class ApiTokenPutModel
{
    [Required, Range(1, int.MaxValue)]
    public virtual int ApiTokenRef { get; set; }

    public virtual ApiTokenBodyModel Body { get; set; }
}

public class ApiTokenBodyModel : TokenAddModel
{
    public bool Active { get; set; }
}