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

    // Mô hình cho giao diện mạng
    public class NetworkInterface
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public string Netmask { get; set; } = string.Empty;
        public string DefaultGateway { get; set; } = string.Empty;
        public long RxBytes { get; set; }
        public long TxBytes { get; set; }
        public long RxPackets { get; set; }
        public long TxPackets { get; set; }
        public double RxRate { get; set; } // bytes per second
        public double TxRate { get; set; } // bytes per second
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }

    // Mô hình cho đối tượng luật tường lửa
    public class FirewallRule
    {
        public string Id { get; set; } = string.Empty;
        public string Chain { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Protocol { get; set; } = string.Empty;
        public string SrcAddress { get; set; } = string.Empty;
        public string DstAddress { get; set; } = string.Empty;
        public string SrcPort { get; set; } = string.Empty;
        public string DstPort { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public bool Disabled { get; set; }
        public int PacketCount { get; set; }
        public int ByteCount { get; set; }
        public DateTime LastHit { get; set; } = DateTime.MinValue;
    }

    // Mô hình cho đối tượng DHCP lease
    public class DhcpLease
    {
        public string Id { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public DateTime ExpiresAfter { get; set; } = DateTime.Now.AddDays(1);
        public DateTime LastSeen { get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty;
        public bool Dynamic { get; set; } = true;
        public bool Blocked { get; set; } = false;
        public bool Active => DateTime.Now < ExpiresAfter && !Blocked;
    }

    // Mô hình cho đối tượng log
    public class LogEntry
    {
        public string Id { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;
        public string Topic { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string LogLevel { get; set; } = string.Empty;
    }

    // Mô hình cho dữ liệu lưu lượng theo thời gian (đồ thị)
    public class TrafficData
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public Dictionary<string, InterfaceTraffic> Interfaces { get; set; } = new Dictionary<string, InterfaceTraffic>();
    }

    public class InterfaceTraffic
    {
        public string Name { get; set; } = string.Empty;
        public double RxRate { get; set; } // bytes per second
        public double TxRate { get; set; } // bytes per second
    }

    // Mô hình cho cài đặt kết nối
    public class ConnectionSettings
    {
        public string IpAddress { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Port { get; set; } = 22; // SSH port
        public string ApiPort { get; set; } = "8728"; // API port
        public bool UseHttps { get; set; } = false;
        public bool RememberCredentials { get; set; } = false;
        public string ConnectionMethod { get; set; } = "API"; // API, SSH, or SNMP
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
