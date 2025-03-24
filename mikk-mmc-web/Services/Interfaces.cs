using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mikk_mmc_web.Models;

namespace mikk_mmc_web.Services
{
    // Interface cho dịch vụ Router
    public interface IRouterService
    {
        Task<RouterInfo> GetRouterInfoAsync();
        Task<SystemResources> GetSystemResourcesAsync();
        Task<bool> ConnectAsync(ConnectionSettings settings);
        Task<bool> DisconnectAsync();
        Task<bool> RebootRouterAsync();
        Task<bool> BackupConfigurationAsync(string filename);
        Task<bool> RestoreConfigurationAsync(string filename);
        bool IsConnected { get; }
        ConnectionSettings CurrentSettings { get; }
    }

    // Interface cho dịch vụ giao diện mạng
    public interface IInterfaceService
    {
        Task<List<NetworkInterface>> GetAllInterfacesAsync();
        Task<NetworkInterface> GetInterfaceByNameAsync(string name);
        Task<bool> EnableInterfaceAsync(string name);
        Task<bool> DisableInterfaceAsync(string name);
        Task<List<TrafficData>> GetTrafficHistoryAsync(string interfaceName, DateTime startTime, DateTime endTime);
        Task<bool> ResetInterfaceCountersAsync(string name);
    }

    // Interface cho dịch vụ tường lửa
    public interface IFirewallService
    {
        Task<List<FirewallRule>> GetAllRulesAsync();
        Task<FirewallRule> GetRuleByIdAsync(string id);
        Task<bool> EnableRuleAsync(string id);
        Task<bool> DisableRuleAsync(string id);
        Task<bool> MoveRuleUpAsync(string id);
        Task<bool> MoveRuleDownAsync(string id);
        Task<bool> DeleteRuleAsync(string id);
        Task<bool> CreateRuleAsync(FirewallRule rule);
        Task<bool> UpdateRuleAsync(FirewallRule rule);
    }

    // Interface cho dịch vụ DHCP
    public interface IDhcpService
    {
        Task<List<DhcpLease>> GetAllLeasesAsync();
        Task<DhcpLease> GetLeaseByIdAsync(string id);
        Task<bool> MakeStaticAsync(string id);
        Task<bool> DeleteLeaseAsync(string id);
        Task<bool> CreateLeaseAsync(DhcpLease lease);
        Task<bool> UpdateLeaseAsync(DhcpLease lease);
        Task<bool> BlockClientAsync(string macAddress);
        Task<bool> UnblockClientAsync(string macAddress);
    }

    // Interface cho dịch vụ nhật ký (log)
    public interface ILogService
    {
        Task<List<LogEntry>> GetAllLogsAsync(int maxEntries = 100);
        Task<List<LogEntry>> GetLogsByTopicAsync(string topic, int maxEntries = 100);
        Task<List<LogEntry>> GetLogsByLevelAsync(string level, int maxEntries = 100);
        Task<List<LogEntry>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate, int maxEntries = 100);
        Task<bool> ClearLogsAsync();
        Task<bool> ExportLogsAsync(string filename);
    }
}
