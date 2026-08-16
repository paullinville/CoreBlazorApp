using Midland.Core.Common;

using System;
using System.ComponentModel.DataAnnotations;

namespace EATTS.Common.Models;

public class ApplicationInventoryModel
{
	[Required(), StringLength(100)]
	public string Name { get; set; }

	public Employee TechContact1 { get; set; }
	public Employee TechContact2 { get; set; }
}