namespace Midland.Core.Api;

public sealed class ApiConstants
{
	public static string ApiAuthorizationToken { get => "API_SECURITY_TOKEN"; }
	public static string DefaultBasePath { get => "consul"; }
	public static string DefaultConsulPostfix { get => "-service-api"; }
	public static string DefaultLogFolder { get => @"E:\Logfiles\"; }
	public static string DefaultScheme { get => "HTTP://"; }
	public static string DeveloperModeAuthorizationHeader { get => "X-Midland-Developer-Mode-Authorization"; }
	public static string EattsApiName { get => "EATTS"; }
	public static string EattsEntryEndpointName { get => "EattsEntry"; }
	public static string EattsEntryEndpointPath { get => "v1/log"; }
	public static string EnvironmentalVaultApiToken { get => "VAULT_API_TOKEN"; }
	public static string GatewayAddress { get => "https://gateway.midfirst.com/api"; }
	public static string GatewayAddressDev { get => "https://gateway.dev.midfirst.com/api"; }
	public static string GatewayAddressUat { get => "https://gateway.uat.midfirst.com/api"; }
	public static string MidlandForwardedUserRefHeader { get => "X-Midland-UserRef"; }
	public static string MidlandForwardedUserToken { get => "X-Midland-Forwarded-User-Token"; }
	public static string MidlandRequestIdHeader { get => "X-Midland-RequestId"; }
	public static string MidlandServiceAddressHeader { get => "X-Midland-Service-Address"; }

	public static string SortByDirPropertyName { get => "SortByDir"; }
	public static string SortByPropertyName { get => "SortBy"; }
	public static Uri TempBaseAddress { get => new($"{DefaultScheme}localhost"); }
	public static string TimestampFormat { get => "dd/MMM/yyyy:HH:mm:ss:mmmm zzz"; }
	public static string VaultTokenHeaderName { get => "X-Vault-Token"; }
}