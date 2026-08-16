namespace Midland.Core.Common;

public class MidlandResult<T> : IMidlandResult<T>
{
	public MidlandResult()
	{ }

	public MidlandResult(T result)
	{
		Results = result;
	}

	public PageInfoModel PageInfo { get; set; }
	public List<string> Messages { get; set; }
	public T Results { get; set; }
}