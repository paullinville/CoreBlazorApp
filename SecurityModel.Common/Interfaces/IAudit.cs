using System;

namespace SecurityModel.Common.Interfaces;

public interface IAudit
{
	int ApplicationRef { get; set; }
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	string Detail { get; set; }
	int AuditRef { get; set; }
	int UserRef { get; set; }

	public static void Map(IAudit fromData, IAudit toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description;
		toData.Detail = fromData.Detail + "";
		toData.AuditRef = fromData.AuditRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IAudit toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IAudit fromData)
	{
		Map(fromData, this);
	}
}