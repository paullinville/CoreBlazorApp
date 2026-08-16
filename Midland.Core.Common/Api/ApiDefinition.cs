namespace Midland.Core.Api;

public class ApiDefinition
{
	public ApiDefinition()
	{
		ConsulPostfix = ApiConstants.DefaultConsulPostfix;
	}

	public ApiDefinition(string name) : this()
	{
		Name = name;
	}

	public ApiDefinition(string name, ApiOptions apiOptions) : this()
	{
		Name = name;
		BasePath = apiOptions.BasePath;
		RequestTimeout = apiOptions.RequestTimeout;
	}

	public ApiDefinition(string name, Application application) : this(name, application.ApiOptions)
	{
	}

	public string BasePath { get; set; }

	public string ConsulPostfix { get; set; }

	public List<EndPoint> EndPoints { get; set; }

	public List<Header> Headers { get; set; }

	public string Name { get; set; }

	public int? RequestTimeout { get; set; }

	public string Scheme { get; set; } = "http://";

	public string ConsulServiceQuery()
	{
		return $"{Name}{ConsulPostfix ?? ApiConstants.DefaultConsulPostfix}";
	}

	public override bool Equals(object obj) => obj is ApiDefinition api && api.Name == Name && api.BasePath == BasePath;

	public override int GetHashCode() => $"{BasePath}{Name}".GetHashCode();

	public override string ToString() => $"{Name}-{BasePath}";
}