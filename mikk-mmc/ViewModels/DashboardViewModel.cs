using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MikroTikMonitor.Models;
using MikroTikMonitor.Services;

namespace MikroTikMonitor.ViewModels
{
    /// <summary>
    /// ViewModel for the dashboard view
    /// </summary>
    public class DashboardViewModel : ViewModelBase
    {
        private readonly RouterApiService _routerApiService;
        private readonly SnmpService _snmpService;
        private RouterDevice _selectedRouter;
        private bool _isRefreshing;
        private string _statusMessage;
        
        /// <summary>
        /// Gets the routers as an observable collection
        /// </summary>
        public ObservableCollection<RouterDevice> Routers { get; }
        
        /// <summary>
        /// Gets or sets the selected router
        /// </summary>
        public RouterDevice SelectedRouter
        {
            get => _selectedRouter;
            set => SetProperty(ref _selectedRouter, value);
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
        /// Gets the view details command
        /// </summary>
        public ICommand ViewDetailsCommand { get; }
        
        /// <summary>
        /// Initializes a new instance of the DashboardViewModel class
        /// </summary>
        /// <param name="routerApiService">The router API service</param>
        /// <param name="snmpService">The SNMP service</param>
        /// <param name="routers">The list of routers</param>
        public DashboardViewModel(
            RouterApiService routerApiService,
            SnmpService snmpService,
            List<RouterDevice> routers)
        {
            _routerApiService = routerApiService ?? throw new ArgumentNullException(nameof(routerApiService));
            _snmpService = snmpService ?? throw new ArgumentNullException(nameof(snmpService));
            
            // Create observable collection from routers list
            Routers = new ObservableCollection<RouterDevice>(routers ?? throw new ArgumentNullException(nameof(routers)));
            
            // Set selected router if there are any
            if (Routers.Count > 0)
                SelectedRouter = Routers[0];
                
            // Create commands
            RefreshCommand = new RelayCommand(ExecuteRefreshCommand, CanExecuteRefreshCommand);
            ViewDetailsCommand = new RelayCommand(ExecuteViewDetailsCommand, CanExecuteViewDetailsCommand);
            
            // Set initial status
            StatusMessage = "Ready";
        }
        
        /// <summary>
        /// Determines whether the refresh command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteRefreshCommand()
        {
            return !IsRefreshing;
        }
        
        /// <summary>
        /// Executes the refresh command
        /// </summary>
        private async void ExecuteRefreshCommand()
        {
            if (Routers.Count == 0)
                return;
                
            IsRefreshing = true;
            StatusMessage = "Refreshing...";
            
            try
            {
                foreach (var router in Routers)
                {
                    if (router.IsConnected)
                    {
                        await _routerApiService.GetSystemInfoAsync(router);
                        await _routerApiService.GetSystemResourcesAsync(router);
                        
                        if (router.UseSnmp)
                        {
                            await _snmpService.GetSystemInfoAsync(router);
                            await _snmpService.GetInterfaceStatisticsAsync(router);
                        }
                    }
                }
                
                StatusMessage = "Refreshed";
            }
            catch (Exception ex)
            {
                StatusMessage = "Refresh error: " + ex.Message;
            }
            finally
            {
                IsRefreshing = false;
            }
        }
        
        /// <summary>
        /// Determines whether the view details command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, otherwise false</returns>
        private bool CanExecuteViewDetailsCommand()
        {
            return SelectedRouter != null;
        }
        
        /// <summary>
        /// Executes the view details command
        /// </summary>
        private void ExecuteViewDetailsCommand()
        {
            // Navigate to details view for selected router
            // This would be handled by a navigation service in a real implementation
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
            }
            else if (propertyName == nameof(SelectedRouter))
            {
                (ViewDetailsCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }
}