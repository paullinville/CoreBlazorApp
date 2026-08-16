namespace EATTS.Common.Interfaces;

public interface IErrorImportance
{
	string AdditionalDescription { get; set; }
	string Description { get; set; }
	short IsActiveFlag { get; set; }
	int ErrorImportanceRef { get; set; }

	public static void Map(IErrorImportance fromData, IErrorImportance toData)
	{
		if (fromData == null || toData == null) return;
		toData.AdditionalDescription = fromData.AdditionalDescription + "";
		toData.Description = fromData.Description + "";
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.ErrorImportanceRef = fromData.ErrorImportanceRef;
	}

	public void MapTo(IErrorImportance toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorImportance fromData)
	{
		Map(fromData, this);
	}
}