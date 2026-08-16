using SecurityModel.Common.Models;
using System.Collections.Generic;

namespace SecurityModel.Common;

public class CollectionChangeRequestBase : ICollectionChangeRequest
{
	public CollectionChangeRequestBase()
	{ }

	public CollectionChangeRequestBase(HashSet<int> existingItems, HashSet<int> requestedItems)
	{
		InitItems(existingItems, requestedItems);
	}

	public HashSet<int> ExistingItems { get; set; }

	public bool HasChanges { get => NewItems.IsNotEmpty() || RemovedItems.IsNotEmpty(); }
	public List<int> KeptItems { get; set; }

	public List<int> NewItems { get; set; }

	public List<int> RemovedItems { get; set; }

	public HashSet<int> RequestedItems { get; set; }

	protected void InitItems(HashSet<int> existingItems, HashSet<int> requestedItems)
	{
		RequestedItems = requestedItems ?? new HashSet<int>();
		ExistingItems = existingItems ?? new HashSet<int>();
		NewItems = RequestedItems.Except(ExistingItems).Distinct().ToList();
		RemovedItems = ExistingItems.Except(RequestedItems).Distinct().ToList();
		KeptItems = ExistingItems.Intersect(RequestedItems).Distinct().ToList();
	}
}

public class CollectionChangeRequest : CollectionChangeRequestBase
{
	public CollectionChangeRequest(HashSet<int> existingRoles, UserRoleCollectionModel request)
	{
		RequestedItems = request?.RoleRefs.Values().ToHashSet() ?? new HashSet<int>();
		ExistingItems = existingRoles ?? new HashSet<int>();
		NewItems = RequestedItems.Except(ExistingItems).Distinct().ToList();
		RemovedItems = ExistingItems.Except(RequestedItems).Distinct().ToList();
		KeptItems = ExistingItems.Intersect(RequestedItems).Distinct().ToList();
	}

	public CollectionChangeRequest(HashSet<int> existingUserRefs, RoleUserCollectionModel request)
	{
		RequestedItems = request?.UserRefs.Values().ToHashSet() ?? new HashSet<int>();
		ExistingItems = existingUserRefs ?? new HashSet<int>();
		NewItems = RequestedItems.Except(ExistingItems).Distinct().ToList();
		RemovedItems = ExistingItems.Except(RequestedItems).Distinct().ToList();
		KeptItems = ExistingItems.Intersect(RequestedItems).Distinct().ToList();
	}

	public CollectionChangeRequest(HashSet<int> existingUserRefs, ServiceTokenUpdateModel request)
	{
		if (request != null)
		{
			RequestedItems = (new List<int>(request.SecondaryResponsibleUserRefs.Values()) { request.PrimaryResponsibleUserRef }).ToHashSet();
		}
		else
		{
			RequestedItems = new HashSet<int>();
		}
		ExistingItems = existingUserRefs ?? new HashSet<int>();
		NewItems = RequestedItems.Except(ExistingItems).Distinct().ToList();
		RemovedItems = ExistingItems.Except(RequestedItems).Distinct().ToList();
		KeptItems = ExistingItems.Intersect(RequestedItems).Distinct().ToList();
	}
}