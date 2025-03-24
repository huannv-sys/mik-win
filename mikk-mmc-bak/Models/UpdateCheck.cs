using System;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents the update check information
    /// </summary>
    public class UpdateCheck : ModelBase
    {
        private bool _enabled = true;
        private string _frequency = "Daily";
        private DateTime _lastCheckTime = DateTime.MinValue;
        private DateTime _nextCheckTime;
        private string _lastVersionFound;
        private string _currentVersion;
        private bool _updateAvailable;
        private string _releaseNotes;
        private string _downloadUrl;
        private string _updateType;
        private bool _criticalUpdate;
        private bool _securityUpdate;
        private bool _autoDownload;
        private bool _autoInstall;
        private string _updateChannel = "Stable";
        private bool _includeBetaVersions;
        private bool _includeAlphaVersions;
        private bool _notifyOnNoUpdates;
        private bool _checkOnStartup = true;
        private bool _checkOnSchedule = true;
        private string _checkTime = "03:00";
        private bool _checkProxy;
        private string _proxyAddress;
        private int _proxyPort;
        private string _proxyUsername;
        private string _proxyPassword;
        private string _updateServer = "https://updates.mikrotikmonitor.com";
        private string _customUpdateUrl;
        private bool _useCustomUpdateUrl;
        private bool _updateDependencies = true;
        private bool _backupBeforeUpdate = true;
        private bool _restartAfterUpdate = true;
        private bool _showUpdateNotification = true;
        private bool _downloadInBackground = true;
        private string _downloadLocation;
        private bool _useUpdater = true;
        private string _updaterPath;
        private string _updaterArguments;
        private bool _runUpdaterAsAdmin = true;
        private bool _validateSignature = true;
        private string _signatureKey;
        private bool _useInstallerForUpdate;
        private string _installerPath;
        private string _installerArguments;
        private bool _runInstallerAsAdmin = true;
        private int _connectionTimeout = 30;
        private int _downloadTimeout = 600;
        private int _installTimeout = 300;
        private bool _logUpdateActivity = true;
        private string _updateLogPath;
        private bool _checkRouterOsUpdates = true;
        private bool _notifyOnRouterOsUpdates = true;
        private bool _autoUpdateRouterOs;
        private bool _checkForExtensionUpdates = true;
        private bool _notifyOnExtensionUpdates = true;
        private bool _autoUpdateExtensions;
        private bool _skipVersions;
        private string _skipVersion;
        private string _minVersionToInstall;
        private bool _enforceMinVersion;
        private bool _enforceMaxVersion;
        private string _maxVersionToInstall;
        private bool _forceUpdate;
        private string _customScript;
        private bool _executeBeforeUpdate;
        private bool _executeAfterUpdate;
        private int _scriptTimeout = 60;
        private bool _abortOnScriptError = true;
        private string _emailRecipients;
        private bool _notifyByEmail;
        private bool _checkHashBeforeInstall = true;
        private string _expectedHash;
        private string _hashAlgorithm = "SHA256";

        /// <summary>
        /// Gets or sets whether update checking is enabled
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }

        /// <summary>
        /// Gets or sets the check frequency
        /// </summary>
        public string Frequency
        {
            get => _frequency;
            set => SetProperty(ref _frequency, value);
        }

        /// <summary>
        /// Gets or sets the last check time
        /// </summary>
        public DateTime LastCheckTime
        {
            get => _lastCheckTime;
            set => SetProperty(ref _lastCheckTime, value);
        }

        /// <summary>
        /// Gets or sets the next check time
        /// </summary>
        public DateTime NextCheckTime
        {
            get => _nextCheckTime;
            set => SetProperty(ref _nextCheckTime, value);
        }

        /// <summary>
        /// Gets or sets the last version found
        /// </summary>
        public string LastVersionFound
        {
            get => _lastVersionFound;
            set => SetProperty(ref _lastVersionFound, value);
        }

        /// <summary>
        /// Gets or sets the current version
        /// </summary>
        public string CurrentVersion
        {
            get => _currentVersion;
            set => SetProperty(ref _currentVersion, value);
        }

        /// <summary>
        /// Gets or sets whether an update is available
        /// </summary>
        public bool UpdateAvailable
        {
            get => _updateAvailable;
            set => SetProperty(ref _updateAvailable, value);
        }

        /// <summary>
        /// Gets or sets the release notes
        /// </summary>
        public string ReleaseNotes
        {
            get => _releaseNotes;
            set => SetProperty(ref _releaseNotes, value);
        }

        /// <summary>
        /// Gets or sets the download URL
        /// </summary>
        public string DownloadUrl
        {
            get => _downloadUrl;
            set => SetProperty(ref _downloadUrl, value);
        }

        /// <summary>
        /// Gets or sets the update type
        /// </summary>
        public string UpdateType
        {
            get => _updateType;
            set => SetProperty(ref _updateType, value);
        }

        /// <summary>
        /// Gets or sets whether this is a critical update
        /// </summary>
        public bool CriticalUpdate
        {
            get => _criticalUpdate;
            set => SetProperty(ref _criticalUpdate, value);
        }

        /// <summary>
        /// Gets or sets whether this is a security update
        /// </summary>
        public bool SecurityUpdate
        {
            get => _securityUpdate;
            set => SetProperty(ref _securityUpdate, value);
        }

        /// <summary>
        /// Gets or sets whether to auto download updates
        /// </summary>
        public bool AutoDownload
        {
            get => _autoDownload;
            set => SetProperty(ref _autoDownload, value);
        }

        /// <summary>
        /// Gets or sets whether to auto install updates
        /// </summary>
        public bool AutoInstall
        {
            get => _autoInstall;
            set => SetProperty(ref _autoInstall, value);
        }

        /// <summary>
        /// Gets or sets the update channel
        /// </summary>
        public string UpdateChannel
        {
            get => _updateChannel;
            set => SetProperty(ref _updateChannel, value);
        }

        /// <summary>
        /// Gets or sets whether to include beta versions
        /// </summary>
        public bool IncludeBetaVersions
        {
            get => _includeBetaVersions;
            set => SetProperty(ref _includeBetaVersions, value);
        }

        /// <summary>
        /// Gets or sets whether to include alpha versions
        /// </summary>
        public bool IncludeAlphaVersions
        {
            get => _includeAlphaVersions;
            set => SetProperty(ref _includeAlphaVersions, value);
        }

        /// <summary>
        /// Gets or sets whether to notify when no updates are available
        /// </summary>
        public bool NotifyOnNoUpdates
        {
            get => _notifyOnNoUpdates;
            set => SetProperty(ref _notifyOnNoUpdates, value);
        }

        /// <summary>
        /// Gets or sets whether to check for updates on startup
        /// </summary>
        public bool CheckOnStartup
        {
            get => _checkOnStartup;
            set => SetProperty(ref _checkOnStartup, value);
        }

        /// <summary>
        /// Gets or sets whether to check for updates on schedule
        /// </summary>
        public bool CheckOnSchedule
        {
            get => _checkOnSchedule;
            set => SetProperty(ref _checkOnSchedule, value);
        }

        /// <summary>
        /// Gets or sets the check time
        /// </summary>
        public string CheckTime
        {
            get => _checkTime;
            set => SetProperty(ref _checkTime, value);
        }

        /// <summary>
        /// Gets or sets whether to use a proxy for update checks
        /// </summary>
        public bool CheckProxy
        {
            get => _checkProxy;
            set => SetProperty(ref _checkProxy, value);
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
        /// Gets or sets the update server
        /// </summary>
        public string UpdateServer
        {
            get => _updateServer;
            set => SetProperty(ref _updateServer, value);
        }

        /// <summary>
        /// Gets or sets the custom update URL
        /// </summary>
        public string CustomUpdateUrl
        {
            get => _customUpdateUrl;
            set => SetProperty(ref _customUpdateUrl, value);
        }

        /// <summary>
        /// Gets or sets whether to use a custom update URL
        /// </summary>
        public bool UseCustomUpdateUrl
        {
            get => _useCustomUpdateUrl;
            set => SetProperty(ref _useCustomUpdateUrl, value);
        }

        /// <summary>
        /// Gets or sets whether to update dependencies
        /// </summary>
        public bool UpdateDependencies
        {
            get => _updateDependencies;
            set => SetProperty(ref _updateDependencies, value);
        }

        /// <summary>
        /// Gets or sets whether to backup before update
        /// </summary>
        public bool BackupBeforeUpdate
        {
            get => _backupBeforeUpdate;
            set => SetProperty(ref _backupBeforeUpdate, value);
        }

        /// <summary>
        /// Gets or sets whether to restart after update
        /// </summary>
        public bool RestartAfterUpdate
        {
            get => _restartAfterUpdate;
            set => SetProperty(ref _restartAfterUpdate, value);
        }

        /// <summary>
        /// Gets or sets whether to show update notification
        /// </summary>
        public bool ShowUpdateNotification
        {
            get => _showUpdateNotification;
            set => SetProperty(ref _showUpdateNotification, value);
        }

        /// <summary>
        /// Gets or sets whether to download in background
        /// </summary>
        public bool DownloadInBackground
        {
            get => _downloadInBackground;
            set => SetProperty(ref _downloadInBackground, value);
        }

        /// <summary>
        /// Gets or sets the download location
        /// </summary>
        public string DownloadLocation
        {
            get => _downloadLocation;
            set => SetProperty(ref _downloadLocation, value);
        }

        /// <summary>
        /// Gets or sets whether to use the updater
        /// </summary>
        public bool UseUpdater
        {
            get => _useUpdater;
            set => SetProperty(ref _useUpdater, value);
        }

        /// <summary>
        /// Gets or sets the updater path
        /// </summary>
        public string UpdaterPath
        {
            get => _updaterPath;
            set => SetProperty(ref _updaterPath, value);
        }

        /// <summary>
        /// Gets or sets the updater arguments
        /// </summary>
        public string UpdaterArguments
        {
            get => _updaterArguments;
            set => SetProperty(ref _updaterArguments, value);
        }

        /// <summary>
        /// Gets or sets whether to run the updater as admin
        /// </summary>
        public bool RunUpdaterAsAdmin
        {
            get => _runUpdaterAsAdmin;
            set => SetProperty(ref _runUpdaterAsAdmin, value);
        }

        /// <summary>
        /// Gets or sets whether to validate the signature
        /// </summary>
        public bool ValidateSignature
        {
            get => _validateSignature;
            set => SetProperty(ref _validateSignature, value);
        }

        /// <summary>
        /// Gets or sets the signature key
        /// </summary>
        public string SignatureKey
        {
            get => _signatureKey;
            set => SetProperty(ref _signatureKey, value);
        }

        /// <summary>
        /// Gets or sets whether to use installer for update
        /// </summary>
        public bool UseInstallerForUpdate
        {
            get => _useInstallerForUpdate;
            set => SetProperty(ref _useInstallerForUpdate, value);
        }

        /// <summary>
        /// Gets or sets the installer path
        /// </summary>
        public string InstallerPath
        {
            get => _installerPath;
            set => SetProperty(ref _installerPath, value);
        }

        /// <summary>
        /// Gets or sets the installer arguments
        /// </summary>
        public string InstallerArguments
        {
            get => _installerArguments;
            set => SetProperty(ref _installerArguments, value);
        }

        /// <summary>
        /// Gets or sets whether to run the installer as admin
        /// </summary>
        public bool RunInstallerAsAdmin
        {
            get => _runInstallerAsAdmin;
            set => SetProperty(ref _runInstallerAsAdmin, value);
        }

        /// <summary>
        /// Gets or sets the connection timeout in seconds
        /// </summary>
        public int ConnectionTimeout
        {
            get => _connectionTimeout;
            set => SetProperty(ref _connectionTimeout, value);
        }

        /// <summary>
        /// Gets or sets the download timeout in seconds
        /// </summary>
        public int DownloadTimeout
        {
            get => _downloadTimeout;
            set => SetProperty(ref _downloadTimeout, value);
        }

        /// <summary>
        /// Gets or sets the install timeout in seconds
        /// </summary>
        public int InstallTimeout
        {
            get => _installTimeout;
            set => SetProperty(ref _installTimeout, value);
        }

        /// <summary>
        /// Gets or sets whether to log update activity
        /// </summary>
        public bool LogUpdateActivity
        {
            get => _logUpdateActivity;
            set => SetProperty(ref _logUpdateActivity, value);
        }

        /// <summary>
        /// Gets or sets the update log path
        /// </summary>
        public string UpdateLogPath
        {
            get => _updateLogPath;
            set => SetProperty(ref _updateLogPath, value);
        }

        /// <summary>
        /// Gets or sets whether to check for RouterOS updates
        /// </summary>
        public bool CheckRouterOsUpdates
        {
            get => _checkRouterOsUpdates;
            set => SetProperty(ref _checkRouterOsUpdates, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on RouterOS updates
        /// </summary>
        public bool NotifyOnRouterOsUpdates
        {
            get => _notifyOnRouterOsUpdates;
            set => SetProperty(ref _notifyOnRouterOsUpdates, value);
        }

        /// <summary>
        /// Gets or sets whether to auto update RouterOS
        /// </summary>
        public bool AutoUpdateRouterOs
        {
            get => _autoUpdateRouterOs;
            set => SetProperty(ref _autoUpdateRouterOs, value);
        }

        /// <summary>
        /// Gets or sets whether to check for extension updates
        /// </summary>
        public bool CheckForExtensionUpdates
        {
            get => _checkForExtensionUpdates;
            set => SetProperty(ref _checkForExtensionUpdates, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on extension updates
        /// </summary>
        public bool NotifyOnExtensionUpdates
        {
            get => _notifyOnExtensionUpdates;
            set => SetProperty(ref _notifyOnExtensionUpdates, value);
        }

        /// <summary>
        /// Gets or sets whether to auto update extensions
        /// </summary>
        public bool AutoUpdateExtensions
        {
            get => _autoUpdateExtensions;
            set => SetProperty(ref _autoUpdateExtensions, value);
        }

        /// <summary>
        /// Gets or sets whether to skip versions
        /// </summary>
        public bool SkipVersions
        {
            get => _skipVersions;
            set => SetProperty(ref _skipVersions, value);
        }

        /// <summary>
        /// Gets or sets the version to skip
        /// </summary>
        public string SkipVersion
        {
            get => _skipVersion;
            set => SetProperty(ref _skipVersion, value);
        }

        /// <summary>
        /// Gets or sets the minimum version to install
        /// </summary>
        public string MinVersionToInstall
        {
            get => _minVersionToInstall;
            set => SetProperty(ref _minVersionToInstall, value);
        }

        /// <summary>
        /// Gets or sets whether to enforce minimum version
        /// </summary>
        public bool EnforceMinVersion
        {
            get => _enforceMinVersion;
            set => SetProperty(ref _enforceMinVersion, value);
        }

        /// <summary>
        /// Gets or sets whether to enforce maximum version
        /// </summary>
        public bool EnforceMaxVersion
        {
            get => _enforceMaxVersion;
            set => SetProperty(ref _enforceMaxVersion, value);
        }

        /// <summary>
        /// Gets or sets the maximum version to install
        /// </summary>
        public string MaxVersionToInstall
        {
            get => _maxVersionToInstall;
            set => SetProperty(ref _maxVersionToInstall, value);
        }

        /// <summary>
        /// Gets or sets whether to force update
        /// </summary>
        public bool ForceUpdate
        {
            get => _forceUpdate;
            set => SetProperty(ref _forceUpdate, value);
        }

        /// <summary>
        /// Gets or sets the custom script
        /// </summary>
        public string CustomScript
        {
            get => _customScript;
            set => SetProperty(ref _customScript, value);
        }

        /// <summary>
        /// Gets or sets whether to execute before update
        /// </summary>
        public bool ExecuteBeforeUpdate
        {
            get => _executeBeforeUpdate;
            set => SetProperty(ref _executeBeforeUpdate, value);
        }

        /// <summary>
        /// Gets or sets whether to execute after update
        /// </summary>
        public bool ExecuteAfterUpdate
        {
            get => _executeAfterUpdate;
            set => SetProperty(ref _executeAfterUpdate, value);
        }

        /// <summary>
        /// Gets or sets the script timeout in seconds
        /// </summary>
        public int ScriptTimeout
        {
            get => _scriptTimeout;
            set => SetProperty(ref _scriptTimeout, value);
        }

        /// <summary>
        /// Gets or sets whether to abort on script error
        /// </summary>
        public bool AbortOnScriptError
        {
            get => _abortOnScriptError;
            set => SetProperty(ref _abortOnScriptError, value);
        }

        /// <summary>
        /// Gets or sets the email recipients
        /// </summary>
        public string EmailRecipients
        {
            get => _emailRecipients;
            set => SetProperty(ref _emailRecipients, value);
        }

        /// <summary>
        /// Gets or sets whether to notify by email
        /// </summary>
        public bool NotifyByEmail
        {
            get => _notifyByEmail;
            set => SetProperty(ref _notifyByEmail, value);
        }

        /// <summary>
        /// Gets or sets whether to check hash before install
        /// </summary>
        public bool CheckHashBeforeInstall
        {
            get => _checkHashBeforeInstall;
            set => SetProperty(ref _checkHashBeforeInstall, value);
        }

        /// <summary>
        /// Gets or sets the expected hash
        /// </summary>
        public string ExpectedHash
        {
            get => _expectedHash;
            set => SetProperty(ref _expectedHash, value);
        }

        /// <summary>
        /// Gets or sets the hash algorithm
        /// </summary>
        public string HashAlgorithm
        {
            get => _hashAlgorithm;
            set => SetProperty(ref _hashAlgorithm, value);
        }
    }
}