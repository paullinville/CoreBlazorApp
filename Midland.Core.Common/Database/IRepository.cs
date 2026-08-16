using Midland.Core.Common.Database;

namespace Midland.Core.Database;

public interface IRepository
{
	bool Online();

	SchemaValidationResult ValidateSchema() { return new SchemaValidationResult() { }; }
}