using System;

namespace EATTS.Common.Interfaces;

public interface IErrorDocument
{
	DateTime CreateDate { get; set; }
	string FileType { get; set; }
	int ErrorDocumentRef { get; set; }
	string Title { get; set; }
	int? ErrorRef { get; set; }

	public static void Map(IErrorDocument fromData, IErrorDocument toData)
	{
		if (fromData == null || toData == null) return;
		toData.CreateDate = fromData.CreateDate;
		toData.FileType = fromData.FileType + "";
		toData.ErrorDocumentRef = fromData.ErrorDocumentRef;
		toData.Title = fromData.Title + "";
		toData.ErrorRef = fromData.ErrorRef;
	}

	public void MapTo(IErrorDocument toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IErrorDocument fromData)
	{
		Map(fromData, this);
	}
}