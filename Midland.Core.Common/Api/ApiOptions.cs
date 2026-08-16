using Midland.Core.Authorization;
using System.Diagnostics;

namespace Midland.Core.Api;

public class ApiOptions
{
    public const int DefaultRequestTimeout = 100;
    private List<ApiDefinition> apiList;
    private string basePath;
    private int? requestTimeout;

    public ApiOptions()
    { }

    public List<ApiDefinition> ApiList
    {
        get
        {
            return apiList;
        }
        set
        {
            apiList = value ?? new List<ApiDefinition>();

            foreach (ApiDefinition api in apiList.Values())
            {
                if (basePath.IsNotNullOrBlank() && api.BasePath.IsNullOrBlank())
                {
                    api.BasePath = basePath;
                }
                if (!api.RequestTimeout.HasValue)
                {
                    api.RequestTimeout = requestTimeout;
                }
            }
        }
    }

    /// <summary>
    /// This value is used to set the secret version used when creating tokens that are used for
    /// intra-api calls
    /// </summary>
    public int ApiTokenSigningVersion { get; set; } = AuthConstants.SecretSigningVersion;

    public int ApiUserTokenLifetimeSeconds { get; set; } = 10;

    public string BasePath
    {
        get
        {
            return basePath;
        }
        set
        {
            basePath = value;
            if (basePath.IsNotNullOrBlank())
            {
                foreach (ApiDefinition api in ApiList.Values())
                {
                    if (api.BasePath.IsNullOrBlank())
                    {
                        api.BasePath = BasePath;
                    }
                }
            }
        }
    }

    public bool? HideErrorDetailsInStaging { get; set; }
    public bool HostsFilter { get; set; }

    public int RequestTimeout
    {
        get { return requestTimeout ?? DefaultRequestTimeout; }
        set
        {
            requestTimeout = value;
            if (requestTimeout.HasValue)
            {
                foreach (ApiDefinition api in ApiList.Values())
                {
                    if (!api.RequestTimeout.HasValue)
                    {
                        api.RequestTimeout = requestTimeout;
                    }
                }
            }
        }
    }

    public bool? UseDeveloperMode { get; set; }

    public ApiOptions Report()
    {
        var options = new ApiOptions();
        options.BasePath = BasePath;
        options.ApiTokenSigningVersion = ApiTokenSigningVersion;
        options.ApiUserTokenLifetimeSeconds = ApiUserTokenLifetimeSeconds;
        options.HideErrorDetailsInStaging = HideErrorDetailsInStaging;
        options.HostsFilter = HostsFilter;
        options.UseDeveloperMode = UseDeveloperMode;
        options.apiList = apiList;
        foreach (var apiDef in options.apiList.Values())
        {
            apiDef.Headers.Values().ForEach(header =>
            {
                if (header.Name == AuthConstants.AuthorizationHeader)
                {
                    header.Value = "cleared for reporting";
                }
            });
            foreach (var endPoint in apiDef.EndPoints.Values())
            {
                endPoint.Headers.Values().ForEach(header =>
                {
                    if (header.Name == AuthConstants.AuthorizationHeader)
                    {
                        header.Value = "cleared for reporting.";
                    }
                });
            }
        }
        return options;
    }
}