using System;
using System.Collections.Generic;
using mikk_mmc_web.Models;

namespace mikk_mmc_web.ViewModels
{
    public class RouterStatusViewModel
    {
        public RouterInfo RouterInfo { get; set; } = new RouterInfo();
        public SystemResources SystemResources { get; set; } = new SystemResources();
    }
    
    public class InterfaceViewModel
    {
        public List<NetworkInterface> Interfaces { get; set; } = new List<NetworkInterface>();
    }
    
    public class FirewallViewModel
    {
        public List<FirewallRule> Rules { get; set; } = new List<FirewallRule>();
    }
    
    public class DhcpViewModel
    {
        public List<DhcpLease> Leases { get; set; } = new List<DhcpLease>();
    }
    
    public class LogViewModel
    {
        public List<LogEntry> Logs { get; set; } = new List<LogEntry>();
        public string Topic { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
