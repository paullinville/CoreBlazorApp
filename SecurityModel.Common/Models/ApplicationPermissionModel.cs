using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class ApplicationPermissionModel
{
	public int ApplicationRef { get; set; }
	public string Description { get; set; }
	public Guid Guid { get; set; }
	public bool IsActive { get; set; }
	public string Name { get; set; }
	public string VirtualDirectory { get; set; }

	[Required]
	public IEnumerable<string> Actions { get; set; }
}