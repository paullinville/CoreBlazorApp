namespace Midland.Core.Common;

public sealed class ErrorCodes
{
    public static string ApiMissingAuthorizationAttributes { get; } = "amaa";
    public static string ApiSecurityNotSet { get; } = "app-sec";
    public static string ApplicationTokenInvalid { get; } = "ati";
    public static string CompositeValidationFailed { get; } = "cvf";
    public static string FriendlyException { get; } = "fe";
    public static string JasonTokenIdentifierNotFound { get; } = "jtinf";
    public static string PrimaryPermissionClaimMissing { get; } = "ppcm";
    public static string ServiceTokenInvalid { get; } = "sti";
    public static string ServiceTokenNotActive { get; } = "stna";
    public static string TokenIssuerInvalid { get; } = "tii";
    public static string TokenNotFound { get; } = "tnf";
    public static string UnauthorizedHost { get; } = "uah";
    public static string UnhandledException { get; } = "ue";
    public static string UserIdentityOrIdentityClaimsNotSet { get; } = "uic";
    public static string UserMissingActionClaims { get; } = "umaa";
    public static string ValidationFailure { get; } = "vf";
}