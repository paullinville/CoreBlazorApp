using BlazorApp.Data;
using EmployeeData.Common.Models;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using SecurityModel.Common;
using System;

namespace BlazorApp.Data;

public class MockEmployeeRepository : IEmployeeRepository
{
    private readonly IEventChannelBus _eventBus;
    private readonly ISecurityModelToken _securityModel;
    private Task<MidlandUserGeneralModel> _currentUser;

    public MockEmployeeRepository(IEventChannelBus eventBus, ISecurityModelToken securityModel)
    {
        _eventBus = eventBus;
        _securityModel = securityModel;
    }

    private static readonly List<UserSelectModelExpanded> MockSelectionUsers =
    [
        new UserSelectModelExpanded { UserRef = 1001, FullName = "Alex Carter", LastNameFirst = "Carter, Alex", Email = "alex.carter@example.com" },
        new UserSelectModelExpanded { UserRef = 1002, FullName = "Jordan Lee", LastNameFirst = "Lee, Jordan", Email = "jordan.lee@example.com" },
        new UserSelectModelExpanded { UserRef = 1003, FullName = "Sam Rivera", LastNameFirst = "Rivera, Sam", Email = "sam.rivera@example.com" },
        new UserSelectModelExpanded { UserRef = 1004, FullName = "Taylor Brooks", LastNameFirst = "Brooks, Taylor", Email = "taylor.brooks@example.com" },
        new UserSelectModelExpanded { UserRef = 1005, FullName = "Casey Morgan", LastNameFirst = "Morgan, Casey", Email = "casey.morgan@example.com" },
        new UserSelectModelExpanded { UserRef = 1006, FullName = "Riley Bennett", LastNameFirst = "Bennett, Riley", Email = "riley.bennett@example.com" },
        new UserSelectModelExpanded { UserRef = 1007, FullName = "Drew Harrison", LastNameFirst = "Harrison, Drew", Email = "drew.harrison@example.com" },
        new UserSelectModelExpanded { UserRef = 1008, FullName = "Jamie Collins", LastNameFirst = "Collins, Jamie", Email = "jamie.collins@example.com" },
        new UserSelectModelExpanded { UserRef = 1009, FullName = "Morgan Price", LastNameFirst = "Price, Morgan", Email = "morgan.price@example.com" },
        new UserSelectModelExpanded { UserRef = 1010, FullName = "Skyler James", LastNameFirst = "James, Skyler", Email = "skyler.james@example.com" },
        new UserSelectModelExpanded { UserRef = 1011, FullName = "Parker Flynn", LastNameFirst = "Flynn, Parker", Email = "parker.flynn@example.com" },
        new UserSelectModelExpanded { UserRef = 1012, FullName = "Avery Sanders", LastNameFirst = "Sanders, Avery", Email = "avery.sanders@example.com" },
        new UserSelectModelExpanded { UserRef = 1013, FullName = "Quinn Foster", LastNameFirst = "Foster, Quinn", Email = "quinn.foster@example.com" },
        new UserSelectModelExpanded { UserRef = 1014, FullName = "Logan Pierce", LastNameFirst = "Pierce, Logan", Email = "logan.pierce@example.com" },
        new UserSelectModelExpanded { UserRef = 1015, FullName = "Emerson Ward", LastNameFirst = "Ward, Emerson", Email = "emerson.ward@example.com" },
        new UserSelectModelExpanded { UserRef = 1016, FullName = "Reese Dalton", LastNameFirst = "Dalton, Reese", Email = "reese.dalton@example.com" },
        new UserSelectModelExpanded { UserRef = 1017, FullName = "Hayden Walsh", LastNameFirst = "Walsh, Hayden", Email = "hayden.walsh@example.com" },
        new UserSelectModelExpanded { UserRef = 1018, FullName = "Kendall Vaughn", LastNameFirst = "Vaughn, Kendall", Email = "kendall.vaughn@example.com" },
        new UserSelectModelExpanded { UserRef = 1019, FullName = "Blake Monroe", LastNameFirst = "Monroe, Blake", Email = "blake.monroe@example.com" },
        new UserSelectModelExpanded { UserRef = 1020, FullName = "Rowan Ellis", LastNameFirst = "Ellis, Rowan", Email = "rowan.ellis@example.com" },
        new UserSelectModelExpanded { UserRef = 1021, FullName = "Cameron Shaw", LastNameFirst = "Shaw, Cameron", Email = "cameron.shaw@example.com" },
        new UserSelectModelExpanded { UserRef = 1022, FullName = "Finley Rhodes", LastNameFirst = "Rhodes, Finley", Email = "finley.rhodes@example.com" },
        new UserSelectModelExpanded { UserRef = 1023, FullName = "Peyton Grant", LastNameFirst = "Grant, Peyton", Email = "peyton.grant@example.com" }
    ];

    private static readonly List<MidlandUserGeneralModel> MockUsers =
    [
        new MidlandUserGeneralModel { UserRef = 49225, UserId = "plinville", FirstName = "Paul", LastName = "Linville", FullName = "Paul Linville", LastNameFirst = "Linville, Paul", Email = "paul.linville@midfirst.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1001, UserId = "acarter", FirstName = "Alex", LastName = "Carter", FullName = "Alex Carter", LastNameFirst = "Carter, Alex", Email = "alex.carter@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1002, UserId = "jlee", FirstName = "Jordan", LastName = "Lee", FullName = "Jordan Lee", LastNameFirst = "Lee, Jordan", Email = "jordan.lee@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1003, UserId = "srivera", FirstName = "Sam", LastName = "Rivera", FullName = "Sam Rivera", LastNameFirst = "Rivera, Sam", Email = "sam.rivera@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "PT" },
        new MidlandUserGeneralModel { UserRef = 1004, UserId = "tbrooks", FirstName = "Taylor", LastName = "Brooks", FullName = "Taylor Brooks", LastNameFirst = "Brooks, Taylor", Email = "taylor.brooks@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1005, UserId = "cmorgan", FirstName = "Casey", LastName = "Morgan", FullName = "Casey Morgan", LastNameFirst = "Morgan, Casey", Email = "casey.morgan@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1006, UserId = "rbennett", FirstName = "Riley", LastName = "Bennett", FullName = "Riley Bennett", LastNameFirst = "Bennett, Riley", Email = "riley.bennett@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "PT" },
        new MidlandUserGeneralModel { UserRef = 1007, UserId = "dharrison", FirstName = "Drew", LastName = "Harrison", FullName = "Drew Harrison", LastNameFirst = "Harrison, Drew", Email = "drew.harrison@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1008, UserId = "jcollins", FirstName = "Jamie", LastName = "Collins", FullName = "Jamie Collins", LastNameFirst = "Collins, Jamie", Email = "jamie.collins@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1009, UserId = "mprice", FirstName = "Morgan", LastName = "Price", FullName = "Morgan Price", LastNameFirst = "Price, Morgan", Email = "morgan.price@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "PT" },
        new MidlandUserGeneralModel { UserRef = 1010, UserId = "sjames", FirstName = "Skyler", LastName = "James", FullName = "Skyler James", LastNameFirst = "James, Skyler", Email = "skyler.james@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1011, UserId = "pflynn", FirstName = "Parker", LastName = "Flynn", FullName = "Parker Flynn", LastNameFirst = "Flynn, Parker", Email = "parker.flynn@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1012, UserId = "asanders", FirstName = "Avery", LastName = "Sanders", FullName = "Avery Sanders", LastNameFirst = "Sanders, Avery", Email = "avery.sanders@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "PT" },
        new MidlandUserGeneralModel { UserRef = 1013, UserId = "qfoster", FirstName = "Quinn", LastName = "Foster", FullName = "Quinn Foster", LastNameFirst = "Foster, Quinn", Email = "quinn.foster@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1014, UserId = "lpierce", FirstName = "Logan", LastName = "Pierce", FullName = "Logan Pierce", LastNameFirst = "Pierce, Logan", Email = "logan.pierce@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1015, UserId = "eward", FirstName = "Emerson", LastName = "Ward", FullName = "Emerson Ward", LastNameFirst = "Ward, Emerson", Email = "emerson.ward@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "PT" },
        new MidlandUserGeneralModel { UserRef = 1016, UserId = "rdalton", FirstName = "Reese", LastName = "Dalton", FullName = "Reese Dalton", LastNameFirst = "Dalton, Reese", Email = "reese.dalton@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1017, UserId = "hwalsh", FirstName = "Hayden", LastName = "Walsh", FullName = "Hayden Walsh", LastNameFirst = "Walsh, Hayden", Email = "hayden.walsh@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1018, UserId = "kvaughn", FirstName = "Kendall", LastName = "Vaughn", FullName = "Kendall Vaughn", LastNameFirst = "Vaughn, Kendall", Email = "kendall.vaughn@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "PT" },
        new MidlandUserGeneralModel { UserRef = 1019, UserId = "bmonroe", FirstName = "Blake", LastName = "Monroe", FullName = "Blake Monroe", LastNameFirst = "Monroe, Blake", Email = "blake.monroe@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1020, UserId = "rellis", FirstName = "Rowan", LastName = "Ellis", FullName = "Rowan Ellis", LastNameFirst = "Ellis, Rowan", Email = "rowan.ellis@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1021, UserId = "cshaw", FirstName = "Cameron", LastName = "Shaw", FullName = "Cameron Shaw", LastNameFirst = "Shaw, Cameron", Email = "cameron.shaw@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "PT" },
        new MidlandUserGeneralModel { UserRef = 1022, UserId = "frhodes", FirstName = "Finley", LastName = "Rhodes", FullName = "Finley Rhodes", LastNameFirst = "Rhodes, Finley", Email = "finley.rhodes@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" },
        new MidlandUserGeneralModel { UserRef = 1023, UserId = "pgrant", FirstName = "Peyton", LastName = "Grant", FullName = "Peyton Grant", LastNameFirst = "Grant, Peyton", Email = "peyton.grant@example.com", Status = "A", EmployeeTypeCode = "EMP", ScheduleTypeCode = "FT" }
    ];

    public Task<List<UserSelectModelExpanded>> GetActiveSelectionUsers()
    {
        MockSelectionUsers.Sort((left, right) => string.Compare(left.LastNameFirst, right.LastNameFirst, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(MockSelectionUsers);
    }

    public Task<List<MidlandUserGeneralModel>> GetActiveUsers()
    {
        MockUsers.Sort((left, right) => string.Compare(left.LastNameFirst, right.LastNameFirst, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(MockUsers);
    }

    public async Task<List<UserSelectModelExpanded>> GetUsersBy(string name)
    {
        var users = await GetActiveSelectionUsers();

        if (string.IsNullOrWhiteSpace(name))
        {
            return users;
        }

        return users
            .Where(user =>
                (!string.IsNullOrWhiteSpace(user.FullName) && user.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrWhiteSpace(user.LastNameFirst) && user.LastNameFirst.Contains(name, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains(name, StringComparison.OrdinalIgnoreCase)))
            .OrderBy(user => user.LastNameFirst)
            .ToList();
    }

    public Task<MidlandUserGeneralModel> CurrentUser => _currentUser ??= LoadCurrentUserAsync();

    public Task<MidlandUserGeneralModel> GetUser(int userRef)
    {
        var user = MockUsers.FirstOrDefault(x => x.UserRef == userRef);
        return Task.FromResult(user);
    }
    private void ShowError()
    {
        _eventBus.Publish(new ApiErrorEvent(new Midland.Core.Common.ErrorResponse
        {
            Description = "An error occurred while loading the current user.",
            Code = "USER_LOAD_ERROR",
            Messages = [ "Message 1" ],
            Errors = [new Midland.Core.Common.ErrorResultError { Name = "ERR001", Type = ErrorType.General, Value = "Detailed error message 1" }],
        }));
    }
    private async Task<MidlandUserGeneralModel> LoadCurrentUserAsync()
    {
        var token = await _securityModel.GetSecurityToken();
        var userRefValue = token?.Claims.FirstOrDefault(claim => string.Equals(claim.Type, "userRef", StringComparison.OrdinalIgnoreCase))?.Value;
        ShowError(); 
        if (!int.TryParse(userRefValue, out var userRef))
        {
            throw new InvalidOperationException("The security token does not contain a valid userRef claim.");
        }

        return await GetUser(userRef);
    }
}
