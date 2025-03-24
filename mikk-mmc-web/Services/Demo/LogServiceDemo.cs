using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mikk_mmc_web.Services.Demo
{
    public class LogServiceDemo : ILogService
    {
        private readonly ILogger<LogServiceDemo> _logger;
        private readonly List<LogEntry> _logs = new();
        private readonly Random _random = new Random();
        private readonly string[] _logTopics = { "system", "firewall", "dhcp", "interface", "wireless", "critical-notes", "vpn", "routing", "ppp", "disk", "web-proxy" };
        private readonly string[] _logLevels = { "info", "warning", "error" };
        private readonly Dictionary<string, string[]> _topicMessages = new();
        private int _nextLogId = 1;

        public LogServiceDemo(ILogger<LogServiceDemo> logger)
        {
            _logger = logger;
            InitializeLogMessages();
            GenerateInitialLogs(200);
        }

        private void InitializeLogMessages()
        {
            _topicMessages["system"] = new[]
            {
                "System started",
                "Uptime: {0} days",
                "CPU load: {0}%",
                "Memory usage: {0}%",
                "Configuration change by admin",
                "Reboot initiated by user",
                "Software update available: RouterOS {0}",
                "Remote access from IP {0}",
                "Scheduled backup completed",
                "System time synchronized with NTP server"
            };
            
            _topicMessages["firewall"] = new[]
            {
                "Rejected connection from {0} to {1}:{2}",
                "Blocked port scan attempt from {0}",
                "Added IP {0} to address list 'Blacklist'",
                "Removed IP {0} from address list 'Blacklist'",
                "Created new firewall rule: {0}",
                "Modified firewall rule: {0}",
                "Multiple connection attempts from {0} blocked",
                "Firewall rule {0} hit count exceeded threshold",
                "Suspicious traffic pattern detected from {0}",
                "Rate-limit exceeded for IP {0}"
            };
            
            _topicMessages["dhcp"] = new[]
            {
                "DHCP address {0} assigned to client {1}",
                "DHCP lease expired for {0} ({1})",
                "DHCP server started on interface {0}",
                "IP conflict detected: {0} is used by {1} and {2}",
                "DHCP lease renewed for {0} ({1})",
                "Static lease created for {0} ({1})",
                "DHCP range modified to {0}-{1}",
                "DHCP server stopped on interface {0}",
                "No free DHCP addresses available in pool {0}",
                "DHCP request from unauthorized MAC {0}"
            };
            
            _topicMessages["interface"] = new[]
            {
                "Interface {0} link up",
                "Interface {0} link down",
                "Interface {0} enabled",
                "Interface {0} disabled",
                "High traffic detected on {0}: {1} Mbps",
                "MTU changed on interface {0} to {1}",
                "Interface {0} added to bridge {1}",
                "Error on interface {0}: {1}",
                "Interface {0} speed changed to {1}",
                "Traffic monitoring started on {0}"
            };
            
            _topicMessages["wireless"] = new[]
            {
                "Wireless client {0} connected to {1}",
                "Wireless client {0} disconnected from {1}",
                "Wireless interface {0} channel changed to {1}",
                "Interference detected on channel {0}",
                "Signal strength low for client {0} on {1}",
                "Wireless network scan completed",
                "Unauthorized access attempt to SSID {0}",
                "Wireless interface {0} mode changed to {1}",
                "WPS session started on {0}",
                "Wireless registration table limit reached"
            };
        }

        private void GenerateInitialLogs(int count)
        {
            var now = DateTime.Now;
            
            for (int i = 0; i < count; i++)
            {
                var topic = _logTopics[_random.Next(_logTopics.Length)];
                var level = GetRandomLogLevel(topic);
                var timeOffset = _random.Next(1, 60 * 24 * 7); // Up to 1 week in minutes
                
                _logs.Add(new LogEntry
                {
                    Id = _nextLogId.ToString(),
                    Time = now.AddMinutes(-timeOffset),
                    Topics = topic,
                    Level = level,
                    Message = GenerateLogMessage(topic)
                });
                
                _nextLogId++;
            }
            
            // Sort logs by time, newest first
            _logs.Sort((a, b) => b.Time.CompareTo(a.Time));
        }

        private string GetRandomLogLevel(string topic)
        {
            // Different distribution of log levels based on topics
            switch (topic)
            {
                case "critical-notes":
                    return _random.Next(10) < 7 ? "error" : "warning";
                    
                case "firewall":
                    return _random.Next(10) < 5 ? "warning" : (_random.Next(10) < 8 ? "info" : "error");
                    
                case "system":
                    return _random.Next(10) < 7 ? "info" : (_random.Next(10) < 8 ? "warning" : "error");
                    
                default:
                    return _logLevels[_random.Next(_logLevels.Length)];
            }
        }

        private string GenerateLogMessage(string topic)
        {
            if (!_topicMessages.TryGetValue(topic, out var messages))
            {
                return $"{topic} event occurred";
            }
            
            var messageTemplate = messages[_random.Next(messages.Length)];
            
            // Replace placeholders with random values
            return messageTemplate
                .Replace("{0}", GetRandomValueForTopic(topic, 0))
                .Replace("{1}", GetRandomValueForTopic(topic, 1))
                .Replace("{2}", GetRandomValueForTopic(topic, 2));
        }

        private string GetRandomValueForTopic(string topic, int placeholderIndex)
        {
            switch (topic)
            {
                case "system":
                    if (placeholderIndex == 0)
                    {
                        switch (_random.Next(4))
                        {
                            case 0: return _random.Next(1, 365).ToString();  // days
                            case 1: return _random.Next(5, 90).ToString();   // CPU load
                            case 2: return _random.Next(20, 95).ToString();  // Memory usage
                            case 3: return $"7.{_random.Next(1, 10)}";       // RouterOS version
                        }
                    }
                    else if (placeholderIndex == 1)
                    {
                        return $"192.168.1.{_random.Next(2, 255)}";  // IP address
                    }
                    break;
                    
                case "firewall":
                    if (placeholderIndex == 0)
                    {
                        // External IP
                        return $"{_random.Next(1, 255)}.{_random.Next(0, 255)}.{_random.Next(0, 255)}.{_random.Next(1, 255)}";
                    }
                    else if (placeholderIndex == 1)
                    {
                        // Internal IP
                        return $"192.168.1.{_random.Next(1, 255)}";
                    }
                    else if (placeholderIndex == 2)
                    {
                        // Port
                        return _random.Next(1, 65535).ToString();
                    }
                    break;
                    
                case "dhcp":
                    if (placeholderIndex == 0)
                    {
                        // IP
                        return $"192.168.1.{_random.Next(10, 250)}";
                    }
                    else if (placeholderIndex == 1)
                    {
                        // MAC
                        return $"{_random.Next(16):X2}:{_random.Next(16):X2}:{_random.Next(16):X2}:{_random.Next(16):X2}:{_random.Next(16):X2}:{_random.Next(16):X2}";
                    }
                    break;
                    
                case "interface":
                    if (placeholderIndex == 0)
                    {
                        // Interface name
                        string[] interfaces = { "ether1", "ether2", "wlan1", "bridge1", "ovpn-out1" };
                        return interfaces[_random.Next(interfaces.Length)];
                    }
                    else if (placeholderIndex == 1)
                    {
                        // Speed/MTU/Error
                        string[] values = { "100M", "1000M", "1500", "2100", "timeout", "no link", "10M" };
                        return values[_random.Next(values.Length)];
                    }
                    break;
                    
                case "wireless":
                    if (placeholderIndex == 0)
                    {
                        // Client name/MAC
                        return $"device-{_random.Next(1, 20)}";
                    }
                    else if (placeholderIndex == 1)
                    {
                        // SSID/Interface
                        string[] values = { "wlan1", "Office-WiFi", "Guest-Network", "wlan2", "5GHz-Network" };
                        return values[_random.Next(values.Length)];
                    }
                    break;
            }
            
            return placeholderIndex.ToString();  // Fallback
        }

        public async Task<IEnumerable<LogEntry>> GetLogsAsync(int limit = 100)
        {
            _logger.LogInformation("Đang lấy nhật ký với giới hạn {Limit}...", limit);
            
            // Giả lập thời gian phản hồi
            await Task.Delay(200);
            
            // Thêm log mới đôi khi
            if (_random.Next(0, 10) > 7)  // 20% cơ hội
            {
                var topic = _logTopics[_random.Next(_logTopics.Length)];
                var level = GetRandomLogLevel(topic);
                
                _logs.Insert(0, new LogEntry
                {
                    Id = _nextLogId.ToString(),
                    Time = DateTime.Now,
                    Topics = topic,
                    Level = level,
                    Message = GenerateLogMessage(topic)
                });
                
                _nextLogId++;
                
                // Giữ danh sách log ở kích thước hợp lý
                if (_logs.Count > 1000)
                {
                    _logs.RemoveAt(_logs.Count - 1);
                }
            }
            
            _logger.LogInformation("Đã lấy nhật ký thành công");
            
            return _logs.Take(limit);
        }

        public async Task<LogEntry> GetLogByIdAsync(string id)
        {
            _logger.LogInformation("Đang lấy thông tin nhật ký {Id}...", id);
            
            // Giả lập thời gian phản hồi
            await Task.Delay(100);
            
            var log = _logs.FirstOrDefault(l => l.Id == id);
            
            if (log == null)
            {
                _logger.LogWarning("Không tìm thấy nhật ký {Id}", id);
                return null;
            }
            
            _logger.LogInformation("Đã lấy thông tin nhật ký {Id} thành công", id);
            
            return log;
        }
    }
}
