namespace Midland.Core.Common;

public class EattsEntryResultModel
{
	public int EntryRef { get; set; }
	public int OccurrenceRef { get; set; }
	public List<string> EmailedTo { get; set; }
}