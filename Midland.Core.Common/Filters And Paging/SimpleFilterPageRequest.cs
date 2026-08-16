namespace Midland.Core.Common;

public class SimpleFilterPageRequest : PageRequestModel
{
	public SimpleFilterPageRequest()
	{ }

	public string Field { get; set; }
	public SortOrderField SortOrder { get; set; }
	public string Value { get; set; }
}