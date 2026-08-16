namespace Midland.Core.Common;

/// <summary>
/// Comparer that sorts GUIDs the same way SQL Server does.
/// </summary>
public class SqlSequentialGuidComparer : IComparer<Guid>
{
	// SQL Server byte order for uniqueidentifier sorting
	private static readonly int[] SqlOrderMap =
	{
			10, 11, 12, 13, 14, 15, 8, 9,
			6, 7, 4, 5, 0, 1, 2, 3
		};

	public int Compare(Guid x, Guid y)
	{
		byte[] xb = x.ToByteArray();
		byte[] yb = y.ToByteArray();

		for (int i = 0; i < 16; i++)
		{
			int xi = xb[SqlOrderMap[i]];
			int yi = yb[SqlOrderMap[i]];

			if (xi != yi)
				return xi.CompareTo(yi);
		}
		return 0;
	}
}