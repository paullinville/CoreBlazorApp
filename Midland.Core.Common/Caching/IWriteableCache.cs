namespace Midland.Core.Common.Caching;

public interface IWriteableCache<TType, TKey> : ICollectionCache<TType, TKey>
{
	Tuple<bool, TType> Remove(TKey key);

	Task<Tuple<bool, TType>> RemoveAsync(TKey key, CancellationToken ct = default);

	void Set(TKey key, TType value);

	Task SetAsync(TKey key, TType value, CancellationToken cancellationToken = default);

	bool TrySet(TKey key, TType value);

	Task<bool> TrySetAsync(TKey key, TType value, CancellationToken cancellationToken = default);
}