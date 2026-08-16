namespace Midland.Core.Api;

public class EndPoint
{
    public EndPoint()
    {
        Headers = new List<Header>();
    }

    public string ApiName { get; private set; }
    public List<Header> Headers { get; set; }

    public string Method { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Scheme { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is EndPoint ep)
        {
            return ep.Name == Name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return $"{ApiName}:{Name}".GetHashCode();
    }

    //PUT, POST, GET, DELETE
    public void SetApi(ApiDefinition api)
    {
        ApiName = api.Name;

        if (Scheme.IsNullOrBlank())
        {
            Scheme = api.Scheme.IsNullOrBlank(ApiConstants.DefaultScheme);
        }

        if (api.Headers.IsNotEmpty())
        {
            if (Headers.IsEmpty())
            {
                Headers = api.Headers;
            }
            else
            {
                Headers = Headers.Union(api.Headers).ToList();
            }
        }
    }

    public override string ToString()
    {
        return $"{Name}-{Path}";
    }
}