namespace Midland.Core.Common.Caching;

public abstract class CacheBase : ICache
{
	public CacheBase(TimeSpan? ttl = null)
	{
		Ttl = ttl ?? TimeSpan.FromMinutes(30);
	}

	protected DateTime LastAccessUtc { get; set; }
	protected SemaphoreSlim Lock { get; } = new(1, 1);
	protected TimeSpan Ttl { get; }

	public abstract bool HasData();

	public abstract void InvalidateAsync();

	public bool IsExpired() => LastAccessUtc == default || (DateTime.UtcNow - LastAccessUtc) > Ttl;

	public void Refresh() => MidlandAsyncUtils.RunSync(() => RefreshAsync());

	public async Task RefreshAsync(CancellationToken ct = default)
	{
		await Lock.WaitAsync(ct);
		try
		{
			await OnLoadAsync(ct);
		}
		finally
		{
			Lock.Release();
		}
	}

	protected async Task EnsureCacheLoadedAsync(CancellationToken ct)
	{
		if (HasData() && !IsExpired()) return;

		await Lock.WaitAsync(ct);
		try
		{
			// Checking again inside of the lock in case it was waiting
			if (HasData() && !IsExpired()) return;

			await OnLoadAsync(ct);
		}
		finally
		{
			Lock.Release();
		}
	}

	protected abstract Task LoadAsync(CancellationToken ct);

	private async Task OnLoadAsync(CancellationToken ct)
	{
		await LoadAsync(ct);
		LastAccessUtc = DateTime.UtcNow;
	}
}