using System.Collections.Concurrent;

namespace Midland.Core.Common.Caching;

public class WritableCache<TType, TKey> : CacheBase, IWriteableCache<TType, TKey>
{
	public WritableCache(Func<CancellationToken, Task<Dictionary<TKey, TType>>> dataFactory,
						   TimeSpan? ttl = null) : base(ttl)
	{
		DataFactory = dataFactory;
	}

	protected Func<CancellationToken, Task<Dictionary<TKey, TType>>> DataFactory { get; }
	protected ConcurrentDictionary<TKey, TType> TypeDictionary { get; set; }

	public async Task<bool> AddAsync(TKey key, TType value, CancellationToken ct = default)
	{
		return (await GetDictionary(ct)).TryAdd(key, value);
	}

	public TType Get(TKey key) => GetAsync(key).RunSync();

	public IReadOnlyCollection<TType> GetAll() => GetAllAsync().RunSync();

	public async Task<IReadOnlyCollection<TType>> GetAllAsync(CancellationToken ct = default)
	{
		return (await GetDictionary(ct)).Values as IReadOnlyCollection<TType> ?? [];
	}

	public async Task<TType> GetAsync(TKey key, CancellationToken ct = default)
	{
		(await GetDictionary(ct)).TryGetValue(key, out var value);

		return value;
	}

	public override bool HasData()
	{
		return TypeDictionary.IsNotEmpty();
	}

	/// <summary>
	/// Will force the datafactory to run next time results are accessed.
	/// </summary>
	/// <returns></returns>
	public override void InvalidateAsync()
	{
		TypeDictionary = null;
	}

	/// <summary>
	/// Removes the value for the key.
	/// </summary>
	/// <param name="key"></param>
	/// <returns>
	/// Item1 is True if it was found and removed. False if it was not found. Item2 is the
	/// </returns>
	public Tuple<bool, TType> Remove(TKey key)
	{
		return RemoveAsync(key).RunSync();
	}

	/// <summary>
	/// Tries to remove the value asynchronously in a thread safe way.
	/// </summary>
	/// <param name="key"></param>
	/// <param name="ct"></param>
	/// <returns>
	/// Item1 True if removed and false if not removed. Item2 the value of the item remove if
	/// remove, otherwise null.
	/// </returns>
	public async Task<Tuple<bool, TType>> RemoveAsync(TKey key, CancellationToken ct = default)
	{
		var removed = (await GetDictionary(ct)).TryRemove(key, out TType value);

		return Tuple.Create(removed, value);
	}

	/// <summary>
	/// Tries to remove the value in a thread safe way.
	/// </summary>
	/// <param name="key"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public void Set(TKey key, TType value)
	{
		MidlandAsyncUtils.RunSync(() => SetAsync(key, value));
	}

	/// <summary>
	/// Will either add the value for the key or update the value for the key.
	/// </summary>
	/// <param name="key"></param>
	/// <param name="value"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task SetAsync(TKey key, TType value, CancellationToken cancellationToken = default)
	{
		(await GetDictionary(cancellationToken)).AddOrUpdate(key, value, (key, oldValue) => value);
	}

	/// <summary>
	/// Will add the value if key doesn't exist.
	/// </summary>
	/// <param name="key"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public bool TrySet(TKey key, TType value)
	{
		return TrySetAsync(key, value).RunSync();
	}

	/// <summary>
	/// Will add the value if key doesn't exist.
	/// </summary>
	/// <param name="key"></param>
	/// <param name="value"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>
	/// True if the item was added if the key wasn't found. False if the key already exists.
	/// </returns>
	public async Task<bool> TrySetAsync(TKey key, TType value, CancellationToken cancellationToken = default)
	{
		var whatWasAdded = (await GetDictionary(cancellationToken)).AddOrUpdate(key, value, (key, oldValue) => oldValue);
		return whatWasAdded.Equals(value);
	}

	protected override async Task LoadAsync(CancellationToken ct)
	{
		var loadedDic = (await DataFactory(ct));
		TypeDictionary = new ConcurrentDictionary<TKey, TType>(loadedDic);
	}

	private async Task<ConcurrentDictionary<TKey, TType>> GetDictionary(CancellationToken ct = default)
	{
		await EnsureCacheLoadedAsync(ct);
		return TypeDictionary;
	}
}