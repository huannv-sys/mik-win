using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;

namespace mikk_mmc_web.Services.Demo
{
    // Triển khai Demo Firewall Service
    public class FirewallServiceDemo : IFirewallService
    {
        private readonly ILogger<FirewallServiceDemo> _logger;
        private List<FirewallRule> _rules;

        public FirewallServiceDemo(ILogger<FirewallServiceDemo> logger)
        {
            _logger = logger;
            _rules = InitializeRules();
        }

        private List<FirewallRule> InitializeRules()
        {
            return new List<FirewallRule>
            {
                new FirewallRule { 
                    Id = "1",
                    Chain = "forward", 
                    Action = "drop", 
                    Protocol = "tcp", 
                    SrcAddress = "0.0.0.0/0", 
                    DstAddress = "192.168.1.0/24", 
                    DstPort = "3389", 
                    Comment = "Block RDP from Internet" 
                },
                new FirewallRule { 
                    Id = "2",
                    Chain = "forward", 
                    Action = "accept", 
                    Protocol = "tcp", 
                    SrcAddress = "192.168.1.0/24", 
                    DstAddress = "0.0.0.0/0", 
                    DstPort = "80,443", 
                    Comment = "Allow HTTP/HTTPS" 
                },
                new FirewallRule { 
                    Id = "3",
                    Chain = "forward", 
                    Action = "drop", 
                    Protocol = "tcp", 
                    SrcAddress = "0.0.0.0/0", 
                    DstAddress = "192.168.1.10", 
                    DstPort = "22", 
                    Comment = "Block SSH to server" 
                },
                new FirewallRule { 
                    Id = "4",
                    Chain = "input", 
                    Action = "accept", 
                    Protocol = "icmp", 
                    SrcAddress = "192.168.1.0/24", 
                    DstAddress = "0.0.0.0/0", 
                    DstPort = "", 
                    Comment = "Allow ping from LAN" 
                },
                new FirewallRule { 
                    Id = "5",
                    Chain = "forward", 
                    Action = "accept", 
                    Protocol = "tcp,udp", 
                    SrcAddress = "192.168.1.15", 
                    DstAddress = "0.0.0.0/0", 
                    DstPort = "any", 
                    Comment = "Allow all for admin", 
                    Disabled = true
                }
            };
        }

        public async Task<List<FirewallRule>> GetAllRulesAsync()
        {
            _logger.LogInformation("Getting all firewall rules");
            await Task.Delay(700); // Mô phỏng độ trễ
            return _rules;
        }

        public async Task<FirewallRule> GetRuleByIdAsync(string id)
        {
            _logger.LogInformation($"Getting firewall rule with ID {id}");
            await Task.Delay(300);
            return _rules.FirstOrDefault(r => r.Id == id) ?? new FirewallRule { Id = id, Action = "not found" };
        }

        public async Task<bool> EnableRuleAsync(string id)
        {
            _logger.LogInformation($"Enabling firewall rule {id}");
            await Task.Delay(800);
            var rule = _rules.FirstOrDefault(r => r.Id == id);
            if (rule != null)
            {
                rule.Disabled = false;
                return true;
            }
            return false;
        }

        public async Task<bool> DisableRuleAsync(string id)
        {
            _logger.LogInformation($"Disabling firewall rule {id}");
            await Task.Delay(800);
            var rule = _rules.FirstOrDefault(r => r.Id == id);
            if (rule != null)
            {
                rule.Disabled = true;
                return true;
            }
            return false;
        }

        public async Task<bool> MoveRuleUpAsync(string id)
        {
            _logger.LogInformation($"Moving firewall rule {id} up");
            await Task.Delay(500);
            
            var index = _rules.FindIndex(r => r.Id == id);
            if (index > 0)
            {
                var rule = _rules[index];
                _rules.RemoveAt(index);
                _rules.Insert(index - 1, rule);
                return true;
            }
            return false;
        }

        public async Task<bool> MoveRuleDownAsync(string id)
        {
            _logger.LogInformation($"Moving firewall rule {id} down");
            await Task.Delay(500);
            
            var index = _rules.FindIndex(r => r.Id == id);
            if (index >= 0 && index < _rules.Count - 1)
            {
                var rule = _rules[index];
                _rules.RemoveAt(index);
                _rules.Insert(index + 1, rule);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteRuleAsync(string id)
        {
            _logger.LogInformation($"Deleting firewall rule {id}");
            await Task.Delay(800);
            var rule = _rules.FirstOrDefault(r => r.Id == id);
            if (rule != null)
            {
                _rules.Remove(rule);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateRuleAsync(FirewallRule rule)
        {
            _logger.LogInformation($"Creating new firewall rule: {rule.Action} {rule.Protocol}");
            await Task.Delay(1000);
            
            // Assign a new ID
            var maxId = _rules.Max(r => int.Parse(r.Id));
            rule.Id = (maxId + 1).ToString();
            _rules.Add(rule);
            
            return true;
        }

        public async Task<bool> UpdateRuleAsync(FirewallRule rule)
        {
            _logger.LogInformation($"Updating firewall rule {rule.Id}");
            await Task.Delay(800);
            
            var existingRule = _rules.FirstOrDefault(r => r.Id == rule.Id);
            if (existingRule != null)
            {
                _rules.Remove(existingRule);
                _rules.Add(rule);
                return true;
            }
            return false;
        }
    }
}
