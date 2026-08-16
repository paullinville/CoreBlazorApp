using System;

namespace SecurityModel.Common.Models;

public class ApplicationSummary
{
	public ApplicationSummary()
	{ }

	public ApplicationSummary(IApplicationUserRoleAction userRole)
	{
		Name = userRole.ApplicationName;
		ApplicationRef = userRole.ApplicationRef;
		Guid = userRole.ApplicationGuid;
		IsActive = userRole.ApplicationIsActiveFlag;
		VirtualDirectory = userRole.ApplicationVirtualDirectory;
		Slug = userRole.ApplicationSlug;
		ApiName = userRole.ApplicationApiName;
	}

	public ApplicationSummary(IApplication userRole)
	{
		Name = userRole.Name;
		ApplicationRef = userRole.ApplicationRef;
		Guid = userRole.Guid;
		IsActive = userRole.IsActiveFlag;
		VirtualDirectory = userRole.VirtualDirectory;
		Slug = userRole.Slug;
		ApiName = userRole.ApiName;
	}

	public string ApiName { get; set; }
	public int ApplicationRef { get; set; }
	public Guid Guid { get; set; }
	public bool IsActive { get; set; }
	public string Name { get; set; }
	public string Slug { get; set; }
	public string VirtualDirectory { get; set; }
}