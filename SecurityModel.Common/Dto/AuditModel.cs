using SecurityModel.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Dto;

public class AuditModel : IAudit
{
	public AuditModel()
	{ }

	public AuditModel(IAudit values)
	{
		values?.MapTo(this);
		if (values.Detail.IsNotEmpty())
		{
			try
			{
				AuditData = AuditJson.DeserializeAuditDynamic(values.Detail);
			}
			catch
			{
			}
		}
		else
		{
		}
	}

	public int ApplicationRef { get; set; }

	public object AuditData { get; set; }

	public int AuditRef { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime CreateDate { get; set; }

	[StringLength(2147483647)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string Detail { get; set; }

	public int UserRef { get; set; }

	public AuditData<T> GetAuditData<T>()
	{
		return (AuditData<T>)AuditData;
	}
}