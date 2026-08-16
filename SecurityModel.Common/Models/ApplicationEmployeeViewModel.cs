using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class ApplicationEmployeeViewModel : EmployeeSimple
{
	public ApplicationEmployeeViewModel()
	{
	}

	public ApplicationEmployeeViewModel(IEmployeeSimple midlandUser) : base(midlandUser)
	{
	}

	public ApplicationSummary Application { get; set; }

	public List<string> RoleNames { get => Roles.Values().Select(r => r.Name).ToList(); }

	public List<RoleViewModel> Roles { get; set; }
}