using mikk_mmc_web.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mikk_mmc_web.Services.Demo
{
    public class InterfaceServiceDemo : IInterfaceService
    {
        private readonly ILogger<InterfaceServiceDemo> _logger;
        private readonly Random _random = new Random();
        private readonly Dictionary<string, NetworkInterface> _interfaces = new();
        private readonly Dictionary<string, List<DataPoint>> _rxHistory = new();
        private readonly Dictionary<string, List<DataPoint>> _txHistory = new();

        public InterfaceServiceDemo(ILogger<InterfaceServiceDemo> logger)
        {
            _logger = logger;
            InitializeInterfaces();
        }

        private void InitializeInterfaces()
        {
            _interfaces.Add("ether1", new NetworkInterface
            {
                Name = "ether1",
                Type = "ethernet",
                IsEnabled = true,
                IsConnected = true,
                MacAddress = "AA:BB:CC:DD:EE:01",
                IpAddress = "192.168.1.1",
                Netmask = "255.255.255.0",
                RxBytes = 1024 * 1024 * 150, // 150 MB
                TxBytes = 1024 * 1024 * 50,  // 50 MB
                RxRate = 650 * 1024,  // 650 KB/s
                TxRate = 230 * 1024,  // 230 KB/s
                LastUpdated = DateTime.Now
            });

            _interfaces.Add("ether2", new NetworkInterface
            {
                Name = "ether2",
                Type = "ethernet",
                IsEnabled = true,
                IsConnected = true,
                MacAddress = "AA:BB:CC:DD:EE:02",
                IpAddress = "10.0.0.1",
                Netmask = "255.255.255.0",
                RxBytes = 1024 * 1024 * 75, // 75 MB
                TxBytes = 1024 * 1024 * 25, // 25 MB
                RxRate = 175 * 1024, // 175 KB/s
                TxRate = 95 * 1024,  // 95 KB/s
                LastUpdated = DateTime.Now
            });

            _interfaces.Add("wlan1", new NetworkInterface
            {
                Name = "wlan1",
                Type = "wireless",
                IsEnabled = false,
                IsConnected = false,
                MacAddress = "AA:BB:CC:DD:EE:03",
                IpAddress = "",
                Netmask = "",
                RxBytes = 0,
                TxBytes = 0,
                RxRate = 0,
                TxRate = 0,
                LastUpdated = DateTime.Now
            });

            _interfaces.Add("bridge1", new NetworkInterface
            {
                Name = "bridge1",
                Type = "bridge",
                IsEnabled = true,
                IsConnected = true,
                MacAddress = "AA:BB:CC:DD:EE:04",
                IpAddress = "172.16.0.1",
                Netmask = "255.255.255.0",
                RxBytes = 1024 * 1024 * 10, // 10 MB
                TxBytes = 1024 * 1024 * 5,  // 5 MB
                RxRate = 65 * 1024, // 65 KB/s
                TxRate = 35 * 1024, // 35 KB/s
                LastUpdated = DateTime.Now
            });

            _interfaces.Add("ovpn-out1", new NetworkInterface
            {
                Name = "ovpn-out1",
                Type = "ovpn",
                IsEnabled = true,
                IsConnected = true,
                MacAddress = "",
                IpAddress = "10.8.0.1",
                Netmask = "255.255.255.0",
                RxBytes = 1024 * 1024 * 5, // 5 MB
                TxBytes = 1024 * 1024 * 2, // 2 MB
                RxRate = 25 * 1024, // 25 KB/s
                TxRate = 15 * 1024, // 15 KB/s
                LastUpdated = DateTime.Now
            });

            // Khởi tạo dữ liệu lịch sử
            foreach (var intf in _interfaces.Keys)
            {
                _rxHistory[intf] = GenerateHistoricalDataPoints(60);
                _txHistory[intf] = GenerateHistoricalDataPoints(60);
            }
        }

        private List<DataPoint> GenerateHistoricalDataPoints(int count)
        {
            var result = new List<DataPoint>();
            var now = DateTime.Now;

            for (int i = count - 1; i >= 0; i--)
            {
                result.Add(new DataPoint
                {
                    Timestamp = now.AddMinutes(-i),
                    Value = _random.Next(10, 100) * 1024 // 10-100 KB/s
                });
            }

            return result;
        }

        public async Task<IEnumerable<NetworkInterface>> GetInterfacesAsync()
        {
            _logger.LogInformation("Đang lấy danh sách giao diện mạng...");
            
            // Giả lập thời gian phản hồi
            await Task.Delay(200);
            
            // Cập nhật các giá trị ngẫu nhiên
            foreach (var intf in _interfaces.Values.Where(i => i.IsConnected))
            {
                UpdateInterfaceStats(intf);
            }
            
            _logger.LogInformation("Đã lấy danh sách giao diện mạng thành công");
            
            return _interfaces.Values;
        }

        public async Task<NetworkInterface> GetInterfaceByNameAsync(string name)
        {
            _logger.LogInformation("Đang lấy thông tin giao diện {Name}...", name);
            
            // Giả lập thời gian phản hồi
            await Task.Delay(100);
            
            if (!_interfaces.TryGetValue(name, out var networkInterface))
            {
                _logger.LogWarning("Không tìm thấy giao diện {Name}", name);
                return null;
            }
            
            // Cập nhật các giá trị ngẫu nhiên
            if (networkInterface.IsConnected)
            {
                UpdateInterfaceStats(networkInterface);
            }
            
            _logger.LogInformation("Đã lấy thông tin giao diện {Name} thành công", name);
            
            return networkInterface;
        }

        public async Task<InterfaceTraffic> GetInterfaceTrafficAsync(string name)
        {
            _logger.LogInformation("Đang lấy dữ liệu lưu lượng cho giao diện {Name}...", name);
            
            // Giả lập thời gian phản hồi
            await Task.Delay(300);
            
            if (!_interfaces.ContainsKey(name))
            {
                _logger.LogWarning("Không tìm thấy giao diện {Name}", name);
                return null;
            }
            
            if (!_rxHistory.TryGetValue(name, out var rxPoints) || 
                !_txHistory.TryGetValue(name, out var txPoints))
            {
                _logger.LogWarning("Không có dữ liệu lịch sử cho giao diện {Name}", name);
                return new InterfaceTraffic { InterfaceName = name };
            }
            
            // Thêm điểm dữ liệu mới
            var now = DateTime.Now;
            
            if (_interfaces[name].IsConnected)
            {
                rxPoints.Add(new DataPoint
                {
                    Timestamp = now,
                    Value = _interfaces[name].RxRate
                });
                
                txPoints.Add(new DataPoint
                {
                    Timestamp = now,
                    Value = _interfaces[name].TxRate
                });
                
                // Giữ chỉ 60 điểm dữ liệu gần nhất
                if (rxPoints.Count > 60)
                    rxPoints = rxPoints.Skip(rxPoints.Count - 60).ToList();
                
                if (txPoints.Count > 60)
                    txPoints = txPoints.Skip(txPoints.Count - 60).ToList();
                
                _rxHistory[name] = rxPoints;
                _txHistory[name] = txPoints;
            }
            
            _logger.LogInformation("Đã lấy dữ liệu lưu lượng cho giao diện {Name} thành công", name);
            
            return new InterfaceTraffic
            {
                InterfaceName = name,
                RxPoints = rxPoints,
                TxPoints = txPoints
            };
        }

        private void UpdateInterfaceStats(NetworkInterface networkInterface)
        {
            // Cập nhật RxRate với phương sai nhỏ
            var rxVariance = _random.Next(-10, 11) / 100.0; // -10% đến +10%
            networkInterface.RxRate = Math.Max(0, networkInterface.RxRate * (1 + rxVariance));
            
            // Cập nhật TxRate với phương sai nhỏ
            var txVariance = _random.Next(-10, 11) / 100.0; // -10% đến +10%
            networkInterface.TxRate = Math.Max(0, networkInterface.TxRate * (1 + txVariance));
            
            // Cập nhật tổng bytes nhận/gửi
            networkInterface.RxBytes += (long)(networkInterface.RxRate * 1); // Giả sử 1 giây
            networkInterface.TxBytes += (long)(networkInterface.TxRate * 1); // Giả sử 1 giây
            
            networkInterface.LastUpdated = DateTime.Now;
        }
    }
}
