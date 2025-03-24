using mikk_mmc_web.Models;
using mikk_mmc_web.Models.Shared;
using System.Collections.Generic;

namespace mikk_mmc_web.ViewModels
{
    public class DashboardViewModel
    {
        public RouterDevice Router { get; set; }
        public SystemResources Resources { get; set; }
        public List<NetworkInterface> Interfaces { get; set; }
        public List<FirewallRule> RecentFirewallRules { get; set; }
        public List<LogEntry> RecentLogs { get; set; }
        public List<DhcpLease> DhcpLeases { get; set; }
    }
}
