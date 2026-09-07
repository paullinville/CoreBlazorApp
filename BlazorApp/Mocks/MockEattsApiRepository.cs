using BlazorApp.Models;
using EATTS.Common.Models;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace BlazorApp.Data;

public class MockEattsRepository : IEattsApiRepository
{
    private readonly IEventChannelBus _eventBus;
    private static int _nextApplicationOptionRef = 3;
    private static int _nextContactRef = 3;

    public MockEattsRepository(IEventChannelBus eventBus)
    {
        _eventBus = eventBus;
    }

    private static readonly List<ApplicationOptionsGetModel> ApplicationOptions =
    [
        new ApplicationOptionsGetModel
        {
            ApplicationOptionsRef = 1,
            ApiName = "core-app",
            EntryEmail = GetRandomEntryEmails(2, 3)
        },
        new ApplicationOptionsGetModel
        {
            ApplicationOptionsRef = 2,
            ApiName = "admin-app",
            EntryEmail = GetRandomEntryEmails(1, 2)
        }
    ];

    private static readonly List<ContactModel> Contacts =
    [
        new ContactModel
        {
            SupportDefaultContactRef = 1,
            UserRef = 1001,
            Order = 1,
            Active = true,
            FullName = "Alex Carter"
        },
        new ContactModel
        {
            SupportDefaultContactRef = 2,
            UserRef = 1002,
            Order = 2,
            Active = true,
            FullName = "Jordan Lee"
        }
    ];

    private static List<string> GetRandomEntryEmails(int minCount, int maxCount)
    {
        var emailPool = MockEmployeeRepository.MockSelectionUsers
            .Select(x => x.Email)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (emailPool.Count == 0)
        {
            return new List<string>();
        }

        var safeMin = Math.Max(1, minCount);
        var safeMax = Math.Min(Math.Max(safeMin, maxCount), emailPool.Count);
        var takeCount = Random.Shared.Next(safeMin, safeMax + 1);

        return emailPool
            .OrderBy(_ => Random.Shared.Next())
            .Take(takeCount)
            .ToList();
    }

    private static readonly List<EntrySummaryModel> Entries =
    [
        new EntrySummaryModel
        {
            EntryRef = 100,
            EntryOccurrenceRef = 1001,
            LastEntryOccurrenceRef = 1001,
            OccurrenceCount = 2,
            Description = "API timeout while retrieving profile",
            OccurrenceDescription = "Timeout after 30 seconds",
            LastOccurrenceDescription = "Timeout after 30 seconds",
            Origin = "CoreBlazorApp",
            CallerId = "api-service",
            Key = "TIMEOUT-PROFILE",
            Subject = "core-app",
            SubjectType = "Api",
            UserRef = 1001,
            IsError = true,
            OccurrenceDate = DateTime.UtcNow.AddMinutes(-20),
            LastOccurrenceDate = DateTime.UtcNow.AddMinutes(-5),
            RequestId = Guid.Parse("11111111-1111-1111-1111-111111111111")
        },
        new EntrySummaryModel
        {
            EntryRef = 101,
            EntryOccurrenceRef = 1011,
            LastEntryOccurrenceRef = 1011,
            OccurrenceCount = 1,
            Description = "Validation warning for missing optional field",
            OccurrenceDescription = "Optional field omitted",
            LastOccurrenceDescription = "Optional field omitted",
            Origin = "CoreBlazorApp",
            CallerId = "ui-client",
            Key = "VALIDATION-OPTIONAL",
            Subject = "admin-app",
            SubjectType = "Human",
            UserRef = 1002,
            IsError = false,
            OccurrenceDate = DateTime.UtcNow.AddMinutes(-50),
            LastOccurrenceDate = DateTime.UtcNow.AddMinutes(-50),
            RequestId = Guid.Parse("22222222-2222-2222-2222-222222222222")
        }
    ];

    private static readonly List<EntryOccurrenceSummaryModel> Occurrences =
        Enumerable.Range(1, 20)
            .Select(index => new EntryOccurrenceSummaryModel
            {
                EntryOccurrenceRef = 2000 + index,
                EntryRef = 100 + ((index - 1) % 5),
                LastEntryOccurrenceRef = 2000 + index,
                OccurrenceCount = (index % 4) + 1,
                Description = $"Mock entry {index}",
                OccurrenceDescription = $"Mock occurrence description {index}",
                Origin = index % 2 == 0 ? "CoreBlazorApp" : "IntegrationService",
                CallerId = index % 2 == 0 ? "api-service" : "ui-client",
                Key = $"MOCK-ENTRY-{index:000}",
                Subject = index % 2 == 0 ? "core-app" : "admin-app",
                SubjectType = index % 2 == 0 ? "Api" : "Human",
                UserRef = 1000 + ((index - 1) % 3) + 1,
                IsError = index % 3 == 0,
                ErrorType = index % 3 == 0 ? "Timeout" : "Validation",
                EmailsSent = index % 3 == 0 ? "support1@example.com;support2@example.com" : string.Empty,
                OccurrenceDate = DateTime.UtcNow.AddMinutes(-(index * 7)),
                LastOccurrenceDate = DateTime.UtcNow.AddMinutes(-(index * 7)),
                RequestId = Guid.Parse($"{index:x8}-aaaa-bbbb-cccc-dddddddddddd")
            })
            .ToList();

    public Task<ApplicationOptionsGetModel> ApplicationOptionAdd(ApplicationOptionsPostModel model)
    {
        var created = new ApplicationOptionsGetModel
        {
            ApplicationOptionsRef = _nextApplicationOptionRef++,
            ApiName = model?.ApiName?.Trim().ToLowerInvariant() ?? string.Empty,
            EntryEmail = model?.EntryEmail?.ToList() ?? []
        };

        ApplicationOptions.Add(created);
        return Task.FromResult(created);
    }

    public void ApplicationOptionDelete(ApplicationOptionsGetModel model)
    {
        if (model == null)
        {
            return;
        }

        var existing = ApplicationOptions.FirstOrDefault(x => x.ApplicationOptionsRef == model.ApplicationOptionsRef);
        if (existing != null)
        {
            ApplicationOptions.Remove(existing);
        }
    }

    public Task<ApplicationOptionsGetModel> ApplicationOptionUpdate(ApplicationOptionsGetModel model)
    {
        if (model == null)
        {
            return Task.FromResult<ApplicationOptionsGetModel>(null);
        }

        var existing = ApplicationOptions.FirstOrDefault(x => x.ApplicationOptionsRef == model.ApplicationOptionsRef);
        if (existing == null)
        {
            ApplicationOptions.Add(model);
            return Task.FromResult(model);
        }

        existing.ApiName = model.ApiName?.Trim().ToLowerInvariant() ?? string.Empty;
        existing.EntryEmail = model.EntryEmail?.ToList() ?? [];
        return Task.FromResult(existing);
    }

    public Task<ContactModel> ContactAdd(ContactModel model)
    {
        var created = new ContactModel
        {
            SupportDefaultContactRef = _nextContactRef++,
            UserRef = model?.UserRef ?? 0,
            Order = model?.Order ?? 0,
            Active = model?.Active ?? true,
            FullName = model?.FullName ?? "Mock User"
        };

        Contacts.Add(created);
        return Task.FromResult(created);
    }

    public void ContactDelete(ContactModel model)
    {
        if (model == null)
        {
            return;
        }

        var existing = Contacts.FirstOrDefault(x => x.SupportDefaultContactRef == model.SupportDefaultContactRef);
        if (existing != null)
        {
            Contacts.Remove(existing);
        }
    }

    public Task<ContactModel> ContactUpdate(ContactModel model)
    {
        if (model == null)
        {
            return Task.FromResult<ContactModel>(null);
        }

        var existing = Contacts.FirstOrDefault(x => x.SupportDefaultContactRef == model.SupportDefaultContactRef);
        if (existing == null)
        {
            Contacts.Add(model);
            return Task.FromResult(model);
        }

        existing.UserRef = model.UserRef;
        existing.Order = model.Order;
        existing.Active = model.Active;
        existing.FullName = model.FullName;
        return Task.FromResult(existing);
    }

    public Task<List<EntrySummaryModel>> FindEntries(EntrySearchCriteria criteria)
    {
        IEnumerable<EntrySummaryModel> result = Entries;

        if (criteria != null)
        {
            if (criteria.EntryRef.HasValue)
            {
                result = result.Where(x => x.EntryRef == criteria.EntryRef.Value);
            }

            if (!string.IsNullOrWhiteSpace(criteria.Key))
            {
                result = result.Where(x => (x.Key ?? string.Empty).Contains(criteria.Key, StringComparison.OrdinalIgnoreCase));
            }

            if (criteria.IsError.HasValue)
            {
                result = result.Where(x => (x.IsError ?? false) == criteria.IsError.Value);
            }
        }

        return Task.FromResult(result.OrderByDescending(x => x.LastOccurrenceDate).ToList());
    }

    public Task<List<EntryOccurrenceSummaryModel>> FindOccurrences(EntryOccurrenceSearchCriteria criteria)
    {
        IEnumerable<EntryOccurrenceSummaryModel> result = Occurrences;

        if (criteria != null)
        {
            if (criteria.EntryRef.HasValue)
            {
                result = result.Where(x => x.EntryRef == criteria.EntryRef.Value);
            }

            if (criteria.OccurrenceRef.HasValue)
            {
                result = result.Where(x => x.EntryOccurrenceRef == criteria.OccurrenceRef.Value);
            }

            if (!string.IsNullOrWhiteSpace(criteria.Key))
            {
                result = result.Where(x => (x.Key ?? string.Empty).Contains(criteria.Key, StringComparison.OrdinalIgnoreCase));
            }
        }

        return Task.FromResult(result.OrderByDescending(x => x.OccurrenceDate).ToList());
    }

    public Task<PageResultsModel<EntryOccurrenceSummaryModel>> GetEntryOccurrenceDetail(EntryOccurrenceSearchCriteria criteria)
    {
        var pageNumber = criteria?.PageNumber > 0 ? criteria.PageNumber : 1;
        var pageSize = criteria?.PageSize > 0 ? criteria.PageSize : 20;

        IEnumerable<EntryOccurrenceSummaryModel> result = Occurrences;

        if (criteria != null)
        {
            if (criteria.EntryRef.HasValue)
            {
                result = result.Where(x => x.EntryRef == criteria.EntryRef.Value);
            }

            if (criteria.OccurrenceRef.HasValue)
            {
                result = result.Where(x => x.EntryOccurrenceRef == criteria.OccurrenceRef.Value);
            }

            if (!criteria.Key.IsNullOrBlank())
            {
                result = result.Where(x => (x.Key ?? string.Empty).Contains(criteria.Key, StringComparison.OrdinalIgnoreCase));
            }
        }

        var ordered = result.OrderByDescending(x => x.OccurrenceDate).ToList();
        var totalCount = ordered.Values().Count();
        var paged = ordered.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        var pageRequest = new PageRequestModel
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        return Task.FromResult(new PageResultsModel<EntryOccurrenceSummaryModel>(paged, pageRequest, totalCount));
    }

    public Task<List<ApplicationOptionsGetModel>> GetAllApplicationOptions()
    {
        ApplicationOptions.Sort((left, right) => string.Compare(left.ApiName, right.ApiName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(ApplicationOptions);
    }

    public Task<EntryDetailModel> GetEntryDetail(int entryRef)
    {
        var found = Entries.FirstOrDefault(x => x.EntryRef == entryRef);
        var detail = new EntryDetailModel(null)
        {
            EntryRef = found?.EntryRef ?? entryRef,
            GenericDescription = found?.Description ?? "Mock entry detail",
            Key = found?.Key ?? $"ENTRY-{entryRef}",
            LastEntryOccurrenceRef = found?.LastEntryOccurrenceRef ?? 0,
            OccurrenceCount = found?.OccurrenceCount ?? 0,
            ErrorTypeCode = new ErrorTypeCode { ErrorTypeRef = 1, Name = "General" },
            Notes = [],
            Occurrences =
            [
                new OccurrenceDetailModel
                {
                    EntryOccurrenceRef = found?.EntryOccurrenceRef ?? 0,
                    Date = found?.OccurrenceDate ?? DateTime.UtcNow,
                    Description = found?.OccurrenceDescription ?? "Mock occurrence",
                    Origin = found?.Origin ?? "CoreBlazorApp",
                    CallerId = found?.CallerId ?? "mock-service",
                    EmailsSent = "support@example.com"
                }
            ]
        };

        return Task.FromResult(detail);
    }

    public Task<EntryOccurrenceDetailModel> GetOccurrenceDetail(int occurrenceRef)
    {
        var found = Occurrences.FirstOrDefault(x => x.EntryOccurrenceRef == occurrenceRef);
        var detail = new EntryOccurrenceDetailModel
        {
            EntryOccurrenceRef = found?.EntryOccurrenceRef ?? occurrenceRef,
            EntryRef = found?.EntryRef ?? 0,
            Date = found?.OccurrenceDate ?? DateTime.UtcNow,
            Description = found?.OccurrenceDescription ?? "Mock occurrence detail",
            Origin = found?.Origin ?? "CoreBlazorApp",
            CallerId = found?.CallerId ?? "mock-service",
            EmailsSent = found?.EmailsSent ?? string.Empty,
            OccurrenceCount = found?.OccurrenceCount ?? 0,
            LastEntryOccurrenceRef = found?.LastEntryOccurrenceRef ?? 0,
            GenericDescription = found?.Description ?? "Mock entry",
            Key = found?.Key ?? $"OCC-{occurrenceRef}",
            TokenSubject = found?.Subject ?? "core-app",
            TokenType = found?.SubjectType ?? "Api",
            Error = found?.IsError,
            ErrorTypeCode = new ErrorTypeCode { ErrorTypeRef = 1, Name = found?.ErrorType ?? "General" },
            ApiLogData =
            [
                new ApiLogDataModel
                {
                    ApiLogRef = 1,
                    ApiName = "Mock API",
                    Error = found?.IsError ?? false,
                    LogDate = DateTime.UtcNow,
                    RequestId = found?.RequestId ?? Guid.NewGuid(),
                    Server = "mock-server"
                }
            ]
        };

        return Task.FromResult(detail);
    }

    public Task<List<ContactModel>> GetSupportDefaultContactEdit()
    {
        Contacts.Sort((left, right) => left.Order.CompareTo(right.Order));
        return Task.FromResult(Contacts);
    }

    public Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        var option = ApplicationOptions.FirstOrDefault();
        var nextEntryRef = Entries.Select(x => x.EntryRef).DefaultIfEmpty(99).Max() + 1;
        var nextOccurrenceRef = Occurrences.Select(x => x.EntryOccurrenceRef).DefaultIfEmpty(999).Max() + 1;
        var now = DateTime.UtcNow;

        var occurrenceDescription = eattsEntryModel.ErrorResponse?.Description
            ?? eattsEntryModel.ErrorResponse?.Title
            ?? "Mock logged occurrence";

        var entry = new EntrySummaryModel
        {
            EntryRef = nextEntryRef,
            EntryOccurrenceRef = nextOccurrenceRef,
            LastEntryOccurrenceRef = nextOccurrenceRef,
            OccurrenceCount = 1,
            Description = occurrenceDescription,
            OccurrenceDescription = occurrenceDescription,
            LastOccurrenceDescription = occurrenceDescription,
            Origin = eattsEntryModel.Origin ?? "CoreBlazorApp",
            CallerId = eattsEntryModel.CallerId ?? "mock-service",
            Key = eattsEntryModel.Key,
            Subject = "core-app",
            SubjectType = "Api",
            UserRef = eattsEntryModel.UserRef ?? 0,
            IsError = true,
            OccurrenceDate = now,
            LastOccurrenceDate = now,
            RequestId = Guid.NewGuid()
        };

        var occurrence = new EntryOccurrenceSummaryModel
        {
            EntryOccurrenceRef = nextOccurrenceRef,
            EntryRef = nextEntryRef,
            LastEntryOccurrenceRef = nextOccurrenceRef,
            OccurrenceCount = 1,
            Description = occurrenceDescription,
            OccurrenceDescription = occurrenceDescription,
            Origin = entry.Origin,
            CallerId = entry.CallerId,
            Key = entry.Key,
            Subject = entry.Subject,
            SubjectType = entry.SubjectType,
            UserRef = entry.UserRef,
            IsError = true,
            ErrorType = "Error",
            EmailsSent = string.Join(";", option?.EntryEmail ?? []),
            OccurrenceDate = now,
            LastOccurrenceDate = now,
            RequestId = entry.RequestId
        };

        Entries.Add(entry);
        Occurrences.Add(occurrence);

        var result = new EattsEntryResultModel
        {
            EntryRef = nextEntryRef,
            OccurrenceRef = nextOccurrenceRef,
            EmailedTo = option?.EntryEmail?.ToList() ?? []
        };

        return Task.FromResult(result);
    }
}