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
    /// ViewModel for network interfaces
    /// </summary>
    public class InterfaceViewModel : ViewModelBase
    {
        private readonly RouterApiService _routerApiService;
        private readonly SnmpService _snmpService;
        private RouterDevice _router;
        private NetworkInterface _selectedInterface;
        private bool _isRefreshing;
        private string _statusMessage;
        
        /// <summary>
        /// Gets the network interfaces as an observable collection
        /// </summary>
        public ObservableCollection<NetworkInterface> Interfaces { get; }
        
        /// <summary>
        /// Gets or sets the selected network interface
        /// </summary>
        public NetworkInterface SelectedInterface
        {
            get => _selectedInterface;
            set => SetProperty(ref _selectedInterface, value);
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
        /// Gets the refresh command
        /// </summary>
        public ICommand RefreshCommand { get; }
        
        /// <summary>
        /// Gets the enable interface command
        /// </summary>
        public ICommand EnableInterfaceCommand { get; }
        
        /// <summary>
        /// Gets the disable interface command
        /// </summary>
        public ICommand DisableInterfaceCommand { get; }
        
        /// <summary>
        /// Initializes a new instance of the InterfaceViewModel class
        /// </summary>
        /// <param name="routerApiService">The router API service</param>
        /// <param name="snmpService">The SNMP service</param>
        /// <param name="router">The router device</param>
        public InterfaceViewModel(
            RouterApiService routerApiService,
            SnmpService snmpService,
            RouterDevice router)
        {
            _routerApiService = routerApiService ?? throw new ArgumentNullException(nameof(routerApiService));
            _snmpService = snmpService ?? throw new ArgumentNullException(nameof(snmpService));
            _router = router ?? throw new ArgumentNullException(nameof(router));
            
            // Create observable collection from router interfaces
            Interfaces = new ObservableCollection<NetworkInterface>();
            
            // Create commands
            RefreshCommand = new RelayCommand(ExecuteRefreshCommand, CanExecuteRefreshCommand);
            EnableInterfaceCommand = new RelayCommand(ExecuteEnableInterfaceCommand, CanExecuteEnableInterfaceCommand);
            DisableInterfaceCommand = new RelayCommand(ExecuteDisableInterfaceCommand, CanExecuteDisableInterfaceCommand);
            
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
            await RefreshInterfaces();
        }
        
        /// <summary>
        /// Refreshes the list of interfaces
        /// </summary>
        private async System.Threading.Tasks.Task RefreshInterfaces()
        {
            if (_router == null || !_router.IsConnected)
                return;
                
            IsRefreshing = true;
            StatusMessage = "Loading interfaces...";
            
            try
            {
                await _routerApiService.GetNetworkInterfacesAsync(_router);
                
                // Update observable collection
                Interfaces.Clear();
                if (_router.Interfaces != null)
                {
                    foreach (var iface in _router.Interfaces)
                    {
                        Interfaces.Add(iface);
                    }
                }
                
                // Select first interface if available
                if (Interfaces.Count > 0 && SelectedInterface == null)
                {
                    SelectedInterface = Interfaces[0];
                }
                
                StatusMessage = "Interfaces loaded";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error loading interfaces: " + ex.Message;
            }
            finally
            {
                IsRefreshing = false;
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
            await RefreshInterfaces();
        }
        
        /// <summary>
        /// Determines whether the enable interface command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteEnableInterfaceCommand()
        {
            return _router != null && _router.IsConnected && 
                   SelectedInterface != null && !SelectedInterface.Enabled && 
                   !IsRefreshing;
        }
        
        /// <summary>
        /// Executes the enable interface command
        /// </summary>
        private async void ExecuteEnableInterfaceCommand()
        {
            if (SelectedInterface == null)
                return;
                
            IsRefreshing = true;
            StatusMessage = "Enabling interface...";
            
            try
            {
                await _routerApiService.EnableNetworkInterfaceAsync(_router, SelectedInterface.Name);
                await RefreshInterfaces();
                StatusMessage = "Interface enabled";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error enabling interface: " + ex.Message;
            }
            finally
            {
                IsRefreshing = false;
            }
        }
        
        /// <summary>
        /// Determines whether the disable interface command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteDisableInterfaceCommand()
        {
            return _router != null && _router.IsConnected && 
                   SelectedInterface != null && SelectedInterface.Enabled && 
                   !IsRefreshing;
        }
        
        /// <summary>
        /// Executes the disable interface command
        /// </summary>
        private async void ExecuteDisableInterfaceCommand()
        {
            if (SelectedInterface == null)
                return;
                
            IsRefreshing = true;
            StatusMessage = "Disabling interface...";
            
            try
            {
                await _routerApiService.DisableNetworkInterfaceAsync(_router, SelectedInterface.Name);
                await RefreshInterfaces();
                StatusMessage = "Interface disabled";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error disabling interface: " + ex.Message;
            }
            finally
            {
                IsRefreshing = false;
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
            if (propertyName == nameof(IsRefreshing) || propertyName == nameof(SelectedInterface))
            {
                (RefreshCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (EnableInterfaceCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DisableInterfaceCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }
}