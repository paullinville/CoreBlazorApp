using System;

namespace SecurityModel.Common.Interfaces;

public interface IContextType
{
	int ApplicationRef { get; set; }
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	string Name { get; set; }
	int ContextTypeRef { get; set; }

	public static void Map(IContextType fromData, IContextType toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.Name = fromData.Name + "";
		toData.ContextTypeRef = fromData.ContextTypeRef;
	}

	public void MapTo(IContextType toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IContextType fromData)
	{
		Map(fromData, this);
	}
}