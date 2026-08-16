using System;

namespace SecurityModel.Common.Interfaces;

public interface IAuditReport
{
	int ApplicationRef { get; set; }
	DateTime AuditCreateDate { get; set; }
	string AuditDescription { get; set; }
	string AuditDetail { get; set; }
	int AuditRef { get; set; }
	int UserRef { get; set; }

	public static void Map(IAuditReport fromData, IAuditReport toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.AuditCreateDate = fromData.AuditCreateDate;
		toData.AuditDescription = fromData.AuditDescription;
		toData.AuditDetail = fromData.AuditDetail + "";
		toData.AuditRef = fromData.AuditRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IAuditReport toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IAuditReport fromData)
	{
		Map(fromData, this);
	}
}