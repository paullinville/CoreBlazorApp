namespace EATTS.Common.Interfaces;

public interface IPage
{
	short InfoLoadedFlag { get; set; }
	string Name { get; set; }
	string Path { get; set; }
	int PageRef { get; set; }

	public static void Map(IPage fromData, IPage toData)
	{
		if (fromData == null || toData == null) return;
		toData.InfoLoadedFlag = fromData.InfoLoadedFlag;
		toData.Name = fromData.Name + "";
		toData.Path = fromData.Path + "";
		toData.PageRef = fromData.PageRef;
	}

	public void MapTo(IPage toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IPage fromData)
	{
		Map(fromData, this);
	}
}