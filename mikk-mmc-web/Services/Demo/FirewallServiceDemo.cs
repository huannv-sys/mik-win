using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mikk_mmc_web.Services.Demo
{
    public class FirewallServiceDemo : IFirewallService
    {
        private readonly ILogger<FirewallServiceDemo> _logger;
        private readonly List<FirewallRule> _rules = new();
        private readonly Random _random = new Random();

        public FirewallServiceDemo(ILogger<FirewallServiceDemo> logger)
        {
            _logger = logger;
            InitializeFirewallRules();
        }

        private void InitializeFirewallRules()
        {
            _rules.Add(new FirewallRule
            {
                Id = "1",
                Chain = "forward",
                Action = "accept",
                Protocol = "tcp",
                SrcAddress = "192.168.1.0/24",
                DstAddress = "0.0.0.0/0", 
                SrcPort = "",
                DstPort = "",
                Disabled = false,
                Comment = "Cho phép mạng LAN truy cập Internet",
                LastHit = DateTime.Now.AddMinutes(-_random.Next(0, 15)),
                HitCount = 1542
            });

            _rules.Add(new FirewallRule
            {
                Id = "2",
                Chain = "forward",
                Action = "drop",
                Protocol = "tcp",
                SrcAddress = "0.0.0.0/0",
                DstAddress = "192.168.1.10",
                SrcPort = "",
                DstPort = "3389",
                Disabled = false,
                Comment = "Chặn kết nối RDP từ bên ngoài",
                LastHit = DateTime.Now.AddMinutes(-_random.Next(15, 30)),
                HitCount = 218
            });

            _rules.Add(new FirewallRule
            {
                Id = "3",
                Chain = "input",
                Action = "accept",
                Protocol = "tcp",
                SrcAddress = "192.168.1.0/24",
                DstAddress = "192.168.1.1", 
                SrcPort = "",
                DstPort = "80,443",
                Disabled = false,
                Comment = "Cho phép truy cập web quản trị từ mạng LAN",
                LastHit = DateTime.Now.AddMinutes(-_random.Next(0, 30)),
                HitCount = 87
            });

            _rules.Add(new FirewallRule
            {
                Id = "4",
                Chain = "input",
                Action = "drop",
                Protocol = "tcp",
                SrcAddress = "0.0.0.0/0",
                DstAddress = "192.168.1.1",
                SrcPort = "",
                DstPort = "22",
                Disabled = false,
                Comment = "Chặn SSH từ Internet",
                LastHit = DateTime.Now.AddMinutes(-_random.Next(30, 60)),
                HitCount = 423
            });

            _rules.Add(new FirewallRule
            {
                Id = "5",
                Chain = "forward",
                Action = "accept",
                Protocol = "tcp,udp",
                SrcAddress = "0.0.0.0/0",
                DstAddress = "192.168.1.20",
                SrcPort = "",
                DstPort = "80,443",
                Disabled = false,
                Comment = "Chuyển tiếp cổng web server",
                LastHit = DateTime.Now.AddMinutes(-_random.Next(0, 60)),
                HitCount = 756
            });

            _rules.Add(new FirewallRule
            {
                Id = "6",
                Chain = "input",
                Action = "drop",
                Protocol = "tcp",
                SrcAddress = "0.0.0.0/0",
                DstAddress = "192.168.1.1",
                SrcPort = "",
                DstPort = "8291",
                Disabled = false,
                Comment = "Chặn Winbox từ Internet",
                LastHit = DateTime.Now.AddHours(-2),
                HitCount = 15
            });

            _rules.Add(new FirewallRule
            {
                Id = "7",
                Chain = "forward",
                Action = "accept",
                Protocol = "icmp",
                SrcAddress = "192.168.1.0/24",
                DstAddress = "0.0.0.0/0",
                SrcPort = "",
                DstPort = "",
                Disabled = false,
                Comment = "Cho phép ICMP từ LAN",
                LastHit = DateTime.Now.AddMinutes(-_random.Next(0, 30)),
                HitCount = 213
            });

            _rules.Add(new FirewallRule
            {
                Id = "8",
                Chain = "input",
                Action = "accept",
                Protocol = "tcp",
                SrcAddress = "192.168.1.100",
                DstAddress = "192.168.1.1",
                SrcPort = "",
                DstPort = "22",
                Disabled = false,
                Comment = "Cho phép SSH từ admin workstation",
                LastHit = DateTime.Now.AddDays(-1),
                HitCount = 42
            });
        }

        public async Task<IEnumerable<FirewallRule>> GetFirewallRulesAsync()
        {
            _logger.LogInformation("Đang lấy danh sách luật tường lửa...");
            
            // Giả lập thời gian phản hồi
            await Task.Delay(300);
            
            // Cập nhật hit count và last hit ngẫu nhiên cho một số luật
            foreach (var rule in _rules.Where(r => !r.Disabled))
            {
                if (_random.Next(0, 10) > 6)  // 30% cơ hội cập nhật
                {
                    rule.HitCount += _random.Next(1, 5);
                    if (_random.Next(0, 10) > 8)  // 10% cơ hội cập nhật thời gian
                    {
                        rule.LastHit = DateTime.Now;
                    }
                }
            }
            
            _logger.LogInformation("Đã lấy danh sách luật tường lửa thành công");
            
            return _rules.OrderBy(r => r.Chain).ThenBy(r => int.Parse(r.Id));
        }

        public async Task<FirewallRule> GetFirewallRuleByIdAsync(string id)
        {
            _logger.LogInformation("Đang lấy thông tin luật tường lửa {Id}...", id);
            
            // Giả lập thời gian phản hồi
            await Task.Delay(100);
            
            var rule = _rules.FirstOrDefault(r => r.Id == id);
            
            if (rule == null)
            {
                _logger.LogWarning("Không tìm thấy luật tường lửa {Id}", id);
                return null;
            }
            
            _logger.LogInformation("Đã lấy thông tin luật tường lửa {Id} thành công", id);
            
            return rule;
        }
    }
}
