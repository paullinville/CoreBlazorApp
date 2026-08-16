using System;

namespace SecurityModel.Common.Interfaces;

public interface IContext
{
	int ApplicationContextRef { get; set; }
	int ApplicationRef { get; set; }
	DateTime CreateDate { get; set; }
	int ContextRef { get; set; }
	int TypeRef { get; set; }

	public static void Map(IContext fromData, IContext toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationContextRef = fromData.ApplicationContextRef;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.CreateDate = fromData.CreateDate;
		toData.ContextRef = fromData.ContextRef;
		toData.TypeRef = fromData.TypeRef;
	}

	public void MapTo(IContext toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IContext fromData)
	{
		Map(fromData, this);
	}
}