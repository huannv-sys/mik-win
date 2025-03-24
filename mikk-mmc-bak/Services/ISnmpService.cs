using System.Collections.Generic;
using System.Threading.Tasks;
using MikroTikMonitor.Models;

namespace MikroTikMonitor.Services
{
    /// <summary>
    /// Interface for the SNMP service
    /// </summary>
    public interface ISnmpService
    {
        /// <summary>
        /// Tests the SNMP connection to the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<bool> TestConnectionAsync(RouterDevice device);
        
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
        /// Gets the CPU usage from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<double> GetCpuUsageAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the memory usage from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<double> GetMemoryUsageAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the disk usage from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<double> GetDiskUsageAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the uptime from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> GetUptimeAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the temperature from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<double> GetTemperatureAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the voltage from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<double> GetVoltageAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the current from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<double> GetCurrentAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the power from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<double> GetPowerAsync(RouterDevice device);
        
        /// <summary>
        /// Gets the SNMP table from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="oid">The OID</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Dictionary<string, string>> GetSnmpTableAsync(RouterDevice device, string oid);
        
        /// <summary>
        /// Gets the SNMP value from the router
        /// </summary>
        /// <param name="device">The router device</param>
        /// <param name="oid">The OID</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> GetSnmpValueAsync(RouterDevice device, string oid);
    }
}