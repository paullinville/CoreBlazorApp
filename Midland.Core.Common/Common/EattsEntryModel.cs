using System.ComponentModel.DataAnnotations;

namespace Midland.Core.Common;

/// <summary>
///
/// </summary>
/// <param name="ApplicationInventoryRef"></param>
/// <param name="Origin"></param>
/// <param name="Key"></param>
/// <param name="UserRef"></param>
/// <param name="CallerId"></param>
/// <param name="ErrorResponse"></param>
public record struct
	EattsEntryModel(
	//Application Inventory application to use for tech support contact.
	int? ApplicationInventoryRef,
	//The origin of the EATTS error. Typically the name of the system making the call.
	string Origin,
	///Unique value to record the error under.
	[property: Required] string Key,
	//Current users Ref. May be null if non-human.
	//API calls may have the UserRef of the original call.
	int? UserRef,
	//Used to identify the non-human service/api recording the error.
	string CallerId,
	//The Detail of the error.
	ErrorResponse ErrorResponse);