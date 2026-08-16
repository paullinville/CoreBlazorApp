namespace Midland.Core.Common.Caching;

public interface ICachedData<TType> : ICache where TType : class
{
	TType Data { get; }

	Task<TType> CachedDataAsync(CancellationToken ct = default);
}