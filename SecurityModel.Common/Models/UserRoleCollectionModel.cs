using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class UserRoleCollectionModel
{
	public virtual int ApplicationRef { get; set; }
	public virtual List<int> RoleRefs { get; set; }
	public virtual int UserRef { get; set; }
}