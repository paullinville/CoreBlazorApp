using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class RoleUserCollectionModel
{
	public int RoleRef { get; set; }
	public List<int> UserRefs { get; set; }
}