using System;

namespace EATTS.Common.Dto;

public class DevEATTSErrorInfoDto : IDevEATTSErrorInfo
{
	public DevEATTSErrorInfoDto(IDevEATTSErrorInfo values)
	{
		values?.MapTo(this);
	}

	public DevEATTSErrorInfoDto()
	{ }

	public string ApplicationDescription { get; set; }

	public int? ApplicationRef { get; set; }

	public string ApplicationVirtualDirectory { get; set; }

	public string ErrorAdditionalDescription { get; set; }

	public string ErrorCategoryDescription { get; set; }

	public int? ErrorCategoryRef { get; set; }

	public DateTime? ErrorCloseDate { get; set; }

	public DateTime ErrorCreateDate { get; set; }

	public string ErrorDescription { get; set; }

	public string ErrorErrorNumber { get; set; }

	public int? ErrorImportanceRef { get; set; }

	public int? ErrorInputUserRef { get; set; }

	public short ErrorIsActiveFlag { get; set; }

	public short ErrorIsStrikeFlag { get; set; }

	public string ErrorPage { get; set; }

	public int? ErrorPrimaryContactUserRef { get; set; }

	public int ErrorRef { get; set; }

	public string ErrorResolutionDescription { get; set; }

	public int? ErrorSecondaryContactUserRef { get; set; }

	public string ErrorStatusAdditionalDescription { get; set; }

	public string ErrorStatusDescription { get; set; }

	public int? ErrorStatusRef { get; set; }

	public string ErrorTypeDescription { get; set; }

	public int? ErrorTypeRef { get; set; }
}