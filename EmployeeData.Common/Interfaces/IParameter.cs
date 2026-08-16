namespace EmployeeData.Common.Interfaces;

public interface IParameter
{
	string Description { get; set; }
	string Name { get; set; }
	string Type { get; set; }
	string Value { get; set; }

	public static void Map(IParameter fromData, IParameter toData)
	{
		if (fromData == null || toData == null) return;
		toData.Name = fromData.Name;
		toData.Type = fromData.Type;
		toData.Value = fromData.Value;
		toData.Description = fromData.Description;
	}

	public void MapFrom(IParameter fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IParameter toData)
	{
		Map(this, toData);
	}
}