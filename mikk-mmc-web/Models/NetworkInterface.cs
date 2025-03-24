namespace mikk_mmc_web.Models
{
    public class NetworkInterface
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string Speed { get; set; } = string.Empty;
        public string TxRx { get; set; } = string.Empty;
    }
}
