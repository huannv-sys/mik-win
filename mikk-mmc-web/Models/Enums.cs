namespace mikk_mmc_web.Models
{
    /// <summary>
    /// Represents the status of a device
    /// </summary>
    public enum DeviceStatus
    {
        /// <summary>
        /// The device is unknown
        /// </summary>
        Unknown = 0,
        
        /// <summary>
        /// The device is offline
        /// </summary>
        Offline = 1,
        
        /// <summary>
        /// The device is online
        /// </summary>
        Online = 2,
        
        /// <summary>
        /// The device is in warning state
        /// </summary>
        Warning = 3,
        
        /// <summary>
        /// The device is in error state
        /// </summary>
        Error = 4
    }
    
    /// <summary>
    /// Represents the severity of a log entry
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// Debug log entry
        /// </summary>
        Debug = 0,
        
        /// <summary>
        /// Information log entry
        /// </summary>
        Info = 1,
        
        /// <summary>
        /// Warning log entry
        /// </summary>
        Warning = 2,
        
        /// <summary>
        /// Error log entry
        /// </summary>
        Error = 3,
        
        /// <summary>
        /// Critical log entry
        /// </summary>
        Critical = 4
    }
    
    /// <summary>
    /// Represents the connection status of a router device
    /// </summary>
    public enum ConnectionStatus
    {
        /// <summary>
        /// The device is disconnected
        /// </summary>
        Disconnected = 0,
        
        /// <summary>
        /// The device is connecting
        /// </summary>
        Connecting = 1,
        
        /// <summary>
        /// The device is connected
        /// </summary>
        Connected = 2,
        
        /// <summary>
        /// The connection failed
        /// </summary>
        Failed = 3
    }
}
