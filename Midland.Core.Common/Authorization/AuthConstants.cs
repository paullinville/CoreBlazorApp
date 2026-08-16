namespace Midland.Core.Authorization;

public sealed class AuthConstants
{
    public const string AuthenticatedUser = "*";
    public const int CertificateSigningVersion = 2;
    public const int SecretSigningVersion = 1;
    public static string ActionClaim { get => "action"; }
    public static string AllowedHosts { get => "hosts"; }
    public static string AudienceClaim { get => "aud"; }
    public static string Authenticated { get => AuthenticatedUser; }
    public static string AuthorizationHeader { get => "Authorization"; }
    public static string AuthorizationScheme { get => "Bearer "; }
    public static string AuthorizeBearerAttributeStandardGroup { get => "Standard"; }
    public static string CostCenterClaim { get => "cc"; }
    public static string EmailClaim { get => "email"; }

    /// <summary>
    /// Used by the gateway as the subject claim of the token it creates to get the user token after
    /// windows authentication. The SecurityModel then ensures that the token it validates is has
    /// this claim before generating and returning the user token.
    /// </summary>
    public static string GatewaySubject { get => "GatewayRequest"; }

    public static string GuidFormat { get => "N"; }
    public static string IssuerClaim { get => "iss"; }
    public static string JwtIdentityClaim { get => "jti"; }
    public static string Permissions { get => "permissions"; }
    public static string SignerId { get => "signingId"; }
    public static string SigningType { get => "signingType"; }
    public static string SubjectClaim { get => "sub"; }
    public static string SubjectTypeClaim { get => "subjectType"; }
    public static string UserRefClaim { get => "userRef"; }
    public static string VersionClaim { get => "version"; }
}