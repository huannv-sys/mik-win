using System;
using System.Collections.Generic;

namespace mikk_mmc_web.Models
{
    public class ConnectionSettings
    {
        public string IpAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Protocol { get; set; } = "API"; // API, SSH, SNMP
        public int Port { get; set; } = 8728; // Default API port
        public int Timeout { get; set; } = 10; // Seconds
    }

    public class RouterInfo
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Version { get; set; }
        public string Architecture { get; set; }
        public string BoardName { get; set; }
        public long UptimeSeconds { get; set; }
        public DateTime LastUpdateCheck { get; set; }
        public bool UpdateAvailable { get; set; }
        public string LicenseLevel { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        
        public string UptimeFormatted => FormatUptime(UptimeSeconds);
        
        private string FormatUptime(long seconds)
        {
            var timeSpan = TimeSpan.FromSeconds(seconds);
            return $"{(timeSpan.Days > 0 ? $"{timeSpan.Days} ngày " : "")}{timeSpan.Hours} giờ {timeSpan.Minutes} phút";
        }
    }

    public class SystemResources
    {
        public double CpuLoad { get; set; } // Percentage
        public double MemoryUsed { get; set; } // Bytes
        public double MemoryTotal { get; set; } // Bytes
        public double HddUsed { get; set; } // Bytes
        public double HddTotal { get; set; } // Bytes
        public double Temperature { get; set; } // Celsius
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        
        public double MemoryPercentage => MemoryTotal > 0 ? (MemoryUsed / MemoryTotal) * 100 : 0;
        public double HddPercentage => HddTotal > 0 ? (HddUsed / HddTotal) * 100 : 0;
        
        public string MemoryFormattedUsed => FormatBytes(MemoryUsed);
        public string MemoryFormattedTotal => FormatBytes(MemoryTotal);
        public string HddFormattedUsed => FormatBytes(HddUsed);
        public string HddFormattedTotal => FormatBytes(HddTotal);
        
        private string FormatBytes(double bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (bytes >= 1024 && order < sizes.Length - 1)
            {
                order++;
                bytes = bytes / 1024;
            }
            return $"{bytes:0.##} {sizes[order]}";
        }
    }

    public class NetworkInterface
    {
        public string Name { get; set; }
        public string Type { get; set; } // ethernet, wireless, vlan, etc.
        public bool IsEnabled { get; set; }
        public bool IsConnected { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Netmask { get; set; }
        public long RxBytes { get; set; }
        public long TxBytes { get; set; }
        public double RxRate { get; set; } // bytes per second
        public double TxRate { get; set; } // bytes per second
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        
        public string FormattedRxRate => FormatBitRate(RxRate * 8); // Convert to bits
        public string FormattedTxRate => FormatBitRate(TxRate * 8); // Convert to bits
        
        private string FormatBitRate(double bitsPerSecond)
        {
            string[] sizes = { "bps", "Kbps", "Mbps", "Gbps" };
            int order = 0;
            while (bitsPerSecond >= 1000 && order < sizes.Length - 1)
            {
                order++;
                bitsPerSecond = bitsPerSecond / 1000;
            }
            return $"{bitsPerSecond:0.#} {sizes[order]}";
        }
    }

    public class InterfaceTraffic
    {
        public string InterfaceName { get; set; }
        public List<DataPoint> RxPoints { get; set; } = new List<DataPoint>();
        public List<DataPoint> TxPoints { get; set; } = new List<DataPoint>();
    }

    public class DataPoint
    {
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
    }

    public class FirewallRule
    {
        public string Id { get; set; }
        public string Chain { get; set; } // input, forward, output
        public string Action { get; set; } // accept, drop, reject
        public string Protocol { get; set; }
        public string SrcAddress { get; set; }
        public string DstAddress { get; set; }
        public string SrcPort { get; set; }
        public string DstPort { get; set; }
        public bool Disabled { get; set; }
        public string Comment { get; set; }
        public DateTime LastHit { get; set; }
        public int HitCount { get; set; }
    }

    public class DhcpLease
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string MacAddress { get; set; }
        public string ClientId { get; set; }
        public string HostName { get; set; }
        public string Comment { get; set; }
        public bool Dynamic { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool Active { get; set; }
        public string Status => Active ? "Kích hoạt" : "Không hoạt động";
    }

    public class LogEntry
    {
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public string Topics { get; set; }
        public string Message { get; set; }
        public string Level { get; set; } // info, error, warning, etc.
    }
}
