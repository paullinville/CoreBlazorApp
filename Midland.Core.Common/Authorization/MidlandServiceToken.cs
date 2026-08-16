using System;

namespace Midland.Core.ApplicationSecurity;

public class MidlandServiceToken : IMidlandServiceToken
{
	public Guid ServiceTokenId { get; set; }
	public bool Active { get; set; }
}