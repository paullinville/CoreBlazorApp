using System;
using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class ServiceTokenDetailViewModel
{
    public bool Active { get; set; }
    public List<string> AllowedHosts { get; set; }
    public List<ApplicationPermissionModel> Applications { get; set; }
    public DateTime Created { get; set; }
    public string CreatedBy { get; set; }
    public string Description { get; set; }
    public DateTime? ExperationDate { get; set; }
    public Guid Id { get; set; }
    public long LifetimeSeconds { get; set; }
    public string Name { get; set; }
    public List<Employee> ResponsibleUsers { get; set; }
}