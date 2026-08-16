using System.ComponentModel.DataAnnotations;

namespace Midland.Core.Common;

public class ApplicationView
{
	public ApplicationView()
	{ }

	[Required]
	[StringLength(500)]
	public string AccessWebSite { get; set; }

	[Required]
	[StringLength(250)]
	public string Aliases { get; set; }

	public int? AmortizationPeriod { get; set; }

	[Required]
	[StringLength(2147483647)]
	public string ApplicationDescription { get; set; }

	[Required]
	[StringLength(100)]
	public string ApplicationName { get; set; }

	public int ApplicationRef { get; set; }

	[StringLength(50)]
	public string ApplicationTypeName { get; set; }

	public int? ApplicationTypeRef { get; set; }

	[Required]
	[StringLength(50)]
	public string ApplicationVersion { get; set; }

	[StringLength(50)]
	public string BusinessCostCenterCode { get; set; }

	[StringLength(250)]
	public string BusinessCostCenterName { get; set; }

	[StringLength(250)]
	public string BusinessDepartmentName { get; set; }

	public int? BusinessUserRef { get; set; }

	[StringLength(76)]
	public string BusinessContactFullName { get; set; }

	public int? CostCenterRef { get; set; }
	public DateTime CreateDate { get; set; }
	public int CreatedUserRef { get; set; }
	public decimal? CurrentBookValue { get; set; }

	[Required]
	[StringLength(500)]
	public string DatabaseName { get; set; }

	[StringLength(50)]
	public string DevelopedByName { get; set; }

	public int? DevelopedByRef { get; set; }

	[StringLength(50)]
	public string DirectCustomerImpactName { get; set; }

	public int DirectCustomerImpactRef { get; set; }

	[Required]
	[StringLength(500)]
	public string ExecutableLocation { get; set; }

	[Required]
	[StringLength(500)]
	public string ExecutableTimestamp { get; set; }

	public DateTime? ImplementationDate { get; set; }

	[Required]
	[StringLength(500)]
	public string InstallDirectory { get; set; }

	public bool InternetApplication { get; set; }

	[StringLength(100)]
	public string LicenseData { get; set; }

	[StringLength(50)]
	public string OrganizationName { get; set; }

	public int? OrganizationRef { get; set; }
	public decimal? OriginalBookValue { get; set; }
	public decimal? PurchasePrice { get; set; }

	[StringLength(50)]
	public string RiskRatingName { get; set; }

	public int? RiskRatingRef { get; set; }

	[Required]
	[StringLength(500)]
	public string ServerScheduledTask { get; set; }

	[Required]
	[StringLength(500)]
	public string SqlScheduledTasks { get; set; }

	public int SupportScoreRef { get; set; }
	public int? SystemAdminUserRef { get; set; }
	public int? SystemOwnerUserRef { get; set; }

	[StringLength(76)]
	public string SystemAdminFullName { get; set; }

	[StringLength(76)]
	public string SystemOwnerFullName { get; set; }

	public int? TechContact1UserRef { get; set; }
	public int? TechContact2UserRef { get; set; }

	[StringLength(50)]
	public string TechCostCenterCode { get; set; }

	[StringLength(250)]
	public string TechCostCenterName { get; set; }

	public int? TechCostCenterRef { get; set; }

	[StringLength(250)]
	public string TechDepartmentName { get; set; }

	[StringLength(76)]
	public string TechPrimaryContactFullName { get; set; }

	[StringLength(76)]
	public string TechSecondaryContactFullName { get; set; }

	public DateTime? TerminationDate { get; set; }
	public DateTime? UpdateDate { get; set; }
	public int? UpdateUserRef { get; set; }

	[StringLength(100)]
	public string VendorName { get; set; }

	public int? VendorRef { get; set; }

	[Required]
	[StringLength(500)]
	public string VirtualDirectoryName { get; set; }

	[Required]
	[StringLength(100)]
	public string WikiUrl { get; set; }
}