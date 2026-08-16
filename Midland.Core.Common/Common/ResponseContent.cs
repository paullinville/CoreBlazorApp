namespace Midland.Core.Common;

public class ResponseContent<T> : ResponseContentBase
{
	public T Content { get; set; }
}