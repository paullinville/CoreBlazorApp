using System;

namespace SecurityModel.Common.Models;

public class ServiceTokenView
{
	public string Name { get; set; }
	public Guid Id { get; set; }
	public bool Active { get; set; }
	public string Description { get; set; }
	public DateTime? ExperationDate { get; set; }
}