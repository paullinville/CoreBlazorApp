using BlazorApp.Data;
using Midland.Core.SimpleMessageBus;
using SecurityModel.Common.Models;

namespace BlazorApp.Data;

public class MockSecurityModelRepository : ISecurityModelApiRepository
{
    private readonly IEventChannelBus _eventBus;

    public MockSecurityModelRepository(IEventChannelBus eventBus)
    {
        _eventBus = eventBus;
    }

    private static readonly List<ApplicationSummary> Applications =
    [
        new ApplicationSummary
        {
            ApplicationRef = 1,
            Name = "Core App",
            Slug = "core-app",
            ApiName = "Core API",
            VirtualDirectory = "/core",
            IsActive = true,
            Guid = Guid.Parse("33333333-3333-3333-3333-333333333333")
        },
        new ApplicationSummary
        {
            ApplicationRef = 2,
            Name = "Admin App",
            Slug = "admin-app",
            ApiName = "Admin API",
            VirtualDirectory = "/admin",
            IsActive = true,
            Guid = Guid.Parse("44444444-4444-4444-4444-444444444444")
        },
        new ApplicationSummary
        {
            ApplicationRef = 3,
            Name = "Loan Portal",
            Slug = "loan-portal",
            ApiName = "Loan API",
            VirtualDirectory = "/loan",
            IsActive = true,
            Guid = Guid.Parse("55555555-5555-5555-5555-555555555555")
        },
        new ApplicationSummary
        {
            ApplicationRef = 4,
            Name = "Payroll Hub",
            Slug = "payroll-hub",
            ApiName = "Payroll API",
            VirtualDirectory = "/payroll",
            IsActive = true,
            Guid = Guid.Parse("66666666-6666-6666-6666-666666666666")
        },
        new ApplicationSummary
        {
            ApplicationRef = 5,
            Name = "Risk Center",
            Slug = "risk-center",
            ApiName = "Risk API",
            VirtualDirectory = "/risk",
            IsActive = true,
            Guid = Guid.Parse("77777777-7777-7777-7777-777777777777")
        },
        new ApplicationSummary
        {
            ApplicationRef = 6,
            Name = "Customer Insights",
            Slug = "customer-insights",
            ApiName = "Insights API",
            VirtualDirectory = "/insights",
            IsActive = true,
            Guid = Guid.Parse("88888888-8888-8888-8888-888888888888")
        },
        new ApplicationSummary
        {
            ApplicationRef = 7,
            Name = "Treasury Tools",
            Slug = "treasury-tools",
            ApiName = "Treasury API",
            VirtualDirectory = "/treasury",
            IsActive = true,
            Guid = Guid.Parse("99999999-9999-9999-9999-999999999999")
        },
        new ApplicationSummary
        {
            ApplicationRef = 8,
            Name = "Fraud Monitor",
            Slug = "fraud-monitor",
            ApiName = "Fraud API",
            VirtualDirectory = "/fraud",
            IsActive = true,
            Guid = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
        },
        new ApplicationSummary
        {
            ApplicationRef = 9,
            Name = "Statements",
            Slug = "statements",
            ApiName = "Statements API",
            VirtualDirectory = "/statements",
            IsActive = true,
            Guid = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
        },
        new ApplicationSummary
        {
            ApplicationRef = 10,
            Name = "Cards Platform",
            Slug = "cards-platform",
            ApiName = "Cards API",
            VirtualDirectory = "/cards",
            IsActive = true,
            Guid = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")
        },
        new ApplicationSummary
        {
            ApplicationRef = 11,
            Name = "Investments",
            Slug = "investments",
            ApiName = "Investments API",
            VirtualDirectory = "/investments",
            IsActive = true,
            Guid = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd")
        },
        new ApplicationSummary
        {
            ApplicationRef = 12,
            Name = "Document Vault",
            Slug = "document-vault",
            ApiName = "Documents API",
            VirtualDirectory = "/documents",
            IsActive = true,
            Guid = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee")
        }
    ];

    public Task<List<ApplicationSummary>> GetApplications()
    {
        Applications.Sort((left, right) => string.Compare(left.Name, right.Name, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(Applications);
    }
}
