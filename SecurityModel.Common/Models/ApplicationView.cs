using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class ApplicationView
{
	public int ApplicationRef { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public Guid Guid { get; set; }
	public List<ActionEditDetailModel> Actions { get; set; }
	public bool Active { get; set; }
}