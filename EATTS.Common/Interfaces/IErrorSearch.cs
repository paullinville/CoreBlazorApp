//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IErrorSearch
{

    string ApplicationDescription { get; set; }
    int? ApplicationRef { get; set; }
    string ApplicationVirtualDirectory { get; set; }
    string ErrorAdditionalDescription { get; set; }
    int? ErrorCategoryRef { get; set; }
    DateTime? ErrorCloseDate { get; set; }
    int? ErrorCount { get; set; }
    DateTime ErrorCreateDate { get; set; }
    string ErrorDescription { get; set; }
    string ErrorErrorNumber { get; set; }
    string ErrorImportanceAdditionalDescription { get; set; }
    string ErrorImportanceDescription { get; set; }
    short ErrorImportanceIsActiveFlag { get; set; }
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
    short ErrorStatusIsActiveFlag { get; set; }
    int? ErrorStatusRef { get; set; }
    string ErrorTypeDescription { get; set; }
    short ErrorTypeIsActiveFlag { get; set; }
    int? ErrorTypeRef { get; set; }
    DateTime? LastOccurenceDate { get; set; }

    public static void Map(IErrorSearch fromData, IErrorSearch toData)
    {
        if (fromData == null || toData == null) return;
        toData.ApplicationDescription = fromData.ApplicationDescription;
        toData.ApplicationRef = fromData.ApplicationRef;
        toData.ApplicationVirtualDirectory = fromData.ApplicationVirtualDirectory;
        toData.ErrorAdditionalDescription = fromData.ErrorAdditionalDescription;
        toData.ErrorCategoryRef = fromData.ErrorCategoryRef;
        toData.ErrorCloseDate = fromData.ErrorCloseDate;
        toData.ErrorCount = fromData.ErrorCount;
        toData.ErrorCreateDate = fromData.ErrorCreateDate;
        toData.ErrorDescription = fromData.ErrorDescription;
        toData.ErrorErrorNumber = fromData.ErrorErrorNumber;
        toData.ErrorImportanceAdditionalDescription = fromData.ErrorImportanceAdditionalDescription;
        toData.ErrorImportanceDescription = fromData.ErrorImportanceDescription;
        toData.ErrorImportanceIsActiveFlag = fromData.ErrorImportanceIsActiveFlag;
        toData.ErrorImportanceRef = fromData.ErrorImportanceRef;
        toData.ErrorInputUserRef = fromData.ErrorInputUserRef;
        toData.ErrorIsActiveFlag = fromData.ErrorIsActiveFlag;
        toData.ErrorIsStrikeFlag = fromData.ErrorIsStrikeFlag;
        toData.ErrorPage = fromData.ErrorPage;
        toData.ErrorPrimaryContactUserRef = fromData.ErrorPrimaryContactUserRef;
        toData.ErrorRef = fromData.ErrorRef;
        toData.ErrorResolutionDescription = fromData.ErrorResolutionDescription;
        toData.ErrorSecondaryContactUserRef = fromData.ErrorSecondaryContactUserRef;
        toData.ErrorStatusAdditionalDescription = fromData.ErrorStatusAdditionalDescription;
        toData.ErrorStatusDescription = fromData.ErrorStatusDescription;
        toData.ErrorStatusIsActiveFlag = fromData.ErrorStatusIsActiveFlag;
        toData.ErrorStatusRef = fromData.ErrorStatusRef;
        toData.ErrorTypeDescription = fromData.ErrorTypeDescription;
        toData.ErrorTypeIsActiveFlag = fromData.ErrorTypeIsActiveFlag;
        toData.ErrorTypeRef = fromData.ErrorTypeRef;
        toData.LastOccurenceDate = fromData.LastOccurenceDate;
    }

    public void MapTo(IErrorSearch toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IErrorSearch fromData)
    {
        Map(fromData, this);
    }

}