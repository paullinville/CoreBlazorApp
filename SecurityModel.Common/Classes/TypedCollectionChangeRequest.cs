using System.Collections.Generic;

namespace SecurityModel.Common;

public class TypedCollectionChangeRequest<T>
{
    public TypedCollectionChangeRequest()
    { }

    public TypedCollectionChangeRequest(HashSet<T> existingItems, HashSet<T> requestedItems)
    {
        InitItems(existingItems, requestedItems);
    }

    public TypedCollectionChangeRequest(IEnumerable<T> existingItems, IEnumerable<T> requestedItems)
    {
        InitItems(existingItems.ToHashSet(), requestedItems.ToHashSet());
    }

    public HashSet<T> ExistingItems { get; set; }

    public List<T> KeptItems { get; set; }

    public List<T> NewItems { get; set; }

    public List<T> RemovedItems { get; set; }

    public HashSet<T> RequestedItems { get; set; }

    protected void InitItems(HashSet<T> existingItems, HashSet<T> requestedItems)
    {
        RequestedItems = requestedItems ?? new HashSet<T>();
        ExistingItems = existingItems ?? new HashSet<T>();
        NewItems = RequestedItems.Except(ExistingItems).Distinct().ToList();
        RemovedItems = ExistingItems.Except(RequestedItems).Distinct().ToList();
        KeptItems = ExistingItems.Intersect(RequestedItems).Distinct().ToList();
    }
}