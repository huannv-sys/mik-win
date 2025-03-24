namespace mikk_mmc_web.Models
{
    public class DhcpLease
    {
        public string Id { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public string Hostname { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ExpiresIn { get; set; } = string.Empty;
    }
}
