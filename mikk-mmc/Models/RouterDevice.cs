using System;
using System.Collections.ObjectModel;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents a Mikrotik router device
    /// </summary>
    public class RouterDevice : ModelBase
    {
        private string _id;
        private string _name;
        private string _hostname;
        private string _username;
        private string _password;
        private int _port = 22;
        private string _apiPort = "8728";
        private string _apiSslPort = "8729";
        private bool _useApiSsl;
        private string _model;
        private string _serialNumber;
        private string _macAddress;
        private string _firmware;
        private string _routerOsVersion;
        private string _firmwareType;
        private bool _isDefault;
        private ConnectionStatus _connectionStatus = ConnectionStatus.Disconnected;
        private bool _isConnected;
        private DateTime _lastConnected;
        private int _connectionAttempts;
        private ObservableCollection<NetworkInterface> _interfaces;
        private ObservableCollection<LogEntry> _logEntries;
        private ObservableCollection<FirewallRule> _firewallRules;
        private SystemResources _systemResources;
        private string _notes;
        private bool _useSnmp;
        private string _snmpCommunity = "public";
        private string _snmpPort = "161";
        private bool _useSsh;
        private bool _useApi = true;
        private string _location;
        private string _customField1;
        private string _customField2;
        private string _customField3;
        private bool _monitored = true;
        private DateTime _lastChecked;
        private int _checkInterval = 300;
        private bool _alertOnDisconnect = true;
        private string _group;
        private string _tags;
        private bool _backup;
        private bool _autoUpdate;
        private string _wifiSsid;
        private string _wifiPassword;

        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Gets or sets the name of the router
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Gets or sets the hostname or IP address of the router
        /// </summary>
        public string Hostname
        {
            get => _hostname;
            set => SetProperty(ref _hostname, value);
        }

        /// <summary>
        /// Gets or sets the username for authentication
        /// </summary>
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        /// <summary>
        /// Gets or sets the password for authentication
        /// </summary>
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        /// <summary>
        /// Gets or sets the SSH port of the router
        /// </summary>
        public int Port
        {
            get => _port;
            set => SetProperty(ref _port, value);
        }

        /// <summary>
        /// Gets or sets the API port of the router
        /// </summary>
        public string ApiPort
        {
            get => _apiPort;
            set => SetProperty(ref _apiPort, value);
        }

        /// <summary>
        /// Gets or sets the API SSL port of the router
        /// </summary>
        public string ApiSslPort
        {
            get => _apiSslPort;
            set => SetProperty(ref _apiSslPort, value);
        }

        /// <summary>
        /// Gets or sets whether to use SSL for API connections
        /// </summary>
        public bool UseApiSsl
        {
            get => _useApiSsl;
            set => SetProperty(ref _useApiSsl, value);
        }

        /// <summary>
        /// Gets or sets the model of the router
        /// </summary>
        public string Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        /// <summary>
        /// Gets or sets the serial number of the router
        /// </summary>
        public string SerialNumber
        {
            get => _serialNumber;
            set => SetProperty(ref _serialNumber, value);
        }

        /// <summary>
        /// Gets or sets the MAC address of the router
        /// </summary>
        public string MacAddress
        {
            get => _macAddress;
            set => SetProperty(ref _macAddress, value);
        }

        /// <summary>
        /// Gets or sets the firmware of the router
        /// </summary>
        public string Firmware
        {
            get => _firmware;
            set => SetProperty(ref _firmware, value);
        }

        /// <summary>
        /// Gets or sets the RouterOS version of the router
        /// </summary>
        public string RouterOsVersion
        {
            get => _routerOsVersion;
            set => SetProperty(ref _routerOsVersion, value);
        }

        /// <summary>
        /// Gets or sets the firmware type of the router
        /// </summary>
        public string FirmwareType
        {
            get => _firmwareType;
            set => SetProperty(ref _firmwareType, value);
        }

        /// <summary>
        /// Gets or sets whether this router is the default router
        /// </summary>
        public bool IsDefault
        {
            get => _isDefault;
            set => SetProperty(ref _isDefault, value);
        }

        /// <summary>
        /// Gets or sets the connection status of the router
        /// </summary>
        public ConnectionStatus ConnectionStatus
        {
            get => _connectionStatus;
            set => SetProperty(ref _connectionStatus, value);
        }

        /// <summary>
        /// Gets or sets whether the router is connected
        /// </summary>
        public bool IsConnected
        {
            get => _isConnected;
            set => SetProperty(ref _isConnected, value);
        }

        /// <summary>
        /// Gets or sets the last time the router was connected
        /// </summary>
        public DateTime LastConnected
        {
            get => _lastConnected;
            set => SetProperty(ref _lastConnected, value);
        }

        /// <summary>
        /// Gets or sets the number of connection attempts
        /// </summary>
        public int ConnectionAttempts
        {
            get => _connectionAttempts;
            set => SetProperty(ref _connectionAttempts, value);
        }

        /// <summary>
        /// Gets or sets the interfaces of the router
        /// </summary>
        public ObservableCollection<NetworkInterface> Interfaces
        {
            get => _interfaces;
            set => SetProperty(ref _interfaces, value);
        }

        /// <summary>
        /// Gets or sets the log entries of the router
        /// </summary>
        public ObservableCollection<LogEntry> LogEntries
        {
            get => _logEntries;
            set => SetProperty(ref _logEntries, value);
        }

        /// <summary>
        /// Gets or sets the firewall rules of the router
        /// </summary>
        public ObservableCollection<FirewallRule> FirewallRules
        {
            get => _firewallRules;
            set => SetProperty(ref _firewallRules, value);
        }

        /// <summary>
        /// Gets or sets the system resources of the router
        /// </summary>
        public SystemResources SystemResources
        {
            get => _systemResources;
            set => SetProperty(ref _systemResources, value);
        }

        /// <summary>
        /// Gets or sets the notes for the router
        /// </summary>
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        /// <summary>
        /// Gets or sets whether to use SNMP for monitoring
        /// </summary>
        public bool UseSnmp
        {
            get => _useSnmp;
            set => SetProperty(ref _useSnmp, value);
        }

        /// <summary>
        /// Gets or sets the SNMP community string
        /// </summary>
        public string SnmpCommunity
        {
            get => _snmpCommunity;
            set => SetProperty(ref _snmpCommunity, value);
        }

        /// <summary>
        /// Gets or sets the SNMP port
        /// </summary>
        public string SnmpPort
        {
            get => _snmpPort;
            set => SetProperty(ref _snmpPort, value);
        }

        /// <summary>
        /// Gets or sets whether to use SSH for communication
        /// </summary>
        public bool UseSsh
        {
            get => _useSsh;
            set => SetProperty(ref _useSsh, value);
        }

        /// <summary>
        /// Gets or sets whether to use the RouterOS API for communication
        /// </summary>
        public bool UseApi
        {
            get => _useApi;
            set => SetProperty(ref _useApi, value);
        }

        /// <summary>
        /// Gets or sets the location of the router
        /// </summary>
        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        /// <summary>
        /// Gets or sets the first custom field
        /// </summary>
        public string CustomField1
        {
            get => _customField1;
            set => SetProperty(ref _customField1, value);
        }

        /// <summary>
        /// Gets or sets the second custom field
        /// </summary>
        public string CustomField2
        {
            get => _customField2;
            set => SetProperty(ref _customField2, value);
        }

        /// <summary>
        /// Gets or sets the third custom field
        /// </summary>
        public string CustomField3
        {
            get => _customField3;
            set => SetProperty(ref _customField3, value);
        }

        /// <summary>
        /// Gets or sets whether the router is monitored
        /// </summary>
        public bool Monitored
        {
            get => _monitored;
            set => SetProperty(ref _monitored, value);
        }

        /// <summary>
        /// Gets or sets the last time the router was checked
        /// </summary>
        public DateTime LastChecked
        {
            get => _lastChecked;
            set => SetProperty(ref _lastChecked, value);
        }

        /// <summary>
        /// Gets or sets the check interval in seconds
        /// </summary>
        public int CheckInterval
        {
            get => _checkInterval;
            set => SetProperty(ref _checkInterval, value);
        }

        /// <summary>
        /// Gets or sets whether to alert when the router disconnects
        /// </summary>
        public bool AlertOnDisconnect
        {
            get => _alertOnDisconnect;
            set => SetProperty(ref _alertOnDisconnect, value);
        }

        /// <summary>
        /// Gets or sets the group the router belongs to
        /// </summary>
        public string Group
        {
            get => _group;
            set => SetProperty(ref _group, value);
        }

        /// <summary>
        /// Gets or sets the tags for the router
        /// </summary>
        public string Tags
        {
            get => _tags;
            set => SetProperty(ref _tags, value);
        }

        /// <summary>
        /// Gets or sets whether to backup the router configuration
        /// </summary>
        public bool Backup
        {
            get => _backup;
            set => SetProperty(ref _backup, value);
        }

        /// <summary>
        /// Gets or sets whether to automatically update the router
        /// </summary>
        public bool AutoUpdate
        {
            get => _autoUpdate;
            set => SetProperty(ref _autoUpdate, value);
        }

        /// <summary>
        /// Gets or sets the WiFi SSID of the router
        /// </summary>
        public string WifiSsid
        {
            get => _wifiSsid;
            set => SetProperty(ref _wifiSsid, value);
        }

        /// <summary>
        /// Gets or sets the WiFi password of the router
        /// </summary>
        public string WifiPassword
        {
            get => _wifiPassword;
            set => SetProperty(ref _wifiPassword, value);
        }

        /// <summary>
        /// Gets the API endpoint for the router
        /// </summary>
        public string ApiEndpoint => UseApiSsl
            ? $"https://{Hostname}:{ApiSslPort}/rest"
            : $"http://{Hostname}:{ApiPort}/rest";

        /// <summary>
        /// Initializes a new instance of the RouterDevice class
        /// </summary>
        public RouterDevice()
        {
            Id = Guid.NewGuid().ToString();
            Interfaces = new ObservableCollection<NetworkInterface>();
            LogEntries = new ObservableCollection<LogEntry>();
            FirewallRules = new ObservableCollection<FirewallRule>();
            SystemResources = new SystemResources();
            LastConnected = DateTime.MinValue;
            LastChecked = DateTime.MinValue;
        }

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            return $"{Name} ({Hostname})";
        }
    }
}