using System;

namespace mikk_mmc_web.Models.Shared
{
    /// <summary>
    /// Extended version of SystemResources that includes additional formatting methods
    /// </summary>
    public class SystemResourcesExtended : SystemResources
    {
        private double _memoryTotal;
        private double _memoryUsed;
        private double _hddTotal;
        private double _hddUsed;

        /// <summary>
        /// Gets or sets the total memory in bytes
        /// </summary>
        public double MemoryTotal
        {
            get => _memoryTotal;
            set => SetProperty(ref _memoryTotal, value);
        }

        /// <summary>
        /// Gets or sets the used memory in bytes
        /// </summary>
        public double MemoryUsed
        {
            get => _memoryUsed;
            set => SetProperty(ref _memoryUsed, value);
        }

        /// <summary>
        /// Gets or sets the total disk space in bytes
        /// </summary>
        public double HddTotal
        {
            get => _hddTotal;
            set => SetProperty(ref _hddTotal, value);
        }

        /// <summary>
        /// Gets or sets the used disk space in bytes
        /// </summary>
        public double HddUsed
        {
            get => _hddUsed;
            set => SetProperty(ref _hddUsed, value);
        }

        /// <summary>
        /// Gets the memory usage percentage
        /// </summary>
        public double MemoryPercentage => MemoryTotal > 0 ? (MemoryUsed / MemoryTotal) * 100 : 0;

        /// <summary>
        /// Gets the disk usage percentage
        /// </summary>
        public double HddPercentage => HddTotal > 0 ? (HddUsed / HddTotal) * 100 : 0;

        /// <summary>
        /// Gets the formatted used memory
        /// </summary>
        public string MemoryFormattedUsed => FormatBytes(MemoryUsed);

        /// <summary>
        /// Gets the formatted total memory
        /// </summary>
        public string MemoryFormattedTotal => FormatBytes(MemoryTotal);

        /// <summary>
        /// Gets the formatted used disk space
        /// </summary>
        public string HddFormattedUsed => FormatBytes(HddUsed);

        /// <summary>
        /// Gets the formatted total disk space
        /// </summary>
        public string HddFormattedTotal => FormatBytes(HddTotal);

        /// <summary>
        /// Formats bytes to a human-readable string
        /// </summary>
        /// <param name="bytes">The number of bytes to format</param>
        /// <returns>A formatted string</returns>
        private string FormatBytes(double bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (bytes >= 1024 && order < sizes.Length - 1)
            {
                order++;
                bytes = bytes / 1024;
            }
            return $"{bytes:0.##} {sizes[order]}";
        }
    }
}
