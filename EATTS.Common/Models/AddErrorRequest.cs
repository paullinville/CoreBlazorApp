using System.ComponentModel.DataAnnotations;

namespace EATTS.Common.Models;

/// <param name="VirtualDirectory"></param>
/// <param name="Description"></param>
/// <param name="AdditionalDescription"></param>
/// <param name="UserRef"> The UserRef of the user that experienced the error. </param>
/// <param name="Location"> The page/route/end point that the error happened on. </param>
public record struct AddErrorRequest(
	[property: Required] string VirtualDirectory,
	[property: Required][property: Display(), MaxLength(500)] string Description,
	string AdditionalDescription,
	int? UserRef,


	[property: MaxLength(200)] string Location);//Location