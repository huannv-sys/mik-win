using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MikroTikMonitor.Models;

namespace MikroTikMonitor.Services
{
    /// <summary>
    /// Interface for the settings service
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets the application settings
        /// </summary>
        /// <returns>The application settings</returns>
        Task<AppSettings> GetSettingsAsync();
        
        /// <summary>
        /// Saves the application settings
        /// </summary>
        /// <param name="settings">The application settings</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveSettingsAsync(AppSettings settings);
        
        /// <summary>
        /// Gets the router devices
        /// </summary>
        /// <returns>The router devices</returns>
        Task<List<RouterDevice>> GetRouterDevicesAsync();
        
        /// <summary>
        /// Saves the router devices
        /// </summary>
        /// <param name="devices">The router devices</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveRouterDevicesAsync(List<RouterDevice> devices);
        
        /// <summary>
        /// Gets a router device
        /// </summary>
        /// <param name="id">The router device ID</param>
        /// <returns>The router device</returns>
        Task<RouterDevice> GetRouterDeviceAsync(string id);
        
        /// <summary>
        /// Saves a router device
        /// </summary>
        /// <param name="device">The router device</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveRouterDeviceAsync(RouterDevice device);
        
        /// <summary>
        /// Deletes a router device
        /// </summary>
        /// <param name="id">The router device ID</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteRouterDeviceAsync(string id);
        
        /// <summary>
        /// Gets the default router device
        /// </summary>
        /// <returns>The default router device</returns>
        Task<RouterDevice> GetDefaultRouterDeviceAsync();
        
        /// <summary>
        /// Sets the default router device
        /// </summary>
        /// <param name="id">The router device ID</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SetDefaultRouterDeviceAsync(string id);
        
        /// <summary>
        /// Gets all device groups
        /// </summary>
        /// <returns>The list of device groups</returns>
        Task<List<string>> GetDeviceGroupsAsync();
        
        /// <summary>
        /// Gets all router backup files
        /// </summary>
        /// <returns>The list of backup files</returns>
        Task<List<string>> GetBackupFilesAsync();
        
        /// <summary>
        /// Gets all router backup files for a specific device
        /// </summary>
        /// <param name="deviceId">The device ID</param>
        /// <returns>The list of backup files</returns>
        Task<List<string>> GetBackupFilesAsync(string deviceId);
        
        /// <summary>
        /// Gets the log file path
        /// </summary>
        /// <returns>The log file path</returns>
        string GetLogFilePath();
        
        /// <summary>
        /// Gets the settings file path
        /// </summary>
        /// <returns>The settings file path</returns>
        string GetSettingsFilePath();
        
        /// <summary>
        /// Gets the devices file path
        /// </summary>
        /// <returns>The devices file path</returns>
        string GetDevicesFilePath();
        
        /// <summary>
        /// Gets the backup directory path
        /// </summary>
        /// <returns>The backup directory path</returns>
        string GetBackupDirectoryPath();
        
        /// <summary>
        /// Gets the backup directory path for a specific device
        /// </summary>
        /// <param name="deviceId">The device ID</param>
        /// <returns>The backup directory path</returns>
        string GetBackupDirectoryPath(string deviceId);
        
        /// <summary>
        /// Gets the connection string for the database
        /// </summary>
        /// <returns>The connection string</returns>
        string GetConnectionString();
        
        /// <summary>
        /// Gets the backup schedule
        /// </summary>
        /// <returns>The backup schedule</returns>
        Task<BackupSchedule> GetBackupScheduleAsync();
        
        /// <summary>
        /// Saves the backup schedule
        /// </summary>
        /// <param name="schedule">The backup schedule</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveBackupScheduleAsync(BackupSchedule schedule);
        
        /// <summary>
        /// Gets the API key
        /// </summary>
        /// <returns>The API key</returns>
        string GetApiKey();
        
        /// <summary>
        /// Sets the API key
        /// </summary>
        /// <param name="apiKey">The API key</param>
        void SetApiKey(string apiKey);
        
        /// <summary>
        /// Gets the custom themes
        /// </summary>
        /// <returns>The custom themes</returns>
        Task<List<CustomTheme>> GetCustomThemesAsync();
        
        /// <summary>
        /// Saves the custom themes
        /// </summary>
        /// <param name="themes">The custom themes</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveCustomThemesAsync(List<CustomTheme> themes);
        
        /// <summary>
        /// Gets a custom theme
        /// </summary>
        /// <param name="name">The theme name</param>
        /// <returns>The custom theme</returns>
        Task<CustomTheme> GetCustomThemeAsync(string name);
        
        /// <summary>
        /// Saves a custom theme
        /// </summary>
        /// <param name="theme">The custom theme</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveCustomThemeAsync(CustomTheme theme);
        
        /// <summary>
        /// Deletes a custom theme
        /// </summary>
        /// <param name="name">The theme name</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteCustomThemeAsync(string name);
        
        /// <summary>
        /// Gets the dashboard layout
        /// </summary>
        /// <returns>The dashboard layout</returns>
        Task<DashboardLayout> GetDashboardLayoutAsync();
        
        /// <summary>
        /// Saves the dashboard layout
        /// </summary>
        /// <param name="layout">The dashboard layout</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveDashboardLayoutAsync(DashboardLayout layout);
        
        /// <summary>
        /// Resets the settings to default
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task ResetSettingsAsync();
        
        /// <summary>
        /// Imports settings from a file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task ImportSettingsAsync(string filePath);
        
        /// <summary>
        /// Exports settings to a file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task ExportSettingsAsync(string filePath);
        
        /// <summary>
        /// Gets the notification settings
        /// </summary>
        /// <returns>The notification settings</returns>
        Task<NotificationSettings> GetNotificationSettingsAsync();
        
        /// <summary>
        /// Saves the notification settings
        /// </summary>
        /// <param name="settings">The notification settings</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveNotificationSettingsAsync(NotificationSettings settings);
        
        /// <summary>
        /// Gets the update check information
        /// </summary>
        /// <returns>The update check information</returns>
        Task<UpdateCheck> GetUpdateCheckAsync();
        
        /// <summary>
        /// Saves the update check information
        /// </summary>
        /// <param name="updateCheck">The update check information</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task SaveUpdateCheckAsync(UpdateCheck updateCheck);
        
        /// <summary>
        /// Event that is raised when the settings are changed
        /// </summary>
        event EventHandler<AppSettings> SettingsChanged;
        
        /// <summary>
        /// Event that is raised when the router devices are changed
        /// </summary>
        event EventHandler<List<RouterDevice>> RouterDevicesChanged;
    }
}