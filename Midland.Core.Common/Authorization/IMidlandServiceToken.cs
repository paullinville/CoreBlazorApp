namespace Midland.Core.ApplicationSecurity;

public interface IMidlandServiceToken
{
	bool Active { get; set; }
	Guid ServiceTokenId { get; set; }
}