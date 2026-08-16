using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class RoleActionAddModel
{
	public int ActionRef { get; set; }
	public int RoleRef { get; set; }
}

public class RoleActionCollectionModel
{
	public RoleActionCollectionModel()
	{
	}

	public RoleActionCollectionModel(RolePostModel postModel, IRole role)
	{
		RoleRef = role.RoleRef;
		ActionRefs = postModel.ActionRefs.Values().ToList();
	}

	public RoleActionCollectionModel(RolePutModel putModel)
	{
		RoleRef = putModel.RoleRef;
		ActionRefs = putModel.Body.ActionRefs.Values().ToList();
	}

	public List<int> ActionRefs { get; set; }

	public int RoleRef { get; set; }
}

public class RoleActionDeleteModel
{
	public int ActionRef { get; set; }
	public int RoleRef { get; set; }
}