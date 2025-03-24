namespace mikk_mmc_web.Models
{
    public class FirewallRule
    {
        public string Id { get; set; } = string.Empty;
        public string Chain { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Protocol { get; set; } = string.Empty;
        public string SrcAddress { get; set; } = string.Empty;
        public string DstAddress { get; set; } = string.Empty;
        public string DstPort { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public bool Disabled { get; set; } = false;
    }
}
