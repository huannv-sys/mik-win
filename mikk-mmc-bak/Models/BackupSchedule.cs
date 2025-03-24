using System;
using System.Collections.Generic;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents the backup schedule configuration
    /// </summary>
    public class BackupSchedule : ModelBase
    {
        private bool _enabled;
        private string _frequency = "Daily"; // Daily, Weekly, Monthly
        private List<DayOfWeek> _daysOfWeek = new List<DayOfWeek> { DayOfWeek.Sunday };
        private int _dayOfMonth = 1;
        private TimeSpan _startTime = new TimeSpan(2, 0, 0); // 2:00 AM
        private List<string> _deviceIds = new List<string>();
        private string _backupLocation;
        private bool _keepOldBackups = true;
        private int _maxBackupCount = 10;
        private bool _compressBackups = true;
        private bool _sendNotification = true;
        private DateTime _lastBackupTime = DateTime.MinValue;
        private DateTime _nextBackupTime;
        private bool _backupAllDevices = true;
        private bool _includeRouterConfig = true;
        private bool _includeFirewallRules = true;
        private bool _includeInterfaces = true;
        private bool _includeDhcpLeases;
        private bool _includeAddressList;
        private bool _includeSystemLogs;
        private int _retryOnFailureCount = 3;
        private int _retryOnFailureDelay = 300; // seconds
        private string _failureNotificationType = "Email";
        private string _successNotificationType = "None";
        private List<string> _notificationRecipients = new List<string>();
        private string _prefix = "backup_";
        private string _suffix = "";
        private bool _appendDate = true;
        private string _dateFormat = "yyyy-MM-dd";
        private bool _skipIfOffline = true;
        private string _backupFileFormat = "Binary"; // Binary, Export, Text
        private bool _encryptBackups;
        private string _encryptionPassword;
        private bool _uploadToCloud;
        private string _cloudProvider; // S3, Azure, Google, FTP, SFTP, etc.
        private string _cloudLocation;
        private string _cloudUsername;
        private string _cloudPassword;
        private string _cloudRegion;
        private bool _testConnectionBeforeBackup = true;
        private bool _executeBeforeScript;
        private string _beforeScriptPath;
        private bool _executeAfterScript;
        private string _afterScriptPath;
        private int _executeBeforeScriptTimeout = 60; // seconds
        private int _executeAfterScriptTimeout = 60; // seconds
        private int _backupTimeout = 300; // seconds
        private bool _continueOnError = true;

        /// <summary>
        /// Gets or sets whether the backup schedule is enabled
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }

        /// <summary>
        /// Gets or sets the backup frequency
        /// </summary>
        public string Frequency
        {
            get => _frequency;
            set => SetProperty(ref _frequency, value);
        }

        /// <summary>
        /// Gets or sets the days of the week to perform backups
        /// </summary>
        public List<DayOfWeek> DaysOfWeek
        {
            get => _daysOfWeek;
            set => SetProperty(ref _daysOfWeek, value);
        }

        /// <summary>
        /// Gets or sets the day of the month to perform backups
        /// </summary>
        public int DayOfMonth
        {
            get => _dayOfMonth;
            set => SetProperty(ref _dayOfMonth, value);
        }

        /// <summary>
        /// Gets or sets the time to start backups
        /// </summary>
        public TimeSpan StartTime
        {
            get => _startTime;
            set => SetProperty(ref _startTime, value);
        }

        /// <summary>
        /// Gets or sets the device IDs to backup
        /// </summary>
        public List<string> DeviceIds
        {
            get => _deviceIds;
            set => SetProperty(ref _deviceIds, value);
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
        /// Gets or sets whether to keep old backups
        /// </summary>
        public bool KeepOldBackups
        {
            get => _keepOldBackups;
            set => SetProperty(ref _keepOldBackups, value);
        }

        /// <summary>
        /// Gets or sets the maximum number of backups to keep
        /// </summary>
        public int MaxBackupCount
        {
            get => _maxBackupCount;
            set => SetProperty(ref _maxBackupCount, value);
        }

        /// <summary>
        /// Gets or sets whether to compress backups
        /// </summary>
        public bool CompressBackups
        {
            get => _compressBackups;
            set => SetProperty(ref _compressBackups, value);
        }

        /// <summary>
        /// Gets or sets whether to send a notification
        /// </summary>
        public bool SendNotification
        {
            get => _sendNotification;
            set => SetProperty(ref _sendNotification, value);
        }

        /// <summary>
        /// Gets or sets the last backup time
        /// </summary>
        public DateTime LastBackupTime
        {
            get => _lastBackupTime;
            set => SetProperty(ref _lastBackupTime, value);
        }

        /// <summary>
        /// Gets or sets the next backup time
        /// </summary>
        public DateTime NextBackupTime
        {
            get => _nextBackupTime;
            set => SetProperty(ref _nextBackupTime, value);
        }

        /// <summary>
        /// Gets or sets whether to backup all devices
        /// </summary>
        public bool BackupAllDevices
        {
            get => _backupAllDevices;
            set => SetProperty(ref _backupAllDevices, value);
        }

        /// <summary>
        /// Gets or sets whether to include router configuration
        /// </summary>
        public bool IncludeRouterConfig
        {
            get => _includeRouterConfig;
            set => SetProperty(ref _includeRouterConfig, value);
        }

        /// <summary>
        /// Gets or sets whether to include firewall rules
        /// </summary>
        public bool IncludeFirewallRules
        {
            get => _includeFirewallRules;
            set => SetProperty(ref _includeFirewallRules, value);
        }

        /// <summary>
        /// Gets or sets whether to include interfaces
        /// </summary>
        public bool IncludeInterfaces
        {
            get => _includeInterfaces;
            set => SetProperty(ref _includeInterfaces, value);
        }

        /// <summary>
        /// Gets or sets whether to include DHCP leases
        /// </summary>
        public bool IncludeDhcpLeases
        {
            get => _includeDhcpLeases;
            set => SetProperty(ref _includeDhcpLeases, value);
        }

        /// <summary>
        /// Gets or sets whether to include address list
        /// </summary>
        public bool IncludeAddressList
        {
            get => _includeAddressList;
            set => SetProperty(ref _includeAddressList, value);
        }

        /// <summary>
        /// Gets or sets whether to include system logs
        /// </summary>
        public bool IncludeSystemLogs
        {
            get => _includeSystemLogs;
            set => SetProperty(ref _includeSystemLogs, value);
        }

        /// <summary>
        /// Gets or sets the number of retry attempts on failure
        /// </summary>
        public int RetryOnFailureCount
        {
            get => _retryOnFailureCount;
            set => SetProperty(ref _retryOnFailureCount, value);
        }

        /// <summary>
        /// Gets or sets the delay between retry attempts in seconds
        /// </summary>
        public int RetryOnFailureDelay
        {
            get => _retryOnFailureDelay;
            set => SetProperty(ref _retryOnFailureDelay, value);
        }

        /// <summary>
        /// Gets or sets the failure notification type
        /// </summary>
        public string FailureNotificationType
        {
            get => _failureNotificationType;
            set => SetProperty(ref _failureNotificationType, value);
        }

        /// <summary>
        /// Gets or sets the success notification type
        /// </summary>
        public string SuccessNotificationType
        {
            get => _successNotificationType;
            set => SetProperty(ref _successNotificationType, value);
        }

        /// <summary>
        /// Gets or sets the notification recipients
        /// </summary>
        public List<string> NotificationRecipients
        {
            get => _notificationRecipients;
            set => SetProperty(ref _notificationRecipients, value);
        }

        /// <summary>
        /// Gets or sets the filename prefix
        /// </summary>
        public string Prefix
        {
            get => _prefix;
            set => SetProperty(ref _prefix, value);
        }

        /// <summary>
        /// Gets or sets the filename suffix
        /// </summary>
        public string Suffix
        {
            get => _suffix;
            set => SetProperty(ref _suffix, value);
        }

        /// <summary>
        /// Gets or sets whether to append the date to the filename
        /// </summary>
        public bool AppendDate
        {
            get => _appendDate;
            set => SetProperty(ref _appendDate, value);
        }

        /// <summary>
        /// Gets or sets the date format for the filename
        /// </summary>
        public string DateFormat
        {
            get => _dateFormat;
            set => SetProperty(ref _dateFormat, value);
        }

        /// <summary>
        /// Gets or sets whether to skip offline devices
        /// </summary>
        public bool SkipIfOffline
        {
            get => _skipIfOffline;
            set => SetProperty(ref _skipIfOffline, value);
        }

        /// <summary>
        /// Gets or sets the backup file format
        /// </summary>
        public string BackupFileFormat
        {
            get => _backupFileFormat;
            set => SetProperty(ref _backupFileFormat, value);
        }

        /// <summary>
        /// Gets or sets whether to encrypt backups
        /// </summary>
        public bool EncryptBackups
        {
            get => _encryptBackups;
            set => SetProperty(ref _encryptBackups, value);
        }

        /// <summary>
        /// Gets or sets the encryption password
        /// </summary>
        public string EncryptionPassword
        {
            get => _encryptionPassword;
            set => SetProperty(ref _encryptionPassword, value);
        }

        /// <summary>
        /// Gets or sets whether to upload backups to the cloud
        /// </summary>
        public bool UploadToCloud
        {
            get => _uploadToCloud;
            set => SetProperty(ref _uploadToCloud, value);
        }

        /// <summary>
        /// Gets or sets the cloud provider
        /// </summary>
        public string CloudProvider
        {
            get => _cloudProvider;
            set => SetProperty(ref _cloudProvider, value);
        }

        /// <summary>
        /// Gets or sets the cloud location
        /// </summary>
        public string CloudLocation
        {
            get => _cloudLocation;
            set => SetProperty(ref _cloudLocation, value);
        }

        /// <summary>
        /// Gets or sets the cloud username
        /// </summary>
        public string CloudUsername
        {
            get => _cloudUsername;
            set => SetProperty(ref _cloudUsername, value);
        }

        /// <summary>
        /// Gets or sets the cloud password
        /// </summary>
        public string CloudPassword
        {
            get => _cloudPassword;
            set => SetProperty(ref _cloudPassword, value);
        }

        /// <summary>
        /// Gets or sets the cloud region
        /// </summary>
        public string CloudRegion
        {
            get => _cloudRegion;
            set => SetProperty(ref _cloudRegion, value);
        }

        /// <summary>
        /// Gets or sets whether to test the connection before backup
        /// </summary>
        public bool TestConnectionBeforeBackup
        {
            get => _testConnectionBeforeBackup;
            set => SetProperty(ref _testConnectionBeforeBackup, value);
        }

        /// <summary>
        /// Gets or sets whether to execute a script before backup
        /// </summary>
        public bool ExecuteBeforeScript
        {
            get => _executeBeforeScript;
            set => SetProperty(ref _executeBeforeScript, value);
        }

        /// <summary>
        /// Gets or sets the path to the script to execute before backup
        /// </summary>
        public string BeforeScriptPath
        {
            get => _beforeScriptPath;
            set => SetProperty(ref _beforeScriptPath, value);
        }

        /// <summary>
        /// Gets or sets whether to execute a script after backup
        /// </summary>
        public bool ExecuteAfterScript
        {
            get => _executeAfterScript;
            set => SetProperty(ref _executeAfterScript, value);
        }

        /// <summary>
        /// Gets or sets the path to the script to execute after backup
        /// </summary>
        public string AfterScriptPath
        {
            get => _afterScriptPath;
            set => SetProperty(ref _afterScriptPath, value);
        }

        /// <summary>
        /// Gets or sets the timeout for the before script in seconds
        /// </summary>
        public int ExecuteBeforeScriptTimeout
        {
            get => _executeBeforeScriptTimeout;
            set => SetProperty(ref _executeBeforeScriptTimeout, value);
        }

        /// <summary>
        /// Gets or sets the timeout for the after script in seconds
        /// </summary>
        public int ExecuteAfterScriptTimeout
        {
            get => _executeAfterScriptTimeout;
            set => SetProperty(ref _executeAfterScriptTimeout, value);
        }

        /// <summary>
        /// Gets or sets the backup timeout in seconds
        /// </summary>
        public int BackupTimeout
        {
            get => _backupTimeout;
            set => SetProperty(ref _backupTimeout, value);
        }

        /// <summary>
        /// Gets or sets whether to continue on error
        /// </summary>
        public bool ContinueOnError
        {
            get => _continueOnError;
            set => SetProperty(ref _continueOnError, value);
        }
    }
}