using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;

namespace mikk_mmc_web.Services
{
    public class LogService : ILogService
    {
        private readonly ILogger<LogService> _logger;
        private readonly IRouterService _routerService;
        private readonly Random _random = new Random(); // Chỉ để demo trong môi trường phát triển

        // Dữ liệu mẫu cho phát triển
        private List<LogEntry> _demoLogs = new List<LogEntry>();

        public LogService(ILogger<LogService> logger, IRouterService routerService)
        {
            _logger = logger;
            _routerService = routerService;
            InitializeDemoLogs();
        }

        private void InitializeDemoLogs()
        {
            var topics = new[] { "system", "interface", "dhcp", "firewall", "wireless", "user", "script" };
            var levels = new[] { "info", "warning", "error", "debug" };
            var messages = new Dictionary<string, List<string>>
            {
                { "system", new List<string> { "system started", "configuration saved", "rebooting device", "upgrade completed", "time synchronized", "backup created" } },
                { "interface", new List<string> { "ether1 link up", "ether1 link down", "wlan1 frequency changed to 5180MHz", "bridge1 learning done", "interface status changed", "pppoe-out1 connected" } },
                { "dhcp", new List<string> { "lease granted to 00:1A:2B:3C:4D:5E", "lease expired for 192.168.1.104", "lease changed from 192.168.1.105 to 192.168.1.110", "dhcp server restarted", "static lease added", "conflict detected" } },
                { "firewall", new List<string> { "dropping packet from 203.0.113.5", "accepting connection to port 443", "connection attempt blocked", "rule chain updated", "address list updated", "rule applied" } },
                { "wireless", new List<string> { "signal strength low on wlan1", "client connected to wlan1", "client disconnected from wlan1", "unauthorized access attempt", "channel switched to 11", "registration table updated" } },
                { "user", new List<string> { "admin logged in via web", "admin logged out", "user password changed", "failed login attempt", "user account created", "permission changed" } },
                { "script", new List<string> { "backup script failed to execute", "scheduled script started", "script execution completed", "script syntax error", "scheduler added new task", "script disabled" } }
            };

            _demoLogs = new List<LogEntry>();
            
            // Tạo 200 bản ghi log mẫu
            for (int i = 0; i < 200; i++)
            {
                var time = DateTime.Now.AddMinutes(-i * 10 - _random.Next(1, 10));
                var topic = topics[_random.Next(topics.Length)];
                var level = levels[_random.Next(levels.Length)];
                var messageList = messages[topic];
                var message = messageList[_random.Next(messageList.Count)];
                
                _demoLogs.Add(new LogEntry
                {
                    Id = (i + 1).ToString(),
                    Time = time,
                    Topic = topic,
                    Message = message,
                    LogLevel = level
                });
            }
            
            // Sắp xếp log theo thời gian (mới nhất lên đầu)
            _demoLogs = _demoLogs.OrderByDescending(l => l.Time).ToList();
        }

        public async Task<List<LogEntry>> GetAllLogsAsync(int maxEntries = 100)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy danh sách log: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy tối đa {maxEntries} bản ghi log");
                
                // Giả lập thời gian trễ
                await Task.Delay(1000);
                
                var logs = _demoLogs.Take(maxEntries).ToList();
                
                _logger.LogInformation($"Đã lấy {logs.Count} bản ghi log thành công");
                return logs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách log: {ex.Message}");
                throw;
            }
        }

        public async Task<List<LogEntry>> GetLogsByTopicAsync(string topic, int maxEntries = 100)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy danh sách log theo chủ đề: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy tối đa {maxEntries} bản ghi log với chủ đề {topic}");
                
                // Giả lập thời gian trễ
                await Task.Delay(800);
                
                var logs = _demoLogs
                    .Where(l => l.Topic.Equals(topic, StringComparison.OrdinalIgnoreCase))
                    .Take(maxEntries)
                    .ToList();
                
                _logger.LogInformation($"Đã lấy {logs.Count} bản ghi log với chủ đề {topic} thành công");
                return logs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách log theo chủ đề: {ex.Message}");
                throw;
            }
        }

        public async Task<List<LogEntry>> GetLogsByLevelAsync(string level, int maxEntries = 100)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy danh sách log theo mức độ: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy tối đa {maxEntries} bản ghi log với mức độ {level}");
                
                // Giả lập thời gian trễ
                await Task.Delay(800);
                
                var logs = _demoLogs
                    .Where(l => l.LogLevel.Equals(level, StringComparison.OrdinalIgnoreCase))
                    .Take(maxEntries)
                    .ToList();
                
                _logger.LogInformation($"Đã lấy {logs.Count} bản ghi log với mức độ {level} thành công");
                return logs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách log theo mức độ: {ex.Message}");
                throw;
            }
        }

        public async Task<List<LogEntry>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate, int maxEntries = 100)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy danh sách log theo khoảng thời gian: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy tối đa {maxEntries} bản ghi log từ {startDate} đến {endDate}");
                
                // Giả lập thời gian trễ
                await Task.Delay(1200);
                
                var logs = _demoLogs
                    .Where(l => l.Time >= startDate && l.Time <= endDate)
                    .Take(maxEntries)
                    .ToList();
                
                _logger.LogInformation($"Đã lấy {logs.Count} bản ghi log trong khoảng thời gian từ {startDate} đến {endDate} thành công");
                return logs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách log theo khoảng thời gian: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ClearLogsAsync()
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể xóa log: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation("Đang xóa tất cả log");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1500);
                
                _demoLogs.Clear();
                
                _logger.LogInformation("Đã xóa tất cả log thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi xóa log: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ExportLogsAsync(string filename)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể xuất log: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang xuất log ra file {filename}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(2000);
                
                _logger.LogInformation($"Đã xuất log ra file {filename} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi xuất log: {ex.Message}");
                return false;
            }
        }
    }
}
