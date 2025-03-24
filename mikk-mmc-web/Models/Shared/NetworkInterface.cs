using System;
using System.Collections.Generic;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents a network interface
    /// </summary>
    public class NetworkInterface : ModelBase
    {
        private string _id;
        private string _name;
        private string _type;
        private string _macAddress;
        private bool _enabled;
        private string _description;
        private string _comment;
        private string _status = "Unknown";
        private bool _running;
        private bool _connected;
        private bool _slave;
        private bool _l2mtu;
        private long _rxBytes;
        private long _txBytes;
        private long _rxPackets;
        private long _txPackets;
        private long _rxDrops;
        private long _txDrops;
        private long _rxErrors;
        private long _txErrors;
        private string _actualMtu;
        private string _linkDowns;
        private bool _testing;
        private string _registerMacAddress;
        private string _interfaceIndex;
        private double _rxBitRate;
        private double _txBitRate;
        private double _rxPacketRate;
        private double _txPacketRate;
        private long _lastRxBytes;
        private long _lastTxBytes;
        private long _lastRxPackets;
        private long _lastTxPackets;
        private DateTime _lastUpdate;
        private string _ipAddress;
        private string _ipNetmask;
        private string _ipNetwork;
        private string _ipGateway;
        private string _dns;
        private string _dhcpClient;
        private string _ipv6Address;
        private string _ipv6Gateway;
        private string _ipv6Dns;
        private string _ipv6Dhcp;
        private bool _useDefaultRoute;
        private string _defaultRouteDistance;
        private string _mtu;
        private string _interfaceId;
        private string _wds;
        private string _mastersInterface;
        private string _ssid;
        private string _radioName;
        private string _band;
        private string _frequency;
        private string _noisef;
        private string _noise;
        private string _signalf;
        private string _signal;
        private string _txPower;
        private string _channel;
        private string _scanList;
        private string _wirelessProtocol;
        private string _routerId;
        private string _mode;
        private string _encryptionKey;
        private string _authentication;
        private string _encryption;
        private string _defaultAuthentication;
        private string _defaultEncryption;
        private string _interfaceType;
        private string _networkType;
        private bool _useL2Mtu;
        private string _arp;
        private string _arpTimeout;
        private string _clientName;
        private string _clientMacAddress;
        private string _clientIpAddress;
        private string _queueType;
        private string _parentQueue;
        private string _priority;
        private string _bursLimit;
        private string _burstThreshold;
        private string _burstTime;
        private string _maxLimit;
        private string _limitAt;
        private string _disabled;
        private string _dynamicSort;
        private bool _isWireless;
        private bool _isVlan;
        private bool _isBridge;
        private int _vlanId;
        private string _bridgedTo;
        private string _lastLinkDownTime;
        private string _lastLinkUpTime;
        private bool _defaultGateway;
        private string _connectedClients;
        private string _activeConnections;
        private string _rxRate;
        private string _txRate;
        private string _rxLimit;
        private string _txLimit;
        private string _rxFcs;
        private string _txFcs;
        private string _rxKbytes;
        private string _txKbytes;
        private string _rxMbytes;
        private string _txMbytes;
        private string _clientCount;
        private string _packetCount;
        private string _packetLoss;
        private string _pingTime;
        private string _jitter;
        private string _throughput;
        private string _rxMaxRate;
        private string _txMaxRate;
        private string _rxAvgRate;
        private string _txAvgRate;
        private string _rxMinRate;
        private string _txMinRate;
        private string _maxQueueLength;
        private string _avgQueueLength;
        private string _currentQueueLength;
        private List<NetworkInterface> _bridgedInterfaces = new List<NetworkInterface>();
        private string _vrrpGroup;
        private string _vrrpPriority;
        private string _vrrpInterval;
        private string _vrrpAuthentication;
        private string _vrrpPassword;
        private bool _isVrrpMaster;
        private string _tags;
        private string _boardName;
        private string _pciId;
        private string _driver;
        private string _firmwareRevision;
        private string _firmwareDate;
        private bool _hasFirmwareUpgrade;
        private string _firmwareUpgradeVersion;
        private string _firmwareUpgradeUrl;
        private DateTime _lastSeenTime;
        private bool _monitored = true;
        private string _graphColor = "#1E88E5";
        private string _parentInterfaceId;
        private string _deviceId;
        private bool _backup;
        private List<string> _ipAddresses = new List<string>();
        private List<string> _ipv6Addresses = new List<string>();
        private string _speedDuplex;
        private string _autoNegotiation;
        private string _actualSpeedDuplex;
        private string _sfpType;
        private string _sfpSerialNumber;
        private string _sfpVendor;
        private string _sfpModel;
        private string _sfpTemperature;
        private string _sfpVoltage;
        private string _sfpTxPower;
        private string _sfpRxPower;

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        /// <summary>
        /// Gets or sets the MAC address
        /// </summary>
        public string MacAddress
        {
            get => _macAddress;
            set => SetProperty(ref _macAddress, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is enabled
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        /// <summary>
        /// Gets or sets the comment
        /// </summary>
        public string Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is running
        /// </summary>
        public bool Running
        {
            get => _running;
            set => SetProperty(ref _running, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is connected
        /// </summary>
        public bool Connected
        {
            get => _connected;
            set => SetProperty(ref _connected, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is a slave
        /// </summary>
        public bool Slave
        {
            get => _slave;
            set => SetProperty(ref _slave, value);
        }

        /// <summary>
        /// Gets or sets the L2MTU
        /// </summary>
        public bool L2mtu
        {
            get => _l2mtu;
            set => SetProperty(ref _l2mtu, value);
        }

        /// <summary>
        /// Gets or sets the received bytes
        /// </summary>
        public long RxBytes
        {
            get => _rxBytes;
            set => SetProperty(ref _rxBytes, value);
        }

        /// <summary>
        /// Gets or sets the transmitted bytes
        /// </summary>
        public long TxBytes
        {
            get => _txBytes;
            set => SetProperty(ref _txBytes, value);
        }

        /// <summary>
        /// Gets or sets the received packets
        /// </summary>
        public long RxPackets
        {
            get => _rxPackets;
            set => SetProperty(ref _rxPackets, value);
        }

        /// <summary>
        /// Gets or sets the transmitted packets
        /// </summary>
        public long TxPackets
        {
            get => _txPackets;
            set => SetProperty(ref _txPackets, value);
        }

        /// <summary>
        /// Gets or sets the received drops
        /// </summary>
        public long RxDrops
        {
            get => _rxDrops;
            set => SetProperty(ref _rxDrops, value);
        }

        /// <summary>
        /// Gets or sets the transmitted drops
        /// </summary>
        public long TxDrops
        {
            get => _txDrops;
            set => SetProperty(ref _txDrops, value);
        }

        /// <summary>
        /// Gets or sets the received errors
        /// </summary>
        public long RxErrors
        {
            get => _rxErrors;
            set => SetProperty(ref _rxErrors, value);
        }

        /// <summary>
        /// Gets or sets the transmitted errors
        /// </summary>
        public long TxErrors
        {
            get => _txErrors;
            set => SetProperty(ref _txErrors, value);
        }

        /// <summary>
        /// Gets or sets the actual MTU
        /// </summary>
        public string ActualMtu
        {
            get => _actualMtu;
            set => SetProperty(ref _actualMtu, value);
        }

        /// <summary>
        /// Gets or sets the link downs
        /// </summary>
        public string LinkDowns
        {
            get => _linkDowns;
            set => SetProperty(ref _linkDowns, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is testing
        /// </summary>
        public bool Testing
        {
            get => _testing;
            set => SetProperty(ref _testing, value);
        }

        /// <summary>
        /// Gets or sets the register MAC address
        /// </summary>
        public string RegisterMacAddress
        {
            get => _registerMacAddress;
            set => SetProperty(ref _registerMacAddress, value);
        }

        /// <summary>
        /// Gets or sets the interface index
        /// </summary>
        public string InterfaceIndex
        {
            get => _interfaceIndex;
            set => SetProperty(ref _interfaceIndex, value);
        }

        /// <summary>
        /// Gets or sets the received bit rate
        /// </summary>
        public double RxBitRate
        {
            get => _rxBitRate;
            set => SetProperty(ref _rxBitRate, value);
        }

        /// <summary>
        /// Gets or sets the transmitted bit rate
        /// </summary>
        public double TxBitRate
        {
            get => _txBitRate;
            set => SetProperty(ref _txBitRate, value);
        }

        /// <summary>
        /// Gets or sets the received packet rate
        /// </summary>
        public double RxPacketRate
        {
            get => _rxPacketRate;
            set => SetProperty(ref _rxPacketRate, value);
        }

        /// <summary>
        /// Gets or sets the transmitted packet rate
        /// </summary>
        public double TxPacketRate
        {
            get => _txPacketRate;
            set => SetProperty(ref _txPacketRate, value);
        }

        /// <summary>
        /// Gets or sets the last received bytes
        /// </summary>
        public long LastRxBytes
        {
            get => _lastRxBytes;
            set => SetProperty(ref _lastRxBytes, value);
        }

        /// <summary>
        /// Gets or sets the last transmitted bytes
        /// </summary>
        public long LastTxBytes
        {
            get => _lastTxBytes;
            set => SetProperty(ref _lastTxBytes, value);
        }

        /// <summary>
        /// Gets or sets the last received packets
        /// </summary>
        public long LastRxPackets
        {
            get => _lastRxPackets;
            set => SetProperty(ref _lastRxPackets, value);
        }

        /// <summary>
        /// Gets or sets the last transmitted packets
        /// </summary>
        public long LastTxPackets
        {
            get => _lastTxPackets;
            set => SetProperty(ref _lastTxPackets, value);
        }

        /// <summary>
        /// Gets or sets the last update time
        /// </summary>
        public DateTime LastUpdate
        {
            get => _lastUpdate;
            set => SetProperty(ref _lastUpdate, value);
        }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        public string IpAddress
        {
            get => _ipAddress;
            set => SetProperty(ref _ipAddress, value);
        }

        /// <summary>
        /// Gets or sets the IP netmask
        /// </summary>
        public string IpNetmask
        {
            get => _ipNetmask;
            set => SetProperty(ref _ipNetmask, value);
        }

        /// <summary>
        /// Gets or sets the IP network
        /// </summary>
        public string IpNetwork
        {
            get => _ipNetwork;
            set => SetProperty(ref _ipNetwork, value);
        }

        /// <summary>
        /// Gets or sets the IP gateway
        /// </summary>
        public string IpGateway
        {
            get => _ipGateway;
            set => SetProperty(ref _ipGateway, value);
        }

        /// <summary>
        /// Gets or sets the DNS
        /// </summary>
        public string Dns
        {
            get => _dns;
            set => SetProperty(ref _dns, value);
        }

        /// <summary>
        /// Gets or sets the DHCP client
        /// </summary>
        public string DhcpClient
        {
            get => _dhcpClient;
            set => SetProperty(ref _dhcpClient, value);
        }

        /// <summary>
        /// Gets or sets the IPv6 address
        /// </summary>
        public string Ipv6Address
        {
            get => _ipv6Address;
            set => SetProperty(ref _ipv6Address, value);
        }

        /// <summary>
        /// Gets or sets the IPv6 gateway
        /// </summary>
        public string Ipv6Gateway
        {
            get => _ipv6Gateway;
            set => SetProperty(ref _ipv6Gateway, value);
        }

        /// <summary>
        /// Gets or sets the IPv6 DNS
        /// </summary>
        public string Ipv6Dns
        {
            get => _ipv6Dns;
            set => SetProperty(ref _ipv6Dns, value);
        }

        /// <summary>
        /// Gets or sets the IPv6 DHCP
        /// </summary>
        public string Ipv6Dhcp
        {
            get => _ipv6Dhcp;
            set => SetProperty(ref _ipv6Dhcp, value);
        }

        /// <summary>
        /// Gets or sets whether to use the default route
        /// </summary>
        public bool UseDefaultRoute
        {
            get => _useDefaultRoute;
            set => SetProperty(ref _useDefaultRoute, value);
        }

        /// <summary>
        /// Gets or sets the default route distance
        /// </summary>
        public string DefaultRouteDistance
        {
            get => _defaultRouteDistance;
            set => SetProperty(ref _defaultRouteDistance, value);
        }

        /// <summary>
        /// Gets or sets the MTU
        /// </summary>
        public string Mtu
        {
            get => _mtu;
            set => SetProperty(ref _mtu, value);
        }

        /// <summary>
        /// Gets or sets the interface ID
        /// </summary>
        public string InterfaceId
        {
            get => _interfaceId;
            set => SetProperty(ref _interfaceId, value);
        }

        /// <summary>
        /// Gets or sets the WDS
        /// </summary>
        public string Wds
        {
            get => _wds;
            set => SetProperty(ref _wds, value);
        }

        /// <summary>
        /// Gets or sets the masters interface
        /// </summary>
        public string MastersInterface
        {
            get => _mastersInterface;
            set => SetProperty(ref _mastersInterface, value);
        }

        /// <summary>
        /// Gets or sets the SSID
        /// </summary>
        public string Ssid
        {
            get => _ssid;
            set => SetProperty(ref _ssid, value);
        }

        /// <summary>
        /// Gets or sets the radio name
        /// </summary>
        public string RadioName
        {
            get => _radioName;
            set => SetProperty(ref _radioName, value);
        }

        /// <summary>
        /// Gets or sets the band
        /// </summary>
        public string Band
        {
            get => _band;
            set => SetProperty(ref _band, value);
        }

        /// <summary>
        /// Gets or sets the frequency
        /// </summary>
        public string Frequency
        {
            get => _frequency;
            set => SetProperty(ref _frequency, value);
        }

        /// <summary>
        /// Gets or sets the noise floor
        /// </summary>
        public string Noisef
        {
            get => _noisef;
            set => SetProperty(ref _noisef, value);
        }

        /// <summary>
        /// Gets or sets the noise
        /// </summary>
        public string Noise
        {
            get => _noise;
            set => SetProperty(ref _noise, value);
        }

        /// <summary>
        /// Gets or sets the signal floor
        /// </summary>
        public string Signalf
        {
            get => _signalf;
            set => SetProperty(ref _signalf, value);
        }

        /// <summary>
        /// Gets or sets the signal
        /// </summary>
        public string Signal
        {
            get => _signal;
            set => SetProperty(ref _signal, value);
        }

        /// <summary>
        /// Gets or sets the transmit power
        /// </summary>
        public string TxPower
        {
            get => _txPower;
            set => SetProperty(ref _txPower, value);
        }

        /// <summary>
        /// Gets or sets the channel
        /// </summary>
        public string Channel
        {
            get => _channel;
            set => SetProperty(ref _channel, value);
        }

        /// <summary>
        /// Gets or sets the scan list
        /// </summary>
        public string ScanList
        {
            get => _scanList;
            set => SetProperty(ref _scanList, value);
        }

        /// <summary>
        /// Gets or sets the wireless protocol
        /// </summary>
        public string WirelessProtocol
        {
            get => _wirelessProtocol;
            set => SetProperty(ref _wirelessProtocol, value);
        }

        /// <summary>
        /// Gets or sets the router ID
        /// </summary>
        public string RouterId
        {
            get => _routerId;
            set => SetProperty(ref _routerId, value);
        }

        /// <summary>
        /// Gets or sets the mode
        /// </summary>
        public string Mode
        {
            get => _mode;
            set => SetProperty(ref _mode, value);
        }

        /// <summary>
        /// Gets or sets the encryption key
        /// </summary>
        public string EncryptionKey
        {
            get => _encryptionKey;
            set => SetProperty(ref _encryptionKey, value);
        }

        /// <summary>
        /// Gets or sets the authentication
        /// </summary>
        public string Authentication
        {
            get => _authentication;
            set => SetProperty(ref _authentication, value);
        }

        /// <summary>
        /// Gets or sets the encryption
        /// </summary>
        public string Encryption
        {
            get => _encryption;
            set => SetProperty(ref _encryption, value);
        }

        /// <summary>
        /// Gets or sets the default authentication
        /// </summary>
        public string DefaultAuthentication
        {
            get => _defaultAuthentication;
            set => SetProperty(ref _defaultAuthentication, value);
        }

        /// <summary>
        /// Gets or sets the default encryption
        /// </summary>
        public string DefaultEncryption
        {
            get => _defaultEncryption;
            set => SetProperty(ref _defaultEncryption, value);
        }

        /// <summary>
        /// Gets or sets the interface type
        /// </summary>
        public string InterfaceType
        {
            get => _interfaceType;
            set => SetProperty(ref _interfaceType, value);
        }

        /// <summary>
        /// Gets or sets the network type
        /// </summary>
        public string NetworkType
        {
            get => _networkType;
            set => SetProperty(ref _networkType, value);
        }

        /// <summary>
        /// Gets or sets whether to use L2MTU
        /// </summary>
        public bool UseL2Mtu
        {
            get => _useL2Mtu;
            set => SetProperty(ref _useL2Mtu, value);
        }

        /// <summary>
        /// Gets or sets the ARP
        /// </summary>
        public string Arp
        {
            get => _arp;
            set => SetProperty(ref _arp, value);
        }

        /// <summary>
        /// Gets or sets the ARP timeout
        /// </summary>
        public string ArpTimeout
        {
            get => _arpTimeout;
            set => SetProperty(ref _arpTimeout, value);
        }

        /// <summary>
        /// Gets or sets the client name
        /// </summary>
        public string ClientName
        {
            get => _clientName;
            set => SetProperty(ref _clientName, value);
        }

        /// <summary>
        /// Gets or sets the client MAC address
        /// </summary>
        public string ClientMacAddress
        {
            get => _clientMacAddress;
            set => SetProperty(ref _clientMacAddress, value);
        }

        /// <summary>
        /// Gets or sets the client IP address
        /// </summary>
        public string ClientIpAddress
        {
            get => _clientIpAddress;
            set => SetProperty(ref _clientIpAddress, value);
        }

        /// <summary>
        /// Gets or sets the queue type
        /// </summary>
        public string QueueType
        {
            get => _queueType;
            set => SetProperty(ref _queueType, value);
        }

        /// <summary>
        /// Gets or sets the parent queue
        /// </summary>
        public string ParentQueue
        {
            get => _parentQueue;
            set => SetProperty(ref _parentQueue, value);
        }

        /// <summary>
        /// Gets or sets the priority
        /// </summary>
        public string Priority
        {
            get => _priority;
            set => SetProperty(ref _priority, value);
        }

        /// <summary>
        /// Gets or sets the burst limit
        /// </summary>
        public string BursLimit
        {
            get => _bursLimit;
            set => SetProperty(ref _bursLimit, value);
        }

        /// <summary>
        /// Gets or sets the burst threshold
        /// </summary>
        public string BurstThreshold
        {
            get => _burstThreshold;
            set => SetProperty(ref _burstThreshold, value);
        }

        /// <summary>
        /// Gets or sets the burst time
        /// </summary>
        public string BurstTime
        {
            get => _burstTime;
            set => SetProperty(ref _burstTime, value);
        }

        /// <summary>
        /// Gets or sets the maximum limit
        /// </summary>
        public string MaxLimit
        {
            get => _maxLimit;
            set => SetProperty(ref _maxLimit, value);
        }

        /// <summary>
        /// Gets or sets the limit at
        /// </summary>
        public string LimitAt
        {
            get => _limitAt;
            set => SetProperty(ref _limitAt, value);
        }

        /// <summary>
        /// Gets or sets the disabled
        /// </summary>
        public string Disabled
        {
            get => _disabled;
            set => SetProperty(ref _disabled, value);
        }

        /// <summary>
        /// Gets or sets the dynamic sort
        /// </summary>
        public string DynamicSort
        {
            get => _dynamicSort;
            set => SetProperty(ref _dynamicSort, value);
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
        /// Gets or sets whether the interface is a VLAN
        /// </summary>
        public bool IsVlan
        {
            get => _isVlan;
            set => SetProperty(ref _isVlan, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is a bridge
        /// </summary>
        public bool IsBridge
        {
            get => _isBridge;
            set => SetProperty(ref _isBridge, value);
        }

        /// <summary>
        /// Gets or sets the VLAN ID
        /// </summary>
        public int VlanId
        {
            get => _vlanId;
            set => SetProperty(ref _vlanId, value);
        }

        /// <summary>
        /// Gets or sets the bridged to
        /// </summary>
        public string BridgedTo
        {
            get => _bridgedTo;
            set => SetProperty(ref _bridgedTo, value);
        }

        /// <summary>
        /// Gets or sets the last link down time
        /// </summary>
        public string LastLinkDownTime
        {
            get => _lastLinkDownTime;
            set => SetProperty(ref _lastLinkDownTime, value);
        }

        /// <summary>
        /// Gets or sets the last link up time
        /// </summary>
        public string LastLinkUpTime
        {
            get => _lastLinkUpTime;
            set => SetProperty(ref _lastLinkUpTime, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is the default gateway
        /// </summary>
        public bool DefaultGateway
        {
            get => _defaultGateway;
            set => SetProperty(ref _defaultGateway, value);
        }

        /// <summary>
        /// Gets or sets the connected clients
        /// </summary>
        public string ConnectedClients
        {
            get => _connectedClients;
            set => SetProperty(ref _connectedClients, value);
        }

        /// <summary>
        /// Gets or sets the active connections
        /// </summary>
        public string ActiveConnections
        {
            get => _activeConnections;
            set => SetProperty(ref _activeConnections, value);
        }

        /// <summary>
        /// Gets or sets the receive rate
        /// </summary>
        public string RxRate
        {
            get => _rxRate;
            set => SetProperty(ref _rxRate, value);
        }

        /// <summary>
        /// Gets or sets the transmit rate
        /// </summary>
        public string TxRate
        {
            get => _txRate;
            set => SetProperty(ref _txRate, value);
        }

        /// <summary>
        /// Gets or sets the receive limit
        /// </summary>
        public string RxLimit
        {
            get => _rxLimit;
            set => SetProperty(ref _rxLimit, value);
        }

        /// <summary>
        /// Gets or sets the transmit limit
        /// </summary>
        public string TxLimit
        {
            get => _txLimit;
            set => SetProperty(ref _txLimit, value);
        }

        /// <summary>
        /// Gets or sets the receive FCS
        /// </summary>
        public string RxFcs
        {
            get => _rxFcs;
            set => SetProperty(ref _rxFcs, value);
        }

        /// <summary>
        /// Gets or sets the transmit FCS
        /// </summary>
        public string TxFcs
        {
            get => _txFcs;
            set => SetProperty(ref _txFcs, value);
        }

        /// <summary>
        /// Gets or sets the receive kilobytes
        /// </summary>
        public string RxKbytes
        {
            get => _rxKbytes;
            set => SetProperty(ref _rxKbytes, value);
        }

        /// <summary>
        /// Gets or sets the transmit kilobytes
        /// </summary>
        public string TxKbytes
        {
            get => _txKbytes;
            set => SetProperty(ref _txKbytes, value);
        }

        /// <summary>
        /// Gets or sets the receive megabytes
        /// </summary>
        public string RxMbytes
        {
            get => _rxMbytes;
            set => SetProperty(ref _rxMbytes, value);
        }

        /// <summary>
        /// Gets or sets the transmit megabytes
        /// </summary>
        public string TxMbytes
        {
            get => _txMbytes;
            set => SetProperty(ref _txMbytes, value);
        }

        /// <summary>
        /// Gets or sets the client count
        /// </summary>
        public string ClientCount
        {
            get => _clientCount;
            set => SetProperty(ref _clientCount, value);
        }

        /// <summary>
        /// Gets or sets the packet count
        /// </summary>
        public string PacketCount
        {
            get => _packetCount;
            set => SetProperty(ref _packetCount, value);
        }

        /// <summary>
        /// Gets or sets the packet loss
        /// </summary>
        public string PacketLoss
        {
            get => _packetLoss;
            set => SetProperty(ref _packetLoss, value);
        }

        /// <summary>
        /// Gets or sets the ping time
        /// </summary>
        public string PingTime
        {
            get => _pingTime;
            set => SetProperty(ref _pingTime, value);
        }

        /// <summary>
        /// Gets or sets the jitter
        /// </summary>
        public string Jitter
        {
            get => _jitter;
            set => SetProperty(ref _jitter, value);
        }

        /// <summary>
        /// Gets or sets the throughput
        /// </summary>
        public string Throughput
        {
            get => _throughput;
            set => SetProperty(ref _throughput, value);
        }

        /// <summary>
        /// Gets or sets the receive maximum rate
        /// </summary>
        public string RxMaxRate
        {
            get => _rxMaxRate;
            set => SetProperty(ref _rxMaxRate, value);
        }

        /// <summary>
        /// Gets or sets the transmit maximum rate
        /// </summary>
        public string TxMaxRate
        {
            get => _txMaxRate;
            set => SetProperty(ref _txMaxRate, value);
        }

        /// <summary>
        /// Gets or sets the receive average rate
        /// </summary>
        public string RxAvgRate
        {
            get => _rxAvgRate;
            set => SetProperty(ref _rxAvgRate, value);
        }

        /// <summary>
        /// Gets or sets the transmit average rate
        /// </summary>
        public string TxAvgRate
        {
            get => _txAvgRate;
            set => SetProperty(ref _txAvgRate, value);
        }

        /// <summary>
        /// Gets or sets the receive minimum rate
        /// </summary>
        public string RxMinRate
        {
            get => _rxMinRate;
            set => SetProperty(ref _rxMinRate, value);
        }

        /// <summary>
        /// Gets or sets the transmit minimum rate
        /// </summary>
        public string TxMinRate
        {
            get => _txMinRate;
            set => SetProperty(ref _txMinRate, value);
        }

        /// <summary>
        /// Gets or sets the maximum queue length
        /// </summary>
        public string MaxQueueLength
        {
            get => _maxQueueLength;
            set => SetProperty(ref _maxQueueLength, value);
        }

        /// <summary>
        /// Gets or sets the average queue length
        /// </summary>
        public string AvgQueueLength
        {
            get => _avgQueueLength;
            set => SetProperty(ref _avgQueueLength, value);
        }

        /// <summary>
        /// Gets or sets the current queue length
        /// </summary>
        public string CurrentQueueLength
        {
            get => _currentQueueLength;
            set => SetProperty(ref _currentQueueLength, value);
        }

        /// <summary>
        /// Gets or sets the bridged interfaces
        /// </summary>
        public List<NetworkInterface> BridgedInterfaces
        {
            get => _bridgedInterfaces;
            set => SetProperty(ref _bridgedInterfaces, value);
        }

        /// <summary>
        /// Gets or sets the VRRP group
        /// </summary>
        public string VrrpGroup
        {
            get => _vrrpGroup;
            set => SetProperty(ref _vrrpGroup, value);
        }

        /// <summary>
        /// Gets or sets the VRRP priority
        /// </summary>
        public string VrrpPriority
        {
            get => _vrrpPriority;
            set => SetProperty(ref _vrrpPriority, value);
        }

        /// <summary>
        /// Gets or sets the VRRP interval
        /// </summary>
        public string VrrpInterval
        {
            get => _vrrpInterval;
            set => SetProperty(ref _vrrpInterval, value);
        }

        /// <summary>
        /// Gets or sets the VRRP authentication
        /// </summary>
        public string VrrpAuthentication
        {
            get => _vrrpAuthentication;
            set => SetProperty(ref _vrrpAuthentication, value);
        }

        /// <summary>
        /// Gets or sets the VRRP password
        /// </summary>
        public string VrrpPassword
        {
            get => _vrrpPassword;
            set => SetProperty(ref _vrrpPassword, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is the VRRP master
        /// </summary>
        public bool IsVrrpMaster
        {
            get => _isVrrpMaster;
            set => SetProperty(ref _isVrrpMaster, value);
        }

        /// <summary>
        /// Gets or sets the tags
        /// </summary>
        public string Tags
        {
            get => _tags;
            set => SetProperty(ref _tags, value);
        }

        /// <summary>
        /// Gets or sets the board name
        /// </summary>
        public string BoardName
        {
            get => _boardName;
            set => SetProperty(ref _boardName, value);
        }

        /// <summary>
        /// Gets or sets the PCI ID
        /// </summary>
        public string PciId
        {
            get => _pciId;
            set => SetProperty(ref _pciId, value);
        }

        /// <summary>
        /// Gets or sets the driver
        /// </summary>
        public string Driver
        {
            get => _driver;
            set => SetProperty(ref _driver, value);
        }

        /// <summary>
        /// Gets or sets the firmware revision
        /// </summary>
        public string FirmwareRevision
        {
            get => _firmwareRevision;
            set => SetProperty(ref _firmwareRevision, value);
        }

        /// <summary>
        /// Gets or sets the firmware date
        /// </summary>
        public string FirmwareDate
        {
            get => _firmwareDate;
            set => SetProperty(ref _firmwareDate, value);
        }

        /// <summary>
        /// Gets or sets whether a firmware upgrade is available
        /// </summary>
        public bool HasFirmwareUpgrade
        {
            get => _hasFirmwareUpgrade;
            set => SetProperty(ref _hasFirmwareUpgrade, value);
        }

        /// <summary>
        /// Gets or sets the firmware upgrade version
        /// </summary>
        public string FirmwareUpgradeVersion
        {
            get => _firmwareUpgradeVersion;
            set => SetProperty(ref _firmwareUpgradeVersion, value);
        }

        /// <summary>
        /// Gets or sets the firmware upgrade URL
        /// </summary>
        public string FirmwareUpgradeUrl
        {
            get => _firmwareUpgradeUrl;
            set => SetProperty(ref _firmwareUpgradeUrl, value);
        }

        /// <summary>
        /// Gets or sets the last seen time
        /// </summary>
        public DateTime LastSeenTime
        {
            get => _lastSeenTime;
            set => SetProperty(ref _lastSeenTime, value);
        }

        /// <summary>
        /// Gets or sets whether the interface is monitored
        /// </summary>
        public bool Monitored
        {
            get => _monitored;
            set => SetProperty(ref _monitored, value);
        }

        /// <summary>
        /// Gets or sets the graph color
        /// </summary>
        public string GraphColor
        {
            get => _graphColor;
            set => SetProperty(ref _graphColor, value);
        }

        /// <summary>
        /// Gets or sets the parent interface ID
        /// </summary>
        public string ParentInterfaceId
        {
            get => _parentInterfaceId;
            set => SetProperty(ref _parentInterfaceId, value);
        }

        /// <summary>
        /// Gets or sets the device ID
        /// </summary>
        public string DeviceId
        {
            get => _deviceId;
            set => SetProperty(ref _deviceId, value);
        }

        /// <summary>
        /// Gets or sets whether to backup the interface
        /// </summary>
        public bool Backup
        {
            get => _backup;
            set => SetProperty(ref _backup, value);
        }

        /// <summary>
        /// Gets or sets the IP addresses
        /// </summary>
        public List<string> IpAddresses
        {
            get => _ipAddresses;
            set => SetProperty(ref _ipAddresses, value);
        }

        /// <summary>
        /// Gets or sets the IPv6 addresses
        /// </summary>
        public List<string> Ipv6Addresses
        {
            get => _ipv6Addresses;
            set => SetProperty(ref _ipv6Addresses, value);
        }

        /// <summary>
        /// Gets or sets the speed duplex
        /// </summary>
        public string SpeedDuplex
        {
            get => _speedDuplex;
            set => SetProperty(ref _speedDuplex, value);
        }

        /// <summary>
        /// Gets or sets the auto negotiation
        /// </summary>
        public string AutoNegotiation
        {
            get => _autoNegotiation;
            set => SetProperty(ref _autoNegotiation, value);
        }

        /// <summary>
        /// Gets or sets the actual speed duplex
        /// </summary>
        public string ActualSpeedDuplex
        {
            get => _actualSpeedDuplex;
            set => SetProperty(ref _actualSpeedDuplex, value);
        }

        /// <summary>
        /// Gets or sets the SFP type
        /// </summary>
        public string SfpType
        {
            get => _sfpType;
            set => SetProperty(ref _sfpType, value);
        }

        /// <summary>
        /// Gets or sets the SFP serial number
        /// </summary>
        public string SfpSerialNumber
        {
            get => _sfpSerialNumber;
            set => SetProperty(ref _sfpSerialNumber, value);
        }

        /// <summary>
        /// Gets or sets the SFP vendor
        /// </summary>
        public string SfpVendor
        {
            get => _sfpVendor;
            set => SetProperty(ref _sfpVendor, value);
        }

        /// <summary>
        /// Gets or sets the SFP model
        /// </summary>
        public string SfpModel
        {
            get => _sfpModel;
            set => SetProperty(ref _sfpModel, value);
        }

        /// <summary>
        /// Gets or sets the SFP temperature
        /// </summary>
        public string SfpTemperature
        {
            get => _sfpTemperature;
            set => SetProperty(ref _sfpTemperature, value);
        }

        /// <summary>
        /// Gets or sets the SFP voltage
        /// </summary>
        public string SfpVoltage
        {
            get => _sfpVoltage;
            set => SetProperty(ref _sfpVoltage, value);
        }

        /// <summary>
        /// Gets or sets the SFP transmit power
        /// </summary>
        public string SfpTxPower
        {
            get => _sfpTxPower;
            set => SetProperty(ref _sfpTxPower, value);
        }

        /// <summary>
        /// Gets or sets the SFP receive power
        /// </summary>
        public string SfpRxPower
        {
            get => _sfpRxPower;
            set => SetProperty(ref _sfpRxPower, value);
        }

        /// <summary>
        /// Gets the formatted receive bit rate
        /// </summary>
        public string FormattedRxBitRate => FormatBitRate(RxBitRate);

        /// <summary>
        /// Gets the formatted transmit bit rate
        /// </summary>
        public string FormattedTxBitRate => FormatBitRate(TxBitRate);

        /// <summary>
        /// Gets the formatted receive packet rate
        /// </summary>
        public string FormattedRxPacketRate => $"{RxPacketRate:N0} pps";

        /// <summary>
        /// Gets the formatted transmit packet rate
        /// </summary>
        public string FormattedTxPacketRate => $"{TxPacketRate:N0} pps";

        /// <summary>
        /// Gets the formatted received bytes
        /// </summary>
        public string FormattedRxBytes => FormatBytes(RxBytes);

        /// <summary>
        /// Gets the formatted transmitted bytes
        /// </summary>
        public string FormattedTxBytes => FormatBytes(TxBytes);

        /// <summary>
        /// Initializes a new instance of the NetworkInterface class
        /// </summary>
        public NetworkInterface()
        {
            Id = Guid.NewGuid().ToString();
            LastUpdate = DateTime.MinValue;
            LastSeenTime = DateTime.MinValue;
        }

        /// <summary>
        /// Formats a bit rate
        /// </summary>
        /// <param name="bitRate">The bit rate</param>
        /// <returns>The formatted bit rate</returns>
        private string FormatBitRate(double bitRate)
        {
            if (bitRate >= 1000000000)
            {
                return $"{bitRate / 1000000000:N2} Gbps";
            }
            
            if (bitRate >= 1000000)
            {
                return $"{bitRate / 1000000:N2} Mbps";
            }
            
            if (bitRate >= 1000)
            {
                return $"{bitRate / 1000:N2} Kbps";
            }
            
            return $"{bitRate:N0} bps";
        }

        /// <summary>
        /// Formats a byte count
        /// </summary>
        /// <param name="bytes">The byte count</param>
        /// <returns>The formatted byte count</returns>
        private string FormatBytes(long bytes)
        {
            if (bytes >= 1099511627776)
            {
                return $"{bytes / 1099511627776.0:N2} TB";
            }
            
            if (bytes >= 1073741824)
            {
                return $"{bytes / 1073741824.0:N2} GB";
            }
            
            if (bytes >= 1048576)
            {
                return $"{bytes / 1048576.0:N2} MB";
            }
            
            if (bytes >= 1024)
            {
                return $"{bytes / 1024.0:N2} KB";
            }
            
            return $"{bytes:N0} bytes";
        }
    }
}