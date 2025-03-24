using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MikroTikMonitor.Services;

namespace MikroTikMonitor.ViewModels
{
    /// <summary>
    /// ViewModel for application settings
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private int _refreshInterval;
        private bool _autoRefresh;
        private bool _darkMode;
        private bool _showNotifications;
        private bool _minimizeToTray;
        private bool _startWithWindows;
        private bool _checkUpdatesAutomatically;
        private string _statusMessage;
        private bool _isSaving;
        
        /// <summary>
        /// Gets or sets the refresh interval in seconds
        /// </summary>
        public int RefreshInterval
        {
            get => _refreshInterval;
            set => SetProperty(ref _refreshInterval, value);
        }
        
        /// <summary>
        /// Gets or sets whether to auto-refresh data
        /// </summary>
        public bool AutoRefresh
        {
            get => _autoRefresh;
            set => SetProperty(ref _autoRefresh, value);
        }
        
        /// <summary>
        /// Gets or sets whether to use dark mode
        /// </summary>
        public bool DarkMode
        {
            get => _darkMode;
            set => SetProperty(ref _darkMode, value);
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
        /// Gets or sets whether to minimize to tray
        /// </summary>
        public bool MinimizeToTray
        {
            get => _minimizeToTray;
            set => SetProperty(ref _minimizeToTray, value);
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
        /// Gets or sets whether to check for updates automatically
        /// </summary>
        public bool CheckUpdatesAutomatically
        {
            get => _checkUpdatesAutomatically;
            set => SetProperty(ref _checkUpdatesAutomatically, value);
        }
        
        /// <summary>
        /// Gets or sets the status message
        /// </summary>
        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }
        
        /// <summary>
        /// Gets or sets whether settings are being saved
        /// </summary>
        public bool IsSaving
        {
            get => _isSaving;
            set => SetProperty(ref _isSaving, value);
        }
        
        /// <summary>
        /// Gets the save command
        /// </summary>
        public ICommand SaveCommand { get; }
        
        /// <summary>
        /// Gets the reset to defaults command
        /// </summary>
        public ICommand ResetToDefaultsCommand { get; }
        
        /// <summary>
        /// Initializes a new instance of the SettingsViewModel class
        /// </summary>
        /// <param name="settingsService">The settings service</param>
        public SettingsViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
            
            // Create commands
            SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            ResetToDefaultsCommand = new RelayCommand(ExecuteResetToDefaultsCommand, CanExecuteResetToDefaultsCommand);
            
            // Load settings
            LoadSettings();
        }
        
        /// <summary>
        /// Loads settings from the settings service
        /// </summary>
        private void LoadSettings()
        {
            RefreshInterval = _settingsService.GetSetting("RefreshInterval", 30);
            AutoRefresh = _settingsService.GetSetting("AutoRefresh", true);
            DarkMode = _settingsService.GetSetting("DarkMode", false);
            ShowNotifications = _settingsService.GetSetting("ShowNotifications", true);
            MinimizeToTray = _settingsService.GetSetting("MinimizeToTray", false);
            StartWithWindows = _settingsService.GetSetting("StartWithWindows", false);
            CheckUpdatesAutomatically = _settingsService.GetSetting("CheckUpdatesAutomatically", true);
            
            StatusMessage = "Settings loaded";
        }
        
        /// <summary>
        /// Determines whether the save command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteSaveCommand()
        {
            return !IsSaving && RefreshInterval > 0;
        }
        
        /// <summary>
        /// Executes the save command
        /// </summary>
        private void ExecuteSaveCommand()
        {
            IsSaving = true;
            StatusMessage = "Saving settings...";
            
            try
            {
                // Save settings
                _settingsService.SetSetting("RefreshInterval", RefreshInterval);
                _settingsService.SetSetting("AutoRefresh", AutoRefresh);
                _settingsService.SetSetting("DarkMode", DarkMode);
                _settingsService.SetSetting("ShowNotifications", ShowNotifications);
                _settingsService.SetSetting("MinimizeToTray", MinimizeToTray);
                _settingsService.SetSetting("StartWithWindows", StartWithWindows);
                _settingsService.SetSetting("CheckUpdatesAutomatically", CheckUpdatesAutomatically);
                
                _settingsService.SaveSettings();
                
                StatusMessage = "Settings saved";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error saving settings: " + ex.Message;
            }
            finally
            {
                IsSaving = false;
            }
        }
        
        /// <summary>
        /// Determines whether the reset to defaults command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteResetToDefaultsCommand()
        {
            return !IsSaving;
        }
        
        /// <summary>
        /// Executes the reset to defaults command
        /// </summary>
        private void ExecuteResetToDefaultsCommand()
        {
            IsSaving = true;
            StatusMessage = "Resetting to defaults...";
            
            try
            {
                // Reset to defaults
                RefreshInterval = 30;
                AutoRefresh = true;
                DarkMode = false;
                ShowNotifications = true;
                MinimizeToTray = false;
                StartWithWindows = false;
                CheckUpdatesAutomatically = true;
                
                StatusMessage = "Reset to defaults";
            }
            finally
            {
                IsSaving = false;
            }
        }
        
        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            
            // Update command states
            if (propertyName == nameof(IsSaving) || propertyName == nameof(RefreshInterval))
            {
                (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (ResetToDefaultsCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }
}