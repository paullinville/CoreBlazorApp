using EmployeeData.Common.Dto;

namespace EmployeeData.Common.Models;

public class ParameterDeleteModel
{ public string ParameterName { get; set; } }

public class ParameterEditModel
{
	public ParameterEditModel()
	{ }

	public ParameterEditModel(IParameter values)
	{
		if (values == null) return;
		Name = values.Name;
		Value = values.Value;
		Type = values.Type;
		Description = values.Description;
	}

	public string Description { get; set; }

	public string Name { get; set; }

	public string Type { get; set; }

	public string Value { get; set; }

	public virtual ParameterDto CreateDto()
	{
		var createdItem = new ParameterDto();
		createdItem.Name = Name;
		createdItem.Value = Value;
		createdItem.Type = Type;
		createdItem.Description = Description;
		return createdItem;
	}
}