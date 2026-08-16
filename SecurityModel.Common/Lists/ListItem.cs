namespace SecurityModel.Common;

public class List
{
	public List()
	{
		Value = 0;
		Name = "-----";
	}

	public List(int? itmRef, string name)
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
		if (obj is List li)
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