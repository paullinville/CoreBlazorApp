using System;

namespace EATTS.Common.Dto;

public class ErrorDto : IError
{
	public ErrorDto(IError values)
	{
		values?.MapTo(this);
	}

	public ErrorDto()
	{ }

	public int? ApplicationRef { get; set; }

	public string AdditionalDescription { get; set; }

	public int? CategoryRef { get; set; }

	public DateTime? CloseDate { get; set; }

	public DateTime CreateDate { get; set; }

	public string Description { get; set; }

	public string Number { get; set; }

	public int? ImportanceRef { get; set; }

	public int? InputUserRef { get; set; }

	public short IsActiveFlag { get; set; }

	public short IsStrikeFlag { get; set; }

	public string Page { get; set; }

	public int? PrimaryContactUserRef { get; set; }

	public int ErrorRef { get; set; }

	public string ResolutionDescription { get; set; }

	public int? SecondaryContactUserRef { get; set; }

	public int? StatusRef { get; set; }

	public int? TypeRef { get; set; }
}