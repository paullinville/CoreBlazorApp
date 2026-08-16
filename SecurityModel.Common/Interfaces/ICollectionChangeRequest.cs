using System.Collections.Generic;

namespace SecurityModel.Common.Interfaces;

public interface ICollectionChangeRequest
{
    HashSet<int> ExistingItems { get; set; }
    List<int> KeptItems { get; set; }
    List<int> NewItems { get; set; }
    List<int> RemovedItems { get; set; }
    HashSet<int> RequestedItems { get; set; }
}