using System.Collections.ObjectModel;

namespace Midland.Core.ApplicationSecurity;

public interface IMidlandApplicationSecurityService
{
    IMidlandApplication Application { get; }

    ReadOnlyDictionary<Guid, MidlandServiceToken> ServiceTokens { get; }

    bool Online();

    void RefreshApplication();

    bool TokenActive(Guid jti);
}