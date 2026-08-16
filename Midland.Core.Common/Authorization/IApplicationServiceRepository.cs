using System.Collections.ObjectModel;

namespace Midland.Core.ApplicationSecurity;

public interface IApplicationServiceRepository
{
	IMidlandApplication GetApplication();

	ReadOnlyDictionary<Guid, MidlandServiceToken> GetServiceTokens();

	bool Online();

	void RefreshApplication();
}