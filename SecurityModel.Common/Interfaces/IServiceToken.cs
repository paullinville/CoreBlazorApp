using System;

namespace SecurityModel.Common.Interfaces;

public interface IServiceToken
{
	bool Active { get; set; }
	string Body { get; set; }
	DateTime Created { get; set; }
	int CreatedBy { get; set; }
	string Description { get; set; }
	Guid Id { get; set; }
	string Name { get; set; }

	public static void Map(IServiceToken fromData, IServiceToken toData)
	{
		if (fromData == null || toData == null) return;
		toData.Active = fromData.Active;
		toData.Body = fromData.Body;
		toData.Created = fromData.Created;
		toData.CreatedBy = fromData.CreatedBy;
		toData.Description = fromData.Description;
		toData.Id = fromData.Id;
		toData.Name = fromData.Name;
	}

	public void MapTo(IServiceToken toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IServiceToken fromData)
	{
		Map(fromData, this);
	}
}