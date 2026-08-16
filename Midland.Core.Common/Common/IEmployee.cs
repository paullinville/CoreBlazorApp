namespace Midland.Core.Common;

public interface IEmployee : IEmployeeSimple
{
	int? CostCenterNumber { get; set; }
	int? CostCenterRef { get; set; }
	string DepartmentCode { get; set; }
	int? DepartmentRef { get; set; }
	string DivisionCode { get; set; }
	int? DivisionRef { get; set; }
	int? EmployeeId { get; set; }
	string FaxNumber { get; set; }
	string LocationCode { get; set; }
	string LocationName { get; set; }
	string ManagerName { get; set; }
	int? ManagerUserRef { get; set; }
	string Title { get; set; }
	string UserId { get; set; }

	public static void Map(IEmployee fromData, IEmployee toData)
	{
		if (fromData == null || toData == null) return;
		IEmployeeSimple.Map(fromData, toData);

		toData.CostCenterNumber = fromData.CostCenterNumber;
		toData.CostCenterRef = fromData.CostCenterRef;
		toData.DepartmentCode = fromData.DepartmentCode;
		toData.DepartmentRef = fromData.DepartmentRef;
		toData.DivisionCode = fromData.DivisionCode;
		toData.DivisionRef = fromData.DivisionRef;
		toData.EmployeeId = fromData.EmployeeId;
		toData.FaxNumber = fromData.FaxNumber;
		toData.LocationCode = fromData.LocationCode;
		toData.LocationName = fromData.LocationName;
		toData.ManagerName = fromData.ManagerName;
		toData.ManagerUserRef = fromData.ManagerUserRef;
		toData.Title = fromData.Title;
		toData.UserId = fromData.UserId;
	}

	public void MapFrom(IEmployee fromData)
	{
		Map(fromData, this);
	}

	public void MapTo(IEmployee toData)
	{
		Map(this, toData);
	}
}