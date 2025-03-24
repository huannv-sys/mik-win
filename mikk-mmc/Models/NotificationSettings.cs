using System.Collections.Generic;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents the notification settings
    /// </summary>
    public class NotificationSettings : ModelBase
    {
        private bool _enableEmailNotifications;
        private bool _enableSmsNotifications;
        private bool _enablePushNotifications;
        private bool _enableDesktopNotifications = true;
        private bool _enableSoundNotifications = true;
        private bool _enableSlackNotifications;
        private bool _enableTeamsNotifications;
        private bool _enableDiscordNotifications;
        private bool _enableTelegramNotifications;
        private bool _enableWebhookNotifications;
        private bool _notifyOnDeviceConnection = true;
        private bool _notifyOnDeviceDisconnection = true;
        private bool _notifyOnDeviceRestart = true;
        private bool _notifyOnFirmwareUpdate = true;
        private bool _notifyOnBackupComplete = true;
        private bool _notifyOnBackupFailure = true;
        private bool _notifyOnCpuUsageThreshold;
        private bool _notifyOnMemoryUsageThreshold;
        private bool _notifyOnDiskUsageThreshold;
        private bool _notifyOnBandwidthThreshold;
        private bool _notifyOnNewDeviceDiscovery;
        private bool _notifyOnDeviceConfigurationChanged;
        private bool _notifyOnNewLogEntry;
        private bool _notifyOnFirewallRuleChange;
        private bool _notifyOnDnsResolutionFailure;
        private bool _notifyOnInterfaceStateChange = true;
        private bool _notifyOnIpAddressChange;
        private bool _notifyOnWirelessClientConnect;
        private bool _notifyOnWirelessClientDisconnect;
        private bool _notifyOnDhcpLeaseChange;
        private bool _notifyOnSystemError = true;
        private bool _notifyOnVpnConnection;
        private bool _notifyOnVpnDisconnection;
        private bool _notifyOnUserLogin;
        private bool _notifyOnUserLoginFailure;
        private bool _notifyOnUserLogout;
        private bool _notifyOnUserAccountChange;
        private bool _notifyOnScheduledTaskFailure;
        private bool _notifyOnScheduledTaskSuccess;
        private int _cpuUsageThreshold = 80;
        private int _memoryUsageThreshold = 80;
        private int _diskUsageThreshold = 80;
        private int _bandwidthThreshold = 90;
        private string _emailRecipients;
        private string _emailSender;
        private string _emailSenderName = "MikroTik Monitor";
        private string _emailServer;
        private int _emailPort = 587;
        private string _emailUsername;
        private string _emailPassword;
        private bool _emailUseSsl = true;
        private string _emailSubjectPrefix = "[MikroTik Monitor]";
        private string _smsRecipients;
        private string _smsProvider;
        private string _smsApiKey;
        private string _smsApiSecret;
        private string _smsFromNumber;
        private string _slackWebhookUrl;
        private string _slackChannel;
        private string _slackUsername = "MikroTik Monitor";
        private string _slackIconUrl;
        private string _teamsWebhookUrl;
        private string _discordWebhookUrl;
        private string _telegramBotToken;
        private string _telegramChatId;
        private string _webhookUrl;
        private string _webhookMethod = "POST";
        private string _webhookHeaders;
        private string _webhookBody;
        private string _webhookAuthType;
        private string _webhookAuthUsername;
        private string _webhookAuthPassword;
        private string _webhookAuthToken;
        private int _throttleInterval = 60;
        private int _maxNotificationsPerHour = 10;
        private bool _groupSimilarNotifications = true;
        private bool _includeDeviceDetails = true;
        private bool _includeTimestamp = true;
        private bool _scheduleQuietHours;
        private string _quietHoursStart = "22:00";
        private string _quietHoursEnd = "07:00";
        private List<string> _quietDays = new List<string>();
        private bool _overrideQuietHoursForCriticalAlerts = true;
        private string _logLevelForEmailNotifications = "Error";
        private string _logLevelForSmsNotifications = "Critical";
        private string _logLevelForPushNotifications = "Warning";
        private string _logLevelForDesktopNotifications = "Information";
        private List<string> _excludedDevices = new List<string>();
        private bool _testNotificationOnSave;
        private string _testNotificationType = "Email";
        private string _pushNotificationProvider;
        private string _pushNotificationApiKey;
        private string _pushNotificationApiSecret;
        private string _pushNotificationTopic;
        private List<string> _pushNotificationTokens = new List<string>();
        private string _notificationSound = "Default";
        private string _criticalNotificationSound = "Alarm";
        private string _notificationType = "Toast";
        private bool _useHtml = true;
        private bool _includeImages = true;
        private string _notificationTemplate;
        private string _emailTemplate;
        private string _smsTemplate;
        private string _pushTemplate;
        private string _slackTemplate;
        private string _teamsTemplate;
        private string _discordTemplate;
        private string _telegramTemplate;
        private string _webhookTemplate;
        private bool _testNotification;
        private string _customScript;
        private bool _executeCustomScript;
        private string _afterNotificationAction;
        private bool _retryFailedNotifications = true;
        private int _maxRetries = 3;
        private int _retryDelay = 60;
        private bool _logNotifications = true;
        private string _logNotificationsPath;
        private bool _enableNotificationHistory = true;
        private int _maxNotificationHistoryCount = 100;
        private bool _enableNotificationAcknowledgement;
        private bool _requireAcknowledgementForCritical = true;
        private string _acknowledgeUrl;
        private string _customNotificationProvider;
        private string _customNotificationConfig;
        private bool _useCompression;
        private bool _useBatching;
        private int _maxBatchSize = 10;
        private int _batchInterval = 300;
        private bool _useEncryption;
        private string _encryptionKey;
        private bool _useAuthentication;
        private string _authenticationKey;
        private bool _validateSslCertificate = true;
        private bool _useProxy;
        private string _proxyAddress;
        private int _proxyPort;
        private string _proxyUsername;
        private string _proxyPassword;
        private bool _useNetworkCredentials;
        private string _networkCredentialsUsername;
        private string _networkCredentialsPassword;
        private string _networkCredentialsDomain;
        private bool _useClientCertificate;
        private string _clientCertificatePath;
        private string _clientCertificatePassword;
        private int _connectionTimeout = 30;
        private bool _followRedirects = true;
        private int _maxRedirects = 5;
        private bool _allowAutoRedirect = true;

        /// <summary>
        /// Gets or sets whether to enable email notifications
        /// </summary>
        public bool EnableEmailNotifications
        {
            get => _enableEmailNotifications;
            set => SetProperty(ref _enableEmailNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable SMS notifications
        /// </summary>
        public bool EnableSmsNotifications
        {
            get => _enableSmsNotifications;
            set => SetProperty(ref _enableSmsNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable push notifications
        /// </summary>
        public bool EnablePushNotifications
        {
            get => _enablePushNotifications;
            set => SetProperty(ref _enablePushNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable desktop notifications
        /// </summary>
        public bool EnableDesktopNotifications
        {
            get => _enableDesktopNotifications;
            set => SetProperty(ref _enableDesktopNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable sound notifications
        /// </summary>
        public bool EnableSoundNotifications
        {
            get => _enableSoundNotifications;
            set => SetProperty(ref _enableSoundNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable Slack notifications
        /// </summary>
        public bool EnableSlackNotifications
        {
            get => _enableSlackNotifications;
            set => SetProperty(ref _enableSlackNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable Microsoft Teams notifications
        /// </summary>
        public bool EnableTeamsNotifications
        {
            get => _enableTeamsNotifications;
            set => SetProperty(ref _enableTeamsNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable Discord notifications
        /// </summary>
        public bool EnableDiscordNotifications
        {
            get => _enableDiscordNotifications;
            set => SetProperty(ref _enableDiscordNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable Telegram notifications
        /// </summary>
        public bool EnableTelegramNotifications
        {
            get => _enableTelegramNotifications;
            set => SetProperty(ref _enableTelegramNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to enable webhook notifications
        /// </summary>
        public bool EnableWebhookNotifications
        {
            get => _enableWebhookNotifications;
            set => SetProperty(ref _enableWebhookNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on device connection
        /// </summary>
        public bool NotifyOnDeviceConnection
        {
            get => _notifyOnDeviceConnection;
            set => SetProperty(ref _notifyOnDeviceConnection, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on device disconnection
        /// </summary>
        public bool NotifyOnDeviceDisconnection
        {
            get => _notifyOnDeviceDisconnection;
            set => SetProperty(ref _notifyOnDeviceDisconnection, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on device restart
        /// </summary>
        public bool NotifyOnDeviceRestart
        {
            get => _notifyOnDeviceRestart;
            set => SetProperty(ref _notifyOnDeviceRestart, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on firmware update
        /// </summary>
        public bool NotifyOnFirmwareUpdate
        {
            get => _notifyOnFirmwareUpdate;
            set => SetProperty(ref _notifyOnFirmwareUpdate, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on backup complete
        /// </summary>
        public bool NotifyOnBackupComplete
        {
            get => _notifyOnBackupComplete;
            set => SetProperty(ref _notifyOnBackupComplete, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on backup failure
        /// </summary>
        public bool NotifyOnBackupFailure
        {
            get => _notifyOnBackupFailure;
            set => SetProperty(ref _notifyOnBackupFailure, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on CPU usage threshold exceeded
        /// </summary>
        public bool NotifyOnCpuUsageThreshold
        {
            get => _notifyOnCpuUsageThreshold;
            set => SetProperty(ref _notifyOnCpuUsageThreshold, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on memory usage threshold exceeded
        /// </summary>
        public bool NotifyOnMemoryUsageThreshold
        {
            get => _notifyOnMemoryUsageThreshold;
            set => SetProperty(ref _notifyOnMemoryUsageThreshold, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on disk usage threshold exceeded
        /// </summary>
        public bool NotifyOnDiskUsageThreshold
        {
            get => _notifyOnDiskUsageThreshold;
            set => SetProperty(ref _notifyOnDiskUsageThreshold, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on bandwidth threshold exceeded
        /// </summary>
        public bool NotifyOnBandwidthThreshold
        {
            get => _notifyOnBandwidthThreshold;
            set => SetProperty(ref _notifyOnBandwidthThreshold, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on new device discovery
        /// </summary>
        public bool NotifyOnNewDeviceDiscovery
        {
            get => _notifyOnNewDeviceDiscovery;
            set => SetProperty(ref _notifyOnNewDeviceDiscovery, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on device configuration changed
        /// </summary>
        public bool NotifyOnDeviceConfigurationChanged
        {
            get => _notifyOnDeviceConfigurationChanged;
            set => SetProperty(ref _notifyOnDeviceConfigurationChanged, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on new log entry
        /// </summary>
        public bool NotifyOnNewLogEntry
        {
            get => _notifyOnNewLogEntry;
            set => SetProperty(ref _notifyOnNewLogEntry, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on firewall rule change
        /// </summary>
        public bool NotifyOnFirewallRuleChange
        {
            get => _notifyOnFirewallRuleChange;
            set => SetProperty(ref _notifyOnFirewallRuleChange, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on DNS resolution failure
        /// </summary>
        public bool NotifyOnDnsResolutionFailure
        {
            get => _notifyOnDnsResolutionFailure;
            set => SetProperty(ref _notifyOnDnsResolutionFailure, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on interface state change
        /// </summary>
        public bool NotifyOnInterfaceStateChange
        {
            get => _notifyOnInterfaceStateChange;
            set => SetProperty(ref _notifyOnInterfaceStateChange, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on IP address change
        /// </summary>
        public bool NotifyOnIpAddressChange
        {
            get => _notifyOnIpAddressChange;
            set => SetProperty(ref _notifyOnIpAddressChange, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on wireless client connect
        /// </summary>
        public bool NotifyOnWirelessClientConnect
        {
            get => _notifyOnWirelessClientConnect;
            set => SetProperty(ref _notifyOnWirelessClientConnect, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on wireless client disconnect
        /// </summary>
        public bool NotifyOnWirelessClientDisconnect
        {
            get => _notifyOnWirelessClientDisconnect;
            set => SetProperty(ref _notifyOnWirelessClientDisconnect, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on DHCP lease change
        /// </summary>
        public bool NotifyOnDhcpLeaseChange
        {
            get => _notifyOnDhcpLeaseChange;
            set => SetProperty(ref _notifyOnDhcpLeaseChange, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on system error
        /// </summary>
        public bool NotifyOnSystemError
        {
            get => _notifyOnSystemError;
            set => SetProperty(ref _notifyOnSystemError, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on VPN connection
        /// </summary>
        public bool NotifyOnVpnConnection
        {
            get => _notifyOnVpnConnection;
            set => SetProperty(ref _notifyOnVpnConnection, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on VPN disconnection
        /// </summary>
        public bool NotifyOnVpnDisconnection
        {
            get => _notifyOnVpnDisconnection;
            set => SetProperty(ref _notifyOnVpnDisconnection, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on user login
        /// </summary>
        public bool NotifyOnUserLogin
        {
            get => _notifyOnUserLogin;
            set => SetProperty(ref _notifyOnUserLogin, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on user login failure
        /// </summary>
        public bool NotifyOnUserLoginFailure
        {
            get => _notifyOnUserLoginFailure;
            set => SetProperty(ref _notifyOnUserLoginFailure, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on user logout
        /// </summary>
        public bool NotifyOnUserLogout
        {
            get => _notifyOnUserLogout;
            set => SetProperty(ref _notifyOnUserLogout, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on user account change
        /// </summary>
        public bool NotifyOnUserAccountChange
        {
            get => _notifyOnUserAccountChange;
            set => SetProperty(ref _notifyOnUserAccountChange, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on scheduled task failure
        /// </summary>
        public bool NotifyOnScheduledTaskFailure
        {
            get => _notifyOnScheduledTaskFailure;
            set => SetProperty(ref _notifyOnScheduledTaskFailure, value);
        }

        /// <summary>
        /// Gets or sets whether to notify on scheduled task success
        /// </summary>
        public bool NotifyOnScheduledTaskSuccess
        {
            get => _notifyOnScheduledTaskSuccess;
            set => SetProperty(ref _notifyOnScheduledTaskSuccess, value);
        }

        /// <summary>
        /// Gets or sets the CPU usage threshold
        /// </summary>
        public int CpuUsageThreshold
        {
            get => _cpuUsageThreshold;
            set => SetProperty(ref _cpuUsageThreshold, value);
        }

        /// <summary>
        /// Gets or sets the memory usage threshold
        /// </summary>
        public int MemoryUsageThreshold
        {
            get => _memoryUsageThreshold;
            set => SetProperty(ref _memoryUsageThreshold, value);
        }

        /// <summary>
        /// Gets or sets the disk usage threshold
        /// </summary>
        public int DiskUsageThreshold
        {
            get => _diskUsageThreshold;
            set => SetProperty(ref _diskUsageThreshold, value);
        }

        /// <summary>
        /// Gets or sets the bandwidth threshold
        /// </summary>
        public int BandwidthThreshold
        {
            get => _bandwidthThreshold;
            set => SetProperty(ref _bandwidthThreshold, value);
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
        /// Gets or sets the email sender
        /// </summary>
        public string EmailSender
        {
            get => _emailSender;
            set => SetProperty(ref _emailSender, value);
        }

        /// <summary>
        /// Gets or sets the email sender name
        /// </summary>
        public string EmailSenderName
        {
            get => _emailSenderName;
            set => SetProperty(ref _emailSenderName, value);
        }

        /// <summary>
        /// Gets or sets the email server
        /// </summary>
        public string EmailServer
        {
            get => _emailServer;
            set => SetProperty(ref _emailServer, value);
        }

        /// <summary>
        /// Gets or sets the email port
        /// </summary>
        public int EmailPort
        {
            get => _emailPort;
            set => SetProperty(ref _emailPort, value);
        }

        /// <summary>
        /// Gets or sets the email username
        /// </summary>
        public string EmailUsername
        {
            get => _emailUsername;
            set => SetProperty(ref _emailUsername, value);
        }

        /// <summary>
        /// Gets or sets the email password
        /// </summary>
        public string EmailPassword
        {
            get => _emailPassword;
            set => SetProperty(ref _emailPassword, value);
        }

        /// <summary>
        /// Gets or sets whether to use SSL for email
        /// </summary>
        public bool EmailUseSsl
        {
            get => _emailUseSsl;
            set => SetProperty(ref _emailUseSsl, value);
        }

        /// <summary>
        /// Gets or sets the email subject prefix
        /// </summary>
        public string EmailSubjectPrefix
        {
            get => _emailSubjectPrefix;
            set => SetProperty(ref _emailSubjectPrefix, value);
        }

        /// <summary>
        /// Gets or sets the SMS recipients
        /// </summary>
        public string SmsRecipients
        {
            get => _smsRecipients;
            set => SetProperty(ref _smsRecipients, value);
        }

        /// <summary>
        /// Gets or sets the SMS provider
        /// </summary>
        public string SmsProvider
        {
            get => _smsProvider;
            set => SetProperty(ref _smsProvider, value);
        }

        /// <summary>
        /// Gets or sets the SMS API key
        /// </summary>
        public string SmsApiKey
        {
            get => _smsApiKey;
            set => SetProperty(ref _smsApiKey, value);
        }

        /// <summary>
        /// Gets or sets the SMS API secret
        /// </summary>
        public string SmsApiSecret
        {
            get => _smsApiSecret;
            set => SetProperty(ref _smsApiSecret, value);
        }

        /// <summary>
        /// Gets or sets the SMS from number
        /// </summary>
        public string SmsFromNumber
        {
            get => _smsFromNumber;
            set => SetProperty(ref _smsFromNumber, value);
        }

        /// <summary>
        /// Gets or sets the Slack webhook URL
        /// </summary>
        public string SlackWebhookUrl
        {
            get => _slackWebhookUrl;
            set => SetProperty(ref _slackWebhookUrl, value);
        }

        /// <summary>
        /// Gets or sets the Slack channel
        /// </summary>
        public string SlackChannel
        {
            get => _slackChannel;
            set => SetProperty(ref _slackChannel, value);
        }

        /// <summary>
        /// Gets or sets the Slack username
        /// </summary>
        public string SlackUsername
        {
            get => _slackUsername;
            set => SetProperty(ref _slackUsername, value);
        }

        /// <summary>
        /// Gets or sets the Slack icon URL
        /// </summary>
        public string SlackIconUrl
        {
            get => _slackIconUrl;
            set => SetProperty(ref _slackIconUrl, value);
        }

        /// <summary>
        /// Gets or sets the Microsoft Teams webhook URL
        /// </summary>
        public string TeamsWebhookUrl
        {
            get => _teamsWebhookUrl;
            set => SetProperty(ref _teamsWebhookUrl, value);
        }

        /// <summary>
        /// Gets or sets the Discord webhook URL
        /// </summary>
        public string DiscordWebhookUrl
        {
            get => _discordWebhookUrl;
            set => SetProperty(ref _discordWebhookUrl, value);
        }

        /// <summary>
        /// Gets or sets the Telegram bot token
        /// </summary>
        public string TelegramBotToken
        {
            get => _telegramBotToken;
            set => SetProperty(ref _telegramBotToken, value);
        }

        /// <summary>
        /// Gets or sets the Telegram chat ID
        /// </summary>
        public string TelegramChatId
        {
            get => _telegramChatId;
            set => SetProperty(ref _telegramChatId, value);
        }

        /// <summary>
        /// Gets or sets the webhook URL
        /// </summary>
        public string WebhookUrl
        {
            get => _webhookUrl;
            set => SetProperty(ref _webhookUrl, value);
        }

        /// <summary>
        /// Gets or sets the webhook method
        /// </summary>
        public string WebhookMethod
        {
            get => _webhookMethod;
            set => SetProperty(ref _webhookMethod, value);
        }

        /// <summary>
        /// Gets or sets the webhook headers
        /// </summary>
        public string WebhookHeaders
        {
            get => _webhookHeaders;
            set => SetProperty(ref _webhookHeaders, value);
        }

        /// <summary>
        /// Gets or sets the webhook body
        /// </summary>
        public string WebhookBody
        {
            get => _webhookBody;
            set => SetProperty(ref _webhookBody, value);
        }

        /// <summary>
        /// Gets or sets the webhook authentication type
        /// </summary>
        public string WebhookAuthType
        {
            get => _webhookAuthType;
            set => SetProperty(ref _webhookAuthType, value);
        }

        /// <summary>
        /// Gets or sets the webhook authentication username
        /// </summary>
        public string WebhookAuthUsername
        {
            get => _webhookAuthUsername;
            set => SetProperty(ref _webhookAuthUsername, value);
        }

        /// <summary>
        /// Gets or sets the webhook authentication password
        /// </summary>
        public string WebhookAuthPassword
        {
            get => _webhookAuthPassword;
            set => SetProperty(ref _webhookAuthPassword, value);
        }

        /// <summary>
        /// Gets or sets the webhook authentication token
        /// </summary>
        public string WebhookAuthToken
        {
            get => _webhookAuthToken;
            set => SetProperty(ref _webhookAuthToken, value);
        }

        /// <summary>
        /// Gets or sets the throttle interval in seconds
        /// </summary>
        public int ThrottleInterval
        {
            get => _throttleInterval;
            set => SetProperty(ref _throttleInterval, value);
        }

        /// <summary>
        /// Gets or sets the maximum notifications per hour
        /// </summary>
        public int MaxNotificationsPerHour
        {
            get => _maxNotificationsPerHour;
            set => SetProperty(ref _maxNotificationsPerHour, value);
        }

        /// <summary>
        /// Gets or sets whether to group similar notifications
        /// </summary>
        public bool GroupSimilarNotifications
        {
            get => _groupSimilarNotifications;
            set => SetProperty(ref _groupSimilarNotifications, value);
        }

        /// <summary>
        /// Gets or sets whether to include device details
        /// </summary>
        public bool IncludeDeviceDetails
        {
            get => _includeDeviceDetails;
            set => SetProperty(ref _includeDeviceDetails, value);
        }

        /// <summary>
        /// Gets or sets whether to include timestamp
        /// </summary>
        public bool IncludeTimestamp
        {
            get => _includeTimestamp;
            set => SetProperty(ref _includeTimestamp, value);
        }

        /// <summary>
        /// Gets or sets whether to schedule quiet hours
        /// </summary>
        public bool ScheduleQuietHours
        {
            get => _scheduleQuietHours;
            set => SetProperty(ref _scheduleQuietHours, value);
        }

        /// <summary>
        /// Gets or sets the quiet hours start time
        /// </summary>
        public string QuietHoursStart
        {
            get => _quietHoursStart;
            set => SetProperty(ref _quietHoursStart, value);
        }

        /// <summary>
        /// Gets or sets the quiet hours end time
        /// </summary>
        public string QuietHoursEnd
        {
            get => _quietHoursEnd;
            set => SetProperty(ref _quietHoursEnd, value);
        }

        /// <summary>
        /// Gets or sets the quiet days
        /// </summary>
        public List<string> QuietDays
        {
            get => _quietDays;
            set => SetProperty(ref _quietDays, value);
        }

        /// <summary>
        /// Gets or sets whether to override quiet hours for critical alerts
        /// </summary>
        public bool OverrideQuietHoursForCriticalAlerts
        {
            get => _overrideQuietHoursForCriticalAlerts;
            set => SetProperty(ref _overrideQuietHoursForCriticalAlerts, value);
        }

        /// <summary>
        /// Gets or sets the log level for email notifications
        /// </summary>
        public string LogLevelForEmailNotifications
        {
            get => _logLevelForEmailNotifications;
            set => SetProperty(ref _logLevelForEmailNotifications, value);
        }

        /// <summary>
        /// Gets or sets the log level for SMS notifications
        /// </summary>
        public string LogLevelForSmsNotifications
        {
            get => _logLevelForSmsNotifications;
            set => SetProperty(ref _logLevelForSmsNotifications, value);
        }

        /// <summary>
        /// Gets or sets the log level for push notifications
        /// </summary>
        public string LogLevelForPushNotifications
        {
            get => _logLevelForPushNotifications;
            set => SetProperty(ref _logLevelForPushNotifications, value);
        }

        /// <summary>
        /// Gets or sets the log level for desktop notifications
        /// </summary>
        public string LogLevelForDesktopNotifications
        {
            get => _logLevelForDesktopNotifications;
            set => SetProperty(ref _logLevelForDesktopNotifications, value);
        }

        /// <summary>
        /// Gets or sets the excluded devices
        /// </summary>
        public List<string> ExcludedDevices
        {
            get => _excludedDevices;
            set => SetProperty(ref _excludedDevices, value);
        }

        /// <summary>
        /// Gets or sets whether to test notification on save
        /// </summary>
        public bool TestNotificationOnSave
        {
            get => _testNotificationOnSave;
            set => SetProperty(ref _testNotificationOnSave, value);
        }

        /// <summary>
        /// Gets or sets the test notification type
        /// </summary>
        public string TestNotificationType
        {
            get => _testNotificationType;
            set => SetProperty(ref _testNotificationType, value);
        }

        /// <summary>
        /// Gets or sets the push notification provider
        /// </summary>
        public string PushNotificationProvider
        {
            get => _pushNotificationProvider;
            set => SetProperty(ref _pushNotificationProvider, value);
        }

        /// <summary>
        /// Gets or sets the push notification API key
        /// </summary>
        public string PushNotificationApiKey
        {
            get => _pushNotificationApiKey;
            set => SetProperty(ref _pushNotificationApiKey, value);
        }

        /// <summary>
        /// Gets or sets the push notification API secret
        /// </summary>
        public string PushNotificationApiSecret
        {
            get => _pushNotificationApiSecret;
            set => SetProperty(ref _pushNotificationApiSecret, value);
        }

        /// <summary>
        /// Gets or sets the push notification topic
        /// </summary>
        public string PushNotificationTopic
        {
            get => _pushNotificationTopic;
            set => SetProperty(ref _pushNotificationTopic, value);
        }

        /// <summary>
        /// Gets or sets the push notification tokens
        /// </summary>
        public List<string> PushNotificationTokens
        {
            get => _pushNotificationTokens;
            set => SetProperty(ref _pushNotificationTokens, value);
        }

        /// <summary>
        /// Gets or sets the notification sound
        /// </summary>
        public string NotificationSound
        {
            get => _notificationSound;
            set => SetProperty(ref _notificationSound, value);
        }

        /// <summary>
        /// Gets or sets the critical notification sound
        /// </summary>
        public string CriticalNotificationSound
        {
            get => _criticalNotificationSound;
            set => SetProperty(ref _criticalNotificationSound, value);
        }

        /// <summary>
        /// Gets or sets the notification type
        /// </summary>
        public string NotificationType
        {
            get => _notificationType;
            set => SetProperty(ref _notificationType, value);
        }

        /// <summary>
        /// Gets or sets whether to use HTML
        /// </summary>
        public bool UseHtml
        {
            get => _useHtml;
            set => SetProperty(ref _useHtml, value);
        }

        /// <summary>
        /// Gets or sets whether to include images
        /// </summary>
        public bool IncludeImages
        {
            get => _includeImages;
            set => SetProperty(ref _includeImages, value);
        }

        /// <summary>
        /// Gets or sets the notification template
        /// </summary>
        public string NotificationTemplate
        {
            get => _notificationTemplate;
            set => SetProperty(ref _notificationTemplate, value);
        }

        /// <summary>
        /// Gets or sets the email template
        /// </summary>
        public string EmailTemplate
        {
            get => _emailTemplate;
            set => SetProperty(ref _emailTemplate, value);
        }

        /// <summary>
        /// Gets or sets the SMS template
        /// </summary>
        public string SmsTemplate
        {
            get => _smsTemplate;
            set => SetProperty(ref _smsTemplate, value);
        }

        /// <summary>
        /// Gets or sets the push template
        /// </summary>
        public string PushTemplate
        {
            get => _pushTemplate;
            set => SetProperty(ref _pushTemplate, value);
        }

        /// <summary>
        /// Gets or sets the Slack template
        /// </summary>
        public string SlackTemplate
        {
            get => _slackTemplate;
            set => SetProperty(ref _slackTemplate, value);
        }

        /// <summary>
        /// Gets or sets the Microsoft Teams template
        /// </summary>
        public string TeamsTemplate
        {
            get => _teamsTemplate;
            set => SetProperty(ref _teamsTemplate, value);
        }

        /// <summary>
        /// Gets or sets the Discord template
        /// </summary>
        public string DiscordTemplate
        {
            get => _discordTemplate;
            set => SetProperty(ref _discordTemplate, value);
        }

        /// <summary>
        /// Gets or sets the Telegram template
        /// </summary>
        public string TelegramTemplate
        {
            get => _telegramTemplate;
            set => SetProperty(ref _telegramTemplate, value);
        }

        /// <summary>
        /// Gets or sets the webhook template
        /// </summary>
        public string WebhookTemplate
        {
            get => _webhookTemplate;
            set => SetProperty(ref _webhookTemplate, value);
        }

        /// <summary>
        /// Gets or sets whether to test notification
        /// </summary>
        public bool TestNotification
        {
            get => _testNotification;
            set => SetProperty(ref _testNotification, value);
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
        /// Gets or sets whether to execute custom script
        /// </summary>
        public bool ExecuteCustomScript
        {
            get => _executeCustomScript;
            set => SetProperty(ref _executeCustomScript, value);
        }

        /// <summary>
        /// Gets or sets the after notification action
        /// </summary>
        public string AfterNotificationAction
        {
            get => _afterNotificationAction;
            set => SetProperty(ref _afterNotificationAction, value);
        }

        /// <summary>
        /// Gets or sets whether to retry failed notifications
        /// </summary>
        public bool RetryFailedNotifications
        {
            get => _retryFailedNotifications;
            set => SetProperty(ref _retryFailedNotifications, value);
        }

        /// <summary>
        /// Gets or sets the maximum retry count
        /// </summary>
        public int MaxRetries
        {
            get => _maxRetries;
            set => SetProperty(ref _maxRetries, value);
        }

        /// <summary>
        /// Gets or sets the retry delay in seconds
        /// </summary>
        public int RetryDelay
        {
            get => _retryDelay;
            set => SetProperty(ref _retryDelay, value);
        }

        /// <summary>
        /// Gets or sets whether to log notifications
        /// </summary>
        public bool LogNotifications
        {
            get => _logNotifications;
            set => SetProperty(ref _logNotifications, value);
        }

        /// <summary>
        /// Gets or sets the log notifications path
        /// </summary>
        public string LogNotificationsPath
        {
            get => _logNotificationsPath;
            set => SetProperty(ref _logNotificationsPath, value);
        }

        /// <summary>
        /// Gets or sets whether to enable notification history
        /// </summary>
        public bool EnableNotificationHistory
        {
            get => _enableNotificationHistory;
            set => SetProperty(ref _enableNotificationHistory, value);
        }

        /// <summary>
        /// Gets or sets the maximum notification history count
        /// </summary>
        public int MaxNotificationHistoryCount
        {
            get => _maxNotificationHistoryCount;
            set => SetProperty(ref _maxNotificationHistoryCount, value);
        }

        /// <summary>
        /// Gets or sets whether to enable notification acknowledgement
        /// </summary>
        public bool EnableNotificationAcknowledgement
        {
            get => _enableNotificationAcknowledgement;
            set => SetProperty(ref _enableNotificationAcknowledgement, value);
        }

        /// <summary>
        /// Gets or sets whether to require acknowledgement for critical alerts
        /// </summary>
        public bool RequireAcknowledgementForCritical
        {
            get => _requireAcknowledgementForCritical;
            set => SetProperty(ref _requireAcknowledgementForCritical, value);
        }

        /// <summary>
        /// Gets or sets the acknowledge URL
        /// </summary>
        public string AcknowledgeUrl
        {
            get => _acknowledgeUrl;
            set => SetProperty(ref _acknowledgeUrl, value);
        }

        /// <summary>
        /// Gets or sets the custom notification provider
        /// </summary>
        public string CustomNotificationProvider
        {
            get => _customNotificationProvider;
            set => SetProperty(ref _customNotificationProvider, value);
        }

        /// <summary>
        /// Gets or sets the custom notification configuration
        /// </summary>
        public string CustomNotificationConfig
        {
            get => _customNotificationConfig;
            set => SetProperty(ref _customNotificationConfig, value);
        }

        /// <summary>
        /// Gets or sets whether to use compression
        /// </summary>
        public bool UseCompression
        {
            get => _useCompression;
            set => SetProperty(ref _useCompression, value);
        }

        /// <summary>
        /// Gets or sets whether to use batching
        /// </summary>
        public bool UseBatching
        {
            get => _useBatching;
            set => SetProperty(ref _useBatching, value);
        }

        /// <summary>
        /// Gets or sets the maximum batch size
        /// </summary>
        public int MaxBatchSize
        {
            get => _maxBatchSize;
            set => SetProperty(ref _maxBatchSize, value);
        }

        /// <summary>
        /// Gets or sets the batch interval in seconds
        /// </summary>
        public int BatchInterval
        {
            get => _batchInterval;
            set => SetProperty(ref _batchInterval, value);
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
        /// Gets or sets the encryption key
        /// </summary>
        public string EncryptionKey
        {
            get => _encryptionKey;
            set => SetProperty(ref _encryptionKey, value);
        }

        /// <summary>
        /// Gets or sets whether to use authentication
        /// </summary>
        public bool UseAuthentication
        {
            get => _useAuthentication;
            set => SetProperty(ref _useAuthentication, value);
        }

        /// <summary>
        /// Gets or sets the authentication key
        /// </summary>
        public string AuthenticationKey
        {
            get => _authenticationKey;
            set => SetProperty(ref _authenticationKey, value);
        }

        /// <summary>
        /// Gets or sets whether to validate SSL certificate
        /// </summary>
        public bool ValidateSslCertificate
        {
            get => _validateSslCertificate;
            set => SetProperty(ref _validateSslCertificate, value);
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
        /// Gets or sets whether to use network credentials
        /// </summary>
        public bool UseNetworkCredentials
        {
            get => _useNetworkCredentials;
            set => SetProperty(ref _useNetworkCredentials, value);
        }

        /// <summary>
        /// Gets or sets the network credentials username
        /// </summary>
        public string NetworkCredentialsUsername
        {
            get => _networkCredentialsUsername;
            set => SetProperty(ref _networkCredentialsUsername, value);
        }

        /// <summary>
        /// Gets or sets the network credentials password
        /// </summary>
        public string NetworkCredentialsPassword
        {
            get => _networkCredentialsPassword;
            set => SetProperty(ref _networkCredentialsPassword, value);
        }

        /// <summary>
        /// Gets or sets the network credentials domain
        /// </summary>
        public string NetworkCredentialsDomain
        {
            get => _networkCredentialsDomain;
            set => SetProperty(ref _networkCredentialsDomain, value);
        }

        /// <summary>
        /// Gets or sets whether to use client certificate
        /// </summary>
        public bool UseClientCertificate
        {
            get => _useClientCertificate;
            set => SetProperty(ref _useClientCertificate, value);
        }

        /// <summary>
        /// Gets or sets the client certificate path
        /// </summary>
        public string ClientCertificatePath
        {
            get => _clientCertificatePath;
            set => SetProperty(ref _clientCertificatePath, value);
        }

        /// <summary>
        /// Gets or sets the client certificate password
        /// </summary>
        public string ClientCertificatePassword
        {
            get => _clientCertificatePassword;
            set => SetProperty(ref _clientCertificatePassword, value);
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
        /// Gets or sets whether to follow redirects
        /// </summary>
        public bool FollowRedirects
        {
            get => _followRedirects;
            set => SetProperty(ref _followRedirects, value);
        }

        /// <summary>
        /// Gets or sets the maximum redirects
        /// </summary>
        public int MaxRedirects
        {
            get => _maxRedirects;
            set => SetProperty(ref _maxRedirects, value);
        }

        /// <summary>
        /// Gets or sets whether to allow auto redirect
        /// </summary>
        public bool AllowAutoRedirect
        {
            get => _allowAutoRedirect;
            set => SetProperty(ref _allowAutoRedirect, value);
        }
    }
}