using System;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents the system resources of a router
    /// </summary>
    public class SystemResources : ModelBase
    {
        private string _boardName;
        private string _version;
        private string _firmwareType;
        private string _factoryFirmware;
        private string _currentFirmware;
        private string _upgradeAvailable;
        private string _architecture;
        private string _cpuCount;
        private string _cpuFrequency;
        private string _cpuLoad;
        private double _cpuUsage;
        private string _freeMemory;
        private string _totalMemory;
        private double _memoryUsage;
        private string _freeHdd;
        private string _totalHdd;
        private double _hddUsage;
        private string _architectureName;
        private string _boardName2;
        private string _platform;
        private string _badBlocks;
        private string _writesSectSinceReboot;
        private string _writeSectTotal;
        private TimeSpan _uptime;
        private string _buildTime;
        private string _factoryFirmware2;
        private string _currentFirmware2;
        private string _firmwareType2;
        private string _temperature;
        private string _voltage;
        private string _current;
        private string _power;

        /// <summary>
        /// Gets or sets the board name
        /// </summary>
        public string BoardName
        {
            get => _boardName;
            set => SetProperty(ref _boardName, value);
        }

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        public string Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }

        /// <summary>
        /// Gets or sets the firmware type
        /// </summary>
        public string FirmwareType
        {
            get => _firmwareType;
            set => SetProperty(ref _firmwareType, value);
        }

        /// <summary>
        /// Gets or sets the factory firmware
        /// </summary>
        public string FactoryFirmware
        {
            get => _factoryFirmware;
            set => SetProperty(ref _factoryFirmware, value);
        }

        /// <summary>
        /// Gets or sets the current firmware
        /// </summary>
        public string CurrentFirmware
        {
            get => _currentFirmware;
            set => SetProperty(ref _currentFirmware, value);
        }

        /// <summary>
        /// Gets or sets whether an upgrade is available
        /// </summary>
        public string UpgradeAvailable
        {
            get => _upgradeAvailable;
            set => SetProperty(ref _upgradeAvailable, value);
        }

        /// <summary>
        /// Gets or sets the architecture
        /// </summary>
        public string Architecture
        {
            get => _architecture;
            set => SetProperty(ref _architecture, value);
        }

        /// <summary>
        /// Gets or sets the CPU count
        /// </summary>
        public string CpuCount
        {
            get => _cpuCount;
            set => SetProperty(ref _cpuCount, value);
        }

        /// <summary>
        /// Gets or sets the CPU frequency
        /// </summary>
        public string CpuFrequency
        {
            get => _cpuFrequency;
            set => SetProperty(ref _cpuFrequency, value);
        }

        /// <summary>
        /// Gets or sets the CPU load
        /// </summary>
        public string CpuLoad
        {
            get => _cpuLoad;
            set => SetProperty(ref _cpuLoad, value);
        }

        /// <summary>
        /// Gets or sets the CPU usage
        /// </summary>
        public double CpuUsage
        {
            get => _cpuUsage;
            set => SetProperty(ref _cpuUsage, value);
        }

        /// <summary>
        /// Gets or sets the free memory
        /// </summary>
        public string FreeMemory
        {
            get => _freeMemory;
            set => SetProperty(ref _freeMemory, value);
        }

        /// <summary>
        /// Gets or sets the total memory
        /// </summary>
        public string TotalMemory
        {
            get => _totalMemory;
            set => SetProperty(ref _totalMemory, value);
        }

        /// <summary>
        /// Gets or sets the memory usage
        /// </summary>
        public double MemoryUsage
        {
            get => _memoryUsage;
            set => SetProperty(ref _memoryUsage, value);
        }

        /// <summary>
        /// Gets or sets the free HDD space
        /// </summary>
        public string FreeHdd
        {
            get => _freeHdd;
            set => SetProperty(ref _freeHdd, value);
        }

        /// <summary>
        /// Gets or sets the total HDD space
        /// </summary>
        public string TotalHdd
        {
            get => _totalHdd;
            set => SetProperty(ref _totalHdd, value);
        }

        /// <summary>
        /// Gets or sets the HDD usage
        /// </summary>
        public double HddUsage
        {
            get => _hddUsage;
            set => SetProperty(ref _hddUsage, value);
        }

        /// <summary>
        /// Gets or sets the architecture name
        /// </summary>
        public string ArchitectureName
        {
            get => _architectureName;
            set => SetProperty(ref _architectureName, value);
        }

        /// <summary>
        /// Gets or sets the secondary board name
        /// </summary>
        public string BoardName2
        {
            get => _boardName2;
            set => SetProperty(ref _boardName2, value);
        }

        /// <summary>
        /// Gets or sets the platform
        /// </summary>
        public string Platform
        {
            get => _platform;
            set => SetProperty(ref _platform, value);
        }

        /// <summary>
        /// Gets or sets the bad blocks
        /// </summary>
        public string BadBlocks
        {
            get => _badBlocks;
            set => SetProperty(ref _badBlocks, value);
        }

        /// <summary>
        /// Gets or sets the writes sectors since reboot
        /// </summary>
        public string WritesSectSinceReboot
        {
            get => _writesSectSinceReboot;
            set => SetProperty(ref _writesSectSinceReboot, value);
        }

        /// <summary>
        /// Gets or sets the total write sectors
        /// </summary>
        public string WriteSectTotal
        {
            get => _writeSectTotal;
            set => SetProperty(ref _writeSectTotal, value);
        }

        /// <summary>
        /// Gets or sets the uptime
        /// </summary>
        public TimeSpan Uptime
        {
            get => _uptime;
            set => SetProperty(ref _uptime, value);
        }

        /// <summary>
        /// Gets the formatted uptime
        /// </summary>
        public string FormattedUptime => FormatTimeSpan(Uptime);

        /// <summary>
        /// Gets or sets the build time
        /// </summary>
        public string BuildTime
        {
            get => _buildTime;
            set => SetProperty(ref _buildTime, value);
        }

        /// <summary>
        /// Gets or sets the secondary factory firmware
        /// </summary>
        public string FactoryFirmware2
        {
            get => _factoryFirmware2;
            set => SetProperty(ref _factoryFirmware2, value);
        }

        /// <summary>
        /// Gets or sets the secondary current firmware
        /// </summary>
        public string CurrentFirmware2
        {
            get => _currentFirmware2;
            set => SetProperty(ref _currentFirmware2, value);
        }

        /// <summary>
        /// Gets or sets the secondary firmware type
        /// </summary>
        public string FirmwareType2
        {
            get => _firmwareType2;
            set => SetProperty(ref _firmwareType2, value);
        }

        /// <summary>
        /// Gets or sets the temperature
        /// </summary>
        public string Temperature
        {
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }

        /// <summary>
        /// Gets or sets the voltage
        /// </summary>
        public string Voltage
        {
            get => _voltage;
            set => SetProperty(ref _voltage, value);
        }

        /// <summary>
        /// Gets or sets the current
        /// </summary>
        public string Current
        {
            get => _current;
            set => SetProperty(ref _current, value);
        }

        /// <summary>
        /// Gets or sets the power
        /// </summary>
        public string Power
        {
            get => _power;
            set => SetProperty(ref _power, value);
        }

        /// <summary>
        /// Initializes a new instance of the SystemResources class
        /// </summary>
        public SystemResources()
        {
            Uptime = TimeSpan.Zero;
        }

        /// <summary>
        /// Formats a TimeSpan into a readable string
        /// </summary>
        /// <param name="timeSpan">The TimeSpan to format</param>
        /// <returns>A formatted string</returns>
        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            if (timeSpan.TotalDays >= 1)
            {
                return $"{(int)timeSpan.TotalDays}d {timeSpan.Hours}h {timeSpan.Minutes}m {timeSpan.Seconds}s";
            }
            
            if (timeSpan.TotalHours >= 1)
            {
                return $"{(int)timeSpan.TotalHours}h {timeSpan.Minutes}m {timeSpan.Seconds}s";
            }
            
            if (timeSpan.TotalMinutes >= 1)
            {
                return $"{(int)timeSpan.TotalMinutes}m {timeSpan.Seconds}s";
            }
            
            return $"{timeSpan.Seconds}s";
        }
    }
}