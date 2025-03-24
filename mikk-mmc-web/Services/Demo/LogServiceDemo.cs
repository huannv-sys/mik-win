using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;

namespace mikk_mmc_web.Services.Demo
{
    // Triển khai Demo Log Service
    public class LogServiceDemo : ILogService
    {
        private readonly ILogger<LogServiceDemo> _logger;
        private List<LogEntry> _logs;

        public LogServiceDemo(ILogger<LogServiceDemo> logger)
        {
            _logger = logger;
            _logs = InitializeLogs();
        }

        private List<LogEntry> InitializeLogs()
        {
            return new List<LogEntry>
            {
                new LogEntry { 
                    Id = "1",
                    Timestamp = DateTime.Parse("2023-03-24 07:00:01"), 
                    Level = "info", 
                    Topic = "system", 
                    Message = "system started" 
                },
                new LogEntry { 
                    Id = "2",
                    Timestamp = DateTime.Parse("2023-03-24 07:01:15"), 
                    Level = "info", 
                    Topic = "interface", 
                    Message = "ether1 link up" 
                },
                new LogEntry { 
                    Id = "3",
                    Timestamp = DateTime.Parse("2023-03-24 07:01:16"), 
                    Level = "info", 
                    Topic = "dhcp", 
                    Message = "lease granted to 00:1A:2B:3C:4D:5E" 
                },
                new LogEntry { 
                    Id = "4",
                    Timestamp = DateTime.Parse("2023-03-24 07:15:22"), 
                    Level = "warning", 
                    Topic = "firewall", 
                    Message = "dropping packet from 203.0.113.5" 
                },
                new LogEntry { 
                    Id = "5",
                    Timestamp = DateTime.Parse("2023-03-24 07:30:45"), 
                    Level = "info", 
                    Topic = "user", 
                    Message = "admin logged in via web" 
                },
                new LogEntry { 
                    Id = "6",
                    Timestamp = DateTime.Parse("2023-03-24 08:10:11"), 
                    Level = "info", 
                    Topic = "interface", 
                    Message = "wlan1 frequency changed to 5180MHz" 
                },
                new LogEntry { 
                    Id = "7",
                    Timestamp = DateTime.Parse("2023-03-24 08:45:32"), 
                    Level = "error", 
                    Topic = "script", 
                    Message = "backup script failed to execute" 
                },
                new LogEntry { 
                    Id = "8",
                    Timestamp = DateTime.Parse("2023-03-24 09:12:05"), 
                    Level = "info", 
                    Topic = "system", 
                    Message = "configuration saved" 
                },
                new LogEntry { 
                    Id = "9",
                    Timestamp = DateTime.Parse("2023-03-24 09:30:18"), 
                    Level = "info", 
                    Topic = "dhcp", 
                    Message = "lease expired for 192.168.1.104" 
                },
                new LogEntry { 
                    Id = "10",
                    Timestamp = DateTime.Parse("2023-03-24 10:05:22"), 
                    Level = "warning", 
                    Topic = "wireless", 
                    Message = "signal strength low on wlan1" 
                }
            };
        }

        public async Task<List<LogEntry>> GetAllLogsAsync(int maxEntries = 100)
        {
            _logger.LogInformation($"Getting {maxEntries} logs");
            await Task.Delay(800); // Mô phỏng độ trễ
            
            return _logs.OrderByDescending(l => l.Timestamp).Take(maxEntries).ToList();
        }

        public async Task<List<LogEntry>> GetLogsByTopicAsync(string topic, int maxEntries = 100)
        {
            _logger.LogInformation($"Getting {maxEntries} logs by topic: {topic}");
            await Task.Delay(600);
            
            return _logs
                .Where(l => l.Topic.ToLower() == topic.ToLower())
                .OrderByDescending(l => l.Timestamp)
                .Take(maxEntries)
                .ToList();
        }

        public async Task<List<LogEntry>> GetLogsByLevelAsync(string level, int maxEntries = 100)
        {
            _logger.LogInformation($"Getting {maxEntries} logs by level: {level}");
            await Task.Delay(600);
            
            return _logs
                .Where(l => l.Level.ToLower() == level.ToLower())
                .OrderByDescending(l => l.Timestamp)
                .Take(maxEntries)
                .ToList();
        }

        public async Task<List<LogEntry>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate, int maxEntries = 100)
        {
            _logger.LogInformation($"Getting logs between {startDate} and {endDate}");
            await Task.Delay(700);
            
            return _logs
                .Where(l => l.Timestamp >= startDate && l.Timestamp <= endDate)
                .OrderByDescending(l => l.Timestamp)
                .Take(maxEntries)
                .ToList();
        }

        public async Task<bool> ClearLogsAsync()
        {
            _logger.LogInformation("Clearing all logs");
            await Task.Delay(1500);
            _logs.Clear();
            return true;
        }

        public async Task<bool> ExportLogsAsync(string filename)
        {
            _logger.LogInformation($"Exporting logs to {filename}");
            await Task.Delay(2000);
            return true;
        }
    }
}
