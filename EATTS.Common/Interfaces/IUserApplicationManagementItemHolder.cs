using System;

namespace EATTS.Common.Interfaces;

public interface IUserApplicationManagementItemHolder
{
	int? ApplicationManagementItemRef { get; set; }
	int ColumnNumber { get; set; }
	DateTime CreateDate { get; set; }
	string ImageType { get; set; }
	int UserApplicationManagementItemHolderRef { get; set; }
	int TablePosition { get; set; }
	int? UserRef { get; set; }

	public static void Map(IUserApplicationManagementItemHolder fromData, IUserApplicationManagementItemHolder toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationManagementItemRef = fromData.ApplicationManagementItemRef;
		toData.ColumnNumber = fromData.ColumnNumber;
		toData.CreateDate = fromData.CreateDate;
		toData.ImageType = fromData.ImageType + "";
		toData.UserApplicationManagementItemHolderRef = fromData.UserApplicationManagementItemHolderRef;
		toData.TablePosition = fromData.TablePosition;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IUserApplicationManagementItemHolder toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IUserApplicationManagementItemHolder fromData)
	{
		Map(fromData, this);
	}
}