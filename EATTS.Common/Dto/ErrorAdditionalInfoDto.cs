using System;

namespace EATTS.Common.Dto;

public class ErrorAdditionalInfoDto : IErrorAdditionalInfo
{
	public ErrorAdditionalInfoDto(IErrorAdditionalInfo values)
	{
		values?.MapTo(this);
	}

	public ErrorAdditionalInfoDto()
	{ }

	public DateTime CreateDate { get; set; }

	public string Description { get; set; }

	public int ErrorAdditionalInfoRef { get; set; }

	public int? ErrorRef { get; set; }

	public int? UserRef { get; set; }
}