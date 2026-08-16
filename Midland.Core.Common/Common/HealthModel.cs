using Midland.Core.Api;
using Midland.Core.Authorization;
using Midland.Core.Common.Database;
using System.ComponentModel.DataAnnotations;

namespace Midland.Core.Common;

public class HealthModel
{
	public List<string> ApiCalls { get; set; }

	[Display(Order = 1)]
	public string ApiName { get; set; }

	public ApiOptions ApiOptions { get; set; }
	public string ApplicationDirectory { get; set; }
	public Guid? ApplicationGuid { get; set; }
	public int? ApplicationRef { get; set; }
	public bool? CertificateFound { get; set; }
	public AllowedCertificate CertificateSetting { get; set; }
	public bool? CertificateValid { get; set; }

	[Display(Order = 2, Description = "The date and time the gateway did the health check.")]
	public DateTime CheckedAt { get; set; }

	public string ComponentVersions { get; set; }

	[Display(Description = "Information about the requesting machine.")]
	public string ConnectionInfo { get; set; }

	public EattsOptions EattsOptions { get; set; }

	[Display(Order = 4, Description = "The ASPNETCORE_ENVIRONMENT (Production, Deployment, Development) the API is running.")]
	public string Environment { get; set; }

	public string ExceptionThrown { get; set; }
	public string FilesDirectory { get; set; }
	public string Headers { get; set; }
	public string Id { get => $"{ServerName}-{ProcessId}"; }

	[Display(Description = "IP address the allocation is running on.")]
	public string Ip { get; set; }

	public string LogFiles { get; set; }

	[Display(Description = "The port assigned to the the allocation by Nomad.")]
	public int? Port { get; set; }

	[Display(Name = "DB Info", Description = "Primary database information.")]
	public string PrimaryDatabaseInfo { get; set; }

	[Display(Order = 6, Name = "Primary DB", Description = "Primary database online status.")]
	public bool PrimaryDatabaseOnline { get; set; }

	public long ProcessId { get; set; }

	[Display(Description = "Where the API is running from.")]
	public string ProcessPath { get; set; }

	public SchemaValidationResult SchemaValidation { get; set; }

	[Display(Order = 7, Name = "Security Info", Description = "Security database information.")]
	public string SecondaryDatabaseInfo { get; set; }

	[Display(Order = 7, Name = "Security DB", Description = "Security database online status.")]
	public bool SecurityDatabaseOnline { get; set; }

	[Display(Order = 3)]
	public string ServerName { get; set; }

	[Display(Order = 1)]
	public string Slug { get; set; }

	public string TokenIssuer { get; set; }

	public List<HealthModelVersion> Versions { get; set; }

	[Display(Order = 5)]
	public long WorkingSet { get; set; }
}