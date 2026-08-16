//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
using System.ComponentModel.DataAnnotations;
using EATTS.Common.Interfaces;

namespace EATTS.Common.Dto;

public class EntryDto : IEntry
{
	public EntryDto(IEntry values)
	{
		values?.MapTo(this);
	}

	public EntryDto()
	{ }

	public int EntryRef { get; set; }

	public int ErrorTypeRef { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(512)]
	public string GenericDescription { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(1024)]
	public string Key { get; set; }

	[Range(typeof(DateTime), "1/1/1753", "12/31/9999 11:59AM")]
	public DateTime? LastEntryOccurrenceDate { get; set; }

	public int LastEntryOccurrenceRef { get; set; }

	public int OccurrenceCount { get; set; }
}