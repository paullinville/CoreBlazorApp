using System;

namespace EATTS.Common.Dto;

public class ErrorDocumentDto : IErrorDocument
{
	public ErrorDocumentDto(IErrorDocument values)
	{
		values?.MapTo(this);
	}

	public ErrorDocumentDto()
	{ }

	public DateTime CreateDate { get; set; }

	public string FileType { get; set; }

	public int ErrorDocumentRef { get; set; }

	public string Title { get; set; }

	public int? ErrorRef { get; set; }
}