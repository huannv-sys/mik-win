using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;

namespace mikk_mmc_web.Services
{
    // Triển khai Demo Router Service
    public class RouterService : IRouterService
    {
        private readonly ILogger<RouterService> _logger;

        public RouterService(ILogger<RouterService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> ConnectToRouterAsync(string ipAddress, string username, string password)
        {
            _logger.LogInformation($"Connecting to router at {ipAddress}");
            // TODO: Thực hiện kết nối thực tế đến router
            await Task.Delay(1000); // Mô phỏng độ trễ kết nối
            return true;
        }

        public async Task<RouterInfo> GetRouterInfoAsync()
        {
            _logger.LogInformation("Getting router information");
            await Task.Delay(800); // Mô phỏng độ trễ
            
            // Dữ liệu mẫu
            return new RouterInfo
            {
                Name = "MikroTik Router",
                Model = "RouterBOARD 3011UiAS",
                SerialNumber = "43E705B1B285",
                RouterOSVersion = "6.48.6 (stable)",
                Uptime = "10d 5h 30m 15s",
                CpuLoad = 15,
                MemoryUsage = 128.5,
                TotalMemory = 1024,
                StorageUsage = 125.2,
                TotalStorage = 512,
                Temperature = 42
            };
        }

        public async Task<SystemResources> GetSystemResourcesAsync()
        {
            _logger.LogInformation("Getting system resources");
            await Task.Delay(700); // Mô phỏng độ trễ
            
            return new SystemResources
            {
                CpuLoad = 15,
                MemoryUsage = 128.5,
                TotalMemory = 1024,
                DiskUsage = 125.2,
                TotalDisk = 512
            };
        }
    }

    // Triển khai Demo Interface Service
    public class InterfaceService : IInterfaceService
    {
        private readonly ILogger<InterfaceService> _logger;

        public InterfaceService(ILogger<InterfaceService> logger)
        {
            _logger = logger;
        }

        public async Task<List<NetworkInterface>> GetNetworkInterfacesAsync()
        {
            _logger.LogInformation("Getting network interfaces");
            await Task.Delay(800); // Mô phỏng độ trễ
            
            // Dữ liệu mẫu
            return new List<NetworkInterface>
            {
                new NetworkInterface {
                    Name = "ether1", 
                    Type = "Ethernet", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:EF", 
                    IpAddress = "192.168.1.1/24", 
                    Speed = "1Gbps", 
                    TxRx = "15.2 MB / 45.6 MB"
                },
                new NetworkInterface {
                    Name = "ether2", 
                    Type = "Ethernet", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:F0", 
                    IpAddress = "10.0.0.1/24", 
                    Speed = "1Gbps", 
                    TxRx = "5.1 MB / 12.3 MB"
                },
                new NetworkInterface {
                    Name = "wlan1", 
                    Type = "Wireless", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:F1", 
                    IpAddress = "172.16.0.1/24", 
                    Speed = "300Mbps", 
                    TxRx = "42.1 MB / 78.5 MB"
                },
                new NetworkInterface {
                    Name = "bridge1", 
                    Type = "Bridge", 
                    Status = "up", 
                    MacAddress = "00:0C:29:AB:CD:F2", 
                    IpAddress = "192.168.10.1/24", 
                    Speed = "-", 
                    TxRx = "10.5 MB / 25.1 MB"
                },
                new NetworkInterface {
                    Name = "vpn-out1", 
                    Type = "OVPN Client", 
                    Status = "down", 
                    MacAddress = "-", 
                    IpAddress = "-", 
                    Speed = "-", 
                    TxRx = "0B / 0B"
                }
            };
        }

        public async Task<InterfaceTraffic> GetInterfaceTrafficAsync(string interfaceName)
        {
            _logger.LogInformation($"Getting traffic for interface {interfaceName}");
            await Task.Delay(500); // Mô phỏng độ trễ
            
            // Dữ liệu mẫu
            return new InterfaceTraffic
            {
                Interface = interfaceName,
                TxBytes = 15728640, // 15 MB
                RxBytes = 47841280, // 45.6 MB
                TxPackets = 12500,
                RxPackets = 32000,
                Timestamp = DateTime.Now
            };
        }
    }

    // Triển khai Demo Firewall Service
    public class FirewallService : IFirewallService
    {
        private readonly ILogger<FirewallService> _logger;

        public FirewallService(ILogger<FirewallService> logger)
        {
            _logger = logger;
        }

        public async Task<List<FirewallRule>> GetFirewallRulesAsync()
        {
            _logger.LogInformation("Getting firewall rules");
            await Task.Delay(800); // Mô phỏng độ trễ
            
            // Dữ liệu mẫu
            return new List<FirewallRule>
            {
                new FirewallRule { 
                    Id = "1", 
                    Chain = "forward", 
                    Action = "accept", 
                    Protocol = "tcp", 
                    SrcAddress = "192.168.1.0/24", 
                    DstAddress = "0.0.0.0/0", 
                    DstPort = "80,443", 
                    Comment = "Allow web access" 
                },
                new FirewallRule { 
                    Id = "2", 
                    Chain = "forward", 
                    Action = "drop", 
                    Protocol = "tcp", 
                    SrcAddress = "0.0.0.0/0", 
                    DstAddress = "192.168.1.0/24", 
                    DstPort = "3389", 
                    Comment = "Block RDP from WAN" 
                },
                new FirewallRule { 
                    Id = "3", 
                    Chain = "input", 
                    Action = "accept", 
                    Protocol = "tcp", 
                    SrcAddress = "192.168.1.0/24", 
                    DstAddress = "192.168.1.1", 
                    DstPort = "22,80,443", 
                    Comment = "Router management" 
                },
                new FirewallRule { 
                    Id = "4", 
                    Chain = "input", 
                    Action = "drop", 
                    Protocol = "tcp", 
                    SrcAddress = "0.0.0.0/0", 
                    DstAddress = "192.168.1.1", 
                    DstPort = "22", 
                    Comment = "Block SSH from WAN" 
                },
                new FirewallRule { 
                    Id = "5", 
                    Chain = "forward", 
                    Action = "accept", 
                    Protocol = "icmp", 
                    SrcAddress = "192.168.1.0/24", 
                    DstAddress = "0.0.0.0/0", 
                    DstPort = "-", 
                    Comment = "Allow ping" 
                }
            };
        }

        public async Task<bool> AddFirewallRuleAsync(FirewallRule rule)
        {
            _logger.LogInformation($"Adding firewall rule to chain {rule.Chain}");
            await Task.Delay(1000); // Mô phỏng độ trễ
            return true;
        }

        public async Task<bool> RemoveFirewallRuleAsync(string id)
        {
            _logger.LogInformation($"Removing firewall rule with ID {id}");
            await Task.Delay(800); // Mô phỏng độ trễ
            return true;
        }
    }

    // Triển khai Demo DHCP Service
    public class DhcpService : IDhcpService
    {
        private readonly ILogger<DhcpService> _logger;

        public DhcpService(ILogger<DhcpService> logger)
        {
            _logger = logger;
        }

        public async Task<List<DhcpLease>> GetDhcpLeasesAsync()
        {
            _logger.LogInformation("Getting DHCP leases");
            await Task.Delay(700); // Mô phỏng độ trễ
            
            // Dữ liệu mẫu
            return new List<DhcpLease>
            {
                new DhcpLease { 
                    IpAddress = "192.168.1.100", 
                    MacAddress = "00:1A:2B:3C:4D:5E", 
                    Hostname = "laptop-user1", 
                    Status = "active", 
                    ExpiresIn = "23h 45m" 
                },
                new DhcpLease { 
                    IpAddress = "192.168.1.101", 
                    MacAddress = "00:1A:2B:3C:4D:5F", 
                    Hostname = "desktop-user2", 
                    Status = "active", 
                    ExpiresIn = "23h 10m" 
                },
                new DhcpLease { 
                    IpAddress = "192.168.1.102", 
                    MacAddress = "00:1A:2B:3C:4D:60", 
                    Hostname = "phone-user1", 
                    Status = "active", 
                    ExpiresIn = "22h 30m" 
                },
                new DhcpLease { 
                    IpAddress = "192.168.1.103", 
                    MacAddress = "00:1A:2B:3C:4D:61", 
                    Hostname = "tablet-user3", 
                    Status = "active", 
                    ExpiresIn = "21h 55m" 
                },
                new DhcpLease { 
                    IpAddress = "192.168.1.104", 
                    MacAddress = "00:1A:2B:3C:4D:62", 
                    Hostname = "iot-device1", 
                    Status = "expired", 
                    ExpiresIn = "0h 0m" 
                }
            };
        }
    }

    // Triển khai Demo Log Service
    public class LogService : ILogService
    {
        private readonly ILogger<LogService> _logger;

        public LogService(ILogger<LogService> logger)
        {
            _logger = logger;
        }

        public async Task<List<LogEntry>> GetSystemLogsAsync(int count = 10)
        {
            _logger.LogInformation($"Getting {count} system logs");
            await Task.Delay(800); // Mô phỏng độ trễ
            
            // Dữ liệu mẫu
            var logs = new List<LogEntry>
            {
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 07:00:01"), 
                    Level = "info", 
                    Topic = "system", 
                    Message = "system started" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 07:01:15"), 
                    Level = "info", 
                    Topic = "interface", 
                    Message = "ether1 link up" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 07:01:16"), 
                    Level = "info", 
                    Topic = "dhcp", 
                    Message = "lease granted to 00:1A:2B:3C:4D:5E" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 07:15:22"), 
                    Level = "warning", 
                    Topic = "firewall", 
                    Message = "dropping packet from 203.0.113.5" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 07:30:45"), 
                    Level = "info", 
                    Topic = "user", 
                    Message = "admin logged in via web" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 08:10:11"), 
                    Level = "info", 
                    Topic = "interface", 
                    Message = "wlan1 frequency changed to 5180MHz" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 08:45:32"), 
                    Level = "error", 
                    Topic = "script", 
                    Message = "backup script failed to execute" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 09:12:05"), 
                    Level = "info", 
                    Topic = "system", 
                    Message = "configuration saved" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 09:30:18"), 
                    Level = "info", 
                    Topic = "dhcp", 
                    Message = "lease expired for 192.168.1.104" 
                },
                new LogEntry { 
                    Timestamp = DateTime.Parse("2023-03-24 10:05:22"), 
                    Level = "warning", 
                    Topic = "wireless", 
                    Message = "signal strength low on wlan1" 
                }
            };
            
            return logs.GetRange(0, Math.Min(count, logs.Count));
        }
    }
}
