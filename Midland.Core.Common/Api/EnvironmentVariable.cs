namespace Midland.Core.Api;

public class EnvironmentVariable
{
	public static string NomadAllocId { get => Environment.GetEnvironmentVariable("NOMAD_ALLOC_ID"); }
	public static string NomadDataCenter { get => Environment.GetEnvironmentVariable("NOMAD_DC"); }
	public static string NomadJobName { get => Environment.GetEnvironmentVariable("NOMAD_JOB_NAME"); }
	public static string NomadNodeName { get => Environment.GetEnvironmentVariable("NOMAD_NODE_NAME"); }
	public static string NomadTaskName { get => Environment.GetEnvironmentVariable("NOMAD_TASK_NAME"); }
}