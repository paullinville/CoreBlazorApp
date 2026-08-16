using EATTS.Common.Models;
using SecurityModel.Common.Models;

namespace BlazorApp.Data;

public interface ISecurityModelApiRepository
{
    Task<List<ApplicationSummary>> GetApplications();
}