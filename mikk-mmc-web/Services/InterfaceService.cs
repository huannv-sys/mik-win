using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using mikk_mmc_web.Models;

namespace mikk_mmc_web.Services
{
    public class InterfaceService : IInterfaceService
    {
        private readonly ILogger<InterfaceService> _logger;
        private readonly IRouterService _routerService;
        private readonly Random _random = new Random(); // Chỉ để demo trong môi trường phát triển
        private readonly Dictionary<string, List<double>> _trafficHistory = new Dictionary<string, List<double>>();

        public InterfaceService(ILogger<InterfaceService> logger, IRouterService routerService)
        {
            _logger = logger;
            _routerService = routerService;
            InitializeTrafficHistory();
        }

        private void InitializeTrafficHistory()
        {
            // Khởi tạo dữ liệu lịch sử lưu lượng mẫu cho demo
            var interfaces = new[] { "ether1", "ether2", "ether3", "wlan1", "bridge1" };
            foreach (var iface in interfaces)
            {
                _trafficHistory[iface] = new List<double>();
                for (int i = 0; i < 60; i++)
                {
                    _trafficHistory[iface].Add(_random.Next(100, 5000) * 1024);
                }
            }
        }

        public async Task<List<NetworkInterface>> GetAllInterfacesAsync()
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy danh sách giao diện mạng: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation("Đang lấy danh sách giao diện mạng");
                
                // Giả lập thời gian trễ
                await Task.Delay(1000);
                
                // Dữ liệu mẫu cho phát triển
                var interfaces = new List<NetworkInterface>
                {
                    new NetworkInterface
                    {
                        Name = "ether1",
                        Type = "ethernet",
                        MacAddress = "00:0C:42:1F:65:E1",
                        IsActive = true,
                        IpAddress = "192.168.1.1",
                        Netmask = "255.255.255.0",
                        DefaultGateway = "",
                        RxBytes = 1234567890,
                        TxBytes = 9876543210,
                        RxPackets = 1234567,
                        TxPackets = 9876543,
                        RxRate = 25600,
                        TxRate = 12800,
                        LastUpdated = DateTime.Now
                    },
                    new NetworkInterface
                    {
                        Name = "ether2",
                        Type = "ethernet",
                        MacAddress = "00:0C:42:1F:65:E2",
                        IsActive = true,
                        IpAddress = "10.0.0.1",
                        Netmask = "255.255.255.0",
                        DefaultGateway = "",
                        RxBytes = 12345678,
                        TxBytes = 87654321,
                        RxPackets = 123456,
                        TxPackets = 654321,
                        RxRate = 12800,
                        TxRate = 6400,
                        LastUpdated = DateTime.Now
                    },
                    new NetworkInterface
                    {
                        Name = "ether3",
                        Type = "ethernet",
                        MacAddress = "00:0C:42:1F:65:E3",
                        IsActive = false,
                        IpAddress = "",
                        Netmask = "",
                        DefaultGateway = "",
                        RxBytes = 0,
                        TxBytes = 0,
                        RxPackets = 0,
                        TxPackets = 0,
                        RxRate = 0,
                        TxRate = 0,
                        LastUpdated = DateTime.Now
                    },
                    new NetworkInterface
                    {
                        Name = "wlan1",
                        Type = "wireless",
                        MacAddress = "00:0C:42:1F:65:F1",
                        IsActive = true,
                        IpAddress = "192.168.2.1",
                        Netmask = "255.255.255.0",
                        DefaultGateway = "",
                        RxBytes = 9876543210,
                        TxBytes = 1234567890,
                        RxPackets = 9876543,
                        TxPackets = 1234567,
                        RxRate = 51200,
                        TxRate = 25600,
                        LastUpdated = DateTime.Now
                    },
                    new NetworkInterface
                    {
                        Name = "bridge1",
                        Type = "bridge",
                        MacAddress = "00:0C:42:1F:65:B1",
                        IsActive = true,
                        IpAddress = "",
                        Netmask = "",
                        DefaultGateway = "",
                        RxBytes = 5432167890,
                        TxBytes = 6789054321,
                        RxPackets = 5432167,
                        TxPackets = 6789054,
                        RxRate = 6400,
                        TxRate = 3200,
                        LastUpdated = DateTime.Now
                    }
                };
                
                _logger.LogInformation($"Đã lấy {interfaces.Count} giao diện mạng thành công");
                return interfaces;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách giao diện mạng: {ex.Message}");
                throw;
            }
        }

        public async Task<NetworkInterface> GetInterfaceByNameAsync(string name)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy thông tin giao diện mạng: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy thông tin giao diện mạng {name}");
                
                // Giả lập thời gian trễ
                await Task.Delay(800);
                
                // Lấy tất cả các giao diện và lọc theo tên
                var interfaces = await GetAllInterfacesAsync();
                var targetInterface = interfaces.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                
                if (targetInterface == null)
                {
                    _logger.LogWarning($"Không tìm thấy giao diện mạng có tên {name}");
                    throw new KeyNotFoundException($"Không tìm thấy giao diện mạng có tên {name}");
                }
                
                _logger.LogInformation($"Đã lấy thông tin giao diện mạng {name} thành công");
                return targetInterface;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy thông tin giao diện mạng {name}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> EnableInterfaceAsync(string name)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể bật giao diện mạng: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang bật giao diện mạng {name}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1500);
                
                _logger.LogInformation($"Đã bật giao diện mạng {name} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi bật giao diện mạng {name}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DisableInterfaceAsync(string name)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể tắt giao diện mạng: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang tắt giao diện mạng {name}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1500);
                
                _logger.LogInformation($"Đã tắt giao diện mạng {name} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi tắt giao diện mạng {name}: {ex.Message}");
                return false;
            }
        }

        public async Task<List<TrafficData>> GetTrafficHistoryAsync(string interfaceName, DateTime startTime, DateTime endTime)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể lấy lịch sử lưu lượng: Chưa kết nối");
                throw new InvalidOperationException("Chưa kết nối đến Router");
            }

            try
            {
                _logger.LogInformation($"Đang lấy lịch sử lưu lượng cho giao diện {interfaceName}");
                
                // Giả lập thời gian trễ
                await Task.Delay(1200);
                
                // Tạo dữ liệu lịch sử mẫu
                var result = new List<TrafficData>();
                var startPoint = startTime;
                
                // Kiểm tra nếu có dữ liệu lịch sử cho giao diện này
                if (!_trafficHistory.ContainsKey(interfaceName))
                {
                    _trafficHistory[interfaceName] = new List<double>();
                    for (int i = 0; i < 60; i++)
                    {
                        _trafficHistory[interfaceName].Add(_random.Next(100, 5000) * 1024);
                    }
                }
                
                // Lấy 60 điểm dữ liệu mẫu trong khoảng thời gian
                for (int i = 0; i < 60; i++)
                {
                    var trafficData = new TrafficData 
                    { 
                        Timestamp = startPoint.AddMinutes(i * ((endTime - startTime).TotalMinutes / 60)), 
                        Interfaces = new Dictionary<string, InterfaceTraffic>() 
                    };
                    
                    trafficData.Interfaces[interfaceName] = new InterfaceTraffic 
                    { 
                        Name = interfaceName,
                        RxRate = _trafficHistory[interfaceName][i],
                        TxRate = _trafficHistory[interfaceName][i] * 0.8 // TX thường nhỏ hơn RX một chút
                    };
                    
                    result.Add(trafficData);
                }
                
                _logger.LogInformation($"Đã lấy {result.Count} điểm dữ liệu lịch sử lưu lượng cho giao diện {interfaceName}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy lịch sử lưu lượng: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ResetInterfaceCountersAsync(string name)
        {
            if (!_routerService.IsConnected)
            {
                _logger.LogWarning("Không thể đặt lại bộ đếm giao diện mạng: Chưa kết nối");
                return false;
            }

            try
            {
                _logger.LogInformation($"Đang đặt lại bộ đếm cho giao diện mạng {name}");
                
                // Giả lập thời gian xử lý
                await Task.Delay(1000);
                
                _logger.LogInformation($"Đã đặt lại bộ đếm cho giao diện mạng {name} thành công");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi đặt lại bộ đếm giao diện mạng {name}: {ex.Message}");
                return false;
            }
        }
    }
}
