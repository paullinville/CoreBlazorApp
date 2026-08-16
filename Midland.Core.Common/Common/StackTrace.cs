namespace Midland.Core.Common;

public class StackTrace : List<string>
{
	public StackTrace()
	{ }

	public StackTrace(IEnumerable<string> message)
	{
		AddRange(message.Values());
	}

	public StackTrace(string message)
	{
		if (message != null)
		{
			AddRange(message.Split("\r\n"));
		}
	}

	public StackTrace(Exception ex)
	{
		if (ex?.StackTrace != null)
		{
			AddRange(ex.StackTrace.Split("\r\n"));
		}
	}

	public List<string> Lines { get; set; }
}