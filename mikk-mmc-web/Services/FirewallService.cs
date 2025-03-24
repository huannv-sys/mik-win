using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;

namespace mikk_mmc_web.Services
{
    public class FirewallService : IFirewallService
    {
        private readonly ILogger<FirewallService> _logger;
        private readonly IRouterService _routerService;
        private readonly Random _random = new Random(); // Chỉ để demo trong môi trường phát triển

        // Dữ liệu mẫu cho phát triển
        private List<FirewallRule> _demoRules = new List<FirewallRule>();

        public FirewallService(ILogger<FirewallService> logger, IRouterService routerService)
        {
            _logger = logger;
            _routerService = routerService;
            InitializeDemoRules();
        }

        private void InitializeDemoRules()
        {
            _demoRules = new List<FirewallRule>
            {
                new FirewallRule
                {
                    Id = "1",
                    Chain = "forward",
                    Action = "accept",
                    Protocol = "tcp",
                    SrcAddress = "0.0.0.0/0",
                    DstAddress = "192.168.1.0/24",
                    SrcPort = "",
                    DstPort = "80,443",
                    Comment = "Allow HTTP and HTTPS to LAN",
                    Disabled = false,
                    PacketCount = 12345,
                    ByteCount = 1234567,
                    LastHit = DateTime.Now.AddMinutes(-5)
                },
                new FirewallRule
                {
                    Id = "2",
                    Chain = "forward",
                    Action = "drop",
                    Protocol = "tcp",
                    SrcAddress = "0.0.0.0/0",
                    DstAddress = "192.168.1.0/24",
                    SrcPort = "",
                    DstPort = "25",
                    Comment = "Block SMTP",
                    Disabled = false,
                    PacketCount = 123,
                    ByteCount = 12345,
                    LastHit = DateTime.Now.AddHours(-2)
                },
                new FirewallRule
                {
                    Id = "3",
                    Chain = "input",
                    Action = "accept",
                    Protocol = "tcp",
                    SrcAddress = "0.0.0.0/0",
                    DstAddress = "0.0.0.0/0",
                    SrcPort = "",
                    DstPort = "8291",
                    Comment = "Allow Winbox",
                    Disabled = false,
                    PacketCount = 4567,
                    ByteCount = 456789,
                    LastHit = DateTime.Now.AddMinutes(-15)
                },
                new FirewallRule
                {
                    Id = "4",
                    Chain = "input",
                    Action = "accept",
                    Protocol = "icmp",
                    SrcAddress = "0.0.0.0/0",
                    DstAddress = "0.0.0.0/0",
                    SrcPort = "",
                    DstPort = "",
                    Comment = "Allow ICMP",
                    Disabled = false,
                    PacketCount = 789,
                    ByteCount = 78901,
                    LastHit = DateTime.Now.AddMinutes(-1)
                },
                new FirewallRule
                {
                    Id = "5",
                    Chain = "forward",
                    Action = "drop",
                    Protocol = "0",
                    SrcAddress = "203.0.113.0/24",
                    DstAddress = "0.0.0.0/0",
                    SrcPort = "",
                    DstPort = "",
                    Comment = "Block suspicious IPs",
                    Disabled = false,
                    PacketCount = 5678,
                    ByteCount = 567890,
                    LastHit = DateTime.Now.AddMinutes(-30)
                },
                new FirewallRule
                {
                    Id = "6",
                    Chain = "forward",
                    Action = "drop",
                    Protocol = "tcp",
                    SrcAddress = "0.0.0.0/0",
                    DstAddress = "0.0.0.0/0",
                    SrcPort = "",
                    DstPort = "23",
                    Comment = "Block Telnet",
                    Disabled = true,
                    PacketCount = 0,
                    ByteCount = 0,
                    LastHit = DateTime.MinValue
                }
            };
        }

        public async Task<List<FirewallRule>> GetAllRulesAsync()
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy danh sách luật tường lửa: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation("Đang lấy danh sách luật tường lửa");
                
                // Giả lập thời gian trễ
                await Task.Delay(1000);
                
                _logger.LogInformation($"Đã lấy {_demoRules.Count} luật tường lửa thành công");
                return _demoRules;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách luật tường lửa: {ex.Message}");
                throw;
            }
        }

        public async Task<FirewallRule> GetRuleByIdAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy thông tin luật tường lửa: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy thông tin luật tường lửa có ID {id}");
                
                // Giả lập thời gian trễ
                await Task.Delay(500);
                
                var rule = _demoRules.FirstOrDefault(r => r.Id == id);
                if (rule == null)
                {
                    _logger.LogWarning($"Không tìm thấy luật tường lửa có ID {id}");
                    throw new KeyNotFoundException($"Không tìm thấy luật tường lửa có ID {id}");
                }
                
                _logger.LogInformation($"Đã lấy thông tin luật tường lửa có ID {id} thành công");
                return rule;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy thông tin luật tường lửa: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> EnableRuleAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể bật luật tường lửa: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang bật luật tường lửa có ID {id}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(800);
                
                var rule = _demoRules.FirstOrDefault(r => r.Id == id);
                if (rule == null)
                {
                    _logger.LogWarning($"Không tìm thấy luật tường lửa có ID {id}");
                    return false;
                }
                
                rule.Disabled = false;
                
                _logger.LogInformation($"Đã bật luật tường lửa có ID {id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi bật luật tường lửa: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DisableRuleAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể tắt luật tường lửa: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang tắt luật tường lửa có ID {id}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(800);
                
                var rule = _demoRules.FirstOrDefault(r => r.Id == id);
                if (rule == null)
                {
                    _logger.LogWarning($"Không tìm thấy luật tường lửa có ID {id}");
                    return false;
                }
                
                rule.Disabled = true;
                
                _logger.LogInformation($"Đã tắt luật tường lửa có ID {id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi tắt luật tường lửa: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> MoveRuleUpAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể di chuyển luật tường lửa: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang di chuyển luật tường lửa có ID {id} lên trên");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1000);
                
                var index = _demoRules.FindIndex(r => r.Id == id);
                if (index <= 0)
                {
                    _logger.LogWarning($"Không thể di chuyển luật ID {id} lên trên (đã ở vị trí đầu tiên hoặc không tồn tại)");
                    return false;
                }
                
                var rule = _demoRules[index];
                _demoRules.RemoveAt(index);
                _demoRules.Insert(index - 1, rule);
                
                _logger.LogInformation($"Đã di chuyển luật tường lửa có ID {id} lên trên thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi di chuyển luật tường lửa: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> MoveRuleDownAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể di chuyển luật tường lửa: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang di chuyển luật tường lửa có ID {id} xuống dưới");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1000);
                
                var index = _demoRules.FindIndex(r => r.Id == id);
                if (index < 0 || index >= _demoRules.Count - 1)
                {
                    _logger.LogWarning($"Không thể di chuyển luật ID {id} xuống dưới (đã ở vị trí cuối hoặc không tồn tại)");
                    return false;
                }
                
                var rule = _demoRules[index];
                _demoRules.RemoveAt(index);
                _demoRules.Insert(index + 1, rule);
                
                _logger.LogInformation($"Đã di chuyển luật tường lửa có ID {id} xuống dưới thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi di chuyển luật tường lửa: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteRuleAsync(string id)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể xóa luật tường lửa: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang xóa luật tường lửa có ID {id}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1200);
                
                var rule = _demoRules.FirstOrDefault(r => r.Id == id);
                if (rule == null)
                {
                    _logger.LogWarning($"Không tìm thấy luật tường lửa có ID {id}");
                    return false;
                }
                
                _demoRules.Remove(rule);
                
                _logger.LogInformation($"Đã xóa luật tường lửa có ID {id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi xóa luật tường lửa: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CreateRuleAsync(FirewallRule rule)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể tạo luật tường lửa: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation("Đang tạo luật tường lửa mới");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1500);
                
                // Gán ID mới
                rule.Id = (_demoRules.Count + 1).ToString();
                
                _demoRules.Add(rule);
                
                _logger.LogInformation($"Đã tạo luật tường lửa mới có ID {rule.Id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi tạo luật tường lửa: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateRuleAsync(FirewallRule rule)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể cập nhật luật tường lửa: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang cập nhật luật tường lửa có ID {rule.Id}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1200);
                
                var index = _demoRules.FindIndex(r => r.Id == rule.Id);
                if (index < 0)
                {
                    _logger.LogWarning($"Không tìm thấy luật tường lửa có ID {rule.Id}");
                    return false;
                }
                
                _demoRules[index] = rule;
                
                _logger.LogInformation($"Đã cập nhật luật tường lửa có ID {rule.Id} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi cập nhật luật tường lửa: {ex.Message}");
                return false;
            }
        }
    }
}
