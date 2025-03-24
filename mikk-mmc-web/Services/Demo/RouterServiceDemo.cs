using System;
using System.Threading.Tasks;
using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;

namespace mikk_mmc_web.Services.Demo
{
    // Triển khai Demo Router Service
    public class RouterServiceDemo : IRouterService
    {
        private readonly ILogger<RouterServiceDemo> _logger;
        private ConnectionSettings _settings;
        private bool _isConnected;

        public RouterServiceDemo(ILogger<RouterServiceDemo> logger)
        {
            _logger = logger;
            _settings = new ConnectionSettings();
            _isConnected = false;
        }

        public bool IsConnected => _isConnected;

        public ConnectionSettings CurrentSettings => _settings;

        public async Task<bool> ConnectAsync(ConnectionSettings settings)
        {
            _logger.LogInformation($"Kết nối tới Router tại {settings.IpAddress}");
            await Task.Delay(1500); // Mô phỏng độ trễ
            
            // Đặt cài đặt kết nối
            _settings = settings;
            _isConnected = true;
            
            return true;
        }

        public async Task<bool> DisconnectAsync()
        {
            _logger.LogInformation("Ngắt kết nối từ Router");
            await Task.Delay(500);
            
            _isConnected = false;
            return true;
        }

        public async Task<RouterInfo> GetRouterInfoAsync()
        {
            _logger.LogInformation("Lấy thông tin Router");
            await Task.Delay(800);
            
            // Dữ liệu mẫu
            return new RouterInfo
            {
                RouterName = "MikroTik-Office",
                Model = "RouterBOARD 3011UiAS",
                SerialNumber = "HY306XD58291",
                FirmwareVersion = "6.48.6",
                Architecture = "tile",
                BoardName = "RB3011UiAS",
                IpAddress = "192.168.1.1",
                MacAddress = "E8:DC:4F:CA:DB:92",
                Uptime = 1209600, // 14 ngày
                LicenseLevel = "4",
                CurrentTime = DateTime.Now
            };
        }

        public async Task<SystemResources> GetSystemResourcesAsync()
        {
            _logger.LogInformation("Lấy thông tin tài nguyên hệ thống");
            await Task.Delay(600);
            
            // Tạo số ngẫu nhiên để giả lập việc thay đổi tài nguyên
            var rand = new Random();
            
            return new SystemResources
            {
                CpuLoad = rand.Next(15, 45),
                MemoryUsed = 256 * 1024 * 1024 + rand.Next(1, 50) * 1024 * 1024,
                MemoryTotal = 1024 * 1024 * 1024,
                HddUsed = 120 * 1024 * 1024 + rand.Next(1, 10) * 1024 * 1024,
                HddTotal = 512 * 1024 * 1024,
                Temperature = rand.Next(35, 55),
                Voltage = 24,
                CurrentFirmwareVersion = 6486,
                LatestFirmwareVersion = rand.Next(0, 2) == 0 ? 6486 : 6487
            };
        }

        public async Task<bool> RebootRouterAsync()
        {
            _logger.LogInformation("Khởi động lại Router");
            await Task.Delay(2000);
            
            // Trong môi trường thực tế, kết nối sẽ mất do router khởi động lại
            // Ở đây ta vẫn giữ trạng thái kết nối cho môi trường demo
            return true;
        }

        public async Task<bool> BackupConfigurationAsync(string filename)
        {
            _logger.LogInformation($"Sao lưu cấu hình tới {filename}");
            await Task.Delay(3000);
            return true;
        }

        public async Task<bool> RestoreConfigurationAsync(string filename)
        {
            _logger.LogInformation($"Khôi phục cấu hình từ {filename}");
            await Task.Delay(5000);
            return true;
        }
    }
}
