using System.Collections.Generic;

namespace Midland.Core.Authorization.Reporting;

public class PathClaimGroup
{
	public string Group { get; set; }
	public List<string> Claims { get; set; }
}