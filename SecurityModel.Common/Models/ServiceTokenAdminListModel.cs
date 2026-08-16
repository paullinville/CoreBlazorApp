using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class ServiceTokenAdminListModel : ServiceTokenView
{
	public DateTime Created { get; set; }
	public string CreatedBy { get; set; }
	public List<string> ResponsibleUsers { get; set; }
}