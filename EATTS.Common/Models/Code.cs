using Midland.Core.Common;

namespace EATTS.Common.Models;

public class Code : ICode
{
	public int CodeRef { get; set; }
	public string Name { get; set; }
}