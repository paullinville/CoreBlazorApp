using System;

namespace EATTS.Common.Interfaces;

public interface IUserManagementItemHolder
{
	int? ManagementItemRef { get; set; }
	int ColumnNumber { get; set; }
	DateTime CreateDate { get; set; }
	string ImageType { get; set; }
	int UserManagementItemHolderRef { get; set; }
	int TablePosition { get; set; }
	int? UserRef { get; set; }

	public static void Map(IUserManagementItemHolder fromData, IUserManagementItemHolder toData)
	{
		if (fromData == null || toData == null) return;
		toData.ManagementItemRef = fromData.ManagementItemRef;
		toData.ColumnNumber = fromData.ColumnNumber;
		toData.CreateDate = fromData.CreateDate;
		toData.ImageType = fromData.ImageType + "";
		toData.UserManagementItemHolderRef = fromData.UserManagementItemHolderRef;
		toData.TablePosition = fromData.TablePosition;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IUserManagementItemHolder toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IUserManagementItemHolder fromData)
	{
		Map(fromData, this);
	}
}