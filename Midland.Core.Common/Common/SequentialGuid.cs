namespace Midland.Core.Common;

public class SequentialGuid
{
	private const int RPC_OK = 0;

	private static int[] _SqlOrderMap = null;

	private static int[] SqlOrderMap
	{
		get
		{
			_SqlOrderMap ??= new int[] { 3, 2, 1, 0, 5, 4, 7, 6, 9, 8, 15, 14, 13, 12, 11, 10 };
			return _SqlOrderMap;
		}
	}

	/// <summary>
	/// Initialises a new instance of the System.Guid class using the algorithm provided by UuidCreateSequential
	/// </summary>
	/// <returns>A Globally Unique Identifier</returns>
	public static Guid NewDotNet()
	{
		Guid sequentialguid = new Guid();
		int hr = UuidCreateSequential(ref sequentialguid);
		if ((hr != RPC_OK)) throw new ApplicationException(string.Format("UuidCreateSequential failed: {0}", hr));
		return sequentialguid;
	}

	public static Guid NewSql()
	{
		return SetSortOrder(NewDotNet());
	}

	private static Guid SetSortOrder(Guid Guid)
	{
		byte[] bytes = Guid.ToByteArray();
		byte[] copy_bytes = new byte[16];
		bytes.CopyTo(copy_bytes, 0);
		int mapIndex = 0;
		while ((mapIndex < 10))
		{
			bytes[mapIndex] = copy_bytes[SqlOrderMap[mapIndex]];
			mapIndex = (mapIndex + 1);
		}
		Guid = new Guid(bytes);
		return Guid;
	}

	[System.Runtime.InteropServices.DllImport("rpcrt4.dll")]
	private static extern int UuidCreateSequential(ref Guid guid);
}