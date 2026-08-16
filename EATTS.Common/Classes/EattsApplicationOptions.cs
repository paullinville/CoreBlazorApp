using System.Collections.Generic;

namespace EATTS.Common;

public class EattsApplicationOptions
{
	public bool DeleteImportedLogFiles { get; set; } = true;
	public bool DeleteOutOfDateLogFiles { get; set; } = true;
	public string GatewaySlug { get; set; } = "gateway";
	public string LogExtension { get; set; } = ".log";
	public string ObservabilityLogExtension { get; set; } = ".olog";
	public string TempLogDirectory { get; set; } = "Temp Log Folder";

	public List<string> LogExtensions()
	{
		return [ObservabilityLogExtension, LogExtension];
	}
}