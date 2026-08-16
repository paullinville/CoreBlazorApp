namespace Midland.Core.Common;

public interface IMidlandResult
{
	List<string> Messages { get; set; }
}

public interface IMidlandResult<T> : IMidlandResult
{
	PageInfoModel PageInfo { get; set; }
	T Results { get; set; }
}