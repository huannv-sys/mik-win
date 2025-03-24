using System;
using System.Collections.Generic;

namespace mikk_mmc_web.Models
{
    // Mô hình cho thông tin hệ thống router
    public class RouterInfo
    {
        public string RouterName { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string FirmwareVersion { get; set; } = string.Empty;
        public string Architecture { get; set; } = string.Empty;
        public string BoardName { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public int Uptime { get; set; } // in seconds
        public string LicenseLevel { get; set; } = string.Empty;
        public DateTime CurrentTime { get; set; } = DateTime.Now;
    }

    // Mô hình cho tài nguyên hệ thống
    public class SystemResources
    {
        public double CpuLoad { get; set; }
        public double MemoryUsed { get; set; }
        public double MemoryTotal { get; set; }
        public double MemoryPercentage => MemoryTotal > 0 ? (MemoryUsed / MemoryTotal) * 100 : 0;
        public double HddUsed { get; set; }
        public double HddTotal { get; set; }
        public double HddPercentage => HddTotal > 0 ? (HddUsed / HddTotal) * 100 : 0;
        public int Temperature { get; set; }
        public int Voltage { get; set; }
        public int CurrentFirmwareVersion { get; set; }
        public int LatestFirmwareVersion { get; set; }
        public bool UpdateAvailable => LatestFirmwareVersion > CurrentFirmwareVersion;
    }

    public class InterfaceTraffic
    {
        public string Name { get; set; } = string.Empty;
        public double RxRate { get; set; } // bytes per second
        public double TxRate { get; set; } // bytes per second
    }

    // Mô hình cho ViewModel Dashboard
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
