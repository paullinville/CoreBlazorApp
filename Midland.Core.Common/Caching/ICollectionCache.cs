namespace Midland.Core.Common.Caching;

public interface ICollectionCache<TType, TKeyType> : ICache
{
	TType Get(TKeyType name);

	IReadOnlyCollection<TType> GetAll();

	Task<IReadOnlyCollection<TType>> GetAllAsync(CancellationToken ct = default);

	Task<TType> GetAsync(TKeyType name, CancellationToken ct = default);
}