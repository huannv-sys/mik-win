using System;
using System.Collections.Generic;
using mikk_mmc_web.Models;

namespace mikk_mmc_web.ViewModels
{
    public class DashboardViewModel
    {
        public RouterInfo RouterInfo { get; set; } = new RouterInfo();
        public SystemResources SystemResources { get; set; } = new SystemResources();
        public List<NetworkInterface> TopInterfaces { get; set; } = new List<NetworkInterface>();
        public List<FirewallRule> RecentRules { get; set; } = new List<FirewallRule>();
        public List<DhcpLease> RecentLeases { get; set; } = new List<DhcpLease>();
        public List<LogEntry> RecentLogs { get; set; } = new List<LogEntry>();
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
