using Midland.Core.Api;
using Midland.Core.ApplicationSecurity;

namespace Midland.Core.Common;

public class Application
{
	public const int DefaultApplicationSecurityMinutes = 30;

	//If the request ends with the string it will not be logged by the ApiLoggingCommand
	public List<string> PathsNotLogged = new List<string>() { "healthz" };

	public string ApiName { get; set; }
	public ApiOptions ApiOptions { get; set; } = new ApiOptions();
	public ApiSecurityInformation ApiSecurityInformation { get; set; }
	public CacheTiming CacheTiming { get; set; } = new CacheTiming() { UserMinutes = 5, ApplicationSecurityMinutes = DefaultApplicationSecurityMinutes };
	public EattsOptions EattsErrorOptions { get; set; } = new EattsOptions { Record = true };
	public string FilesDirectory { get; set; }
	public string GatewayAddress { get; set; }
	public string LogOutputFolder { get; set; }
	public int LogRolloverMinute { get; set; } = 10;
	public int MaxMemoryUsage { get; set; } = 1500;
	public bool ReportExceptionDetail { get; set; }
	public TokenSecuritySettings TokenSecuritySettings { get; set; }
	public ApiDefinition VaultApi { get; set; }

	public string ApiId()
	{
		return ApiName?.ToLower();
	}

	public string DefaultFilesDirectory(string environment)
	{
		return @$"\\mg-midnetfiles\Files\{environment}\Private\{ApiName}";
	}
}