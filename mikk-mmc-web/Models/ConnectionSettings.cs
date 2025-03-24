namespace mikk_mmc_web.Models
{
    public class ConnectionSettings
    {
        public string IpAddress { get; set; } = string.Empty;
        public int Port { get; set; } = 22;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Protocol { get; set; } = "API";
        public bool SaveCredentials { get; set; } = false;
    }
}
