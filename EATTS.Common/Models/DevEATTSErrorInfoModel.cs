using System;
using System.ComponentModel.DataAnnotations;

namespace EATTS.Common.Models;

public class DevEATTSErrorInfoModel : IDevEATTSErrorInfo
{
	public DevEATTSErrorInfoModel()
	{ }

	public DevEATTSErrorInfoModel(IDevEATTSErrorInfo values)
	{
		values?.MapTo(this);
	}

	[Required]
	[StringLength(50)]
	public string ApplicationDescription { get; set; }

	public int? ApplicationRef { get; set; }

	[Required]
	[StringLength(250)]
	public string ApplicationVirtualDirectory { get; set; }

	[StringLength(2147483647)]
	public string ErrorAdditionalDescription { get; set; }

	[Required]
	[StringLength(250)]
	public string ErrorCategoryDescription { get; set; }

	public int? ErrorCategoryRef { get; set; }
	public DateTime? ErrorCloseDate { get; set; }
	public DateTime ErrorCreateDate { get; set; }

	[Required]
	[StringLength(500)]
	public string ErrorDescription { get; set; }

	[StringLength(50)]
	public string ErrorErrorNumber { get; set; }

	public int? ErrorImportanceRef { get; set; }
	public int? ErrorInputUserRef { get; set; }
	public short ErrorIsActiveFlag { get; set; }
	public short ErrorIsStrikeFlag { get; set; }

	[Required]
	[StringLength(200)]
	public string ErrorPage { get; set; }

	public int? ErrorPrimaryContactUserRef { get; set; }
	public int ErrorRef { get; set; }

	[Required]
	[StringLength(2000)]
	public string ErrorResolutionDescription { get; set; }

	public int? ErrorSecondaryContactUserRef { get; set; }

	[Required]
	[StringLength(2000)]
	public string ErrorStatusAdditionalDescription { get; set; }

	[Required]
	[StringLength(50)]
	public string ErrorStatusDescription { get; set; }

	public int? ErrorStatusRef { get; set; }

	[Required]
	[StringLength(50)]
	public string ErrorTypeDescription { get; set; }

	public int? ErrorTypeRef { get; set; }
}