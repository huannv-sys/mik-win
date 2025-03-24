using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MikroTikMonitor.Models;

namespace MikroTikMonitor.Services
{
    /// <summary>
    /// Interface for the router API service
    /// </summary>
    public interface IRouterApiService
    {
        /// <summary>
        /// Connects to the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> ConnectAsync(RouterDevice device);
        
        /// <summary>
        /// Disconnects from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> DisconnectAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the system information from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<RouterDevice> GetSystemInfoAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the system resources from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<SystemResources> GetSystemResourcesAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the network interfaces from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<List<NetworkInterface>> GetNetworkInterfacesAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the interface statistics from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<List<NetworkInterface>> GetInterfaceStatisticsAsync(RouterDevice device);
        
        /// <summary>
        /// Enables a network interface
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="interfaceId">The interface ID</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> EnableNetworkInterfaceAsync(RouterDevice device, string interfaceId);
        
        /// <summary>
        /// Disables a network interface
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="interfaceId">The interface ID</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> DisableNetworkInterfaceAsync(RouterDevice device, string interfaceId);
        
        /// <summary>
        /// Gets the log entries from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<List<LogEntry>> GetLogEntriesAsync(RouterDevice device);
        
        /// <summary>
        /// Clears the log entries from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> ClearLogEntriesAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the firewall rules from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<List<FirewallRule>> GetFirewallRulesAsync(RouterDevice device);
        
        /// <summary>
        /// Adds a firewall rule to the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="rule">The firewall rule</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> AddFirewallRuleAsync(RouterDevice device, FirewallRule rule);
        
        /// <summary>
        /// Updates a firewall rule on the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="rule">The firewall rule</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> UpdateFirewallRuleAsync(RouterDevice device, FirewallRule rule);
        
        /// <summary>
        /// Removes a firewall rule from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="ruleId">The rule ID</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> RemoveFirewallRuleAsync(RouterDevice device, string ruleId);
        
        /// <summary>
        /// Backs up the router configuration
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="filename">The backup filename</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> BackupAsync(RouterDevice device, string filename);
        
        /// <summary>
        /// Restores the router configuration
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="filename">The backup filename</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> RestoreAsync(RouterDevice device, string filename);
        
        /// <summary>
        /// Checks for firmware updates
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> CheckForUpdatesAsync(RouterDevice device);
        
        /// <summary>
        /// Installs firmware updates
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> InstallUpdatesAsync(RouterDevice device);
        
        /// <summary>
        /// Executes a command on the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="command">The command to execute</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> ExecuteCommandAsync(RouterDevice device, string command);
    }
}