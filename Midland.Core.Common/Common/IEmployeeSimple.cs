namespace Midland.Core.Common;

public interface IEmployeeSimple
{
    public bool Active { get => Status?.Equals(IMidlandUser.ActiveValue, StringComparison.OrdinalIgnoreCase) ?? false; }
    string CostCenterCode { get; set; }
    string CostCenterName { get; set; }
    string DepartmentName { get; set; }
    string DivisionName { get; set; }
    string Email { get; set; }
    string FirstName { get; set; }
    string FullName { get; set; }
    string LastName { get; set; }
    string LastNameFirst { get; set; }
    string LastNameFirstTermDate { get; set; }
    string PhoneNumber { get; set; }
    string Status { get; set; }
    int UserRef { get; set; }

    public static void Map(IEmployeeSimple fromData, IEmployeeSimple toData)
    {
        if (fromData == null || toData == null) return;
        toData.CostCenterCode = fromData.CostCenterCode;
        toData.CostCenterName = fromData.CostCenterName;
        toData.DepartmentName = fromData.DepartmentName;
        toData.DivisionName = fromData.DivisionName;
        toData.Email = fromData.Email;
        toData.FirstName = fromData.FirstName;
        toData.FullName = fromData.FullName;
        toData.LastName = fromData.LastName;
        toData.LastNameFirst = fromData.LastNameFirst;
        toData.LastNameFirstTermDate = fromData.LastNameFirstTermDate;
        toData.PhoneNumber = fromData.PhoneNumber;
        toData.Status = fromData.Status;
        toData.UserRef = fromData.UserRef;
    }

    public void MapFrom(IEmployeeSimple fromData)
    {
        Map(fromData, this);
    }

    public void MapTo(IEmployeeSimple toData)
    {
        Map(this, toData);
    }
}