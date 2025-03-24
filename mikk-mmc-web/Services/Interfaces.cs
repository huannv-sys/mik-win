using mikk_mmc_web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mikk_mmc_web.Services
{
    public interface IRouterService
    {
        bool IsConnected { get; }
        Task<bool> ConnectAsync(ConnectionSettings settings);
        Task<bool> DisconnectAsync();
        Task<RouterInfo> GetRouterInfoAsync();
        Task<SystemResources> GetSystemResourcesAsync();
    }

    public interface IInterfaceService
    {
        Task<IEnumerable<NetworkInterface>> GetInterfacesAsync();
        Task<NetworkInterface> GetInterfaceByNameAsync(string name);
        Task<InterfaceTraffic> GetInterfaceTrafficAsync(string name);
    }

    public interface IFirewallService
    {
        Task<IEnumerable<FirewallRule>> GetFirewallRulesAsync();
        Task<FirewallRule> GetFirewallRuleByIdAsync(string id);
    }

    public interface IDhcpService
    {
        Task<IEnumerable<DhcpLease>> GetDhcpLeasesAsync();
        Task<DhcpLease> GetDhcpLeaseByMacAsync(string macAddress);
    }

    public interface ILogService
    {
        Task<IEnumerable<LogEntry>> GetLogsAsync(int limit = 100);
        Task<LogEntry> GetLogByIdAsync(string id);
    }
}
