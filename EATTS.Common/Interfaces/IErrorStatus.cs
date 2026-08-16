//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;

namespace EATTS.Common.Interfaces;

public interface IErrorStatus
{
	string AdditionalDescription { get; set; }
	string Description { get; set; }
	int ErrorStatusRef { get; set; }
	short IsActiveFlag { get; set; }

	public static void Map(IErrorStatus fromData, IErrorStatus toData)
	{
		if (fromData == null || toData == null) return;
		toData.AdditionalDescription = fromData.AdditionalDescription;
		toData.Description = fromData.Description;
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.ErrorStatusRef = fromData.ErrorStatusRef;
	}

	public void MapFrom(IErrorStatus fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IErrorStatus toData)
	{
		Map(this, toData);
	}

	public void Update(IErrorStatus fromData)
	{
		var currentRef = this.ErrorStatusRef;
		Map(fromData, this);
		this.ErrorStatusRef = currentRef;
	}
}