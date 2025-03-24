namespace mikk_mmc_web.Models.Shared
{
    /// <summary>
    /// Defines the connection status for a router device
    /// </summary>
    public enum ConnectionStatus
    {
        /// <summary>
        /// The device is disconnected
        /// </summary>
        Disconnected,
        
        /// <summary>
        /// The device is connecting
        /// </summary>
        Connecting,
        
        /// <summary>
        /// The device is connected
        /// </summary>
        Connected,
        
        /// <summary>
        /// The device is disconnecting
        /// </summary>
        Disconnecting,
        
        /// <summary>
        /// The connection to the device failed
        /// </summary>
        Failed
    }
}
