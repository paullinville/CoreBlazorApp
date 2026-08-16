using Midland.Core.Common;
using Midland.Core.Validation;
using System.Collections.Generic;

namespace EATTS.Common.Interfaces;

public interface IValidationRepository : IValidationData
{
	bool ErrorCategoriesInUse(int errorCatRef);

	bool ErrorExists(int errorRef);

	bool ErrorImportanceInUse(int Ref);

	bool ErrorStatusInUse(int errorStatusRef);

	bool ErrorTypeInUse(int ErrorTypeRef);

	IApplication GetApplication(string slug);

	IEnumerable<IApplicationOptions> GetApplicationOptions(string slug);
	IEntry GetEntry(int entryRef);
	IEnumerable<IErrorCategory> GetErrorCategories();

	IEnumerable<IErrorImportance> GetErrorImportance();

	IEnumerable<IErrorStatus> GetErrorStatuses();

	IEnumerable<IErrorType> GetErrorTypes();
	ISupportOptionsOverride GetSupportOptionOverride(int supportOptionsOverrideRef);
	IEnumerable<ISupportOptionsOverride> GetSupportOptionOverrideForEntry(int entryRef);
	IMidlandUser GetUserByEmail(string email);
}