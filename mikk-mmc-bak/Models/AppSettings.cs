using System;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents the application settings
    /// </summary>
    public class AppSettings : ModelBase
    {
        private bool _darkMode;
        private string _theme = "Light";
        private bool _startWithWindows;
        private bool _minimizeToTray;
        private bool _closeToTray;
        private bool _showNotifications = true;
        private bool _playSounds;
        private int _dataRefreshInterval = 5000;
        private bool _autoConnect;
        private int _connectionTimeout = 10000;
        private string _connectionRetryPolicy = "Linear";
        private int _connectionRetryCount = 3;
        private int _connectionRetryDelay = 5000;
        private bool _checkForUpdatesOnStartup = true;
        private bool _autoInstallUpdates;
        private bool _saveLoginCredentials = true;
        private bool _useEncryption = true;
        private string _language = "en-US";
        private string _dateFormat = "yyyy-MM-dd";
        private string _timeFormat = "HH:mm:ss";
        private bool _useTelemetry;
        private string _logLevel = "Information";
        private int _maxLogFileSize = 10;
        private int _maxLogFileCount = 5;
        private bool _enableLogging = true;
        private string _proxyAddress;
        private int _proxyPort;
        private string _proxyUsername;
        private string _proxyPassword;
        private bool _useProxy;
        private bool _proxyAuthentication;
        private bool _openLastProject = true;
        private string _lastProjectPath;
        private bool _autoSaveProjects = true;
        private int _autoSaveInterval = 300000;
        private bool _backupBeforeSaving = true;
        private int _maxBackupCount = 5;
        private string _backupLocation;
        private bool _showStartupTips = true;
        private bool _showTooltips = true;
        private int _mainWindowWidth = 1024;
        private int _mainWindowHeight = 768;
        private bool _mainWindowMaximized;
        private int _mainWindowLeft;
        private int _mainWindowTop;
        private string _customThemeName;
        private double _uiScaleFactor = 1.0;
        private string _fontFamily = "Segoe UI";
        private int _fontSize = 12;
        private bool _enableHardwareAcceleration = true;
        private bool _showDataLabels = true;
        private bool _showLegends = true;
        private bool _animateCharts = true;

        /// <summary>
        /// Gets or sets whether to use dark mode
        /// </summary>
        public bool DarkMode
        {
            get => _darkMode;
            set => SetProperty(ref _darkMode, value);
        }

        /// <summary>
        /// Gets or sets the theme
        /// </summary>
        public string Theme
        {
            get => _theme;
            set => SetProperty(ref _theme, value);
        }

        /// <summary>
        /// Gets or sets whether to start with Windows
        /// </summary>
        public bool StartWithWindows
        {
            get => _startWithWindows;
            set => SetProperty(ref _startWithWindows, value);
        }

        /// <summary>
        /// Gets or sets whether to minimize to tray
        /// </summary>
        public bool MinimizeToTray
        {
            get => _minimizeToTray;
            set => SetProperty(ref _minimizeToTray, value);
        }

        /// <summary>
        /// Gets or sets whether to close to tray
        /// </summary>
        public bool CloseToTray
        {
            get => _closeToTray;
            set => SetProperty(ref _closeToTray, value);
        }

        /// <summary>
        /// Gets or sets whether to show notifications
        /// </summary>
        public bool ShowNotifications
        {
            get => _showNotifications;
            set => SetProperty(ref _showNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to play sounds
        /// </summary>
        public bool PlaySounds
        {
            get => _playSounds;
            set => SetProperty(ref _playSounds, value);
        }

        /// <summary>
        /// Gets or sets the data refresh interval in milliseconds
        /// </summary>
        public int DataRefreshInterval
        {
            get => _dataRefreshInterval;
            set => SetProperty(ref _dataRefreshInterval, value);
        }

        /// <summary>
        /// Gets or sets whether to automatically connect to the router
        /// </summary>
        public bool AutoConnect
        {
            get => _autoConnect;
            set => SetProperty(ref _autoConnect, value);
        }

        /// <summary>
        /// Gets or sets the connection timeout in milliseconds
        /// </summary>
        public int ConnectionTimeout
        {
            get => _connectionTimeout;
            set => SetProperty(ref _connectionTimeout, value);
        }

        /// <summary>
        /// Gets or sets the connection retry policy
        /// </summary>
        public string ConnectionRetryPolicy
        {
            get => _connectionRetryPolicy;
            set => SetProperty(ref _connectionRetryPolicy, value);
        }

        /// <summary>
        /// Gets or sets the connection retry count
        /// </summary>
        public int ConnectionRetryCount
        {
            get => _connectionRetryCount;
            set => SetProperty(ref _connectionRetryCount, value);
        }

        /// <summary>
        /// Gets or sets the connection retry delay in milliseconds
        /// </summary>
        public int ConnectionRetryDelay
        {
            get => _connectionRetryDelay;
            set => SetProperty(ref _connectionRetryDelay, value);
        }

        /// <summary>
        /// Gets or sets whether to check for updates on startup
        /// </summary>
        public bool CheckForUpdatesOnStartup
        {
            get => _checkForUpdatesOnStartup;
            set => SetProperty(ref _checkForUpdatesOnStartup, value);
        }

        /// <summary>
        /// Gets or sets whether to automatically install updates
        /// </summary>
        public bool AutoInstallUpdates
        {
            get => _autoInstallUpdates;
            set => SetProperty(ref _autoInstallUpdates, value);
        }

        /// <summary>
        /// Gets or sets whether to save login credentials
        /// </summary>
        public bool SaveLoginCredentials
        {
            get => _saveLoginCredentials;
            set => SetProperty(ref _saveLoginCredentials, value);
        }

        /// <summary>
        /// Gets or sets whether to use encryption
        /// </summary>
        public bool UseEncryption
        {
            get => _useEncryption;
            set => SetProperty(ref _useEncryption, value);
        }

        /// <summary>
        /// Gets or sets the language
        /// </summary>
        public string Language
        {
            get => _language;
            set => SetProperty(ref _language, value);
        }

        /// <summary>
        /// Gets or sets the date format
        /// </summary>
        public string DateFormat
        {
            get => _dateFormat;
            set => SetProperty(ref _dateFormat, value);
        }

        /// <summary>
        /// Gets or sets the time format
        /// </summary>
        public string TimeFormat
        {
            get => _timeFormat;
            set => SetProperty(ref _timeFormat, value);
        }

        /// <summary>
        /// Gets or sets whether to use telemetry
        /// </summary>
        public bool UseTelemetry
        {
            get => _useTelemetry;
            set => SetProperty(ref _useTelemetry, value);
        }

        /// <summary>
        /// Gets or sets the log level
        /// </summary>
        public string LogLevel
        {
            get => _logLevel;
            set => SetProperty(ref _logLevel, value);
        }

        /// <summary>
        /// Gets or sets the maximum log file size in MB
        /// </summary>
        public int MaxLogFileSize
        {
            get => _maxLogFileSize;
            set => SetProperty(ref _maxLogFileSize, value);
        }

        /// <summary>
        /// Gets or sets the maximum log file count
        /// </summary>
        public int MaxLogFileCount
        {
            get => _maxLogFileCount;
            set => SetProperty(ref _maxLogFileCount, value);
        }

        /// <summary>
        /// Gets or sets whether to enable logging
        /// </summary>
        public bool EnableLogging
        {
            get => _enableLogging;
            set => SetProperty(ref _enableLogging, value);
        }

        /// <summary>
        /// Gets or sets the proxy address
        /// </summary>
        public string ProxyAddress
        {
            get => _proxyAddress;
            set => SetProperty(ref _proxyAddress, value);
        }

        /// <summary>
        /// Gets or sets the proxy port
        /// </summary>
        public int ProxyPort
        {
            get => _proxyPort;
            set => SetProperty(ref _proxyPort, value);
        }

        /// <summary>
        /// Gets or sets the proxy username
        /// </summary>
        public string ProxyUsername
        {
            get => _proxyUsername;
            set => SetProperty(ref _proxyUsername, value);
        }

        /// <summary>
        /// Gets or sets the proxy password
        /// </summary>
        public string ProxyPassword
        {
            get => _proxyPassword;
            set => SetProperty(ref _proxyPassword, value);
        }

        /// <summary>
        /// Gets or sets whether to use a proxy
        /// </summary>
        public bool UseProxy
        {
            get => _useProxy;
            set => SetProperty(ref _useProxy, value);
        }

        /// <summary>
        /// Gets or sets whether to use proxy authentication
        /// </summary>
        public bool ProxyAuthentication
        {
            get => _proxyAuthentication;
            set => SetProperty(ref _proxyAuthentication, value);
        }

        /// <summary>
        /// Gets or sets whether to open the last project
        /// </summary>
        public bool OpenLastProject
        {
            get => _openLastProject;
            set => SetProperty(ref _openLastProject, value);
        }

        /// <summary>
        /// Gets or sets the last project path
        /// </summary>
        public string LastProjectPath
        {
            get => _lastProjectPath;
            set => SetProperty(ref _lastProjectPath, value);
        }

        /// <summary>
        /// Gets or sets whether to automatically save projects
        /// </summary>
        public bool AutoSaveProjects
        {
            get => _autoSaveProjects;
            set => SetProperty(ref _autoSaveProjects, value);
        }

        /// <summary>
        /// Gets or sets the auto-save interval in milliseconds
        /// </summary>
        public int AutoSaveInterval
        {
            get => _autoSaveInterval;
            set => SetProperty(ref _autoSaveInterval, value);
        }

        /// <summary>
        /// Gets or sets whether to backup before saving
        /// </summary>
        public bool BackupBeforeSaving
        {
            get => _backupBeforeSaving;
            set => SetProperty(ref _backupBeforeSaving, value);
        }

        /// <summary>
        /// Gets or sets the maximum backup count
        /// </summary>
        public int MaxBackupCount
        {
            get => _maxBackupCount;
            set => SetProperty(ref _maxBackupCount, value);
        }

        /// <summary>
        /// Gets or sets the backup location
        /// </summary>
        public string BackupLocation
        {
            get => _backupLocation;
            set => SetProperty(ref _backupLocation, value);
        }

        /// <summary>
        /// Gets or sets whether to show startup tips
        /// </summary>
        public bool ShowStartupTips
        {
            get => _showStartupTips;
            set => SetProperty(ref _showStartupTips, value);
        }

        /// <summary>
        /// Gets or sets whether to show tooltips
        /// </summary>
        public bool ShowTooltips
        {
            get => _showTooltips;
            set => SetProperty(ref _showTooltips, value);
        }

        /// <summary>
        /// Gets or sets the main window width
        /// </summary>
        public int MainWindowWidth
        {
            get => _mainWindowWidth;
            set => SetProperty(ref _mainWindowWidth, value);
        }

        /// <summary>
        /// Gets or sets the main window height
        /// </summary>
        public int MainWindowHeight
        {
            get => _mainWindowHeight;
            set => SetProperty(ref _mainWindowHeight, value);
        }

        /// <summary>
        /// Gets or sets whether the main window is maximized
        /// </summary>
        public bool MainWindowMaximized
        {
            get => _mainWindowMaximized;
            set => SetProperty(ref _mainWindowMaximized, value);
        }

        /// <summary>
        /// Gets or sets the main window left position
        /// </summary>
        public int MainWindowLeft
        {
            get => _mainWindowLeft;
            set => SetProperty(ref _mainWindowLeft, value);
        }

        /// <summary>
        /// Gets or sets the main window top position
        /// </summary>
        public int MainWindowTop
        {
            get => _mainWindowTop;
            set => SetProperty(ref _mainWindowTop, value);
        }

        /// <summary>
        /// Gets or sets the custom theme name
        /// </summary>
        public string CustomThemeName
        {
            get => _customThemeName;
            set => SetProperty(ref _customThemeName, value);
        }

        /// <summary>
        /// Gets or sets the UI scale factor
        /// </summary>
        public double UiScaleFactor
        {
            get => _uiScaleFactor;
            set => SetProperty(ref _uiScaleFactor, value);
        }

        /// <summary>
        /// Gets or sets the font family
        /// </summary>
        public string FontFamily
        {
            get => _fontFamily;
            set => SetProperty(ref _fontFamily, value);
        }

        /// <summary>
        /// Gets or sets the font size
        /// </summary>
        public int FontSize
        {
            get => _fontSize;
            set => SetProperty(ref _fontSize, value);
        }

        /// <summary>
        /// Gets or sets whether to enable hardware acceleration
        /// </summary>
        public bool EnableHardwareAcceleration
        {
            get => _enableHardwareAcceleration;
            set => SetProperty(ref _enableHardwareAcceleration, value);
        }

        /// <summary>
        /// Gets or sets whether to show data labels
        /// </summary>
        public bool ShowDataLabels
        {
            get => _showDataLabels;
            set => SetProperty(ref _showDataLabels, value);
        }

        /// <summary>
        /// Gets or sets whether to show legends
        /// </summary>
        public bool ShowLegends
        {
            get => _showLegends;
            set => SetProperty(ref _showLegends, value);
        }

        /// <summary>
        /// Gets or sets whether to animate charts
        /// </summary>
        public bool AnimateCharts
        {
            get => _animateCharts;
            set => SetProperty(ref _animateCharts, value);
        }
    }
}