namespace Midland.Core.Common.Caching;

public interface ICache
{
	void InvalidateAsync();

	bool IsExpired();

	void Refresh();

	Task RefreshAsync(CancellationToken ct = default);
}