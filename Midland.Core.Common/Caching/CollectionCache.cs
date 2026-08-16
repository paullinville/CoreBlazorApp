namespace Midland.Core.Common.Caching;

public abstract class CollectionCache<TType, TKeyType> : CacheBase, ICollectionCache<TType, TKeyType>
{
	public CollectionCache(Func<CancellationToken, Task<IEnumerable<TType>>> dataFactory,
						   TimeSpan? ttl = null) : base(ttl)
	{
		DataFactory = dataFactory;
	}

	protected Func<CancellationToken, Task<IEnumerable<TType>>> DataFactory { get; }
	protected Func<TType, TKeyType> Selector { get; set; }
	protected Dictionary<TKeyType, TType> TypeDictionary { get; set; }

	public TType Get(TKeyType name) => GetAsync(name).RunSync();

	public IReadOnlyCollection<TType> GetAll() => GetAllAsync().RunSync();

	public async Task<IReadOnlyCollection<TType>> GetAllAsync(CancellationToken ct = default)
	{
		await EnsureCacheLoadedAsync(ct);

		return TypeDictionary?.Values as IReadOnlyCollection<TType> ?? [];
	}

	/// <summary>
	/// Gets the value for the key.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="ct"></param>
	/// <returns>The Value for the key if found. Otherwise the default value of TType</returns>
	public async Task<TType> GetAsync(TKeyType name, CancellationToken ct = default)
	{
		await EnsureCacheLoadedAsync(ct);

		TypeDictionary.TryGetValue(name, out var value);

		return value;
	}

	public override bool HasData()
	{
		return TypeDictionary.IsNotEmpty();
	}

	public override void InvalidateAsync()
	{
		TypeDictionary = null;
	}

	protected override async Task LoadAsync(CancellationToken ct)
	{
		if (Selector == null) throw new InvalidOperationException("Selector not configured.");
		TypeDictionary = (await DataFactory(ct)).Values().ToList().ToDictionary(Selector);
	}
}