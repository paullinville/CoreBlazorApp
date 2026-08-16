using System.ComponentModel.DataAnnotations;

namespace Midland.Core.Common;

public class PageRequestModel : IPageRequest
{
	public PageRequestModel()
	{ }

	public PageRequestModel(PageRequestModel model)
	{
		PageNumber = model.PageNumber;
		PageSize = model.PageSize;
	}

	[Required(), SortAndFilterIgnoreAttribute]
	public int PageNumber { get; set; }

	[Required(), SortAndFilterIgnoreAttribute]
	public int PageSize { get; set; }

	public int Skip()
	{
		return Math.Abs(PageSize * Math.Max(PageNumber - 1, 0));
	}

	public int Take()
	{
		return Math.Abs(PageSize);
	}
}