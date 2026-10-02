using BlazorApp.Models;
using EATTS.Common.Models;
using Midland.Core.SimpleMessageBus;
using System;
using System.Collections.Generic;
using System.Linq;

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

    private static SupportOptionsEditModel SupportOptions = CreateMockSupportOptions();

    private static readonly List<SupportOptionsOverrideGetModel> SupportOptionOverrides =
    [
        new SupportOptionsOverrideGetModel
        {
            SupportOptionsOverrideRef = 1,
            EntryRef = 100,
            DoNotSendEmail = false,
            FloodCount = 3,
            FloodTime = 30,
            FloodEmail = "alerts@coreblazorapp.local",
            OtherEmail = string.Empty,
            Reason = "Critical production entry"
        },
        new SupportOptionsOverrideGetModel
        {
            SupportOptionsOverrideRef = 2,
            EntryRef = 101,
            DoNotSendEmail = true,
            FloodCount = 5,
            FloodTime = 60,
            FloodEmail = "ops@coreblazorapp.local",
            OtherEmail = string.Empty,
            Reason = "Do not send flood emails for known issue"
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

    private static readonly List<ApiLogDataModel> ApiLogs =
    [
        new ApiLogDataModel
        {
            ApiLogRef = 9001,
            ApiName = MockSecurityModelRepository.ApiNames.GetRandom(),
            Error = true,
            LogDate = DateTime.UtcNow.AddMinutes(-15),
            RequestId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Server = "mock-server-01",
            LogData = new LogDataBindingModel
            {
                Action = "GetProfile",
                Api = MockSecurityModelRepository.ApiNames.GetRandom(),
                CallerContext = "ProfileController.Get",
                ClientIp = "10.0.0.21",
                Controller = "Profile",
                CostCenter = "CC100",
                Exception = new ExceptionModel
                {
                    Message = "Timed out retrieving profile.",
                    Source = "MockEattsApiRepository",
                    StackTrace = "at CoreBlazorApp.Controllers.ProfileController.Get()"
                },
                ExceptionDetail = new ErrorException(new TimeoutException("Timed out retrieving profile.")),
                Input = new Dictionary<string, string>
                {
                    ["userRef"] = "1001",
                    ["includeAudit"] = "true"
                },
                Level = 4,
                LogId = "LOG-9001",
                Message = "Request timed out while retrieving profile.",
                NomadAllocId = "alloc-001",
                NomadDatacenter = "dc1",
                NomadJobName = "core-app",
                NomadNodeName = "node-a",
                NomadTaskName = "api",
                Output = "{}",
                ProcessId = 1234,
                RecorderId = "rec-001",
                RequestId = "33333333-3333-3333-3333-333333333333",
                Route = "/api/profile",
                Server = "mock-server-01",
                StatusCode = 504,
                TimeElapsed = 15234,
                TimeStamp = DateTime.UtcNow.AddMinutes(-15).ToString("O"),
                TraceId = "trace-9001",
                UserType = "Api",
                Query = "userRef=1001",
                SourceContext = "CoreBlazorApp.Controllers.ProfileController",
                SpanId = "span-9001",
                TraceFlags = "01"
            }
        },
        new ApiLogDataModel
        {
            ApiLogRef = 9002,
            ApiName = MockSecurityModelRepository.ApiNames.GetRandom(),
            Error = false,
            LogDate = DateTime.UtcNow.AddMinutes(-40),
            RequestId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Server = "mock-server-02",
            LogData = new LogDataBindingModel
            {
                Action = "UpdateSettings",
                Api = MockSecurityModelRepository.ApiNames.GetRandom(),
                CallerContext = "SettingsController.Update",
                ClientIp = "10.0.0.22",
                Controller = "Settings",
                CostCenter = "CC200",
                ExceptionDetail = null,
                Input = new Dictionary<string, string>
                {
                    ["settingName"] = "Theme",
                    ["value"] = "Dark"
                },
                Level = 2,
                LogId = "LOG-9002",
                Message = "Settings updated successfully.",
                NomadAllocId = "alloc-002",
                NomadDatacenter = "dc1",
                NomadJobName = "admin-app",
                NomadNodeName = "node-b",
                NomadTaskName = "ui",
                Output = new { Success = true, Updated = 1 },
                ProcessId = 2345,
                RecorderId = "rec-002",
                RequestId = "44444444-4444-4444-4444-444444444444",
                Route = "/api/settings",
                Server = "mock-server-02",
                StatusCode = 200,
                TimeElapsed = 842,
                TimeStamp = DateTime.UtcNow.AddMinutes(-40).ToString("O"),
                TraceId = "trace-9002",
                UserType = "Human",
                Query = "settingName=Theme",
                SourceContext = "CoreBlazorApp.Controllers.SettingsController",
                SpanId = "span-9002",
                TraceFlags = "00"
            }
        },
        ..CreateMockApiLogs()
    ];

    private static IEnumerable<ApiLogDataModel> CreateMockApiLogs()
    {
        var actions = new[]
        {
            "GetProfile",
            "UpdateProfile",
            "GetSettings",
            "UpdateSettings",
            "SearchUsers",
            "CreateEntry",
            "GetEntry",
            "UpdateEntry",
            "DeleteEntry",
            "GenerateReport"
        };

        return Enumerable.Range(3, 300).Select(index =>
        {
            var sequence = index - 3;
            var actionIndex = sequence % actions.Length;
            var dayOffset = sequence / actions.Length;
            var action = actions[actionIndex];
            var apiName = actionIndex % 2 == 0 ? "core-app" : "admin-app";
            var isError = (sequence + 1) % 9 == 0;
            var requestId = Guid.Parse($"{(9000 + index):x8}-5555-6666-7777-888888888888");
            var logDate = DateTime.UtcNow.Date.AddDays(-dayOffset).AddHours(actionIndex * 2).AddMinutes(sequence % 60);
            var server = $"mock-server-{(actionIndex % 4) + 1:00}";

            return new ApiLogDataModel
            {
                ApiLogRef = 9000 + index,
                ApiName = MockSecurityModelRepository.ApiNames.GetRandom(),
                Error = isError,
                LogDate = logDate,
                RequestId = requestId,
                Server = server,
                LogData = new LogDataBindingModel
                {
                    Action = action,
                    Api = apiName,
                    CallerContext = $"{(apiName == "core-app" ? "Core" : "Admin")}Controller.{(isError ? "Post" : "Get")}",
                    ClientIp = $"10.0.0.{20 + index}",
                    Controller = apiName == "core-app" ? "Core" : "Admin",
                    CostCenter = apiName == "core-app" ? "CC100" : "CC200",
                    Exception = isError
                        ? new ExceptionModel
                        {
                            Message = $"Mock exception {index}",
                            Source = "MockEattsApiRepository",
                            StackTrace = $"at CoreBlazorApp.Controllers.{(apiName == "core-app" ? "Core" : "Admin")}Controller.{(isError ? "Post" : "Get")}()"
                        }
                        : null,
                    ExceptionDetail = isError ? new ErrorException(new InvalidOperationException($"Mock exception {index}")) : null,
                    Input = new Dictionary<string, string>
                    {
                        ["index"] = index.ToString(),
                        ["apiName"] = apiName,
                        ["error"] = isError.ToString(),
                        ["action"] = action
                    },
                    Level = isError ? 4 : 2,
                    LogId = $"LOG-{9000 + index}",
                    Message = isError ? $"Mock error log {index}" : $"Mock success log {index}",
                    NomadAllocId = $"alloc-{index:000}",
                    NomadDatacenter = actionIndex % 2 == 0 ? "dc1" : "dc2",
                    NomadJobName = apiName,
                    NomadNodeName = $"node-{(char)('a' + (actionIndex % 4))}",
                    NomadTaskName = apiName == "core-app" ? "api" : "ui",
                    Output = isError ? "{}" : new { Success = true, Index = index },
                    ProcessId = 1000 + index,
                    RecorderId = $"rec-{index:000}",
                    RequestId = requestId.ToString(),
                    Route = $"/api/{apiName}/{action.ToLowerInvariant()}",
                    Server = server,
                    StatusCode = isError ? 500 : 200,
                    TimeElapsed = Random.Shared.Next(2, 1001),
                    TimeStamp = logDate.ToString("O"),
                    TraceId = $"trace-{9000 + index}",
                    UserType = isError ? "Api" : "Human",
                    Query = $"index={index}&apiName={apiName}&action={action}",
                    SourceContext = $"CoreBlazorApp.Controllers.{(apiName == "core-app" ? "Core" : "Admin")}Controller",
                    SpanId = $"span-{9000 + index}",
                    TraceFlags = isError ? "01" : "00"
                }
            };
        });
    }

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

    public Task<List<ApiLogDataModel>> FindApiLogData(ApiLogCriteria criteria)
    {
        var query = ApiLogs.AsQueryable();
        var results = query.Where(r => r.LogDate >= criteria.BeginDate && r.LogDate <= criteria.EndDate);
        if (criteria.ApiSlug.IsNotNullOrBlank())
        {
            results = results.Where(r => r.ApiName.Equals(criteria.ApiSlug, StringComparison.OrdinalIgnoreCase));
        }
        return Task.FromResult(results.ToList());
    }

    public async Task<ContactModel> ContactAdd(ContactModel model)
    {
        var created = await PostSupportContact(model);
        return new ContactModel(created)
        {
            FullName = model?.FullName ?? "Mock User"
        };
    }

    public async void ContactDelete(ContactModel model)
    {
        if (model == null)
        {
            return;
        }

        await DeleteSupportContact(model.SupportDefaultContactRef);
    }

    public async Task<ContactModel> ContactUpdate(ContactModel model)
    {
        if (model == null)
        {
            return null;
        }

        var updated = await PutSupportContact(model);
        return new ContactModel(updated)
        {
            FullName = model.FullName
        };
    }

    public Task<SupportDefaultContactEditModel> PostSupportContact(SupportDefaultContactAddModel model)
    {
        var created = new ContactModel
        {
            SupportDefaultContactRef = _nextContactRef++,
            UserRef = model?.UserRef ?? 0,
            Order = model?.Order ?? 0,
            Active = model?.Active ?? true,
            FullName = "Mock User"
        };

        Contacts.Add(created);

        return Task.FromResult<SupportDefaultContactEditModel>(new SupportDefaultContactEditModel
        {
            SupportDefaultContactRef = created.SupportDefaultContactRef,
            UserRef = created.UserRef,
            Order = created.Order,
            Active = created.Active
        });
    }

    public Task<SupportDefaultContactEditModel> PutSupportContact(SupportDefaultContactEditModel model)
    {
        if (model == null)
        {
            return Task.FromResult<SupportDefaultContactEditModel>(null);
        }

        var existing = Contacts.FirstOrDefault(x => x.SupportDefaultContactRef == model.SupportDefaultContactRef);
        if (existing == null)
        {
            existing = new ContactModel
            {
                SupportDefaultContactRef = model.SupportDefaultContactRef,
                FullName = "Mock User"
            };
            Contacts.Add(existing);
        }

        existing.UserRef = model.UserRef;
        existing.Order = model.Order;
        existing.Active = model.Active;

        return Task.FromResult<SupportDefaultContactEditModel>(new SupportDefaultContactEditModel
        {
            SupportDefaultContactRef = existing.SupportDefaultContactRef,
            UserRef = existing.UserRef,
            Order = existing.Order,
            Active = existing.Active
        });
    }

    public Task DeleteSupportContact(int supportDefaultContactRef)
    {
        var existing = Contacts.FirstOrDefault(x => x.SupportDefaultContactRef == supportDefaultContactRef);
        if (existing != null)
        {
            Contacts.Remove(existing);
        }

        return Task.CompletedTask;
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

    public Task<EntryOccurrenceDetailModel?> GetOccurrenceDetail(int occurrenceRef)
    {
        var found = Occurrences.FirstOrDefault(x => x.EntryOccurrenceRef == occurrenceRef);
        EntryOccurrenceDetailModel? detail = null;
        if (found != null)
        {
            detail = new EntryOccurrenceDetailModel
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
                ErrorResponse = new ErrorResponse
                {
                    Code = found?.IsError == true ? "Mock.Error" : "Mock.Info",
                    Title = "Mock Occurrence Detail",
                    Description = found?.OccurrenceDescription ?? "Mock occurrence detail",
                    RequestId = (found?.RequestId ?? Guid.NewGuid()).ToString(),
                    RequestPath = $"/api/eatts/occurrence/{occurrenceRef}",
                    Messages = ["Mock response generated for occurrence detail."]
                },
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
        }

        return Task.FromResult(detail);
    }

    public Task<List<ContactModel>> GetSupportDefaultContactEdit()
    {
        Contacts.Sort((left, right) => left.Order.CompareTo(right.Order));
        return Task.FromResult(Contacts);
    }

    public Task<List<SupportOptionsOverrideGetModel>> GetAllSupportOptionOverrideList()
    {
        return Task.FromResult(SupportOptionOverrides.ToList());
    }

    public Task<SupportOptionsOverrideGetModel> GetSupportOptionOverride(int supportOptionsOverrideRef)
    {
        return Task.FromResult(SupportOptionOverrides.FirstOrDefault(x => x.SupportOptionsOverrideRef == supportOptionsOverrideRef));
    }

    public Task<SupportOptionsOverrideGetModel> PostSupportOptionOverride(SupportOptionsOverridePostModel model)
    {
        var nextRef = SupportOptionOverrides.Select(x => x.SupportOptionsOverrideRef).DefaultIfEmpty(0).Max() + 1;
        var created = new SupportOptionsOverrideGetModel
        {
            SupportOptionsOverrideRef = nextRef,
            EntryRef = model?.EntryRef ?? 0,
            DoNotSendEmail = model?.DoNotSendEmail,
            FloodCount = model?.FloodCount,
            FloodEmail = model?.FloodEmail,
            FloodTime = model?.FloodTime,
            OtherEmail = model?.OtherEmail,
            Reason = model?.Reason
        };

        SupportOptionOverrides.Add(created);
        return Task.FromResult(created);
    }

    public Task<SupportOptionsOverrideGetModel> PutSupportOptionOverride(int supportOptionsOverrideRef, SupportOptionsOverridePostModel model)
    {
        var existing = SupportOptionOverrides.FirstOrDefault(x => x.SupportOptionsOverrideRef == supportOptionsOverrideRef);
        if (existing == null)
        {
            existing = new SupportOptionsOverrideGetModel
            {
                SupportOptionsOverrideRef = supportOptionsOverrideRef
            };
            SupportOptionOverrides.Add(existing);
        }

        existing.EntryRef = model?.EntryRef ?? existing.EntryRef;
        existing.DoNotSendEmail = model?.DoNotSendEmail;
        existing.FloodCount = model?.FloodCount;
        existing.FloodEmail = model?.FloodEmail;
        existing.FloodTime = model?.FloodTime;
        existing.OtherEmail = model?.OtherEmail;
        existing.Reason = model?.Reason;

        return Task.FromResult(existing);
    }

    public Task DeleteSupportOptionOverride(int supportOptionsOverrideRef)
    {
        var existing = SupportOptionOverrides.FirstOrDefault(x => x.SupportOptionsOverrideRef == supportOptionsOverrideRef);
        if (existing != null)
        {
            SupportOptionOverrides.Remove(existing);
        }

        return Task.CompletedTask;
    }

    public Task<SupportOptionsEditModel> GetSupportOptions()
    {
        return Task.FromResult(CloneSupportOptions(SupportOptions));
    }

    public Task<SupportOptionsEditModel> UpdateSupportOptions(SupportOptionsEditModel model)
    {
        SupportOptions = model is null
            ? CreateMockSupportOptions()
            : CloneSupportOptions(model);

        return Task.FromResult(CloneSupportOptions(SupportOptions));
    }

    private static SupportOptionsEditModel CreateMockSupportOptions()
    {
        var model = new SupportOptionsEditModel();

        SetSupportOptionsPropertyValue(model, "AutoAssign", true);
        SetSupportOptionsPropertyValue(model, "AutoClose", false);
        SetSupportOptionsPropertyValue(model, "IncludeStackTrace", true);
        SetSupportOptionsPropertyValue(model, "EmailEnabled", true);
        SetSupportOptionsPropertyValue(model, "FromEmail", "no-reply@coreblazorapp.local");
        SetSupportOptionsPropertyValue(model, "ReplyToEmail", "support@coreblazorapp.local");
        SetSupportOptionsPropertyValue(model, "AlertEmails", GetRandomEntryEmails(2, 4));

        return model;
    }

    private static SupportOptionsEditModel CloneSupportOptions(SupportOptionsEditModel source)
    {
        if (source == null)
        {
            return new SupportOptionsEditModel();
        }

        var clone = new SupportOptionsEditModel();
        foreach (var property in typeof(SupportOptionsEditModel).GetProperties())
        {
            if (!property.CanRead || !property.CanWrite)
            {
                continue;
            }

            var value = property.GetValue(source);
            if (value is System.Collections.IList list && property.PropertyType != typeof(string))
            {
                var copiedList = Activator.CreateInstance(property.PropertyType) as System.Collections.IList;
                if (copiedList != null)
                {
                    foreach (var item in list)
                    {
                        copiedList.Add(item);
                    }

                    property.SetValue(clone, copiedList);
                    continue;
                }
            }

            property.SetValue(clone, value);
        }

        return clone;
    }

    private static void SetSupportOptionsPropertyValue(SupportOptionsEditModel model, string propertyName, object value)
    {
        var property = typeof(SupportOptionsEditModel).GetProperty(propertyName);
        if (property is null || !property.CanWrite)
        {
            return;
        }

        if (value is null)
        {
            property.SetValue(model, null);
            return;
        }

        if (property.PropertyType.IsAssignableFrom(value.GetType()))
        {
            property.SetValue(model, value);
            return;
        }

        try
        {
            var convertedValue = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(model, convertedValue);
        }
        catch
        {
        }
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