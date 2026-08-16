using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class RoleEditModel
{
	public RoleEditModel()
	{ }

	public RoleEditModel(IRole values)
	{
		if (values == null) return;

		Description = values.Description + "";
		Name = values.Name + "";
		RoleRef = values.RoleRef;
	}

	[Required(AllowEmptyStrings = false)]
	[StringLength(400)]
	[MinLength(5)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = false)]
	[StringLength(150)]
	[MinLength(3)]
	public string Name { get; set; }

	public int RoleRef { get; set; }
}

public class RoleAddModel
{
	public RoleAddModel()
	{ }

	public RoleAddModel(IRole values)
	{
		if (values == null) return;
		ApplicationRef = values.ApplicationRef;
		Description = values.Description + "";
		Name = values.Name + "";
	}

	[Required]
	[Range(1, int.MaxValue)]
	public int ApplicationRef { get; set; }

	[Required(AllowEmptyStrings = false)]
	[StringLength(400)]
	[MinLength(4)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = false)]
	[StringLength(150)]
	[MinLength(2)]
	public string Name { get; set; }
}