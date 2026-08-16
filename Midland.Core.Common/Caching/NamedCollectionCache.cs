namespace Midland.Core.Common.Caching;

public class NamedCollectionCache<TType> : CollectionCache<TType, string>
{
	public NamedCollectionCache(Func<CancellationToken, Task<IEnumerable<TType>>> dataFactory,
								Func<TType, string> nameSelector, TimeSpan? ttl = null) : base(dataFactory, ttl)

	{
		Selector = nameSelector;
	}
}