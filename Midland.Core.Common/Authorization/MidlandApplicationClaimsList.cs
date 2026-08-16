using Midland.Core.Authorization;

namespace Midland.Core.Abstractions.Security;

public class MidlandApplicationClaimsList
{
    public Guid ApplicationGuid { get; set; }
    public List<MidlandClaimRequirement> Claims { get; set; }

    public List<ActionGroup> Groups { get; set; }
}