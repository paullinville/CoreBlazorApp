namespace EATTS.Common.Dto;

public class PageDto : IPage
{
	public PageDto(IPage values)
	{
		values?.MapTo(this);
	}

	public PageDto()
	{ }

	public short InfoLoadedFlag { get; set; }

	public string Name { get; set; }

	public string Path { get; set; }

	public int PageRef { get; set; }
}