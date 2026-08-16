namespace Midland.Core.Common.Caching;

public class IdCollectionCache<TType> : CollectionCache<TType, int>
{
	public IdCollectionCache(Func<CancellationToken,
							 Task<IEnumerable<TType>>> dataFactory,
							 Func<TType, int> selector,
							 TimeSpan? ttl = null) : base(dataFactory, ttl)

	{
		Selector = selector;
	}
}