using System.Collections.Generic;

namespace Midland.Core.Authorization.Reporting;

public class ControllerClaim
{
	public string Controller { get; set; }

	public List<EndpointClaims> EndpointClaims { get; set; }
}