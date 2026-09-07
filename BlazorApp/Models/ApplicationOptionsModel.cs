using EATTS.Common.Models;
using EmployeeData.Common.Models;
using System.Linq;

namespace BlazorApp.Models;

public class ApplicationOptionsModel : ApplicationOptionsGetModel
{
    public ApplicationOptionsModel()
    { }

    public ApplicationOptionsModel(ApplicationOptionsGetModel values, IEnumerable<UserSelectModelExpanded> contacts)
    {
        ApiName = values.ApiName;
        ApplicationOptionsRef = values.ApplicationOptionsRef;
        EntryEmail = values.EntryEmail?.ToList() ?? new List<string>();

        SelectedContactUserRefs = contacts
            .Where(r => r is not null && EntryEmail.Contains(r.Email))
            .GroupBy(r => r.UserRef)
            .Select(g => g.Key)
            .ToList();
    }

    public List<int> SelectedContactUserRefs { get; set; } = new List<int>();
}
