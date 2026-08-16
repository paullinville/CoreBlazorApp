namespace Midland.Core.Common;

[AttributeUsage(AttributeTargets.Property)]
public class SortOrderAttribute : Attribute
{
	public SortOrderAttribute()
	{
	}

	public SortOrderAttribute(string field)
	{
		Field = field;
	}

	public SortOrderAttribute(string field, int order)
	{
		Field = field;
		Order = order;
	}

	public SortOrderAttribute(string field, int order, bool asc)
	{
		Field = field;
		Order = order;
		Asc = asc;
	}

	public bool Asc { get; set; }
	public string Field { get; set; }
	public int Order { get; set; }
}