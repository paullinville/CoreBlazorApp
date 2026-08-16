namespace Midland.Core.Common;

public class PageInfoModel : PageRequestModel
{
	public int? NumberOfPages { get; set; }

	public int? NumberOfRecords { get; set; }

	public int? ResultLimit { get; set; }
}