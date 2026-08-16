using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EATTS.Common.Models;

public class SupportOptionsEditModel
{
	public SupportOptionsEditModel()
	{ }

	public SupportOptionsEditModel(ISupportOptions values)
	{
		if (values == null) return;
		EmailSubject = values.EmailSubject + "";
		EmailTemplate = values.EmailTemplate + "";
		FloodCount = values.FloodCount;
		FloodTime = values.FloodTime;
		OtherEmail = values.OtherEmail.Split(";").ToList();
	}

	[Required(AllowEmptyStrings = true)]
	[StringLength(256)]
	public string EmailSubject { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(2147483647)]
	public string EmailTemplate { get; set; }

	[Range(1, int.MaxValue)]
	public int FloodCount { get; set; }

	[Range(1, int.MaxValue)]
	public int FloodTime { get; set; }

	public List<string> OtherEmail { get; set; }
}