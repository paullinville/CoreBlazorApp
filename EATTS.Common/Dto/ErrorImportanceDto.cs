namespace EATTS.Common.Dto;

public class ErrorImportanceDto : IErrorImportance
{
	public ErrorImportanceDto(IErrorImportance values)
	{
		values?.MapTo(this);
	}

	public ErrorImportanceDto()
	{ }

	public string AdditionalDescription { get; set; }

	public string Description { get; set; }

	public short IsActiveFlag { get; set; }

	public int ErrorImportanceRef { get; set; }
}