namespace EmployeeData.Common.Dto;

public class ParameterDto : IParameter
{
	public ParameterDto(IParameter values)
	{
		values?.MapTo(this);
	}

	public ParameterDto()
	{ }

	public string Description { get; set; }
	public string Name { get; set; }
	public string Type { get; set; }
	public string Value { get; set; }
}