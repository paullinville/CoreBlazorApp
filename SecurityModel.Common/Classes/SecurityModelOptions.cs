using System.Collections.Generic;

namespace SecurityModel.Common;

public class SecurityModelOptions
{
	public int ApiTokenSecretVersion { get; set; } = 1;
	public List<string> DefaultApplications { get; set; }
	public List<Setting> OtherSettings { get; set; }
	public int RecentUserTake { get; set; } = 25;
	public int UserTokenLifetime { get; set; }
}

public class Setting
{
	public string Name { get; set; }
	public object Value { get; set; }
}