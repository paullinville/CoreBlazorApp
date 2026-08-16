using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class RoleViewModel : RoleEditModel
{
	public RoleViewModel()
	{ }

	public RoleViewModel(IRole values) : base(values)
	{
		ApplicationRef = values.ApplicationRef;
		IsActive = values.IsActiveFlag;
	}

	public int? ApplicationRef { get; set; }

	[Required]
	public bool IsActive { get; set; }
}