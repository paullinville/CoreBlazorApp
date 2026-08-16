namespace Midland.Core.Common;

public class PageResultsModel<T> : IMidlandResult<List<T>>
{
	public PageResultsModel()
	{ }

	public PageResultsModel(List<T> values, PageRequestModel pageRequestModel, int count, int? max = null)
	{
		Set(values, pageRequestModel, count, max);
	}

	public PageResultsModel(List<T> values, IPageRequest pageRequestModel, int count, int? max = null)
	{
		Set(values, pageRequestModel, count, max);
	}

	public PageResultsModel(List<T> converted, PageInfoModel oldResults)
	{
		PageInfo = oldResults;
	}

	public List<string> Messages { get; set; }
	public PageInfoModel PageInfo { get; set; }
	public int ResultCount { get; set; }
	public List<T> Results { get; set; }

	public void Set(List<T> values, IPageRequest pageRequestModel, int count, int? max = null)
	{
		if (count < -1) count = 0;

		PageInfo = new PageInfoModel()
		{
			NumberOfRecords = count,
			PageNumber = Math.Abs(pageRequestModel.PageNumber),
			PageSize = pageRequestModel.Take(),
			NumberOfPages = (int)(pageRequestModel.Take() == 0 ? 0 : Math.Ceiling((decimal)count / (decimal)(pageRequestModel.Take()))),
			ResultLimit = max
		};
		ResultCount = values.Values().Count();
		PageInfo.PageNumber = Math.Min(PageInfo.PageNumber, PageInfo.NumberOfPages.Value);
		Results = values ?? new List<T>();
	}
}