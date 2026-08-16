namespace Midland.Core.Common.Caching;

public class DataCache<TType> : CacheBase, ICachedData<TType> where TType : class
{
	public DataCache(Func<CancellationToken, Task<TType>> dataFactory, TimeSpan? ttl = null) : base(ttl)
	{
		DataFactory = dataFactory;
	}

	public TType Data
	{
		get
		{
			return CachedDataAsync().RunSync();
		}
	}

	protected Func<CancellationToken, Task<TType>> DataFactory { get; }
	private TType CachedItem { get; set; }

	public async Task<TType> CachedDataAsync(CancellationToken ct = default)
	{
		await EnsureCacheLoadedAsync(ct);

		LastAccessUtc = DateTime.UtcNow;

		return CachedItem;
	}

	public override bool HasData()
	{
		return CachedItem != null;
	}

	public override void InvalidateAsync()
	{
		CachedItem = null;
	}

	protected override async Task LoadAsync(CancellationToken ct)
	{
		CachedItem = (await DataFactory(ct));
	}
}