namespace Midland.Core.Api;

public class Header
{
	public string Name { get; set; }
	public string Value { get; set; }

	public override bool Equals(object obj)
	{
		if (obj is Header hdr)
		{
			return hdr.Name == Name;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}

	public override string ToString()
	{
		return Name;
	}
}