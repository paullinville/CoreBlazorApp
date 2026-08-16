namespace EmployeeData.Common;

public class ListItem
{
	public ListItem()
	{
		Value = 0;
		Name = "-----";
	}

	public ListItem(int? itmRef, string name)
	{
		Value = itmRef.GetValueOrDefault(0);
		Name = name;
		Selected = true;
	}

	public int Value { get; set; }
	public string Name { get; set; }
	public bool Selected { get; set; }

	public override string ToString()
	{
		return Value.ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj is ListItem li)
		{
			return li.Value == Value;
		}

		return false;
	}

	public override int GetHashCode()
	{
		return Value;
	}
}