namespace Midland.Core.Common;

public interface IPageRequest
{
	int PageNumber { get; set; }
	int PageSize { get; set; }

	int Skip();
	int Take();
}