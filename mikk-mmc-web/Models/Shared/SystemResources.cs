using System;

namespace mikk_mmc_web.Models.Shared
{
    /// <summary>
    /// Represents system resources of a router device
    /// </summary>
    public class SystemResources : ModelBase
    {
        private double _cpuUsage;
        private double _memoryUsage;
        private double _diskUsage;
        private double _temperature;
        private double _uptime;
        private int _activeSessions;
        private string _version;
        private DateTime _lastUpdated;

        /// <summary>
        /// Gets or sets the CPU usage percentage
        /// </summary>
        public double CpuUsage
        {
            get => _cpuUsage;
            set => SetProperty(ref _cpuUsage, value);
        }

        /// <summary>
        /// Gets or sets the memory usage percentage
        /// </summary>
        public double MemoryUsage
        {
            get => _memoryUsage;
            set => SetProperty(ref _memoryUsage, value);
        }

        /// <summary>
        /// Gets or sets the disk usage percentage
        /// </summary>
        public double DiskUsage
        {
            get => _diskUsage;
            set => SetProperty(ref _diskUsage, value);
        }

        /// <summary>
        /// Gets or sets the temperature in Celsius
        /// </summary>
        public double Temperature
        {
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }

        /// <summary>
        /// Gets or sets the uptime in seconds
        /// </summary>
        public double Uptime
        {
            get => _uptime;
            set => SetProperty(ref _uptime, value);
        }

        /// <summary>
        /// Gets or sets the number of active sessions
        /// </summary>
        public int ActiveSessions
        {
            get => _activeSessions;
            set => SetProperty(ref _activeSessions, value);
        }

        /// <summary>
        /// Gets or sets the version of the system
        /// </summary>
        public string Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }

        /// <summary>
        /// Gets or sets the last updated time
        /// </summary>
        public DateTime LastUpdated
        {
            get => _lastUpdated;
            set => SetProperty(ref _lastUpdated, value);
        }
    }
}
