using System.Collections.Generic;

namespace Midland.Core.Authorization.Reporting;

public class PathClaimGroups
{
	public string Api { get; set; }
	public string Path { get; set; }
	public string Method { get; set; }
	public string PathId { get => $"{Method} {Api}{Path}"; }
	public List<PathClaimGroup> Groups { get; set; } = new List<PathClaimGroup>();
}