using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MikroTikMonitor.Models;
using MikroTikMonitor.Services;

namespace MikroTikMonitor.ViewModels
{
    /// <summary>
    /// ViewModel for router logs
    /// </summary>
    public class LogViewModel : ViewModelBase
    {
        private readonly RouterApiService _routerApiService;
        private RouterDevice _router;
        private LogEntry _selectedLogEntry;
        private bool _isRefreshing;
        private string _statusMessage;
        private string _searchText;
        private int _maxEntries = 100;
        
        /// <summary>
        /// Gets the log entries as an observable collection
        /// </summary>
        public ObservableCollection<LogEntry> LogEntries { get; }
        
        /// <summary>
        /// Gets the filtered log entries as an observable collection
        /// </summary>
        public ObservableCollection<LogEntry> FilteredLogEntries { get; }
        
        /// <summary>
        /// Gets or sets the selected log entry
        /// </summary>
        public LogEntry SelectedLogEntry
        {
            get => _selectedLogEntry;
            set => SetProperty(ref _selectedLogEntry, value);
        }
        
        /// <summary>
        /// Gets or sets whether data is being refreshed
        /// </summary>
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
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
        /// Gets or sets the search text for filtering log entries
        /// </summary>
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    FilterLogEntries();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the maximum number of log entries to retrieve
        /// </summary>
        public int MaxEntries
        {
            get => _maxEntries;
            set => SetProperty(ref _maxEntries, value);
        }
        
        /// <summary>
        /// Gets the refresh command
        /// </summary>
        public ICommand RefreshCommand { get; }
        
        /// <summary>
        /// Gets the clear logs command
        /// </summary>
        public ICommand ClearLogsCommand { get; }
        
        /// <summary>
        /// Gets the export logs command
        /// </summary>
        public ICommand ExportLogsCommand { get; }
        
        /// <summary>
        /// Initializes a new instance of the LogViewModel class
        /// </summary>
        /// <param name="routerApiService">The router API service</param>
        /// <param name="router">The router device</param>
        public LogViewModel(
            RouterApiService routerApiService,
            RouterDevice router)
        {
            _routerApiService = routerApiService ?? throw new ArgumentNullException(nameof(routerApiService));
            _router = router ?? throw new ArgumentNullException(nameof(router));
            
            // Create observable collections
            LogEntries = new ObservableCollection<LogEntry>();
            FilteredLogEntries = new ObservableCollection<LogEntry>();
            
            // Create commands
            RefreshCommand = new RelayCommand(ExecuteRefreshCommand, CanExecuteRefreshCommand);
            ClearLogsCommand = new RelayCommand(ExecuteClearLogsCommand, CanExecuteClearLogsCommand);
            ExportLogsCommand = new RelayCommand(ExecuteExportLogsCommand, CanExecuteExportLogsCommand);
            
            // Set initial status
            StatusMessage = "Ready";
            
            // Load data
            LoadData();
        }
        
        /// <summary>
        /// Loads initial data
        /// </summary>
        private async void LoadData()
        {
            await RefreshLogs();
        }
        
        /// <summary>
        /// Refreshes the list of log entries
        /// </summary>
        private async System.Threading.Tasks.Task RefreshLogs()
        {
            if (_router == null || !_router.IsConnected)
                return;
                
            IsRefreshing = true;
            StatusMessage = "Loading logs...";
            
            try
            {
                await _routerApiService.GetLogEntriesAsync(_router, MaxEntries);
                
                // Update observable collection
                LogEntries.Clear();
                if (_router.LogEntries != null)
                {
                    foreach (var entry in _router.LogEntries)
                    {
                        LogEntries.Add(entry);
                    }
                }
                
                // Apply filtering
                FilterLogEntries();
                
                StatusMessage = "Logs loaded";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error loading logs: " + ex.Message;
            }
            finally
            {
                IsRefreshing = false;
            }
        }
        
        /// <summary>
        /// Filters log entries based on search text
        /// </summary>
        private void FilterLogEntries()
        {
            FilteredLogEntries.Clear();
            
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // No filter, add all entries
                foreach (var entry in LogEntries)
                {
                    FilteredLogEntries.Add(entry);
                }
            }
            else
            {
                // Apply filter
                var filter = SearchText.ToLowerInvariant();
                foreach (var entry in LogEntries.Where(e => 
                    e.Message.ToLowerInvariant().Contains(filter) || 
                    e.Topic.ToLowerInvariant().Contains(filter)))
                {
                    FilteredLogEntries.Add(entry);
                }
            }
        }
        
        /// <summary>
        /// Determines whether the refresh command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteRefreshCommand()
        {
            return _router != null && _router.IsConnected && !IsRefreshing;
        }
        
        /// <summary>
        /// Executes the refresh command
        /// </summary>
        private async void ExecuteRefreshCommand()
        {
            await RefreshLogs();
        }
        
        /// <summary>
        /// Determines whether the clear logs command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteClearLogsCommand()
        {
            return _router != null && _router.IsConnected && !IsRefreshing && LogEntries.Count > 0;
        }
        
        /// <summary>
        /// Executes the clear logs command
        /// </summary>
        private async void ExecuteClearLogsCommand()
        {
            IsRefreshing = true;
            StatusMessage = "Clearing logs...";
            
            try
            {
                await _routerApiService.ClearLogEntriesAsync(_router);
                
                // Clear collections
                LogEntries.Clear();
                FilteredLogEntries.Clear();
                
                StatusMessage = "Logs cleared";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error clearing logs: " + ex.Message;
            }
            finally
            {
                IsRefreshing = false;
            }
        }
        
        /// <summary>
        /// Determines whether the export logs command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteExportLogsCommand()
        {
            return !IsRefreshing && LogEntries.Count > 0;
        }
        
        /// <summary>
        /// Executes the export logs command
        /// </summary>
        private void ExecuteExportLogsCommand()
        {
            // This would be implemented to export logs to a file
            // In a real application, this would use a file dialog service
            StatusMessage = "Export logs functionality not implemented";
        }
        
        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            
            // Update command states
            if (propertyName == nameof(IsRefreshing))
            {
                (RefreshCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (ClearLogsCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (ExportLogsCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }
}