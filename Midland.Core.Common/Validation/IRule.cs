using System.Net;

namespace Midland.Core.Validation;

public interface IRule
{
    string Description { get; set; }
    bool IsField { get; set; }
    string Name { get; set; }
    string SeverityName { get; set; }
    HttpStatusCode StatusCode { get; set; }
}