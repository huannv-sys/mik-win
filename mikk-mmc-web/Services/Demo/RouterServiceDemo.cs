using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace mikk_mmc_web.Services.Demo
{
    public class RouterServiceDemo : IRouterService
    {
        private readonly ILogger<RouterServiceDemo> _logger;
        private bool _isConnected;
        private ConnectionSettings _settings;
        private readonly Random _random = new Random();

        public bool IsConnected => _isConnected;

        public RouterServiceDemo(ILogger<RouterServiceDemo> logger)
        {
            _logger = logger;
        }

        public async Task<bool> ConnectAsync(ConnectionSettings settings)
        {
            _logger.LogInformation("Đang kết nối đến Router {IpAddress} qua {Protocol}...", 
                settings.IpAddress, settings.Protocol);
            
            // Giả lập kết nối
            await Task.Delay(500);
            
            _settings = settings;
            _isConnected = true;
            
            _logger.LogInformation("Đã kết nối thành công đến Router {IpAddress}", settings.IpAddress);
            
            return true;
        }

        public async Task<bool> DisconnectAsync()
        {
            if (!_isConnected)
                return true;
                
            _logger.LogInformation("Đang ngắt kết nối từ Router...");
            
            // Giả lập ngắt kết nối
            await Task.Delay(200);
            
            _isConnected = false;
            _settings = null;
            
            _logger.LogInformation("Đã ngắt kết nối thành công");
            
            return true;
        }

        public async Task<RouterInfo> GetRouterInfoAsync()
        {
            _logger.LogInformation("Đang lấy thông tin Router...");
            
            if (!_isConnected)
            {
                _logger.LogWarning("Không thể lấy thông tin Router: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }
            
            // Giả lập thời gian phản hồi
            await Task.Delay(300);
            
            var routerInfo = new RouterInfo
            {
                Name = "MikroTik Demo",
                Model = "RouterBOARD 3011",
                SerialNumber = "44G70B7777AA",
                Version = "RouterOS v7.10",
                Architecture = "arm64",
                BoardName = "CCR2004-1G-12S+2XS",
                UptimeSeconds = 924168, // 10 ngày 16 giờ 42 phút 48 giây
                LastUpdateCheck = DateTime.Now.AddDays(-2),
                UpdateAvailable = false,
                LicenseLevel = "5",
                MacAddress = "AA:BB:CC:DD:EE:FF",
                IpAddress = _settings?.IpAddress ?? "192.168.1.1"
            };
            
            _logger.LogInformation("Đã lấy thông tin Router thành công");
            
            return routerInfo;
        }

        public async Task<SystemResources> GetSystemResourcesAsync()
        {
            _logger.LogInformation("Đang lấy thông tin tài nguyên hệ thống...");
            
            if (!_isConnected)
            {
                _logger.LogWarning("Không thể lấy thông tin tài nguyên: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }
            
            // Giả lập thời gian phản hồi
            await Task.Delay(200);
            
            // Tạo giá trị ngẫu nhiên nhưng thực tế
            var cpuLoad = _random.Next(10, 35); // 10-35%
            
            var systemResources = new SystemResources
            {
                CpuLoad = cpuLoad,
                MemoryUsed = 409.6 * 1024 * 1024, // 409.6 MB
                MemoryTotal = 1024 * 1024 * 1024, // 1 GB
                HddUsed = 60 * 1024 * 1024, // 60 MB
                HddTotal = 200 * 1024 * 1024, // 200 MB
                Temperature = 41 + _random.Next(0, 3), // 41-44°C
                LastUpdated = DateTime.Now
            };
            
            _logger.LogInformation("Đã lấy thông tin tài nguyên hệ thống thành công");
            
            return systemResources;
        }
    }
}
