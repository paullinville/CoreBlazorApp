using System;

namespace EATTS.Common.Interfaces;

public interface IDevEATTSErrorInfo
{
	string ApplicationDescription { get; set; }
	int? ApplicationRef { get; set; }
	string ApplicationVirtualDirectory { get; set; }
	string ErrorAdditionalDescription { get; set; }
	string ErrorCategoryDescription { get; set; }
	int? ErrorCategoryRef { get; set; }
	DateTime? ErrorCloseDate { get; set; }
	DateTime ErrorCreateDate { get; set; }
	string ErrorDescription { get; set; }
	string ErrorErrorNumber { get; set; }
	int? ErrorImportanceRef { get; set; }
	int? ErrorInputUserRef { get; set; }
	short ErrorIsActiveFlag { get; set; }
	short ErrorIsStrikeFlag { get; set; }
	string ErrorPage { get; set; }
	int? ErrorPrimaryContactUserRef { get; set; }
	int ErrorRef { get; set; }
	string ErrorResolutionDescription { get; set; }
	int? ErrorSecondaryContactUserRef { get; set; }
	string ErrorStatusAdditionalDescription { get; set; }
	string ErrorStatusDescription { get; set; }
	int? ErrorStatusRef { get; set; }
	string ErrorTypeDescription { get; set; }
	int? ErrorTypeRef { get; set; }

	public static void Map(IDevEATTSErrorInfo fromData, IDevEATTSErrorInfo toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationDescription = fromData.ApplicationDescription + "";
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.ApplicationVirtualDirectory = fromData.ApplicationVirtualDirectory + "";
		toData.ErrorAdditionalDescription = fromData.ErrorAdditionalDescription;
		toData.ErrorCategoryDescription = fromData.ErrorCategoryDescription + "";
		toData.ErrorCategoryRef = fromData.ErrorCategoryRef;
		toData.ErrorCloseDate = fromData.ErrorCloseDate;
		toData.ErrorCreateDate = fromData.ErrorCreateDate;
		toData.ErrorDescription = fromData.ErrorDescription + "";
		toData.ErrorErrorNumber = fromData.ErrorErrorNumber;
		toData.ErrorImportanceRef = fromData.ErrorImportanceRef;
		toData.ErrorInputUserRef = fromData.ErrorInputUserRef;
		toData.ErrorIsActiveFlag = fromData.ErrorIsActiveFlag;
		toData.ErrorIsStrikeFlag = fromData.ErrorIsStrikeFlag;
		toData.ErrorPage = fromData.ErrorPage + "";
		toData.ErrorPrimaryContactUserRef = fromData.ErrorPrimaryContactUserRef;
		toData.ErrorRef = fromData.ErrorRef;
		toData.ErrorResolutionDescription = fromData.ErrorResolutionDescription + "";
		toData.ErrorSecondaryContactUserRef = fromData.ErrorSecondaryContactUserRef;
		toData.ErrorStatusAdditionalDescription = fromData.ErrorStatusAdditionalDescription + "";
		toData.ErrorStatusDescription = fromData.ErrorStatusDescription + "";
		toData.ErrorStatusRef = fromData.ErrorStatusRef;
		toData.ErrorTypeDescription = fromData.ErrorTypeDescription + "";
		toData.ErrorTypeRef = fromData.ErrorTypeRef;
	}

	public void MapTo(IDevEATTSErrorInfo toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IDevEATTSErrorInfo fromData)
	{
		Map(fromData, this);
	}
}