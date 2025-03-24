using System;

namespace mikk_mmc_web.Models.Shared
{
    /// <summary>
    /// Represents a network interface on a router device
    /// </summary>
    public class NetworkInterface : ModelBase
    {
        private string _id;
        private string _name;
        private string _type;
        private string _macAddress;
        private string _ipAddress;
        private string _netmask;
        private string _gateway;
        private bool _isUp;
        private bool _isRunning;
        private bool _isDynamic;
        private long _rxBytes;
        private long _txBytes;
        private long _rxPackets;
        private long _txPackets;
        private long _rxDrops;
        private long _txDrops;
        private long _rxErrors;
        private long _txErrors;
        private DateTime _lastUpdated;
        private string _comment;
        private bool _isWireless;
        private string _ssid;
        private string _frequency;
        private int _channel;
        private string _signalStrength;
        private int _clients;
        private string _parentInterface;

        /// <summary>
        /// Gets or sets the identifier of the interface
        /// </summary>
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Gets or sets the name of the interface
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Gets or sets the type of the interface
        /// </summary>
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        /// <summary>
        /// Gets or sets the MAC address of the interface
        /// </summary>
        public string MacAddress
        {
            get => _macAddress;
            set => SetProperty(ref _macAddress, value);
        }

        /// <summary>
        /// Gets or sets the IP address of the interface
        /// </summary>
        public string IpAddress
        {
            get => _ipAddress;
            set => SetProperty(ref _ipAddress, value);
        }

        /// <summary>
        /// Gets or sets the netmask of the interface
        /// </summary>
        public string Netmask
        {
            get => _netmask;
            set => SetProperty(ref _netmask, value);
        }

        /// <summary>
        /// Gets or sets the gateway of the interface
        /// </summary>
        public string Gateway
        {
            get => _gateway;
            set => SetProperty(ref _gateway, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is up
        /// </summary>
        public bool IsUp
        {
            get => _isUp;
            set => SetProperty(ref _isUp, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is running
        /// </summary>
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        /// <summary>
        /// Gets or sets whether the interface has a dynamic IP
        /// </summary>
        public bool IsDynamic
        {
            get => _isDynamic;
            set => SetProperty(ref _isDynamic, value);
        }

        /// <summary>
        /// Gets or sets the number of received bytes
        /// </summary>
        public long RxBytes
        {
            get => _rxBytes;
            set => SetProperty(ref _rxBytes, value);
        }

        /// <summary>
        /// Gets or sets the number of transmitted bytes
        /// </summary>
        public long TxBytes
        {
            get => _txBytes;
            set => SetProperty(ref _txBytes, value);
        }

        /// <summary>
        /// Gets or sets the number of received packets
        /// </summary>
        public long RxPackets
        {
            get => _rxPackets;
            set => SetProperty(ref _rxPackets, value);
        }

        /// <summary>
        /// Gets or sets the number of transmitted packets
        /// </summary>
        public long TxPackets
        {
            get => _txPackets;
            set => SetProperty(ref _txPackets, value);
        }

        /// <summary>
        /// Gets or sets the number of received drops
        /// </summary>
        public long RxDrops
        {
            get => _rxDrops;
            set => SetProperty(ref _rxDrops, value);
        }

        /// <summary>
        /// Gets or sets the number of transmitted drops
        /// </summary>
        public long TxDrops
        {
            get => _txDrops;
            set => SetProperty(ref _txDrops, value);
        }

        /// <summary>
        /// Gets or sets the number of received errors
        /// </summary>
        public long RxErrors
        {
            get => _rxErrors;
            set => SetProperty(ref _rxErrors, value);
        }

        /// <summary>
        /// Gets or sets the number of transmitted errors
        /// </summary>
        public long TxErrors
        {
            get => _txErrors;
            set => SetProperty(ref _txErrors, value);
        }

        /// <summary>
        /// Gets or sets the last time the interface was updated
        /// </summary>
        public DateTime LastUpdated
        {
            get => _lastUpdated;
            set => SetProperty(ref _lastUpdated, value);
        }

        /// <summary>
        /// Gets or sets the comment for the interface
        /// </summary>
        public string Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is wireless
        /// </summary>
        public bool IsWireless
        {
            get => _isWireless;
            set => SetProperty(ref _isWireless, value);
        }

        /// <summary>
        /// Gets or sets the SSID of the wireless interface
        /// </summary>
        public string Ssid
        {
            get => _ssid;
            set => SetProperty(ref _ssid, value);
        }

        /// <summary>
        /// Gets or sets the frequency of the wireless interface
        /// </summary>
        public string Frequency
        {
            get => _frequency;
            set => SetProperty(ref _frequency, value);
        }

        /// <summary>
        /// Gets or sets the channel of the wireless interface
        /// </summary>
        public int Channel
        {
            get => _channel;
            set => SetProperty(ref _channel, value);
        }

        /// <summary>
        /// Gets or sets the signal strength of the wireless interface
        /// </summary>
        public string SignalStrength
        {
            get => _signalStrength;
            set => SetProperty(ref _signalStrength, value);
        }

        /// <summary>
        /// Gets or sets the number of clients connected to the wireless interface
        /// </summary>
        public int Clients
        {
            get => _clients;
            set => SetProperty(ref _clients, value);
        }

        /// <summary>
        /// Gets or sets the parent interface
        /// </summary>
        public string ParentInterface
        {
            get => _parentInterface;
            set => SetProperty(ref _parentInterface, value);
        }
    }
}
