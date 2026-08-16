namespace Midland.Core.Authorization;

public class AllowedCertificate
{
    public string CertificateId { get; set; }
    public int CertificateIdSearchType { get; set; }
    public bool Current { get; set; }
    public string PublicKey { get; set; }
}